#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2027/problem/A problem.
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
		int rectanglesCount = int.Parse(input.ReadLine());
		int maxWidth = 0;
		int maxHeight = 0;
		for (int i = 0; i < rectanglesCount; ++i) {
			string[] valuesFromInput = input.ReadLine().Split();
			int width = int.Parse(valuesFromInput[0]);
			int height = int.Parse(valuesFromInput[1]);
			maxWidth = Math.Max(maxWidth, width);
			maxHeight = Math.Max(maxHeight, height);
		}
		output.WriteLine((maxWidth + maxHeight) * 2);
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
