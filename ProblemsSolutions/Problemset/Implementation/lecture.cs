#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/499/B problem.
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

	private static StreamReaderWrapper input;
	private static StreamWriter output;

	private static void SolveProblem()
	{
		int sentenceLength = input.GetInt();
		int languagesSize = input.GetInt();
		Dictionary<string, string> wordsMapping = new();
		for (int i = 0; i < languagesSize; ++i) {
			string wordFromFirstLanguage = input.GetString();
			string wordFromSecondLanguage = input.GetString();
			wordsMapping[wordFromFirstLanguage] = wordFromFirstLanguage.Length <= wordFromSecondLanguage.Length
				? wordFromFirstLanguage
				: wordFromSecondLanguage;
		}
		for (int i = 0; i < sentenceLength - 1; ++i) {
			output.Write(wordsMapping[input.GetString()]);
			output.Write(' ');
		}
		output.WriteLine(wordsMapping[input.GetString()]);
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
