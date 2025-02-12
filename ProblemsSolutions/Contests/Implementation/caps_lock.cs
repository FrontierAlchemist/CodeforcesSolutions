#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/131/A problem.
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
		string str = input.ReadLine();
		bool wasCapsLockPressedByAccident = true;
		for (int i = 1; i < str.Length; ++i) {
			if (char.IsLower(str[i])) {
				wasCapsLockPressedByAccident = false;
				break;
			}
		}
		if (wasCapsLockPressedByAccident) {
			char firstLetter = char.IsLower(str[0]) ? char.ToUpper(str[0]) : char.ToLower(str[0]);
			string modifiedString = firstLetter + str[1..].ToLower();
			output.WriteLine(modifiedString);
		} else {
			output.WriteLine(str);
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
