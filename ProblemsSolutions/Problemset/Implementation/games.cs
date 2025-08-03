#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/268/A problem.
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
		int teamsCount = int.Parse(input.ReadLine());
		int[] homeUniformPerTeam = new int[teamsCount];
		int[] guestUniformPerTeam = new int[teamsCount];
		for (int i = 0; i < teamsCount; ++i) {
			string[] valuesFromInput = input.ReadLine().Split();
			homeUniformPerTeam[i] = int.Parse(valuesFromInput[0]);
			guestUniformPerTeam[i] = int.Parse(valuesFromInput[1]);
		}
		int uniformsCollisionsCount = 0;
		for (int i = 0; i < teamsCount; ++i) {
			for (int j = 0; j < teamsCount; ++j) {
				if (i == j) {
					continue;
				}
				if (homeUniformPerTeam[i] == guestUniformPerTeam[j]) {
					++uniformsCollisionsCount;
				}
			}
		}
		output.WriteLine(uniformsCollisionsCount);
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
