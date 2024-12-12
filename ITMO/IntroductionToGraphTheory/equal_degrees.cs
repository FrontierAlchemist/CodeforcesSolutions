// https://codeforces.com/edu/course/2/lesson/8/3/practice/contest/290941/problem/C

using System;

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split();
		int degreeOut = int.Parse(valuesFromConsole[0]);
		int degreeIn = int.Parse(valuesFromConsole[1]);

		if (degreeOut != degreeIn) {
			Console.WriteLine("NO");
			return;
		}
		Console.WriteLine("YES");

		int verticesCount = degreeIn;
		int edgesCount = degreeIn * degreeIn;
		Console.WriteLine($"{verticesCount} {edgesCount}");
		for (int i = 1; i <= verticesCount; ++i) {
			for (int j = 1; j <= verticesCount; ++j) {
				Console.WriteLine($"{i} {j}");
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
