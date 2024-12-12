// https://codeforces.com/edu/course/2/lesson/8/3/practice/contest/290941/problem/B

using System;

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split();
		int verticesCount = int.Parse(valuesFromConsole[0]);
		int edgesCount = int.Parse(valuesFromConsole[1]);

		int[] outDegrees = new int[verticesCount + 1];
		for (int i = 0; i < edgesCount; ++i) {
			valuesFromConsole = Console.ReadLine().Split();
			int outVertex = int.Parse(valuesFromConsole[0]);
			++outDegrees[outVertex];
		}

		int turnsCount = 0;
		for (int i = 1; i <= verticesCount; ++i) {
			if (outDegrees[i] == 0) {
				++turnsCount;
			} else if (outDegrees[i] > 1) {
				turnsCount += outDegrees[i] - 1;
			}
		}
		Console.WriteLine(turnsCount);
	}

	static void RunTests()
	{
		int testsCount = int.Parse(Console.ReadLine());
		for (int i = 0; i < testsCount; ++i) {
			Console.ReadLine();
			SolveTestCase();
		}
	}

	static void Main()
	{
		RunTests();
	}
}
