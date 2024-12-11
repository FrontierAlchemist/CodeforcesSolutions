// https://codeforces.com/edu/course/2/lesson/8/3/practice/contest/290941/problem/A

using System;

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split();
		int verticesCount = int.Parse(valuesFromConsole[0]);
		int edgesCount = int.Parse(valuesFromConsole[1]);
		int[] outDegrees = new int[verticesCount + 1];
		int[] inDegrees = new int[verticesCount + 1];
		for (int i = 0; i < edgesCount; ++i) {
			valuesFromConsole = Console.ReadLine().Split();
			int fromVertex = int.Parse(valuesFromConsole[0]);
			int toVertex = int.Parse(valuesFromConsole[1]);
			++outDegrees[fromVertex];
			++inDegrees[toVertex];
		}

		int sourcesCount = 0;
		int sinksCount = 0;
		for (int i = 1; i <= verticesCount; ++i) {
			if (outDegrees[i] == 0) {
				++sinksCount;
			}
			if (inDegrees[i] == 0) {
				++sourcesCount;
			}
		}
		Console.WriteLine($"{sourcesCount} {sinksCount}");
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
