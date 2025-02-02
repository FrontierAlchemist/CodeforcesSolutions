#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2059/problem/B problem.
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
		int arraySize = int.Parse(valuesFromInput[0]);
		int subarraysCount = int.Parse(valuesFromInput[1]);
		var array = new int[arraySize];
		valuesFromInput = input.ReadLine().Split();
		for (int i = 0; i < arraySize; ++i) {
			array[i] = int.Parse(valuesFromInput[i]);
		}

		int answer = 0;
		if (arraySize == subarraysCount) {
			answer = subarraysCount / 2 + 1;
			for (int i = 1; i < arraySize; i += 2) {
				if (array[i] != (i + 1) / 2) {
					answer = (i + 1) / 2;
					break;
				}
			}
		} else {
			int borderIndex = arraySize - subarraysCount + 2;
			answer = 2;
			for (int i = 1; i < borderIndex; ++i) {
				if (array[i] != 1) {
					answer = 1;
					break;
				}
			}
		}

		output.WriteLine(answer);
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
