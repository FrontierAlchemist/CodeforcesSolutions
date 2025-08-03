using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1999/B problem.
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
		int suneetCard1 = input.GetInt();
		int suneetCard2 = input.GetInt();
		int slavicCard1 = input.GetInt();
		int slavicCard2 = input.GetInt();

		int suneetVictoriesNumber = 0;
		if (suneetCard1.CompareTo(slavicCard1) + suneetCard2.CompareTo(slavicCard2) > 0) {
			++suneetVictoriesNumber;
		}
		if (suneetCard1.CompareTo(slavicCard2) + suneetCard2.CompareTo(slavicCard1) > 0) {
			++suneetVictoriesNumber;
		}
		if (suneetCard2.CompareTo(slavicCard1) + suneetCard1.CompareTo(slavicCard2) > 0) {
			++suneetVictoriesNumber;
		}
		if (suneetCard2.CompareTo(slavicCard2) + suneetCard1.CompareTo(slavicCard1) > 0) {
			++suneetVictoriesNumber;
		}

		output.WriteLine(suneetVictoriesNumber);
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

	public int GetInt() => int.Parse(GetInputLine());

	public int[] GetIntArray(int size)
	{
		int[] array = new int[size];
		for (int i = 0; i < size; ++i) {
			array[i] = GetInt();
		}
		return array;
	}

	public double GetDouble() => double.Parse(GetInputLine());

	public double[] GetDoubleArray(int size)
	{
		double[] array = new double[size];
		for (int i = 0; i < size; ++i) {
			array[i] = GetDouble();
		}
		return array;
	}

	public long GetLong() => long.Parse(GetInputLine());

	public long[] GetLongArray(int size)
	{
		long[] array = new long[size];
		for (int i = 0; i < size; ++i) {
			array[i] = GetInt();
		}
		return array;
	}

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
