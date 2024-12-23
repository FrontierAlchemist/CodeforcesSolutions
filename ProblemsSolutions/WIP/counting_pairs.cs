// https://codeforces.com/contest/2051/problem/D

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
	const bool IsSeveralTests = true;

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
		string[] valuesFromInput = reader.ReadLine().Split();
		uint numbersCount = uint.Parse(valuesFromInput[0]);
		ulong leftBorder = ulong.Parse(valuesFromInput[1]);
		ulong rightBorder = ulong.Parse(valuesFromInput[2]);

		valuesFromInput = reader.ReadLine().Split();
		ulong[] numbers = new ulong[numbersCount];
		ulong totalSum = 0;
		for (uint i = 0; i < numbersCount; ++i) {
			numbers[i] = ulong.Parse(valuesFromInput[i]);
			totalSum += numbers[i];
		}

		Array.Sort(numbers);

		ulong interestingPairsCount = 0;
		
		for (uint i = 0; i < numbersCount - 1; ++i) {
			ulong currentSum = totalSum - numbers[i];
			uint leftPointer = i + 1;
			uint rightPointer = numbersCount - 1;
			while (leftPointer <= rightPointer && (currentSum - numbers[leftPointer]) > rightBorder) {
				++leftPointer;
			}
			if (leftPointer > rightPointer) {
				continue;
			}

			while (leftPointer <= rightPointer && (currentSum - numbers[rightPointer] < leftBorder)) {
				--rightPointer;
			}
			if (leftPointer > rightPointer) {
				continue;
			}

			interestingPairsCount += (ulong)rightPointer - leftPointer + 1;
		}
		writer.WriteLine(interestingPairsCount.ToString());
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
