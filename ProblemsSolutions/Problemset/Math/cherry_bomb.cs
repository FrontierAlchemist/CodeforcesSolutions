using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2106/problem/C problem.
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
		int limit = Input.ReadInt();
		int[] a = Input.ReadIntArray(arraySize);
		int[] b = Input.ReadIntArray(arraySize);

		int x = -1;
		int minInA = a[0];
		int maxInA = a[0];
		int minInB = b[0];
		int maxInB = b[0];

		for (int i = 0; i < arraySize; ++i) {
			if (a[i] != -1 && b[i] != -1) {
				int currentX = a[i] + b[i];
				if (x == -1) {
					x = currentX;
				} else if (x != currentX) {
					Output.WriteLine(0);
					return;
				}
			}

			minInA = Math.Min(minInA, a[i]);
			maxInA = Math.Max(maxInA, a[i]);
			minInB = Math.Min(minInB, b[i]);
			maxInB = Math.Max(maxInB, b[i]);
		}

		int differentSumsCount = 0;
		if (x == -1) {
			int minPossibleSum = Math.Max(maxInA, maxInB);
			int maxPossibleSum = Math.Max(minInA, minInB) + limit;
			differentSumsCount = maxPossibleSum - minPossibleSum + 1;
		} else {
			int minValue = minInA;
			if (minInB != -1) {
				minValue = Math.Min(minValue, minInB);
			}
			differentSumsCount = x >= Math.Max(maxInA, maxInB) && x <= minValue + limit ? 1 : 0;
		}
		Output.WriteLine(differentSumsCount);
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
