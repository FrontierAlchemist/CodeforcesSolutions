#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve [PROBLEM_LINK] problem.
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

	private static StreamReaderWrapper input;
	private static StreamWriter output;

	private static void SolveProblem()
	{
	}

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.GetString()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			SolveProblem();
		}
	}

	private static void OpenIo()
	{
		var inputStream = IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());
		input = new StreamReaderWrapper(inputStream);
		output = IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());
	}

	private static void CloseIo()
	{
		input.Close();
		output.Close();
	}

	private static void Main()
	{
		OpenIo();
		RunTests();
		CloseIo();
	}
}

internal class StreamReaderWrapper
{
	private readonly StreamReader streamReader;
	private readonly IEnumerator<string> inputLinesEnumerator;

	public StreamReaderWrapper(StreamReader streamReader)
	{
		this.streamReader = streamReader;
		inputLinesEnumerator = GetInputLinesEnumerator();
	}

	public string GetString() => GetInputLine();

	public void Close()
	{
		streamReader.Close();
	}

	private string GetInputLine()
	{
		inputLinesEnumerator.MoveNext();
		return inputLinesEnumerator.Current;
	}

	private IEnumerator<string> GetInputLinesEnumerator()
	{
		while (true) {
			string[] splitedLineFromInput = streamReader.ReadLine().Split();
			foreach (var line in splitedLineFromInput) {
				yield return line;
			}
		}
	}
}
