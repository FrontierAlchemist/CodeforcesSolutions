#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/122/A problem.
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
		int number = int.Parse(input.ReadLine());
		bool isAlmostLuckyNumber = false;
		for (int i = number; i >= 1; --i) {
			if (IsLuckyNumber(i) && number % i == 0) {
				isAlmostLuckyNumber = true;
				break;
			}
		}
		output.WriteLine(isAlmostLuckyNumber ? "YES" : "NO");

		bool IsLuckyNumber(int number)
		{
			while (number > 0) {
				int digit = number % 10;
				if (digit != 4 && digit != 7) {
					return false;
				}
				number /= 10;
			}
			return true;
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
