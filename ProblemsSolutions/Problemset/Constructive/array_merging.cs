using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1831/B problem.
/// </summary>
internal class Solver
{
	private const bool IsSeveralTests = true;

	private static StreamReaderWrapper Input => Program.Input;
	private static StreamWriterWrapper Output => Program.Output;

	public static void Run()
	{
		int testsCount = IsSeveralTests ? int.Parse(Input.ReadString()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			Solve();
		}
	}

	private static void Solve()
	{
		int arraySize = Input.ReadInt();
		int[] firstArray = Input.ReadIntArray(arraySize);
		int[] secondArray = Input.ReadIntArray(arraySize);

		Dictionary<int, int> lengthesOfEqualSubarrays = new();
		int currentEqualSubsegmentLength = 1;
		int maxEqualSubsegmentLength = 1;
		for (int i = 1; i < arraySize; ++i) {
			if (firstArray[i - 1] == firstArray[i]) {
				++currentEqualSubsegmentLength;
			} else {
				if (lengthesOfEqualSubarrays.TryGetValue(firstArray[i - 1], out int previousLength)) {
					lengthesOfEqualSubarrays[firstArray[i - 1]] = Math.Max(previousLength, currentEqualSubsegmentLength);
				} else {
					lengthesOfEqualSubarrays[firstArray[i - 1]] = currentEqualSubsegmentLength;
				}
				maxEqualSubsegmentLength = Math.Max(maxEqualSubsegmentLength, lengthesOfEqualSubarrays[firstArray[i - 1]]);
				currentEqualSubsegmentLength = 1;
			}
		}

		{
			if (lengthesOfEqualSubarrays.TryGetValue(firstArray[arraySize - 1], out int previousLength)) {
				lengthesOfEqualSubarrays[firstArray[arraySize - 1]] = Math.Max(previousLength, currentEqualSubsegmentLength);
			} else {
				lengthesOfEqualSubarrays[firstArray[arraySize - 1]] = currentEqualSubsegmentLength;
			}
			maxEqualSubsegmentLength = Math.Max(maxEqualSubsegmentLength, lengthesOfEqualSubarrays[firstArray[arraySize - 1]]);
			currentEqualSubsegmentLength = 0;
		}

		currentEqualSubsegmentLength = 1;
		for (int i = 1; i < arraySize; ++i) {
			if (secondArray[i - 1] == secondArray[i]) {
				++currentEqualSubsegmentLength;
			} else {
				if (lengthesOfEqualSubarrays.TryGetValue(secondArray[i - 1], out int previousLength)) {
					currentEqualSubsegmentLength += previousLength;
				}
				maxEqualSubsegmentLength = Math.Max(maxEqualSubsegmentLength, currentEqualSubsegmentLength);
				currentEqualSubsegmentLength = 1;
			}
		}

		{
			if (lengthesOfEqualSubarrays.TryGetValue(secondArray[arraySize - 1], out int previousLength)) {
				currentEqualSubsegmentLength += previousLength;
			}
			maxEqualSubsegmentLength = Math.Max(maxEqualSubsegmentLength, currentEqualSubsegmentLength);
			currentEqualSubsegmentLength = 0;
		}

		Output.WriteLine(maxEqualSubsegmentLength);
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

	public string ReadString() => ReadLine();

	public char ReadChar() => ReadLine()[0];

	public int ReadInt() => int.Parse(ReadLine());

	public int[] ReadIntArray(int size)
	{
		int[] array = new int[size];
		for (int i = 0; i < size; ++i) {
			array[i] = ReadInt();
		}
		return array;
	}

	public double ReadDouble() => double.Parse(ReadLine());

	public double[] ReadDoubleArray(int size)
	{
		double[] array = new double[size];
		for (int i = 0; i < size; ++i) {
			array[i] = ReadDouble();
		}
		return array;
	}

	public long ReadLong() => long.Parse(ReadLine());

	public long[] ReadLongArray(int size)
	{
		long[] array = new long[size];
		for (int i = 0; i < size; ++i) {
			array[i] = ReadLong();
		}
		return array;
	}

	public void Close()
	{
		streamReader.Close();
	}

	private string ReadLine()
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

	public void WriteLine() => streamWriter.WriteLine();

	public void Close()
	{
		streamWriter.Close();
	}
}

internal class Program
{
	private const string InputFilePath = "..\\..\\..\\input.txt";
	private const string OutputFilePath = "..\\..\\..\\output.txt";

	public static StreamReaderWrapper Input { get; private set; }
	public static StreamWriterWrapper Output { get; private set; }

	private static void Main()
	{
		OpenIo();
		Solver.Run();
		CloseIo();
	}

	private static void OpenIo()
	{
		var inputStream = IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());
		Input = new StreamReaderWrapper(inputStream);
		var outputStream = IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());
		Output = new StreamWriterWrapper(outputStream);
	}

	private static bool IsDebug()
	{
#if DEBUG
		return true;
#else
		return false;
#endif
	}

	private static void CloseIo()
	{
		Input.Close();
		Output.Close();
	}
}
