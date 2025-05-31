#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1794/B problem.
/// </summary>
void SolveProblem() {
	int array_size;
	cin >> array_size;

	int* array = new int[array_size];
	for (int i = 0; i < array_size; ++i) {
		cin >> array[i];
		if (array[i] == 1) {
			++array[i];
		}
	}

	for (int i = 0; i < array_size - 1; ++i) {
		if (array[i + 1] % array[i] == 0) {
			++array[i + 1];
		}
		cout << array[i] << ' ';
	}
	cout << array[array_size - 1] << '\n';

	delete[] array;
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
