#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2063/problem/A problem.
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
		int leftBorder = int.Parse(valuesFromInput[0]);
		int rightBorder = int.Parse(valuesFromInput[1]);
		int minimalCoprimeSegmentsCount = 0;
		if (leftBorder == 1 && rightBorder == 1) {
			minimalCoprimeSegmentsCount = 1;
		} else {
			minimalCoprimeSegmentsCount = rightBorder - leftBorder;
		}
		output.WriteLine(minimalCoprimeSegmentsCount);
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
