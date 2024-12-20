// https://codeforces.com/edu/course/2/lesson/8/2/practice/contest/290940/problem/B

using System;

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split();
		int verticesCount = int.Parse(valuesFromConsole[0]);
		int regularDegree = int.Parse(valuesFromConsole[1]);

		int doubleEdgesCount = verticesCount * regularDegree;
		if (doubleEdgesCount % 2 != 0 || verticesCount <= regularDegree) {
			Console.WriteLine("NO");
			return;
		}

		int edgesCount = doubleEdgesCount / 2;
		Console.WriteLine("YES");
		Console.WriteLine(edgesCount);

		int neighborsCount = regularDegree / 2;
		for (int i = 1; i <= verticesCount; ++i) {
			for (int j = 1; j <= neighborsCount; ++j) {
				int to = i + j;
				if (to > verticesCount) {
					to %= verticesCount;
				}
				Console.WriteLine($"{i} {to}");
			}
		}

		if (regularDegree % 2 == 1) {
			int halfOfVerticesCount = verticesCount / 2;
			for (int i = 1; i <= halfOfVerticesCount; ++i) {
				Console.WriteLine($"{i} {i + halfOfVerticesCount}");
			}
		}
	}

	static void RunTests()
	{
		int testsCount = int.Parse(Console.ReadLine());
		for (int i = 0; i < testsCount; ++i) {
			SolveTestCase();
		}
	}

	static void Main()
	{
		RunTests();
	}
}
