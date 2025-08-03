#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1832/B problem.
/// </summary>
void SolveProblem() {
	int array_size, operations_count;
	cin >> array_size >> operations_count;

	vector<int> array(array_size);
	for (int i = 0; i < array_size; ++i) {
		cin >> array[i];
	}

	sort(array.begin(), array.end());

	int max_removed_elements = operations_count * 2;
	long long current_sum = 0LL;
	for (int i = array_size - 1; i >= max_removed_elements; --i) {
		current_sum += array[i];
	}

	long long max_sum = current_sum;
	int largest_element_index = array_size - 1;
	for (int i = max_removed_elements - 1; i > 0; i -= 2) {
		current_sum -= array[largest_element_index--];
		current_sum += array[i - 1] + array[i];
		max_sum = max(max_sum, current_sum);
	}

	cout << max_sum << '\n';
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
