#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/546/A problem.
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
		int costPerItem = int.Parse(valuesFromInput[0]);
		long balance = int.Parse(valuesFromInput[1]);
		int neededItems = int.Parse(valuesFromInput[2]);
		long totalCost = (long)costPerItem * neededItems * (neededItems + 1) / 2;
		long moneyToBorrow = 0L;
		if (balance < totalCost) {
			moneyToBorrow = totalCost - balance;
		}
		output.WriteLine(moneyToBorrow);
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
