#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/110/A problem.
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
		string number = input.ReadLine();
		int luckyDigitsCount = 0;
		for (int i = 0; i < number.Length; ++i) {
			if (number[i] == '4' || number[i] == '7') {
				++luckyDigitsCount;
			}
		}
		bool isNumberNearlyLucky = luckyDigitsCount > 0;
		while (luckyDigitsCount > 0) {
			int digit = luckyDigitsCount % 10;
			if (digit != 4 && digit != 7) {
				isNumberNearlyLucky = false;
				break;
			}
			luckyDigitsCount /= 10;
		}
		output.WriteLine(isNumberNearlyLucky ? "YES" : "NO");
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
