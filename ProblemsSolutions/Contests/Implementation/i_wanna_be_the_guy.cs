#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/469/A problem.
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
		int levelsCount = int.Parse(input.ReadLine());
		bool[] isLevelPassed = new bool[levelsCount + 1];
		for (int i = 0; i < 2; ++i) {
			string[] valuesFromInput = input.ReadLine().Split();
			int levelsPassed = int.Parse(valuesFromInput[0]);
			for (int j = 1; j <= levelsPassed; ++j) {
				int level = int.Parse(valuesFromInput[j]);
				isLevelPassed[level] = true;
			}
		}
		int passedLevelsCount = 0;
		for (int i = 1; i <= levelsCount; ++i) {
			if (isLevelPassed[i]) {
				++passedLevelsCount;
			}
		}
		string verdict = passedLevelsCount == levelsCount ? "I become the guy." : "Oh, my keyboard!";
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
