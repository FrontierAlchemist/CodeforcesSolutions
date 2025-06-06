#define _CRT_SECURE_NO_WARNINGS

#include <cmath>
#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1765/M problem.
/// </summary>
void SolveProblem() {
	int number;
	cin >> number;
	int limit = sqrt(number);
	
	int a = number - 1;
	int b = 1;
	for (int i = 2; i <= limit; ++i) {
		if (number % i == 0) {
			b = number / i;
			a = number - b;
			break;
		}
	}

	cout << a << ' ' << b << '\n';
}

void RedirectIOStreams() {
	auto fin = freopen("input.txt", "r", stdin);
	auto fout = freopen("output.txt", "w", stdout);
}

void SpeedUpIO() {
	ios::sync_with_stdio(false);
	cin.tie(0);
	cout.tie(0);
}

void RunTests() {
	int testsCount = 1;
	if (IS_SEVERAL_TESTS) {
		cin >> testsCount;
	}
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
