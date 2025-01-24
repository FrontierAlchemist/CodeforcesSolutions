#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/158/A problem.
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

	private static readonly StreamReader input =
		IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());

	private static readonly StreamWriter output =
		IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());

	private static void SolveProblem()
	{
		string[] valuesFromInput = input.ReadLine().Split();
		int contestantsCount = int.Parse(valuesFromInput[0]);
		int requiredPlace = int.Parse(valuesFromInput[1]) - 1;
		valuesFromInput = input.ReadLine().Split();
		int advancedContestantsCount = 0;
		int requiredScore = -1;
		for (int i = 0; i < contestantsCount; ++i) {
			int score = int.Parse(valuesFromInput[i]);
			if (i > requiredPlace && score != requiredScore) {
				break;
			}
			if (i == requiredPlace) {
				requiredScore = score;
			}
			if (score > 0) {
				++advancedContestantsCount;
			} else {
				break;
			}
		}
		output.WriteLine(advancedContestantsCount);
	}

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.ReadLine()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			SolveProblem();
		}
	}

	private static void CloseStreams()
	{
		input.Close();
		output.Close();
	}

	private static void Main()
	{
		RunTests();
		CloseStreams();
	}
}
