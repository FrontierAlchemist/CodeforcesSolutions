#nullable disable

using System;
using System.IO;
using System.Text;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/705/A problem.
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
		int layersOfFillings = int.Parse(input.ReadLine());
		StringBuilder stringBuilder = new();
		stringBuilder.Append("I hate ");
		for (int i = 1; i < layersOfFillings; ++i) {
			stringBuilder.Append("that ");
			stringBuilder.Append(i % 2 == 0 ? "I hate " : "I love ");
		}
		stringBuilder.Append("it");
		output.WriteLine(stringBuilder.ToString());
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
