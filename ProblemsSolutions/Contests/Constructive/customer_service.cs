#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2059/problem/C problem.
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

	private static StreamReader input;
	private static StreamWriter output;

	private static void SolveProblem()
	{
		int queuesCount = int.Parse(input.ReadLine());
		int[,] visitors = new int[queuesCount, queuesCount];
		for (int i = 0; i < queuesCount; ++i) {
			string[] valuesFromInput = input.ReadLine().Split();
			for (int j = 0; j < queuesCount; ++j) {
				visitors[i, j] = int.Parse(valuesFromInput[j]);
			}
		}

		int[] suffixesSumOfOnes = new int[queuesCount];
		for (int i = 0; i < queuesCount; ++i) {
			for (int j = queuesCount - 1; j >= 0; --j) {
				if (visitors[i, j] != 1) {
					break;
				}
				++suffixesSumOfOnes[i];
			}
		}
		Array.Sort(suffixesSumOfOnes);

		int answer = 1;
		for (int i = 0; i < queuesCount; ++i) {
			if (suffixesSumOfOnes[i] >= answer) {
				++answer;
			}
		}
		answer = Math.Min(answer, queuesCount);
		output.WriteLine(answer);
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
