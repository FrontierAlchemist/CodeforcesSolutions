#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2055/problem/C problem.
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
		int rowsCount = int.Parse(valuesFromInput[0]);
		int columnsCount = int.Parse(valuesFromInput[1]);
		string path = input.ReadLine();
		long[,] matrix = new long[rowsCount, columnsCount];
		for (int i = 0; i < rowsCount; ++i) {
			valuesFromInput = input.ReadLine().Split();
			for (int j = 0; j < columnsCount; ++j) {
				matrix[i, j] = long.Parse(valuesFromInput[j]);
			}
		}

		int x = 0, y = 0;
		foreach (char step in path) {
			if (step == 'D') {
				long columnSum = 0L;
				for (int j = 0; j < columnsCount; ++j) {
					columnSum += matrix[x, j];
				}
				matrix[x++, y] = -columnSum;
			} else {
				long rowSum = 0L;
				for (int i = 0; i < rowsCount; ++i) {
					rowSum += matrix[i, y];
				}
				matrix[x, y++] = -rowSum;
			}
		}

		long sourceSum = 0L;
		for (int j = 0; j < columnsCount; ++j) {
			sourceSum += matrix[rowsCount - 1, j];
		}
		matrix[rowsCount - 1, columnsCount - 1] = -sourceSum;
		for (int i = 0; i < rowsCount; ++i) {
			for (int j = 0; j < columnsCount; ++j) {
				output.Write($"{matrix[i, j]} ");
			}
			output.WriteLine();
		}
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
