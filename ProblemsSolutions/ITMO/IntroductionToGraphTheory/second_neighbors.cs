// https://codeforces.com/edu/course/2/lesson/8/3/practice/contest/290941/problem/D?locale=ru

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split(' ');
		int verticesCount = int.Parse(valuesFromConsole[0]);
		int edgesCount = int.Parse(valuesFromConsole[1]);
		SortedSet<int>[] adjacencyLists = new SortedSet<int>[verticesCount + 1];
		for (int i = 1; i <= verticesCount; ++i) {
			adjacencyLists[i] = new SortedSet<int>();
		}
		for (int i = 0; i < edgesCount; ++i) {
			valuesFromConsole = Console.ReadLine().Split(' ');
			int outVertex = int.Parse(valuesFromConsole[0]);
			int inVertex = int.Parse(valuesFromConsole[1]);
			adjacencyLists[outVertex].Add(inVertex);
		}

		for (int i = 1; i <= verticesCount; ++i) {
			SortedSet<int> secondNeighbors = new SortedSet<int>();
			foreach (int firstNeighbor in adjacencyLists[i]) {
				foreach (int secondNeighbor in adjacencyLists[firstNeighbor]) {
					secondNeighbors.Add(secondNeighbor);
				}
			}
			foreach (int vertex in secondNeighbors) {
				Console.Write($"{vertex} ");
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
