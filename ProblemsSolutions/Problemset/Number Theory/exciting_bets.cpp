#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1543/A problem.
/// </summary>
void SolveProblem() {
	long long a, b;
	cin >> a >> b;

	long long max_gcd = 0LL, min_moves = 0LL;
	if (a != b) {
		if (a < b) {
			swap(a, b);
		}

		max_gcd = a - b;

		long long previous_closest_remainder = b % max_gcd;
		long long next_closest_remainder = max_gcd - (b % max_gcd);
		min_moves = min(previous_closest_remainder, next_closest_remainder);
	}

	cout << max_gcd << ' ' << min_moves << '\n';
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
