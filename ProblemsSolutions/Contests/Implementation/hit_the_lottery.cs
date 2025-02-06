#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/996/A problem.
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
		int deposite = int.Parse(input.ReadLine());
		List<int> denominations = new() { 100, 20, 10, 5, 1, };
		int billsCount = 0;
		for (int i = 0; i < denominations.Count; ++i) {
			billsCount += Math.DivRem(deposite, denominations[i], out int remaidner);
			deposite = remaidner;
		}
		output.WriteLine(billsCount);
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
