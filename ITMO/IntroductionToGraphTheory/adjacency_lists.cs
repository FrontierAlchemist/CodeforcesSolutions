// https://codeforces.com/edu/course/2/lesson/8/4/practice/contest/290943/problem/C

using System;

public class Program
{
	static void SolveTestCase()
	{
		int verticesCount = int.Parse(Console.ReadLine());
		byte[,] adjacencyMatrix = new byte[verticesCount, verticesCount];
		for (int i = 0; i < verticesCount; ++i) {
			string[] valuesFromConsole = Console.ReadLine().Split(' ');
			for (int j = 0; j < verticesCount; ++j) {
				adjacencyMatrix[i, j] = byte.Parse(valuesFromConsole[j]);
			}
		}
		for (int i = 0; i < verticesCount; ++i) {
			for (int j = 0; j < verticesCount; ++j) {
				if (adjacencyMatrix[i, j] == 1) {
					Console.Write($"{j + 1} ");
				}
			}
			Console.WriteLine();
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
