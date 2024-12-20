// https://codeforces.com/edu/course/2/lesson/6/2/practice/contest/283932/problem/C

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
		int requestedCopiesCount = int.Parse(valuesFromInput[0]);
		int firstCopierSpeed = int.Parse(valuesFromInput[1]);
		int secondCopierSpeed = int.Parse(valuesFromInput[2]);

		long time = Math.Min(firstCopierSpeed, secondCopierSpeed);
		if (--requestedCopiesCount == 0) {
			writer.WriteLine(time.ToString());
			return;
		}

		long leftBorder = 0;
		long rightBorder = Math.Min(firstCopierSpeed, secondCopierSpeed) * requestedCopiesCount;
		while (leftBorder + 1 < rightBorder) {
			long checkedTime = (leftBorder + rightBorder) / 2;
			if (IsEnoughTime(checkedTime)) {
				rightBorder = checkedTime;
			} else {
				leftBorder = checkedTime;
			}
		}

		time += rightBorder;
		writer.WriteLine(time.ToString());

		bool IsEnoughTime(long checkedTime)
		{
			long printedByFirst = checkedTime / firstCopierSpeed;
			long printedBySecond = checkedTime / secondCopierSpeed;
			return printedByFirst + printedBySecond >= requestedCopiesCount;
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
