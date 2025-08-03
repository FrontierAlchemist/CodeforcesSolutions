#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <vector>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1891/B problem.
/// </summary>
void SolveProblem() {
	int source_array_size, modification_array_size;
	cin >> source_array_size >> modification_array_size;

	vector<long> source_array(source_array_size);
	for (int i = 0; i < source_array_size; ++i) {
		cin >> source_array[i];
	}

	int modificator;
	cin >> modificator;
	vector<int> modification_array { modificator };
	for (int j = 1; j < modification_array_size; ++j) {
		cin >> modificator;
		if (modificator < modification_array.back()) {
			modification_array.push_back(modificator);
		}
	}
	modification_array_size = modification_array.size();

	vector<int> powers_of_two(31);
	powers_of_two[0] = 1;
	for (int k = 1; k <= 30; ++k) {
		powers_of_two[k] = powers_of_two[k - 1] << 1;
	}

	vector<long> added_sums(modification_array_size);
	added_sums[modification_array_size - 1] = powers_of_two[modification_array[modification_array_size - 1] - 1];
	for (int j = modification_array.size() - 2; j >= 0; --j) {
		added_sums[j] += powers_of_two[modification_array[j] - 1] + added_sums[j + 1];
	}

	for (int i = 0; i < source_array_size; ++i) {
		for (int j = 0; j < modification_array_size; ++j) {
			if (source_array[i] % powers_of_two[modification_array[j]] == 0) {
				source_array[i] += added_sums[j];
				break;
			}
		}

		cout << source_array[i] << ' ';
	}

	cout << '\n';
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
