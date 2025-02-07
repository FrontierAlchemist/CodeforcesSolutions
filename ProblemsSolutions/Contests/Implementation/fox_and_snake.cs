#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/510/A problem.
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
		int rowsCount = int.Parse(valuesFromInput[0]);
		int columnsCount = int.Parse(valuesFromInput[1]);
		for (int i = 0; i < rowsCount; ++i) {
			if (i % 4 == 1) {
				for (int j = 0; j < columnsCount - 1; ++j) {
					output.Write('.');
				}
				output.Write('#');
			} else if (i % 4 == 3) {
				output.Write('#');
				for (int j = 1; j < columnsCount; ++j) {
					output.Write('.');
				}
			} else if (i % 2 == 0) {
				for (int j = 0; j < columnsCount; ++j) {
					output.Write('#');
				}
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
