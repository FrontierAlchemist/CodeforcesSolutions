#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/230/A problem.
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
		int playerPower = int.Parse(valuesFromInput[0]);
		int dragonsCount = int.Parse(valuesFromInput[1]);
		(int power, int bonus)[] dragonStats = new (int, int)[dragonsCount];
		for (int i = 0; i < dragonsCount; ++i) {
			valuesFromInput = input.ReadLine().Split();
			dragonStats[i].power = int.Parse(valuesFromInput[0]);
			dragonStats[i].bonus = int.Parse(valuesFromInput[1]);
		}
		Array.Sort(dragonStats);

		bool isPlayerCanCompleteLevel = true;
		for (int i = 0; i < dragonsCount; ++i) {
			if (playerPower > dragonStats[i].power) {
				playerPower += dragonStats[i].bonus;
			} else {
				isPlayerCanCompleteLevel = false;
			}
		}
		output.WriteLine(isPlayerCanCompleteLevel ? "YES" : "NO");
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
