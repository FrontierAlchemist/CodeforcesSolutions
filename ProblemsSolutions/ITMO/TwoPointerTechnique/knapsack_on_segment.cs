using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/edu/course/2/lesson/9/3/practice/contest/307094/problem/E problem.
/// </summary>
public class ProblemSolver
{
	private struct Item
	{
		public int Weight { get; set; }
		public int Cost { get; set; }
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
		string[] valuesFromInput = input.ReadLineAndSplit();
		int itemsCount = int.Parse(valuesFromInput[0]);
		int knapsackCapacity = int.Parse(valuesFromInput[1]);
		Item[] items = new Item[itemsCount];
		valuesFromInput = input.ReadLineAndSplit();
		for (int i = 0; i < itemsCount; ++i) {
			items[i].Weight = int.Parse(valuesFromInput[i]);
		}
		valuesFromInput = input.ReadLineAndSplit();
		for (int i = 0; i < itemsCount; ++i) {
			items[i].Cost = int.Parse(valuesFromInput[i]);
		}

		int leftPointer = 0;
		int currentKnapsackWeight = 0;
		long currentCost = 0L;
		long maximalCost = 0L;
		for (int rightPointer = 0; rightPointer < itemsCount; ++rightPointer) {
			while (currentKnapsackWeight + items[rightPointer].Weight > knapsackCapacity) {
				currentKnapsackWeight -= items[leftPointer].Weight;
				currentCost -= items[leftPointer].Cost;
				++leftPointer;
			}
			currentKnapsackWeight += items[rightPointer].Weight;
			currentCost += items[rightPointer].Cost;
			maximalCost = Math.Max(currentCost, maximalCost);
		}

		output.WriteLine(maximalCost);
	}
}

public interface IInputReader
{
	string ReadLine();
	string[] ReadLineAndSplit();
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

	public string[] ReadLineAndSplit() => ReadLine().Split();
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

	public string[] ReadLineAndSplit() => ReadLine().Split();

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
