#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2060/problem/A problem.
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
		string[] valuesFromInput = input.ReadLine().Split();
		int[] arrray = new int[5];
		arrray[0] = int.Parse(valuesFromInput[0]);
		arrray[1] = int.Parse(valuesFromInput[1]);
		arrray[3] = int.Parse(valuesFromInput[2]);
		arrray[4] = int.Parse(valuesFromInput[3]);
		int maximalFibonacciness = 0;
		int leftBorder = Math.Min(arrray[0] + arrray[1], arrray[4] - arrray[3]);
		int rightBorder = Math.Max(arrray[0] + arrray[1], arrray[4] - arrray[3]);
		for (int i = leftBorder; i <= rightBorder; ++i) {
			int fibonacciness = 0;
			arrray[2] = i;
			for (int j = 0; j < 3; ++j) {
				if (arrray[j] + arrray[j + 1] == arrray[j + 2]) {
					++fibonacciness;
				}
			}
			maximalFibonacciness = Math.Max(maximalFibonacciness, fibonacciness);
		}
		output.WriteLine(maximalFibonacciness);
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
