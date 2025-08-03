using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1904/A problem.
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

	private struct Point
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static bool operator ==(Point lhs, Point rhs) => lhs.X == rhs.X && lhs.Y == rhs.Y;


		public static bool operator !=(Point lhs, Point rhs) => !(lhs == rhs);
	}

	private static void Solve()
	{
		int knightFirstMoveLength = Input.ReadInt();
		int knightSecondMoveLength = Input.ReadInt();
		Point kingPosition = new(Input.ReadInt(), Input.ReadInt());
		Point queenPosition = new(Input.ReadInt(), Input.ReadInt());

		HashSet<Point> uniqueKnightPositions = new(GetKnightPositions(kingPosition));
		foreach (var position in GetKnightPositions(queenPosition)) {
			uniqueKnightPositions.Add(position);
		}

		int totalKnightPositions = knightFirstMoveLength == knightSecondMoveLength ? 8 : 16;
		Output.WriteLine(totalKnightPositions - uniqueKnightPositions.Count);


		IEnumerable<Point> GetKnightPositions(Point target)
		{
			yield return new Point(target.X + knightFirstMoveLength, target.Y + knightSecondMoveLength);
			yield return new Point(target.X + knightFirstMoveLength, target.Y - knightSecondMoveLength);
			yield return new Point(target.X - knightFirstMoveLength, target.Y + knightSecondMoveLength);
			yield return new Point(target.X - knightFirstMoveLength, target.Y - knightSecondMoveLength);

			if (knightFirstMoveLength == knightSecondMoveLength) {
				yield break;
			}

			yield return new Point(target.X + knightSecondMoveLength, target.Y + knightFirstMoveLength);
			yield return new Point(target.X + knightSecondMoveLength, target.Y - knightFirstMoveLength);
			yield return new Point(target.X - knightSecondMoveLength, target.Y + knightFirstMoveLength);
			yield return new Point(target.X - knightSecondMoveLength, target.Y - knightFirstMoveLength);
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
