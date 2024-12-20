// https://codeforces.com/edu/course/2/lesson/6/2/practice/contest/283932/problem/B

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
		string[] valuesFromInput = reader.ReadLine().Split(' ');
		int ropesCount = int.Parse(valuesFromInput[0]);
		int requiredPartsCount = int.Parse(valuesFromInput[1]);
		double[] ropesLengthes = new double[ropesCount];
		for (int i = 0; i < ropesCount; ++i) {
			ropesLengthes[i] = double.Parse(reader.ReadLine());
		}

		double leftBorder = 0.0;
		double rightBorder = 1e8; // Because the limitation for ropes length is 1e7.

		const int MaxIterationsCount = 100;
		for (int i = 0; i <= MaxIterationsCount; ++i) {
			double checkedLength = (leftBorder + rightBorder) / 2;
			if (IsLengthEnough(checkedLength)) {
				leftBorder = checkedLength;
			} else {
				rightBorder = checkedLength;
			}
		}

		writer.WriteLine(rightBorder.ToString());

		bool IsLengthEnough(double checkedLength)
		{
			long partsCount = 0;
			for (int i = 0; i < ropesCount; ++i) {
				partsCount += (long)(ropesLengthes[i] / checkedLength);
			}
			return partsCount >= requiredPartsCount;
		}
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
