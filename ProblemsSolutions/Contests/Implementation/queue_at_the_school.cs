#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/266/B problem.
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
		int queueLength = int.Parse(valuesFromInput[0]);
		int transformationTime = int.Parse(valuesFromInput[1]);
		string queueDescription = input.ReadLine();
		bool[] isBoyOnPosition = new bool[queueLength];
		for (int i = 0; i < queueLength; ++i) {
			isBoyOnPosition[i] = queueDescription[i] == 'B';
		}
		for (int t = 0; t < transformationTime; ++t) {
			for (int i = 0; i < queueLength - 1; ++i) {
				if (isBoyOnPosition[i] && !isBoyOnPosition[i + 1]) {
					isBoyOnPosition[i] = false;
					isBoyOnPosition[i + 1] = true;
					++i;
				}
			}
		}
		for (int i = 0; i < queueLength; ++i) {
			output.Write(isBoyOnPosition[i] ? 'B' : 'G');
		}
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
