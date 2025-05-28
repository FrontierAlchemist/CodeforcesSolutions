#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <string>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1606/A problem.
/// </summary>
void SolveProblem() {
	string str;
	cin >> str;
	int ab_count = 0;
	int ba_count = 0;
	for (int i = 1; i < str.length(); ++i) {
		if (str[i] == 'b' && str[i - 1] == 'a') {
			++ab_count;
		}
		else if (str[i] == 'a' && str[i - 1] == 'b') {
			++ba_count;
		}
	}

	if (ab_count == ba_count) {
		cout << str << '\n';
	}
	else {
		for (int i = 0; i < str.length() - 1; ++i) {
			cout << str[i];
		}
		cout << (str[str.length() - 1] == 'a' ? 'b' : 'a') << '\n';
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
