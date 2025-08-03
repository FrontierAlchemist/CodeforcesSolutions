#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/734/A problem.
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
		int gamesCount = int.Parse(input.ReadLine());
		string gamesResult = input.ReadLine();
		int antonWinsCount = 0;
		int danikWinsCount = 0;
		for (int i = 0; i < gamesCount; ++i) {
			if (gamesResult[i] == 'A') {
				++antonWinsCount;
			} else if (gamesResult[i] == 'D') {
				++danikWinsCount;
			}
		}
		string verdict;
		if (antonWinsCount > danikWinsCount) {
			verdict = "Anton";
		} else if (antonWinsCount < danikWinsCount) {
			verdict = "Danik";
		} else {
			verdict = "Friendship";
		}
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
