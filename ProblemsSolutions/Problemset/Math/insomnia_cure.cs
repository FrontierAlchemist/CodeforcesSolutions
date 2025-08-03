#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/148/A problem.
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
		int punchedDragonOrder = int.Parse(input.ReadLine());
		int injuredDragonsTailsOrder = int.Parse(input.ReadLine());
		int trampledDragonsPawsOrder = int.Parse(input.ReadLine());
		int calledDragonsMomsOrder = int.Parse(input.ReadLine());
		int dragonsCount = int.Parse(input.ReadLine());

		int injuredDragonsCount = 0;
		for (int i = 1; i <= dragonsCount; ++i) {
			bool punched = i % punchedDragonOrder == 0;
			bool tailInjured = i % injuredDragonsTailsOrder == 0;
			bool pawsTrampled = i % trampledDragonsPawsOrder == 0;
			bool momCalled = i % calledDragonsMomsOrder == 0;
			if (punched || tailInjured || pawsTrampled || momCalled) {
				++injuredDragonsCount;
			}
		}
		output.WriteLine(injuredDragonsCount);
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
