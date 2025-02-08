#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1343/B problem.
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
		int arraySize = int.Parse(input.ReadLine());
		int halfOfArraySize = arraySize / 2;
		if (halfOfArraySize % 2 == 0) {
			output.WriteLine("YES");
			for (int i = 1; i <= halfOfArraySize; ++i) {
				output.Write($"{i * 2} ");
			}
			for (int i = 0; i < halfOfArraySize - 1; ++i) {
				output.Write($"{1 + i * 2} ");
			}
			output.WriteLine($"{halfOfArraySize * 3 - 1}");
		} else {
			output.WriteLine("NO");
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
