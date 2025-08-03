#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2065/problem/B problem.
/// </summary>
internal class Program
{
	private const bool IsSeveralTests = true;

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
		var valuesFromInput = input.ReadLine().Split();
		int arraysCount = int.Parse(valuesFromInput[0]);
		int arraySize = int.Parse(valuesFromInput[1]);
		(long sumOfArray, long scoreOfArray)[] sums = new (long, long)[arraysCount];
		for (int i = 0; i < arraysCount; ++i) {
			valuesFromInput = input.ReadLine().Split();
			for (int j = 0; j < arraySize; ++j) {
				long number = long.Parse(valuesFromInput[j]);
				sums[i].sumOfArray += number;
				sums[i].scoreOfArray += number * (arraySize - j);
			}
		}
		Array.Sort(sums);
		long maximalTotalScore = 0L;
		for (int i = arraysCount - 1; i >= 0; --i) {
			int occurencesCount = i * arraySize;
			maximalTotalScore += sums[i].scoreOfArray + sums[i].sumOfArray * occurencesCount;
		}
		output.WriteLine(maximalTotalScore);
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
