// https://codeforces.com/edu/course/2/lesson/6/2/practice/contest/283932/problem/F

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
		string sourceString = reader.ReadLine();
		string targetString = reader.ReadLine();
		int sourceLength = sourceString.Length;
		int targetLength = targetString.Length;
		string[] valuesFromConsole = reader.ReadLine().Split(' ');
		int[] removingIndices = new int[sourceLength];
		for (int i = 0; i < valuesFromConsole.Length; ++i) {
			removingIndices[i] = int.Parse(valuesFromConsole[i]);
		}

		int leftBorder = 0;
		int rightBorder = sourceLength;
		while (leftBorder < rightBorder) {
			bool isLastIteration = rightBorder - leftBorder == 1;
			int removingOperationsCount = (leftBorder + rightBorder) / 2;
			if (CanTrasformSourceToTarget(removingOperationsCount)) {
				rightBorder = removingOperationsCount;
			} else {
				leftBorder = removingOperationsCount;
			}
			if (isLastIteration) {
				break;
			}
		}

		writer.WriteLine(leftBorder.ToString());

		bool CanTrasformSourceToTarget(int removingOperationsCount)
		{
			bool[] isCharRemoved = new bool[sourceLength];
			for (int i = 0; i < removingOperationsCount; ++i) {
				isCharRemoved[removingIndices[i] - 1] = true;
			}
			int searchPointer = 0;
			for (int i = 0; i < targetLength; ++i) {
				while (searchPointer < sourceLength) {
					if (!isCharRemoved[searchPointer] && targetString[i] == sourceString[searchPointer]) {
						break;
					}
					++searchPointer;
				}
				if (searchPointer >= sourceLength) {
					return true;
				}
				++searchPointer;
			}
			return false;
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
