#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1418/A problem.
/// </summary>
void SolveProblem() {
	long long stick_to_stick, stick_to_coal, torch_requsted;
	cin >> stick_to_stick >> stick_to_coal >> torch_requsted;

	long long all_sticks_needed = stick_to_coal * torch_requsted + torch_requsted - 1LL;
	long long getting_sticks_per_exchange = stick_to_stick - 1LL;
	long long minimal_moves = all_sticks_needed / getting_sticks_per_exchange;
	if (all_sticks_needed % getting_sticks_per_exchange > 0) {
		++minimal_moves;
	}
	minimal_moves += torch_requsted;

	cout << minimal_moves << '\n';
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
