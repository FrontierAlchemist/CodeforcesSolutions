#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/43/A problem.
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
		int goalsNumber = int.Parse(input.ReadLine());

		string firstTeamName = null;
		string secondTeamName = null;
		int firstTeamScore = 0;
		int secondTeamScore = 0;

		for (int i = 0; i < goalsNumber; ++i) {
			string teamName = input.ReadLine();
			if (firstTeamName == null || firstTeamName == teamName) {
				firstTeamName ??= teamName;
				++firstTeamScore;
			} else if (secondTeamName == null || secondTeamName == teamName) {
				secondTeamName ??= teamName;
				++secondTeamScore;
			}
		}

		output.WriteLine(firstTeamScore > secondTeamScore ? firstTeamName : secondTeamName);
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
