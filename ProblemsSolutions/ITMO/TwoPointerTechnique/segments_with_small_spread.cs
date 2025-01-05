using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/edu/course/2/lesson/9/2/practice/contest/307093/problem/F problem.
/// </summary>
public class ProblemSolver
{
	private class MinMaxStack
	{
		private readonly Stack<long> mainStack = new();
		private readonly Stack<long> minStack = new();
		private readonly Stack<long> maxStack = new();

		public void Push(long value)
		{
			mainStack.Push(value);
			minStack.Push(Math.Min(value, GetMinValue()));
			maxStack.Push(Math.Max(value, GetMaxValue()));
		}

		public long Pop()
		{
			_ = minStack.Pop();
			_ = maxStack.Pop();
			return mainStack.Pop();
		}

		public bool IsEmpty() => mainStack.Count == 0;

		public long GetMinValue() => minStack.Count == 0 ? long.MaxValue : minStack.Peek();
		public long GetMaxValue() => maxStack.Count == 0 ? long.MinValue : maxStack.Peek();
	}

	const bool IsSeveralTests = false;

	private readonly IInputReader input;
	private readonly IOutputWriter output;

	public ProblemSolver(IInputReader input, IOutputWriter output)
	{
		this.input = input;
		this.output = output;
	}

	public void Solve()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.ReadLine()) : 1;
		for (int i = 0; i < testsCount; i++) {
			SolveTestCase();
		}
	}

	private void SolveTestCase()
	{
		string[] valuesFromInput = input.ReadLine().Split();
		int arraySize = int.Parse(valuesFromInput[0]);
		long spreadLimit = long.Parse(valuesFromInput[1]);
		valuesFromInput = input.ReadLine().Split();
		long[] array = new long[arraySize];
		for (int i = 0; i < arraySize; ++i) {
			array[i] = long.Parse(valuesFromInput[i]);
		}

		MinMaxStack leftStack = new();
		MinMaxStack rightStack = new();

		int leftBorder = 0;
		long validSegmentsCount = 0L;
		for (int rightBorder = 0; rightBorder < arraySize; ++rightBorder) {
			AddElementToSegment(array[rightBorder]);
			while (!IsSegmentValid()) {
				RemoveElementFromSegment();
				++leftBorder;
			}
			validSegmentsCount += rightBorder - leftBorder + 1;
		}

		output.WriteLine(validSegmentsCount);

		bool IsSegmentValid()
		{
			long minValue = Math.Min(leftStack.GetMinValue(), rightStack.GetMinValue());
			long maxValue = Math.Max(leftStack.GetMaxValue(), rightStack.GetMaxValue());
			return maxValue - minValue <= spreadLimit;
		}

		void AddElementToSegment(long element)
		{
			rightStack.Push(element);
		}

		void RemoveElementFromSegment()
		{
			if (leftStack.IsEmpty()) {
				while (!rightStack.IsEmpty()) {
					leftStack.Push(rightStack.Pop());
				}
			}
			_ = leftStack.Pop();
		}
	}
}

public interface IInputReader
{
	string ReadLine();
}

public interface IOutputWriter
{
	void Write(string value);
	public void Write(object obj);
	void WriteLine(string value);
	public void WriteLine(object obj);
}

public class ConsoleReader : IInputReader
{
	public string ReadLine()
		=> Console.ReadLine() ?? throw new FormatException("Error on trying read line from console.");
}

public class ConsoleWriter : IOutputWriter
{
	public void Write(string value) => Console.Write(value);

	public void Write(object obj) => Console.Write(obj);

	public void WriteLine(string value) => Console.WriteLine(value);
	public void WriteLine(object obj) => Console.WriteLine(obj);
}

public abstract class FileHolder
{
	private const string RelativePathToFiles = "..\\..\\..\\";

	protected readonly string fileName;

	protected virtual string PathToFile => Path.Combine(RelativePathToFiles, fileName);

	public FileHolder(string fileName)
	{
		this.fileName = fileName;
	}

	public abstract void CloseFile();
}

public class FileReader : FileHolder, IInputReader
{
	private readonly StreamReader file;

	public FileReader() : base("input.txt")
	{
		file = new StreamReader(PathToFile);
	}

	public string ReadLine()
		=> file.ReadLine() ?? throw new FormatException($"Error on trying read line from file: {PathToFile}.");

	public override void CloseFile() => file.Close();
}

public class FileWriter : FileHolder, IOutputWriter
{
	private readonly StreamWriter file;

	public FileWriter() : base("output.txt")
	{
		file = new StreamWriter(PathToFile);
	}

	public void Write(string value) => file.Write(value);

	public void Write(object obj) => file.Write(obj);

	public void WriteLine(string value) => file.WriteLine(value);

	public void WriteLine(object obj) => file.WriteLine(obj);

	public override void CloseFile() => file.Close();
}

internal class Program
{
	private static Action? onProgramClosing;

	private static bool IsDebug()
	{
#if DEBUG
		return true;
#else
		return false;
#endif
	}

	private static void Close()
	{
		onProgramClosing?.Invoke();
	}

	private static ProblemSolver CreateProblemSolver()
	{
		IInputReader input;
		IOutputWriter output;

		if (IsDebug()) {
			var fileReader = new FileReader();
			var fileWriter = new FileWriter();

			onProgramClosing += fileReader.CloseFile;
			onProgramClosing += fileWriter.CloseFile;

			input = fileReader;
			output = fileWriter;
		} else {
			input = new ConsoleReader();
			output = new ConsoleWriter();
		}

		return new ProblemSolver(input, output);
	}

	private static void Main()
	{
		CreateProblemSolver().Solve();
		Close();
	}
}
