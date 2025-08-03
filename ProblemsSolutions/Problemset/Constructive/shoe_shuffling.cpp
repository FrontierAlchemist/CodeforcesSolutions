#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <vector>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1691/B problem.
/// </summary>
void SolveProblem() {
	int array_size;
	cin >> array_size;
	vector<int> source_array(array_size);
	for (int i = 0; i < array_size; ++i) {
		cin >> source_array[i];
	}

	bool is_requested_array_exist = true;
	vector<int> modified_array(array_size);
	int first_index_of_current_size = array_size - 1;
	int current_count = 1;
	for (int i = array_size - 2; i >= 0; --i) {
		if (source_array[i] == source_array[i + 1]) {
			++current_count;
		}
		else {
			if (current_count == 1) {
				is_requested_array_exist = false;
				break;
			}
			else {
				modified_array[i + 1] = first_index_of_current_size + 1;
				int subarray_size = first_index_of_current_size - i - 1;
				for (int j = 0; j < subarray_size; ++j) {
					modified_array[i + 2 + j] = i + 2 + j;
				}

				first_index_of_current_size = i;
				current_count = 1;
			}
		}
	}

	if (current_count == 1) {
		is_requested_array_exist = false;
	}
	else {
		modified_array[0] = first_index_of_current_size + 1;
		int subarray_size = first_index_of_current_size;
		for (int j = 0; j < subarray_size; ++j) {
			modified_array[1 + j] = 1 + j;
		}
	}

	if (is_requested_array_exist) {
		for (int i = 0; i < array_size; ++i) {
			cout << modified_array[i] << ' ';
		}
		cout << '\n';
	}
	else {
		cout << "-1\n";
	}
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
