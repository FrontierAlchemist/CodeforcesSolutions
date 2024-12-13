// https://codeforces.com/edu/course/2/lesson/8/4/practice/contest/290943/problem/B

using System;

public class Program
{
	static void SolveTestCase()
	{
		int verticesCount = int.Parse(Console.ReadLine());
		byte[,] adjacencyMatrix = new byte[verticesCount, verticesCount];
		for (int i = 0; i < verticesCount; ++i) {
			string[] valuesFromConsole = Console.ReadLine().Split();
			for (int j = 0; j < verticesCount; ++j) {
				adjacencyMatrix[i, j] = byte.Parse(valuesFromConsole[j]);
			}
		}

		int[] verticesDegrees = new int[verticesCount];
		for (int i = 0; i < verticesCount; ++i) {
			for (int j = 0; j < verticesCount; ++j) {
				if (i == j && adjacencyMatrix[i, j] != 0) {
					Console.WriteLine("NO");
					return;
				}
				if (adjacencyMatrix[i, j] > 1) {
					Console.WriteLine("NO");
					return;
				}
				if (adjacencyMatrix[i, j] != adjacencyMatrix[j, i]) {
					Console.WriteLine("NO");
					return;
				}
				verticesDegrees[i] += adjacencyMatrix[i, j];
			}
		}

		Console.WriteLine("YES");
		for (int i = 0; i < verticesCount; ++i) {
			Console.Write($"{verticesDegrees[i]} ");
		}
		Console.WriteLine();
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
