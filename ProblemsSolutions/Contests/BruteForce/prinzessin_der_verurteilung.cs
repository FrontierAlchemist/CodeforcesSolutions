using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1536/B problem.
/// </summary>
internal class Solver
{
	private const bool IsSeveralTests = true;

	private static StreamReaderWrapper Input => Program.Input;
	private static StreamWriterWrapper Output => Program.Output;

	public static void Run()
	{
		PrepareControlSet();
		int testsCount = IsSeveralTests ? int.Parse(Input.ReadString()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			Solve();
		}
	}

	private static void PrepareControlSet()
	{
		controlSet = new(comparer);
		for (char i = 'a'; i <= 'z'; ++i) {
			controlSet.Add($"{i}");
			for (char j = 'a'; j <= 'z'; ++j) {
				controlSet.Add($"{i}{j}");
				for (char k = 'a'; k <= 'z'; ++k) {
					controlSet.Add($"{i}{j}{k}");
				}
			}
		}
	}

	private static void Solve()
	{
		int length = Input.ReadInt();
		string str = Input.ReadString();

		SortedSet<string> set = new(comparer);
		for (int i = 0; i < length; ++i) {
			set.Add($"{str[i]}");
		}
		for (int i = 0; i < length - 1; ++i) {
			set.Add($"{str[i]}{str[i + 1]}");
		}
		for (int i = 0; i < length - 2; ++i) {
			set.Add($"{str[i]}{str[i + 1]}{str[i + 2]}");
		}

		foreach (string candidate in controlSet) {
			if (!set.Contains(candidate)) {
				Output.WriteLine(candidate);
				return;
			}
		}

		throw new Exception();
	}

	private static readonly Comparer comparer = new();
	private static SortedSet<string> controlSet;

	private class Comparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			int strCmp = x.Length.CompareTo(y.Length);
			if (strCmp == 0) {
				for (int i = 0; i < x.Length; ++i) {
					int letterCmp = x[i].CompareTo(y[i]);
					if (letterCmp != 0) {
						strCmp = letterCmp;
						break;
					}
				}
			}
			return strCmp;
		}
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
