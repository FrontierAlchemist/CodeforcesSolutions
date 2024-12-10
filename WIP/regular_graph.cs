// https://codeforces.com/edu/course/2/lesson/8/2/practice/contest/290940/problem/B

public class Program
{
	static void SolveTestCase()
	{
		string[] valuesFromConsole = Console.ReadLine().Split();
		int verticesCount = int.Parse(valuesFromConsole[0]);
		int regularDegree = int.Parse(valuesFromConsole[1]);
		
		int doubleEdgesCount = verticesCount * regularDegree;
		if (doubleEdgesCount % 2 != 0 || verticesCount < regularDegree) {
			Console.WriteLine("NO");
			return;
		}

		int edgesCount = doubleEdgesCount / 2;
		Console.WriteLine("YES");
		Console.WriteLine(edgesCount);

		int cycle = edgesCount / verticesCount;
		for (int i = 1; i <= cycle; ++i) {
			for (int j = 1; j <= verticesCount; ++j) {
				int to = j + i;
				if (to > verticesCount) {
					to %= verticesCount;
				}
				Console.WriteLine($"{j} {to}");
			}
		}
		int remainder = edgesCount % verticesCount;
		for (int i = 1; i <= remainder; ++i) {
			Console.WriteLine($"{i} {i + remainder}");
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
