﻿using System;
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
		public override string ReadLine() => Console.ReadLine();

		public override void Write(string value) => Console.Write(value);

		public override void WriteLine(string value) => Console.WriteLine(value);
		public override void Close() {}
	}

	public class FileReaderWrite : ReaderWriter
	{
		private const string FileInPath = "..\\..\\..\\input.txt";
		private const string FileOutPath = "..\\..\\..\\output.txt";

		private readonly StreamReader fileIn;
		private readonly StreamWriter fileOut;

		public FileReaderWrite()
		{
			fileIn = new StreamReader(FileInPath);
			fileOut = new StreamWriter(FileOutPath);
		}

		public override string ReadLine() => fileIn.ReadLine();

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
			int testsCount = int.Parse(readerWriter.ReadLine());
			for (int i = 0; i < testsCount; i++) {
				SolveTestCase();
			}
		}

		static void Main()
		{
			RunTests();
			readerWriter.Close();
		}
	}
}
