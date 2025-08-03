// https://codeforces.com/contest/2009/problem/E

using System;
using System.IO;

namespace CodeForcesCSharpTemplate
{
	public interface IReaderFromInput
	{
		string ReadLine();
	}

	public interface IWriterFromOutput
	{
		void Write(string value);
		void WriteLine(string value);
	}

	public abstract class ReaderWriter: IReaderFromInput, IWriterFromOutput
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
		public override void Close() {}
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
			string[] readedValues = readerWriter.ReadLine().Split(' ');
			long n = long.Parse(readedValues[0]);
			long k = long.Parse(readedValues[1]);

			long CalculateSum(long i) => i * (2 * k + i - 1) / 2;

			long maximumSum = CalculateSum(n);

			long left = 1;
			long right = n;
			long targetIndex = 1;
			while (left <= right) {
				long middle = (right + left) / 2;
				long leftPartSum = CalculateSum(middle);
				long rightPartSum = maximumSum - leftPartSum;
				if (rightPartSum > leftPartSum) {
					targetIndex = middle;
					left = middle + 1;
				} else {
					right = middle - 1;
				}
			}

			long firstLeftPartSum = CalculateSum(targetIndex);
			long firstRightPartSum = maximumSum - firstLeftPartSum;
			long firstCandidate = firstRightPartSum - firstLeftPartSum;

			long secondLeftPart = CalculateSum(targetIndex + 1);
			long secondRightPart = maximumSum - secondLeftPart;
			long secondCandidate = secondLeftPart - secondRightPart;

			long answer = Math.Min(firstCandidate, secondCandidate);
			readerWriter.WriteLine(answer.ToString());
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
}
