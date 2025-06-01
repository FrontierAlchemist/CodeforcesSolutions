#define _CRT_SECURE_NO_WARNINGS

#include <cmath>
#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1582/B problem.
/// </summary>
void SolveProblem() {
	int array_size;
	cin >> array_size;
	
	long long ones_count = 0L;
	long long zeroes_count = 0L;
	for (int i = 0; i < array_size; ++i) {
		int number;
		cin >> number;

		if (number == 0) {
			++zeroes_count;
		}
		else if (number == 1) {
			++ones_count;
		}
	}

	long long requested_subsequences_count = ones_count * pow(2LL, zeroes_count);
	cout << requested_subsequences_count << '\n';
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
