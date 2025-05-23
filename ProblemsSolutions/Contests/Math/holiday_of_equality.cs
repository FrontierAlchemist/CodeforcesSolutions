#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/758/A problem.
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
		int citizensCount = int.Parse(input.ReadLine());
		var valuesFromInput = input.ReadLine().Split();
		int[] welfareOfCitizens = new int[citizensCount];
		int maximalWelfare = 0;
		for (int i = 0; i < citizensCount; ++i) {
			welfareOfCitizens[i] = int.Parse(valuesFromInput[i]);
			maximalWelfare = Math.Max(maximalWelfare, welfareOfCitizens[i]);
		}
		int amountOfMoneyToSpend = 0;
		for (int i = 0; i < citizensCount; ++i) {
			amountOfMoneyToSpend += maximalWelfare - welfareOfCitizens[i];
		}
		output.WriteLine(amountOfMoneyToSpend);
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
