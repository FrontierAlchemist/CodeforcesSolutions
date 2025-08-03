#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1899/C problem.
/// </summary>
void SolveProblem() {
	int array_size;
	cin >> array_size;
	vector<int> array(array_size);
	for (int i = 0; i < array_size; ++i) {
		cin >> array[i];
	}

	int current_sum = array[0];
	int max_subarray_sum = current_sum;
	int local_minimal_sum = min(current_sum, 0);

	for (int i = 1; i < array_size; ++i) {
		if (abs(array[i - 1]) % 2 == abs(array[i] % 2)) {
			current_sum = array[i];
			max_subarray_sum = max(max_subarray_sum, current_sum);
			local_minimal_sum = min(current_sum, 0);
		}
		else {
			current_sum += array[i];
			max_subarray_sum = max(max_subarray_sum, current_sum - local_minimal_sum);
			local_minimal_sum = min(local_minimal_sum, current_sum);
		}
	}

	cout << max_subarray_sum << '\n';
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
