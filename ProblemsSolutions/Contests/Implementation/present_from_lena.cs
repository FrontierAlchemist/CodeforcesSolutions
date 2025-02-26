using System;
using System.Collections.Generic;
using System.IO;

internal class Solver
{
	private static StreamReaderWrapper Input => Program.Input;
	private static StreamWriterWrapper Output => Program.Output;

	/// <summary>
	/// Solve https://codeforces.com/problemset/problem/118/B problem.
	/// </summary>
	public static void SolveProblem()
	{
		int number = Input.ReadInt();
		int matrixSize = number * 2 + 1;
		int[,] matrix = new int[matrixSize, matrixSize];
		for (int i = 0; i < matrixSize; ++i) {
			int currentNumber = i <= number ? i : number - (i - number);
			matrix[i, number] = currentNumber;
			for (int j = number - 1; j >= 0; --j) {
				matrix[i, j] = currentNumber - (number - j);
			}
			for (int j = number + 1; j < matrixSize; ++j) {
				matrix[i, j] = currentNumber - (j - number);
			}
		}
		for (int i = 0; i < matrixSize; ++i) {
			Output.Write(matrix[i, 0] >= 0 ? (char)('0' + matrix[i, 0]) : ' ');
			for (int j = 1; j < matrixSize; ++j) {
				if (matrix[i, j] < 0 && j > number) {
					break;
				}
				Output.Write(' ');
				Output.Write(matrix[i, j] >= 0 ? (char)('0' + matrix[i, j]) : ' ');
			}
			Output.WriteLine();
		}
	}
}

internal class Program
{
	private const bool IsSeveralTests = false;

	private const string InputFilePath = "..\\..\\..\\input.txt";
	private const string OutputFilePath = "..\\..\\..\\output.txt";

	public static StreamReaderWrapper Input { get; private set; }
	public static StreamWriterWrapper Output { get; private set; }

	private static void Main()
	{
		OpenIo();
		RunTests();
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

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(Input.ReadString()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			Solver.SolveProblem();
		}
	}

	private static void CloseIo()
	{
		Input.Close();
		Output.Close();
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
