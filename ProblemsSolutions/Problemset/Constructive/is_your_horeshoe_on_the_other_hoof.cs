#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/228/A problem.
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
		int first = int.Parse(valuesFromInput[0]);
		int second = int.Parse(valuesFromInput[1]);
		int third = int.Parse(valuesFromInput[2]);
		int fourth = int.Parse(valuesFromInput[3]);
		int clothesToBuy = 0;
		if (first == second || first == third || first == fourth) {
			++clothesToBuy;
		}
		if (second == third || second == fourth) {
			++clothesToBuy;
		}
		if (third == fourth) {
			++clothesToBuy;
		}
		output.WriteLine(clothesToBuy);
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
