using System;
using System.Collections.Generic;
using System.IO;

// https://codeforces.com/edu/course/2/lesson/6/3/practice/contest/285083/problem/A

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

	struct Segment
	{
		public readonly double LeftPoint { get; }
		public readonly double RightPoint { get; }

		public Segment(double leftPoint, double rightPoint)
		{
			LeftPoint = leftPoint;
			RightPoint = rightPoint;
		}
	}

	struct PersonInfo
	{
		public readonly double Position { get; }
		public readonly double Speed { get; }

		public PersonInfo(double position, double speed)
		{
			Position = position;
			Speed = speed;
		}

		public readonly Segment GetReachableSegment(double time)
		{
			double maximalDistance = time * Speed;
			return new Segment(Position - maximalDistance, Position + maximalDistance);
		}
	}

	static void SolveTestCase()
	{
		const double Infinity = 1e9 + 1;

		int personsCount = int.Parse(reader.ReadLine());
		double minimalPosition = Infinity;
		double maximalPosition = -Infinity;
		double minimalSpeed = Infinity;
		List<PersonInfo> personsInfos = new(personsCount);
		for (int i = 0; i < personsCount; ++i) {
			var valuesFromInput = reader.ReadLine().Split(' ');
			double position = double.Parse(valuesFromInput[0]);
			double speed = double.Parse(valuesFromInput[1]);
			personsInfos.Add(new PersonInfo(position, speed));
			minimalPosition = Math.Min(personsInfos[i].Position, minimalPosition);
			maximalPosition = Math.Max(personsInfos[i].Position, maximalPosition);
			minimalSpeed = Math.Min(personsInfos[i].Speed, minimalSpeed);
		}

		const int MaxIterationsCount = 100;

		double minimalTime = 0.0;
		double maximalTime = (maximalPosition - minimalPosition) / minimalSpeed;

		for (int i = 0; i <= MaxIterationsCount; ++i) {
			double targetTime = (minimalTime + maximalTime) / 2.0;
			if (IsCommonPointExist(targetTime)) {
				maximalTime = targetTime;
			} else {
				minimalTime = targetTime;
			}
		}

		writer.WriteLine(maximalTime.ToString());

		bool IsCommonPointExist(double time)
		{
			double maximalLeftPoint = -Infinity;
			double minimalRightPoint = Infinity;
			foreach (var personInfo in personsInfos) {
				var reachableSegmentForPerson = personInfo.GetReachableSegment(time);
				maximalLeftPoint = Math.Max(maximalLeftPoint, reachableSegmentForPerson.LeftPoint);
				minimalRightPoint = Math.Min(minimalRightPoint, reachableSegmentForPerson.RightPoint);
			}
			return maximalLeftPoint <= minimalRightPoint;
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
