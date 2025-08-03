#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/750/A problem.
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
		int problemsCount = int.Parse(valuesFromInput[0]);
		int timeToReachParty = int.Parse(valuesFromInput[1]);
		int availableTime = 240 - timeToReachParty;
		int solvedProblems = 0;
		int timeToSolveCurrentProblem = 5;
		while (availableTime >= timeToSolveCurrentProblem && solvedProblems < problemsCount) {
			availableTime -= timeToSolveCurrentProblem;
			++solvedProblems;
			timeToSolveCurrentProblem += 5;
		}
		output.WriteLine(solvedProblems);
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
