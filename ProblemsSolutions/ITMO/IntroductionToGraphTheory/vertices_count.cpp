// https://codeforces.com/edu/course/2/lesson/8/2/practice/contest/290940/problem/A

#define _CRT_SECURE_NO_WARNINGS

#include <cmath>
#include <iostream>

using namespace std;

void RedirectIOStreams() {
	auto fin = freopen("input.txt", "r", stdin);
	auto fout = freopen("output.txt", "w", stdout);
}

void SpeedUpIO() {
	ios::sync_with_stdio(false);
	cin.tie(0);
	cout.tie(0);
}

void SolveProblem() {
	long long edgesCount;
	cin >> edgesCount;

	// Maximum of edges count in graph with n vertices is m = n(n - 1) / 2;
	// So we need find positive root of quadratic equation n**2 - n - 2m = 0 with extra conditions:
	// 1. Square root of discriminat should be integer number;
	// 2. n should be integer number;
	long long discriminant = 1 + 8 * edgesCount;
	long long rootOfDiscriminant = ceil(sqrt(discriminant));
	long long numerator = 1 + rootOfDiscriminant + (1 - rootOfDiscriminant % 2);
	long long verticesCount = numerator / 2;
	
	cout << verticesCount << '\n';
}

void RunTests() {
	int testsCount;
	cin >> testsCount;
	for (int t = 0; t < testsCount; ++t) {
		SolveProblem();
	}
}

int main() {
#if _DEBUG
	RedirectIOStreams();
#endif

	SpeedUpIO();
	RunTests();

	return 0;
}
