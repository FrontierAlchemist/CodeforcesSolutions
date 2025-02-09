#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1/A problem.
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
		int squareLength = int.Parse(valuesFromInput[0]);
		int squareWidth = int.Parse(valuesFromInput[1]);
		int flagstoneSize = int.Parse(valuesFromInput[2]);
		int flagstonesCountByLength = Math.DivRem(squareLength, flagstoneSize, out int remainderByLength);
		if (remainderByLength > 0) {
			++flagstonesCountByLength;
		}
		int flagstonesCountByWidth = Math.DivRem(squareWidth, flagstoneSize, out int remainderByWidth);
		if (remainderByWidth > 0) {
			++flagstonesCountByWidth;
		}
		long flagstonesCount = (long)flagstonesCountByWidth * flagstonesCountByLength;
		output.WriteLine(flagstonesCount);
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
