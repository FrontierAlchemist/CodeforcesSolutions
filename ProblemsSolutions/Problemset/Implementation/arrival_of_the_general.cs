#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/144/A problem.
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
		int soldiersCount = int.Parse(input.ReadLine());
		string[] valuesFromInput = input.ReadLine().Split();
		int soldierHeight = int.Parse(valuesFromInput[0]);
		int lowestSoldierPosition = 0;
		int minimalHight = soldierHeight;
		int highestSoldierPosition = 0;
		int maximalHight = soldierHeight;
		for (int i = 1; i < soldiersCount; ++i) {
			soldierHeight = int.Parse(valuesFromInput[i]);
			if (minimalHight >= soldierHeight) {
				minimalHight = soldierHeight;
				lowestSoldierPosition = i;
			}
			if (maximalHight < soldierHeight) {
				maximalHight = soldierHeight;
				highestSoldierPosition = i;
			}
		}

		int operationsCount = highestSoldierPosition + soldiersCount - 1 - lowestSoldierPosition;
		if (highestSoldierPosition > lowestSoldierPosition) {
			--operationsCount;
		}
		output.WriteLine(operationsCount);
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
