#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2059/problem/A problem.
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
		int numbersCount = int.Parse(input.ReadLine());
		HashSet<int> uniqueElementsOfFirstArray = new();
		string[] valuesFromInput = input.ReadLine().Split();
		for (int i = 0; i < numbersCount; i++) {
			uniqueElementsOfFirstArray.Add(int.Parse(valuesFromInput[i]));
		}
		HashSet<int> uniqueElementsOfSecondArray = new();
		valuesFromInput = input.ReadLine().Split();
		for (int i = 0; i < numbersCount; i++) {
			uniqueElementsOfSecondArray.Add(int.Parse(valuesFromInput[i]));
		}
		HashSet<int> uniqueSums = new();
		foreach (int i in uniqueElementsOfFirstArray) {
			foreach (int j in uniqueElementsOfSecondArray) {
				uniqueSums.Add(i + j);
			}
		}
		output.WriteLine(uniqueSums.Count >= 3 ? "YES" : "NO");
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
