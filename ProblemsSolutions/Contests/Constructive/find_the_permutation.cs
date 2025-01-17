#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2056/problem/B problem.
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
		int permutationLength = int.Parse(valuesFromInput[0]);
		int[] elementsBefore = new int[permutationLength];
		int[] indexOfNumber = new int[permutationLength];
		for (int i = 0; i < permutationLength; ++i) {
			string lineFromInput = input.ReadLine();
			for (int j = i + 1; j < permutationLength; ++j) {
				if (lineFromInput[j] == '0') {
					++elementsBefore[i];
				} else {
					++elementsBefore[j];
				}
			}
			indexOfNumber[elementsBefore[i]] = i + 1;
		}
		output.WriteLine(string.Join(' ', indexOfNumber));
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
