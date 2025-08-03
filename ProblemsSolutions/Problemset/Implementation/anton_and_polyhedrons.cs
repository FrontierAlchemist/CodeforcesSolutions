#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/785/A problem.
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
		int figuresCount = int.Parse(input.ReadLine());
		int totalFacesCount = 0;
		for (int i = 0; i < figuresCount; ++i) {
			string figureName = input.ReadLine();
			totalFacesCount += GetFigureFacesCountByName(figureName);
		}
		output.WriteLine(totalFacesCount);

		int GetFigureFacesCountByName(string figureName) => figureName switch {
			"Tetrahedron" => 4,
			"Cube" => 6,
			"Octahedron" => 8,
			"Dodecahedron" => 12,
			"Icosahedron" => 20,
			_ => throw new ArgumentException($"Unknown figure: \"{figureName}\""),
		};
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
