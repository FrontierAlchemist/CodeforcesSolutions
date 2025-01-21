#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2060/problem/D problem.
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

	private static readonly StreamReader input =
		IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());

	private static readonly StreamWriter output =
		IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());

	private static void SolveProblem()
	{
		int arraySize = int.Parse(input.ReadLine());
		int[] array = new int[arraySize];
		string[] valuesFromInput = input.ReadLine().Split();
		for (int i = 0; i < arraySize; ++i) {
			array[i] = int.Parse(valuesFromInput[i]);
		}

		bool isCanBeSorted = true;
		for (int i = 0; i < arraySize - 1; ++i) {
			if (array[i] > array[i + 1]) {
				isCanBeSorted = false;
				break;
			} else {
				int decreasingValue = array[i];
				array[i] -= decreasingValue;
				array[i + 1] -= decreasingValue;
			}
		}

		output.WriteLine(isCanBeSorted ? "YES" : "NO");
	}

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.ReadLine()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			SolveProblem();
		}
	}

	private static void CloseStreams()
	{
		input.Close();
		output.Close();
	}

	private static void Main()
	{
		RunTests();
		CloseStreams();
	}
}
