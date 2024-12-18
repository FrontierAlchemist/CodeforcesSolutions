using System;
using System.IO;

public interface IReaderFromInput
{
	string ReadLine();
}

public interface IWriterFromOutput
{
	void Write(string value);
	void WriteLine(string value);
}

public abstract class ReaderWriter : IReaderFromInput, IWriterFromOutput
{
	public abstract string ReadLine();
	public abstract void Write(string value);
	public abstract void WriteLine(string value);
	public abstract void Close();
}

public class ConsoleReaderWriter : ReaderWriter
{
	public override string ReadLine()
		=> Console.ReadLine() ?? throw new FormatException("Error on trying read line from console.");

	public override void Write(string value) => Console.Write(value);

	public override void WriteLine(string value) => Console.WriteLine(value);
	public override void Close() { }
}

public class FileReaderWrite : ReaderWriter
{

	private const string RelativePathToFiles = "..\\..\\..\\";
	private const string FileInName = "input.txt";
	private const string FileOutName = "output.txt";

	private static string FileInPath => Path.Combine(RelativePathToFiles, FileInName);
	private static string FileOutPath => Path.Combine(RelativePathToFiles, FileOutName);

	private readonly StreamReader fileIn;
	private readonly StreamWriter fileOut;

	public FileReaderWrite()
	{
		fileIn = new StreamReader(FileInPath);
		fileOut = new StreamWriter(FileOutPath);
	}

	public override string ReadLine()
		=> fileIn.ReadLine() ?? throw new FormatException($"Error on trying read line from file: {FileInPath}.");

	public override void Write(string value) => fileOut.Write(value);

	public override void WriteLine(string value) => fileOut.WriteLine(value);

	public override void Close()
	{
		fileIn.Close();
		fileOut.Close();
	}
}

public class Program
{
	const bool IsSeveralTests = true;

	static readonly ReaderWriter readerWriter = IsDebug() ? new FileReaderWrite() : new ConsoleReaderWriter();

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
	}

	static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(readerWriter.ReadLine()) : 1;
		for (int i = 0; i < testsCount; i++) {
			SolveTestCase();
		}
	}

	static void OnProgramClose() => readerWriter.Close();

	static void Main()
	{
		RunTests();
		OnProgramClose();
	}
}
