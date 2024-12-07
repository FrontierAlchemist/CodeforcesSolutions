// https://codeforces.com/edu/course/2/lesson/8/1/practice/contest/290939/problem/D

using System;

namespace Sandbox
{
	public class DSU
	{
		private readonly int[] parentsOfSets;
		private readonly int[] sizesOfSets;

		public DSU(int setsCount)
		{
			int listsSize = setsCount + 1;
			parentsOfSets = new int[listsSize];
			sizesOfSets = new int[listsSize];
			for (int i = 0; i < listsSize; i++) {
				parentsOfSets[i] = i;
				sizesOfSets[i] = 1;
			}
		}

		public int FindParent(int set)
		{
			if (parentsOfSets[set] == set) {
				return set;
			}
			return parentsOfSets[set] = FindParent(parentsOfSets[set]);
		}

		public void UnionSets(int firstSet, int secondSet)
		{
			int firstParent = FindParent(firstSet);
			int secondParent = FindParent(secondSet);
			if (firstParent != secondParent) {
				if (sizesOfSets[firstParent] >= sizesOfSets[secondParent]) {
					parentsOfSets[secondParent] = firstParent;
					sizesOfSets[firstParent] += sizesOfSets[secondParent];
				} else {
					parentsOfSets[firstParent] = secondParent;
					sizesOfSets[secondParent] += sizesOfSets[firstParent];
				}
			}
		}
	}

	public class Program
	{
		static void SolveProblem()
		{
			string lineFromConsole = ReadLineFromConsole();
			string[] valuesFromLine = lineFromConsole.Split();
			int verticesCount = int.Parse(valuesFromLine[0]);
			int edgesCount = int.Parse(valuesFromLine[1]);
			int sequenceLength = int.Parse(valuesFromLine[2]);

			int[] sequence = new int[sequenceLength];
			lineFromConsole = ReadLineFromConsole();
			valuesFromLine = lineFromConsole.Split();
			for (int i = 0; i < sequenceLength; ++i) {
				sequence[i] = int.Parse(valuesFromLine[i]);
			}

			DSU dsu = new(verticesCount);
			for (int i = 0; i < edgesCount; ++i) {
				lineFromConsole = ReadLineFromConsole();
				valuesFromLine = lineFromConsole.Split();
				int firsVertex = int.Parse(valuesFromLine[0]);
				int secondVertex = int.Parse(valuesFromLine[1]);
				dsu.UnionSets(firsVertex, secondVertex);
			}

			bool[] isSetHaveSequencesVertex = new bool[verticesCount + 1];
			bool[] isVertexInSequence = new bool[verticesCount + 1];
			for (int i = 0; i < sequenceLength; ++i) {
				int setNumber = dsu.FindParent(sequence[i]);
				isSetHaveSequencesVertex[setNumber] = true;
				isVertexInSequence[sequence[i]] = true;
			}

			for (int i = 1; i <= verticesCount; ++i) {
				if (!isVertexInSequence[i] && isSetHaveSequencesVertex[dsu.FindParent(i)]) {
					Console.WriteLine("NO");
					return;
				}
			}
			Console.WriteLine("YES");
		}

		static void RunTests()
		{
			string lineFromConsole = ReadLineFromConsole();
			int testsCount = int.Parse(lineFromConsole);
			for (int i = 0; i < testsCount; ++i) {
				SolveProblem();
			}
		}

		static string ReadLineFromConsole()
		{
			string lineFromConsole = Console.ReadLine() ?? string.Empty;
			while (lineFromConsole == string.Empty) {
				lineFromConsole = Console.ReadLine() ?? string.Empty;
			}
			return lineFromConsole.Trim();
		}

		static void Main()
		{
			RunTests();
		}
	}
}
