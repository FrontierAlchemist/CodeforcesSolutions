#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/339/B problem.
/// </summary>
internal class Program
{
	private const bool IsSeveralTests = false;

	private const string InputFilePath = "..\\..\\..\\input.txt";
	private const string OutputFilePath = "..\\..\\..\\output.txt";

	private static bool IsDebug()
	{
#if DEBUG
		return true;
#else
		return false;
#endif
	}

	private static StreamReader input;
	private static StreamWriter output;

	private static void SolveProblem()
	{
		string[] valuesFromInput = input.ReadLine().Split();
		int housesCount = int.Parse(valuesFromInput[0]);
		int tasksCount = int.Parse(valuesFromInput[1]);
		valuesFromInput = input.ReadLine().Split();
		int[] housesPerTask = new int[tasksCount];
		for (int i = 0; i < tasksCount; ++i) {
			housesPerTask[i] = int.Parse(valuesFromInput[i]) - 1;
		}

		int currentHouse = 0;
		long minimalTotalTimeToCompleteAllTasks = 0L;
		for (int i = 0; i < tasksCount; ++i) {
			long distanceBetweenHouses = 0L;
			if (currentHouse < housesPerTask[i]) {
				distanceBetweenHouses  = housesPerTask[i] - currentHouse;
			} else if (currentHouse > housesPerTask[i]) {
				distanceBetweenHouses  = housesCount - currentHouse + housesPerTask[i];
			}
			minimalTotalTimeToCompleteAllTasks += distanceBetweenHouses;
			currentHouse = housesPerTask[i];
		}
		output.WriteLine(minimalTotalTimeToCompleteAllTasks);
	}

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.ReadLine()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			SolveProblem();
		}
	}

	private static void OpenIoStreams()
	{
		input = IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());
		output = IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());
	}

	private static void CloseIoStreams()
	{
		input.Close();
		output.Close();
	}

	private static void Main()
	{
		OpenIoStreams();
		RunTests();
		CloseIoStreams();
	}
}
