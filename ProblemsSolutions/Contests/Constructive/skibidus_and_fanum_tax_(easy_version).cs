#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2065/problem/C1 problem.
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
		var valuesFromInput = input.ReadLine().Split();
		int n = int.Parse(valuesFromInput[0]);
		int m = int.Parse(valuesFromInput[1]);
		int[] a = new int[n];
		valuesFromInput = input.ReadLine().Split();
		for (int i = 0; i < n; ++i) {
			a[i] = int.Parse(valuesFromInput[i]);
		}
		int b = int.Parse(input.ReadLine());
		bool sorted = true;
		bool[] modified = new bool[n];
		for (int i = 0; i < n - 1; ++i) {
			int c = b - a[i];
			if (c < a[i] && !modified[i]) {
				if (i == 0 || (i > 0 && c >= a[i - 1])) {
					modified[i] = true;
					a[i] = c;
				}
			}
			if (a[i] > a[i + 1]) {
				int d = b - a[i + 1];
				if (a[i] <= d && !modified[i + 1]) {
					a[i + 1] = d;
					modified[i + 1] = true;
				} else {
					sorted = false;
					break;
				}
			}
		}
		output.WriteLine(sorted ? "YES" : "NO");
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
