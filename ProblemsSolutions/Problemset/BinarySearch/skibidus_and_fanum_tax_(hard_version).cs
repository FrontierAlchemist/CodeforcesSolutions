#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2065/problem/C2 problem.
/// </summary>
internal class Program
{
	private const bool IsSeveralTests = true;

	private const string InputFilePath = "..\\..\\..\\input.txt";
	private const string OutputFilePath = "..\\..\\..\\output.txt";

	private static bool IsDebug()
	{
#if DEBUG
		return true;
#else
		return false;
#endif
	}

	private static StreamReaderWrapper input;
	private static StreamWriter output;

	private static void SolveProblem()
	{
		int n = input.GetInt();
		int m = input.GetInt();
		int[] a = input.GetIntArray(n);
		int[] b = input.GetIntArray(m);

		Array.Sort(b);

		bool sorted = true;
		bool[] modified = new bool[n];
		for (int i = 0; i < n - 1; ++i) {
			if (!modified[i]) {
				int lowerBoundIndex = GetLowerBound(a[i] + (i > 0 ? a[i - 1] : int.MinValue));
				if (lowerBoundIndex != -1) {
					int canidate = b[lowerBoundIndex] - a[i];
					if (canidate <= a[i]) {
						a[i] = canidate;
						modified[i] = true;
					}
				}
			}

			if (a[i] > a[i + 1]) {
				if (!modified[i + 1]) {
					int lowerBoundIndex = GetLowerBound(a[i + 1] + a[i]);
					if (lowerBoundIndex != -1) {
						int candiate = b[lowerBoundIndex] - a[i + 1];
						if (candiate >= a[i + 1]) {
							a[i + 1] = candiate;
							modified[i + 1] = true;
						}
					}
				}
			}

			if (a[i] > a[i + 1]) {
				sorted = false;
				break;
			}
		}
		output.WriteLine(sorted ? "YES" : "NO");

		int GetLowerBound(int target)
		{
			int leftBorder = 0;
			int rightBorder = m;
			while (leftBorder < rightBorder) {
				int middlePoint = (leftBorder + rightBorder) / 2;
				if (b[middlePoint] >= target) {
					rightBorder = middlePoint;
				} else {
					leftBorder = middlePoint + 1;
				}
			}
			return rightBorder == m ? -1 : rightBorder;
		}
	}

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.GetString()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			SolveProblem();
		}
	}

	private static void OpenIo()
	{
		var inputStream = IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());
		input = new StreamReaderWrapper(inputStream);
		output = IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());
	}

	private static void CloseIo()
	{
		input.Close();
		output.Close();
	}

	private static void Main()
	{
		OpenIo();
		RunTests();
		CloseIo();
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

	public string GetString() => GetInputLine();

	public int GetInt() => int.Parse(GetInputLine());

	public int[] GetIntArray(int size)
	{
		int[] array = new int[size];
		for (int i = 0; i < size; ++i) {
			array[i] = GetInt();
		}
		return array;
	}

	public double GetDouble() => double.Parse(GetInputLine());

	public double[] GetDoubleArray(int size)
	{
		double[] array = new double[size];
		for (int i = 0; i < size; ++i) {
			array[i] = GetDouble();
		}
		return array;
	}

	public void Close()
	{
		streamReader.Close();
	}

	private string GetInputLine()
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
