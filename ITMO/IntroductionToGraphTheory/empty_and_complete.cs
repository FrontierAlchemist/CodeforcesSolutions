// https://codeforces.com/edu/course/2/lesson/8/2/practice/contest/290940/problem/C

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split();
		int verticesCount = int.Parse(valuesFromConsole[0]);
		int edgesCount = int.Parse(valuesFromConsole[1]);
		int[] degrees = new int[verticesCount];
		for (int i = 0;i < edgesCount; ++i) {
			valuesFromConsole = Console.ReadLine().Split();
			int firstVertex = int.Parse(valuesFromConsole[0]);
			int secondVertex = int.Parse(valuesFromConsole[1]);
			++degrees[firstVertex - 1];
			++degrees[secondVertex - 1];
		}

		int[] uniqueDegrees = new int[verticesCount];
		for (int i = 0; i < uniqueDegrees.Length; ++i) {
			++uniqueDegrees[degrees[i]];
		}

		bool isCompleteGraphFound = false;
		for (int i = 1; i < verticesCount; ++i) {
			if (uniqueDegrees[i] == 0) {
				continue;
			}
			if (uniqueDegrees[i] == i + 1) {
				if (isCompleteGraphFound) {
					Console.WriteLine("NO");
					return;
				}
				isCompleteGraphFound = true;
			} else {
				Console.WriteLine("NO");
				return;
			}
		}
		if (!isCompleteGraphFound && uniqueDegrees[0] == 0) {
			Console.WriteLine("NO");
		} else {
			Console.WriteLine("YES");
		}
	}

	static void RunTests()
	{
		int testsCount = int.Parse(Console.ReadLine());
		for (int i = 0; i < testsCount; i++) {
			Console.ReadLine();
			SolveTestCase();
		}
	}

	static void Main()
	{
		RunTests();
	}
}
