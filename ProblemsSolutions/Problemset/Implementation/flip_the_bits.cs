using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1504/B problem.
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
		int length = Input.ReadInt();
		string sourceString = Input.ReadString();
		string targetString = Input.ReadString();

		bool isPossibleToTransform = length % 2 == 0 || sourceString[^1] == targetString[^1];
		
		if (isPossibleToTransform) {
			int shortLength = length % 2 == 0 ? length : length - 1;

			int zeroesCount = 0;
			for (int i = 0; i < shortLength; ++i) {
				if (sourceString[i] == '0') {
					++zeroesCount;
				}
			}

			int onesCount = shortLength - zeroesCount;
			bool isReverted = false;
			for (int i = shortLength - 1; i >= 0; i -= 2) {
				char current = isReverted ? (sourceString[i] == '0' ? '1' : '0') : sourceString[i];
				char previous = isReverted ? (sourceString[i - 1] == '0' ? '1' : '0') : sourceString[i - 1];

				bool isNeedToRevert = current != targetString[i] || previous != targetString[i - 1];
				if (isNeedToRevert) {
					bool isCouldBeReverted = onesCount == zeroesCount && current != targetString[i] && previous != targetString[i - 1];
					if (!isCouldBeReverted) {
						isPossibleToTransform = false;
						break;
					}

					current = current == '0' ? '1' : '0';
					previous = previous == '0' ? '1' : '0';

					(zeroesCount, onesCount) = (onesCount, zeroesCount);
					isReverted = !isReverted;
				}

				zeroesCount -= current == '0' ? 1 : 0;
				zeroesCount -= previous == '0' ? 1 : 0;
				onesCount -= current == '1' ? 1 : 0;
				onesCount -= previous == '1' ? 1 : 0;
			}
		}

		Output.WriteLine(isPossibleToTransform ? "YES" : "NO");
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
