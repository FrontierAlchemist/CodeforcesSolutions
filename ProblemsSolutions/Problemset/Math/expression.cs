#nullable disable

using System;
using System.IO;
using System.Runtime.CompilerServices;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/479/A problem.
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
		int a = int.Parse(input.ReadLine());
		int b = int.Parse(input.ReadLine());
		int c = int.Parse(input.ReadLine());
		int result = 0;
		if (a != 1 && b != 1 && c != 1) {
			result = a * b * c;
		} else if (a == 1 && c == 1) {
			result = a + b + c;
		} else if (b == 1) {
			result = (a > c) ? a * (b + c) : (a + b) * c;
		} else if (a == 1) {
			result = (a + b) * c;
		} else if (c == 1) {
			result = a * (b + c);
		}
		output.WriteLine(result);
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
