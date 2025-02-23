using System;
using System.Collections.Generic;
using System.IO;

internal class Solver
{
	private static StreamReaderWrapper Input => Program.Input;
	private static StreamWriterWrapper Output => Program.Output;

	/// <summary>
	/// Solve https://codeforces.com/problemset/problem/1791/D problem.
	/// </summary>
	public static void SolveProblem()
	{
		int stringLength = Input.GetInt();
		string sourceString = Input.GetString();

		Dictionary<char, int> firstSubstringFrequencyMapping = new();
		Dictionary<char, int> secondSubstringFrequencyMapping = new();
		firstSubstringFrequencyMapping[sourceString[0]] = 1;
		for (int i = 1; i < stringLength; ++i) {
			IncreaseFrequence(sourceString[i], secondSubstringFrequencyMapping);
		}

		int bestFunctionValue = GetFunctionValue();
		for (int i = 1; i < stringLength - 1; ++i) {
			IncreaseFrequence(sourceString[i], firstSubstringFrequencyMapping);
			DecreaseFrequence(sourceString[i], secondSubstringFrequencyMapping);
			bestFunctionValue = Math.Max(GetFunctionValue(), bestFunctionValue);
		}
		Output.WriteLine(bestFunctionValue);

		void IncreaseFrequence(char character, Dictionary<char, int> frequencyMapping)
		{
			if (!frequencyMapping.ContainsKey(character)) {
				frequencyMapping[character] = 0;
			}
			++frequencyMapping[character];
		}

		void DecreaseFrequence(char character, Dictionary<char, int> frequencyMapping)
		{
			if (--frequencyMapping[character] == 0) {
				frequencyMapping.Remove(character);
			}
		}

		int GetFunctionValue() => firstSubstringFrequencyMapping.Count + secondSubstringFrequencyMapping.Count;
 	}
}

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

	public static StreamReaderWrapper Input { get; private set; }
	public static StreamWriterWrapper Output { get; private set; }

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(Input.GetString()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			Solver.SolveProblem();
		}
	}

	private static void OpenIo()
	{
		var inputStream = IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());
		Input = new StreamReaderWrapper(inputStream);
		var outputStream = IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());
		Output = new StreamWriterWrapper(outputStream);
	}

	private static void CloseIo()
	{
		Input.Close();
		Output.Close();
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

internal class StreamWriterWrapper
{
	private readonly StreamWriter streamWriter;

	public StreamWriterWrapper(StreamWriter streamWriter)
	{
		this.streamWriter = streamWriter;
	}

	public void Write(object obj) => streamWriter.Write(obj);

	public void WriteLine(object obj) => streamWriter.WriteLine(obj);

	public void Close()
	{
		streamWriter.Close();
	}
}
