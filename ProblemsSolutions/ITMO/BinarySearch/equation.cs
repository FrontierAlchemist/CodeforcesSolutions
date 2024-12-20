// https://codeforces.com/edu/course/2/lesson/6/2/practice/contest/283932/problem/E

using System;
using System.IO;

public interface IInputReader
{
	string ReadLine();
}

public interface IOutputWriter
{
	void Write(string value);
	void WriteLine(string value);
}

public class ConsoleReader : IInputReader
{
	public string ReadLine()
		=> Console.ReadLine() ?? throw new FormatException("Error on trying read line from console.");
}

public class ConsoleWriter : IOutputWriter
{
	public void Write(string value) => Console.Write(value);

	public void WriteLine(string value) => Console.WriteLine(value);
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

	public void WriteLine(string value) => file.WriteLine(value);

	public override void CloseFile() => file.Close();
}

public class Program
{
	const bool IsSeveralTests = false;

	static readonly IInputReader reader;
	static readonly IOutputWriter writer;

	static readonly Action? onProgramClosing;

	static Program()
	{
		if (IsDebug()) {
			var fileReader = new FileReader();
			var fileWriter = new FileWriter();

			onProgramClosing += fileReader.CloseFile;
			onProgramClosing += fileWriter.CloseFile;

			reader = fileReader;
			writer = fileWriter;
		} else {
			reader = new ConsoleReader();
			writer = new ConsoleWriter();
		}
	}

	static bool IsDebug()
	{
#if DEBUG
		return true;
#else
		return false;
#endif
	}

	static void SolveTestCase()
	{
		double c = double.Parse(reader.ReadLine());

		const double Epsilon = 10e-9;
		const int MaxIterationsCount = 100;

		double leftBorder = 0.0;
		double rightBorder = c;
		int iterationNumber = 0;
		while ((rightBorder - leftBorder) > Epsilon) {
			double middleValue = (leftBorder + rightBorder) / 2;
			double other = Math.Pow(middleValue, 2.0) + Math.Sqrt(middleValue);
			if (Math.Abs(other - c) < Epsilon) {
				writer.WriteLine(middleValue.ToString());
				return;
			} else if (other > c) {
				rightBorder = middleValue;
			} else if (other < c) {
				leftBorder = middleValue;
			}
			if (++iterationNumber > MaxIterationsCount) {
				break;
			}
		}
		writer.WriteLine(rightBorder.ToString());
	}

	static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(reader.ReadLine()) : 1;
		for (int i = 0; i < testsCount; i++) {
			SolveTestCase();
		}
	}

	static void Close()
	{
		onProgramClosing?.Invoke();
	}

	static void Main()
	{
		RunTests();
		Close();
	}
}
