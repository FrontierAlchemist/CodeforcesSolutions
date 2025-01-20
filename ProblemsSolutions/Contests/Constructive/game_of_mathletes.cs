#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2060/problem/C problem.
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
		int numbersCount = int.Parse(valuesFromInput[0]);
		int k = int.Parse(valuesFromInput[1]);
		int[] numbers = new int[k];
		valuesFromInput = input.ReadLine().Split();
		for (int i = 0; i < numbersCount; ++i) {
			int number = int.Parse(valuesFromInput[i]);
			if (number < k) {
				++numbers[number];
			}
		}
		int score = 0;
		for (int n = 1; n < k; ++n) {
			if (n == k - n) {
				score += numbers[n] / 2;
				continue;
			}
			int pairsCount = Math.Min(numbers[n], numbers[k - n]);
			numbers[n] -= pairsCount;
			numbers[k - n] -= pairsCount;
			score += pairsCount;
		}
		output.WriteLine(score);
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