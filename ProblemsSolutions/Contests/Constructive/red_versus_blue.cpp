#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1659/A problem.
/// </summary>
void SolveProblem() {
	int matches_count, red_wins, blue_wins;
	cin >> matches_count >> red_wins >> blue_wins;

	int red_segments = blue_wins + 1;
	int segment_length = red_wins / red_segments;
	int red_extra_wins = red_wins % red_segments;

	for (int i = 0; i < red_segments - 1; ++i) {
		for (int j = 0; j < segment_length; ++j) {
			cout << 'R';
		}
		if (red_extra_wins > 0) {
			cout << 'R';
			--red_extra_wins;
		}
		cout << 'B';
	}
	for (int j = 0; j < segment_length; ++j) {
		cout << 'R';
	}
	if (red_extra_wins > 0) {
		cout << 'R';
		--red_extra_wins;
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
