#nullable disable

using System;
using System.IO;

/// <summary>
/// Solve https://codeforces.com/contest/2060/problem/B problem.
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
		string[] valuesFromInput = input.ReadLine().Split();
		int playersCount = int.Parse(valuesFromInput[0]);
		int roundsCount = int.Parse(valuesFromInput[1]);
		int[][] cards = new int[playersCount][];
		for (int i = 0; i < playersCount; ++i) {
			cards[i] = new int[roundsCount];
			valuesFromInput = input.ReadLine().Split();
			for (int j = 0; j < roundsCount; ++j) {
				cards[i][j] = int.Parse(valuesFromInput[j]);
			}
			Array.Sort(cards[i]);
		}

		(int cardValue, int playerNumber)[] firstRoundCards = new (int, int)[playersCount];
		for (int i = 0; i < playersCount; ++i) {
			firstRoundCards[i].playerNumber = i;
			firstRoundCards[i].cardValue = cards[i][0];
		}
		Array.Sort(firstRoundCards);

		int[] playersOrder = new int[playersCount];
		for (int i = 0; i < playersCount; ++i) {
			playersOrder[i] = firstRoundCards[i].playerNumber + 1;
		}

		int topCard = -1;
		for (int i = 0; i < roundsCount; ++i) {
			for (int j = 0; j < playersCount; ++j) {
				if (cards[playersOrder[j] - 1][i] > topCard) {
					topCard = cards[playersOrder[j] - 1][i];
				} else {
					output.WriteLine(-1);
					return;
				}
			}
		}

		output.WriteLine(string.Join(' ', playersOrder));
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
