#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/141/A problem.
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
		string guestName = input.ReadLine();
		string residenceHostName = input.ReadLine();
		string disorderedPileOfLetters = input.ReadLine();
		if (guestName.Length + residenceHostName.Length != disorderedPileOfLetters.Length) {
			output.WriteLine("NO");
			return;
		}

		SortedDictionary<char, int> sourceLetters = new();
		foreach (char letter in guestName + residenceHostName) {
			if (!sourceLetters.ContainsKey(letter)) {
				sourceLetters.Add(letter, 0);
			}
			++sourceLetters[letter];
		}
		
		SortedDictionary<char, int> disorderedLetters = new();
		foreach (char letter in disorderedPileOfLetters) {
			if (!disorderedLetters.ContainsKey(letter)) {
				disorderedLetters.Add(letter, 0);
			}
			++disorderedLetters[letter];
		}
		output.WriteLine(disorderedLetters.SequenceEqual(sourceLetters) ? "YES" : "NO");
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
