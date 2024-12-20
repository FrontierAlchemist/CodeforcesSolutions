// https://codeforces.com/edu/course/2/lesson/8/4/practice/contest/290943/problem/A

using System;

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split();
		int verticesCount = int.Parse(valuesFromConsole[0]);
		int edgesCount = int.Parse(valuesFromConsole[1]);
		byte[,] adjacencyMatrix = new byte[verticesCount, verticesCount];
		for (int i = 0; i < edgesCount; ++i) {
			valuesFromConsole = Console.ReadLine().Split();
			int firstVertex = int.Parse(valuesFromConsole[0]);
			int secondVertex = int.Parse(valuesFromConsole[1]);
			adjacencyMatrix[firstVertex - 1, secondVertex - 1] = 1;
			adjacencyMatrix[secondVertex - 1, firstVertex - 1] = 1;
		}

		for (int i = 0; i < verticesCount; ++i) {
			for (int j = 0; j < verticesCount; ++j) {
				Console.Write($"{adjacencyMatrix[i, j]} ");
			}
			Console.WriteLine();
		}
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
