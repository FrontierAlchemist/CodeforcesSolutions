#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/476/A problem.
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
		var valuesFromInput = input.ReadLine().Split();
		int stepsCount = int.Parse(valuesFromInput[0]);
		int delimeter = int.Parse(valuesFromInput[1]);
		int minOperations = Math.DivRem(stepsCount, 2, out int extraOperation) + extraOperation;
		int maxOperations = stepsCount;
		int answer = -1;
		if (delimeter <= maxOperations) {
			int remainder = minOperations % delimeter;
			if (remainder == 0) {
				answer = minOperations;
			} else {
				answer = minOperations + (delimeter - remainder);
				if (answer > maxOperations) {
					answer = -1;
				}
			}
		}
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
