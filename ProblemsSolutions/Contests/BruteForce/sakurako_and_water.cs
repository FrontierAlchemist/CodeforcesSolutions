#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2033/problem/B problem.
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
		int matrixSize = int.Parse(input.ReadLine());
		int[,] matrix = new int[matrixSize, matrixSize];
		for (int i = 0; i < matrixSize; ++i) {
			string[] valuesFromInput = input.ReadLine().Split();
			for (int j = 0; j < matrixSize; ++j) {
				matrix[i, j] = int.Parse(valuesFromInput[j]);
			}
		}

		long operationsCount = 0L;
		for (int i = 0; i < matrixSize; ++i) {
			int minNegativeNumber = 0;
			for (int j = 0; j < matrixSize - i; ++j) {
				minNegativeNumber = Math.Min(matrix[i + j, j], minNegativeNumber);
			}
			operationsCount += -minNegativeNumber;
		}
		for (int j = 1; j < matrixSize; ++j) {
			int minNegativeNumber = 0;
			for (int i = 0; i < matrixSize - j; ++i) {
				minNegativeNumber = Math.Min(matrix[i, j + i], minNegativeNumber);
			}
			operationsCount += -minNegativeNumber;
		}

		output.WriteLine(operationsCount);
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
