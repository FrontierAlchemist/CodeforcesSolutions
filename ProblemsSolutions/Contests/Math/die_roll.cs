#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/9/A problem.
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
		string lineFromInput = input.ReadLine();
		int yakkoPoints = lineFromInput[0] - '0';
		int wakkoPoints = lineFromInput[2] - '0';
		int maxPoints = Math.Max(yakkoPoints, wakkoPoints);
		string verdict = maxPoints switch {
			1 => "1/1",
			2 => "5/6",
			3 => "2/3",
			4 => "1/2",
			5 => "1/3",
			6 => "1/6",
			_ => throw new ArgumentException($"Invalid points number: '{yakkoPoints}' or '{wakkoPoints}'"),
		};
		output.WriteLine(verdict);
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
