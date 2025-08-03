using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1618/C problem.
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
		long[] array = Input.ReadLongArray(arraySize);

		long gcd1 = array[0];
		for (int i = 2; i < arraySize; i += 2) {
			gcd1 = Gcd(gcd1, array[i]);
		}

		long gcd2 = array[1];
		for (int i = 3; i < arraySize; i += 2) {
			gcd2 = Gcd(gcd2, array[i]);
		}

		bool isAnswerFound = true;
		for (int i = 1; i < arraySize; i += 2) {
			if (array[i] % gcd1 == 0) {
				isAnswerFound = false;
				break;
			}
		}

		long answer = 0L;
		if (isAnswerFound) {
			answer = gcd1;
		} else {
			isAnswerFound = true;
			for (int i = 0; i < arraySize; i += 2) {
				if (array[i] % gcd2 == 0) {
					isAnswerFound = false;
					break;
				}
			}
			if (isAnswerFound) {
				answer = gcd2;
			}
		}

		Output.WriteLine(answer);
	}

	private static long Gcd(long a, long b)
	{
		while (b > 0) {
			a %= b;
			(a, b) = (b, a);
		}
		return a;
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
