#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2055/problem/B problem.
/// </summary>
internal class Program
{
	private const bool IsSeveralTests = true;

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

	private static readonly StreamReader input =
		IsDebug() ? new StreamReader(InputFilePath) : new StreamReader(Console.OpenStandardInput());

	private static readonly StreamWriter output =
		IsDebug() ? new StreamWriter(OutputFilePath) : new StreamWriter(Console.OpenStandardOutput());

	private static void SolveProblem()
	{
		long resourcesTypesCount = long.Parse(input.ReadLine());
		string[] valuesFromInput = input.ReadLine().Split();
		int[] currentResourcesQuantity = new int[resourcesTypesCount];
		for (int i = 0; i < resourcesTypesCount; i++) {
			currentResourcesQuantity[i] = int.Parse(valuesFromInput[i]);
		}
		valuesFromInput = input.ReadLine().Split();
		int[] requierdResourcesQuantity = new int[resourcesTypesCount];
		for (int i = 0; i < resourcesTypesCount; i++) {
			requierdResourcesQuantity[i] = int.Parse(valuesFromInput[i]);
		}
		int requiredTransformationsCount = 0;
		int availableTransformationsCount = int.MaxValue;
		for (int i = 0; i < resourcesTypesCount; ++i) {
			if (currentResourcesQuantity[i] >= requierdResourcesQuantity[i]) {
				availableTransformationsCount = Math.Min(
                    availableTransformationsCount,
                    currentResourcesQuantity[i] - requierdResourcesQuantity[i]
                );
			} else {
				if (requiredTransformationsCount > 0) {
					output.WriteLine("NO");
					return;
				}
				requiredTransformationsCount = requierdResourcesQuantity[i] - currentResourcesQuantity[i];
			}
		}
		output.WriteLine(availableTransformationsCount >= requiredTransformationsCount ? "YES" : "NO");
	}

	private static void RunTests()
	{
		int testsCount = IsSeveralTests ? int.Parse(input.ReadLine()) : 1;
		for (int i = 0; i < testsCount; ++i) {
			SolveProblem();
		}
	}

	private static void CloseStreams()
	{
		input.Close();
		output.Close();
	}

	private static void Main()
	{
		RunTests();
		CloseStreams();
	}
}
