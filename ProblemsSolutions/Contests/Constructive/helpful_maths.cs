#nullable disable

using System;
using System.IO;
using System.Text;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/339/A problem.
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

	private static readonly StreamReader input =
		IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());

	private static readonly StreamWriter output =
		IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());

	private static void SolveProblem()
	{
		string expression = input.ReadLine();
		int[] terms = new int[3];
		for (int i = 0; i < expression.Length; i += 2) {
			++terms[expression[i] - '1'];
		}

		bool firstNumberPrinted = false;
		StringBuilder resultExpressionBuilder = new();
		for (int i = 0; i < 3; ++i) {
			int count = terms[i];
			char symbol = (char)('1' + i);
			if (!firstNumberPrinted && count > 0) {
				resultExpressionBuilder.Append(symbol);
				--count;
				firstNumberPrinted = true;
			}
			for (int j = 0; j < count; ++j) {
				resultExpressionBuilder.Append('+');
				resultExpressionBuilder.Append(symbol);
			}
		}

		output.WriteLine(resultExpressionBuilder.ToString());
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
