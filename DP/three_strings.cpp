// https://codeforces.com/contest/2050/problem/E

#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

void RedirectIOStreams() {
	auto fin = freopen("input.txt", "r", stdin);
	auto fout = freopen("output.txt", "w", stdout);
}

void SpeedUpIO() {
	ios::sync_with_stdio(false);
	cin.tie(0);
	cout.tie(0);
}

void SolveProblem() {
	string a, b, c;
	cin >> a >> b >> c;

	int al = a.size();
	int bl = b.size();
	int cl = c.size();

	vector<vector<int>> dp(al + 1, vector<int>(bl + 1, INT_MAX));
	dp[0][0] = 0;
	for (int i = 0; i < al; ++i) {
		dp[i + 1][0] = dp[i][0] + (a[i] != c[i]);
	}
	for (int j = 0; j < bl; ++j) {
		dp[0][j + 1] = dp[0][j] + (b[j] != c[j]);
	}
	for (int i = 1; i <= al; ++i) {
		for (int j = 1; j <= bl; ++j) {
			dp[i][j] = min(
				dp[i - 1][j] + (a[i - 1] != c[i + j - 1]),
				dp[i][j - 1] + (b[j - 1] != c[i + j - 1])
			);
		}
	}
	cout << dp[al][bl] << "\n";
}

void RunTests() {
	int testsCount;
	cin >> testsCount;
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
