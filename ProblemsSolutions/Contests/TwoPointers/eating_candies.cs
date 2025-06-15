using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1669/F problem.
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
		int candiesCount = Input.ReadInt();
		int[] candiesWeights = Input.ReadIntArray(candiesCount);

		if (candiesCount == 1) {
			Output.WriteLine(0);
			return;
		}

		int maximalEatenCandiesCount = 0;
		{
			int eatenCandiesCount = 0;

			int aliceIndex = -1;
			int aliceWeightOfEatenCandies = 0;

			int bobIndex = candiesCount;
			int bobWeightOfEatenCandies = 0;

			while (bobIndex - aliceIndex > 1) {
				aliceWeightOfEatenCandies += candiesWeights[++aliceIndex];
				if (bobIndex - aliceIndex == 1) {
					break;
				}
				while (bobWeightOfEatenCandies < aliceWeightOfEatenCandies) {
					bobWeightOfEatenCandies += candiesWeights[--bobIndex];
					if (aliceWeightOfEatenCandies == bobWeightOfEatenCandies) {
						eatenCandiesCount = aliceIndex + 1 + candiesCount - bobIndex;
					}
					if (bobIndex - aliceIndex == 1) {
						break;
					}
				}
			}

			maximalEatenCandiesCount = eatenCandiesCount;
		}

		{
			int eatenCandiesCount = 0;

			int aliceIndex = -1;
			int aliceWeightOfEatenCandies = 0;

			int bobIndex = candiesCount;
			int bobWeightOfEatenCandies = 0;

			while (bobIndex - aliceIndex > 1) {
				bobWeightOfEatenCandies += candiesWeights[--bobIndex];
				if (bobIndex - aliceIndex == 1) {
					break;
				}
				while (aliceWeightOfEatenCandies < bobWeightOfEatenCandies) {
					aliceWeightOfEatenCandies += candiesWeights[++aliceIndex];
					if (aliceWeightOfEatenCandies == bobWeightOfEatenCandies) {
						eatenCandiesCount = aliceIndex + 1 + candiesCount - bobIndex;
					}
					if (bobIndex - aliceIndex == 1) {
						break;
					}
				}
			}

			maximalEatenCandiesCount = Math.Max(maximalEatenCandiesCount, eatenCandiesCount);
		}

		Output.WriteLine(maximalEatenCandiesCount);
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
