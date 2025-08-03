#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2055/problem/A problem.
/// </summary>
internal class Program
{
	private const bool IsSeveralTests = true;

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
		int placesCount = int.Parse(valuesFromInput[0]);
		int firstPlayerPosition = int.Parse(valuesFromInput[1]);
		int secondPlayerPosition = int.Parse(valuesFromInput[2]);
		int distance = Math.Abs(firstPlayerPosition - secondPlayerPosition) - 1
		bool isFirstPlayerWin = distance % 2 == 1;
		output.WriteLine(isFirstPlayerWin ? "YES" : "NO");
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
