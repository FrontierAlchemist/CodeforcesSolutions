using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1620/B problem.
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
		int width = Input.ReadInt();
		int height = Input.ReadInt();

		int topPointsCount = Input.ReadInt();
		int smallestTopPoint = Input.ReadInt();
		for (int i = 1; i < topPointsCount - 1; ++i) {
			_ = Input.ReadInt();
		}
		int largestTopPoint = Input.ReadInt();

		int bottomPointsCount = Input.ReadInt();
		int smallestBottomPoint = Input.ReadInt();
		for (int i = 1; i < bottomPointsCount - 1; ++i) {
			_ = Input.ReadInt();
		}
		int largestBottomPoint = Input.ReadInt();

		int leftPointsCount = Input.ReadInt();
		int smallestLeftPoint = Input.ReadInt();
		for (int i = 1; i < leftPointsCount - 1; ++i) {
			_ = Input.ReadInt();
		}
		int largestLeftPoint = Input.ReadInt();

		int rightPointsCount = Input.ReadInt();
		int smallestRightPoint = Input.ReadInt();
		for (int i = 1; i < rightPointsCount - 1; ++i) {
			_ = Input.ReadInt();
		}
		int largestRightPoint = Input.ReadInt();

		long topLength = largestTopPoint - smallestTopPoint;
		long bottomLength = largestBottomPoint - smallestBottomPoint;
		long leftLength = largestLeftPoint - smallestLeftPoint;
		long rightLength = largestRightPoint - smallestRightPoint;

		long maximalTriangleSquare = 0;
		maximalTriangleSquare = Math.Max(maximalTriangleSquare, topLength * height);
		maximalTriangleSquare = Math.Max(maximalTriangleSquare, bottomLength * height);
		maximalTriangleSquare = Math.Max(maximalTriangleSquare, leftLength * width);
		maximalTriangleSquare = Math.Max(maximalTriangleSquare, rightLength * width);

		Output.WriteLine(maximalTriangleSquare);
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
