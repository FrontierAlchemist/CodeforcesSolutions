using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1914/D problem.
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
		int daysCount = Input.ReadInt();
		(int friendsCount, int dayNumber)[] friendsForSkiing = new (int, int)[daysCount];
		for (int i = 0; i < daysCount; ++i) {
			friendsForSkiing[i].friendsCount = Input.ReadInt();
			friendsForSkiing[i].dayNumber = i;
		}

		(int friendsCount, int dayNumber)[] friendsForMovie = new (int, int)[daysCount];
		for (int i = 0; i < daysCount; ++i) {
			friendsForMovie[i].friendsCount = Input.ReadInt();
			friendsForMovie[i].dayNumber = i;
		}

		(int friendsCount, int dayNumber)[] friendsForBoardGames = new (int, int)[daysCount];
		for (int i = 0; i < daysCount; ++i) {
			friendsForBoardGames[i].friendsCount = Input.ReadInt();
			friendsForBoardGames[i].dayNumber = i;
		}

		Array.Sort(friendsForSkiing);
		Array.Sort(friendsForMovie);
		Array.Sort(friendsForBoardGames);

		int maximalFriendsCountForThreeDays = 0;
		maximalFriendsCountForThreeDays = Math.Max(maximalFriendsCountForThreeDays, Calculate(
			friendsForSkiing, friendsForMovie, friendsForBoardGames
		));
		maximalFriendsCountForThreeDays = Math.Max(maximalFriendsCountForThreeDays, Calculate(
			friendsForSkiing, friendsForBoardGames, friendsForMovie
		));
		maximalFriendsCountForThreeDays = Math.Max(maximalFriendsCountForThreeDays, Calculate(
			friendsForMovie, friendsForSkiing, friendsForBoardGames
		));
		maximalFriendsCountForThreeDays = Math.Max(maximalFriendsCountForThreeDays, Calculate(
			friendsForMovie, friendsForBoardGames, friendsForSkiing
		));
		maximalFriendsCountForThreeDays = Math.Max(maximalFriendsCountForThreeDays, Calculate(
			friendsForBoardGames, friendsForSkiing, friendsForMovie
		));
		maximalFriendsCountForThreeDays = Math.Max(maximalFriendsCountForThreeDays, Calculate(
			friendsForBoardGames, friendsForMovie, friendsForSkiing
		));

		Output.WriteLine(maximalFriendsCountForThreeDays);
	}

	private static int Calculate(
		(int friendsCount, int dayNumber)[] a,
		(int friendsCount, int dayNumber)[] b,
		(int friendsCount, int dayNumber)[] c)
	{
		int maximalFriendsCount = 0;
		for (int i = a.Length - 1; i >= a.Length - 3; --i) {
			int currentFriendsCount = a[i].friendsCount;
			int aDay = a[i].dayNumber;

			int bDay = -1;
			for (int j = b.Length - 1; j >= 0; --j) {
				if (b[j].dayNumber != aDay) {
					bDay = b[j].dayNumber;
					currentFriendsCount += b[j].friendsCount;
					break;
				}
			}

			for (int j = c.Length - 1; j >= 0; --j) {
				if (c[j].dayNumber != aDay && c[j].dayNumber != bDay) {
					currentFriendsCount += c[j].friendsCount;
					break;
				}
			}

			maximalFriendsCount = Math.Max(maximalFriendsCount, currentFriendsCount);
		}

		return maximalFriendsCount;
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
