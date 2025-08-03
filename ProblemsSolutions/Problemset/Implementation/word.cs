#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/59/A problem.
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
		string sourceString = input.ReadLine();
		int lowercaseLettersCount = 0;
		int uppercaseLettersCount = 0;
		for (int i = 0; i < sourceString.Length; ++i) {
			if (char.IsLower(sourceString[i])) {
				++lowercaseLettersCount;
			} else if (char.IsUpper(sourceString[i])) {
				++uppercaseLettersCount;
			}
		}
		string modifiedString = lowercaseLettersCount >= uppercaseLettersCount ? sourceString.ToLower() : sourceString.ToUpper();
		output.WriteLine(modifiedString);
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
