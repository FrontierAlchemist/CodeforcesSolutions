#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1537/B problem.
/// </summary>
void SolveProblem() {
	int rows_count, columns_count, source_x, source_y;
	cin >> rows_count >> columns_count >> source_x >> source_y;

	int target1_x, target1_y, target2_x, target2_y;
	if (source_x <= rows_count / 2) {
		if (source_y <= columns_count / 2) {
			target1_x = 1;
			target1_y = columns_count;

			target2_x = rows_count;
			target2_y = 1;
		}
		else {
			target1_x = 1;
			target1_y = 1;

			target2_x = rows_count;
			target2_y = columns_count;
		}
	}
	else {
		if (source_y <= columns_count / 2) {
			target1_x = 1;
			target1_y = 1;

			target2_x = rows_count;
			target2_y = columns_count;
		}
		else {
			target1_x = 1;
			target1_y = columns_count;

			target2_x = rows_count;
			target2_y = 1;
		}
	}

	cout << target1_x << ' ' << target1_y << ' ' << target2_x << ' ' << target2_y << '\n';
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
