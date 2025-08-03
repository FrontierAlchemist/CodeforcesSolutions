#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2056/problem/A problem.
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

	private static readonly StreamReader input =
		IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());

	private static readonly StreamWriter output =
		IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());

	private static void SolveProblem()
	{
		string[] valuesFromInput = input.ReadLine().Split();
		int operationsCount = int.Parse(valuesFromInput[0]);
		int stampSize = int.Parse(valuesFromInput[1]);
		int shapeWidth = stampSize;
		int shapeHeight = stampSize;
		_ = input.ReadLine().Split();
		(int x, int y) leftBotCorner = (0, 0);
		(int x, int y) rightTopCorner = (stampSize, stampSize);
		for (int i = 1; i < operationsCount; i++) {
			valuesFromInput = input.ReadLine().Split();
			int stepByX = int.Parse(valuesFromInput[0]);
			int stepByY = int.Parse(valuesFromInput[1]);
			leftBotCorner.x += stepByX;
			leftBotCorner.y += stepByY;
			shapeWidth += stampSize - (rightTopCorner.x - leftBotCorner.x);
			shapeHeight += stampSize - (rightTopCorner.y - leftBotCorner.y);
			rightTopCorner = (leftBotCorner.x + stampSize, leftBotCorner.y + stampSize);
		}
		output.WriteLine((shapeWidth + shapeHeight) * 2);
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
