#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/151/A problem.
/// </summary>
internal class Program
{
	private const bool IsSeveralTests = false;

	private const string InputFilePath = "..\\..\\..\\input.txt";
	private const string OutputFilePath = "..\\..\\..\\output.txt";

	private static bool IsDebug()
	{
#if DEBUG
		return true;
#else
		return false;
#endif
	}

	private static StreamReader input;
	private static StreamWriter output;

	private static void SolveProblem()
	{
		string[] valuesFromInput = input.ReadLine().Split();

		int friendsCount = int.Parse(valuesFromInput[0]);
		int bottlesCount = int.Parse(valuesFromInput[1]);
		int bottleVolume = int.Parse(valuesFromInput[2]);
		int limesCount = int.Parse(valuesFromInput[3]);
		int slicesPerLimeCount = int.Parse(valuesFromInput[4]);
		int saltAmount = int.Parse(valuesFromInput[5]);
		int volumeOfDrinkPerToast = int.Parse(valuesFromInput[6]);
		int volumeOfSaltPerToast = int.Parse(valuesFromInput[7]);

		int toastsCount = int.MaxValue;
		int volumeOfDrink = bottlesCount * bottleVolume;
		toastsCount = Math.Min(toastsCount, volumeOfDrink / volumeOfDrinkPerToast / friendsCount);
		int totalSlicesCount = limesCount * slicesPerLimeCount;
		toastsCount = Math.Min(toastsCount, totalSlicesCount / friendsCount);
		toastsCount = Math.Min(toastsCount, saltAmount / volumeOfSaltPerToast / friendsCount);

		output.WriteLine(toastsCount);
	}

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.ReadLine()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			SolveProblem();
		}
	}

	private static void OpenIoStreams()
	{
		input = IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());
		output = IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());
	}

	private static void CloseIoStreams()
	{
		input.Close();
		output.Close();
	}

	private static void Main()
	{
		OpenIoStreams();
		RunTests();
		CloseIoStreams();
	}
}
