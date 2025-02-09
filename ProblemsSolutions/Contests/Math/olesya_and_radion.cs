#nullable disable

using System;
using System.IO;
using System.Runtime.CompilerServices;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/584/A problem.
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
		var valuesFromInput = input.ReadLine().Split();
		int digitsCount = int.Parse(valuesFromInput[0]);
		int divider = int.Parse(valuesFromInput[1]);
		if (divider == 10) {
			if (digitsCount == 1) {
				output.WriteLine("-1");
				return;
			} else {
				output.Write("1");
				--digitsCount;
				divider = 0;
			}
		}
		for (int i = 0; i < digitsCount; ++i) {
			output.Write(divider);
		}
		output.WriteLine();
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
