// https://codeforces.com/contest/2042/problem/B

#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <cmath>
#include <iostream>
#include <iomanip>
#include <map>
#include <queue>
#include <set>
#include <stack>
#include <string>
#include <utility>
#include <vector>

using namespace std;

#define READV(v) for (int i = 0; i < v.size(); ++i) { cin >> v[i]; }
#define WRITEV(v) for (int i = 0; i < v.size(); ++i) { cout << v[i] << ' '; } cout << '\n';

typedef unsigned long long ull;
typedef long long ll;
typedef vector<int> vi;
typedef pair<int, int> pii;

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
	int marblesCount;
	cin >> marblesCount;
	vi colors(marblesCount + 1);
	for (int i = 0; i < marblesCount; ++i) {
		int color;
		cin >> color;
		++colors[color];
	}

	int diiferentColors = 0;
	int uniqueColors = 0;
	for (int i = 1; i <= marblesCount; ++i) {
		if (colors[i] == 1) {
			++uniqueColors;
		}
		if (colors[i] >= 1) {
			++diiferentColors;
		}
	}
	long points = 2 * (uniqueColors / 2 + uniqueColors % 2) + (diiferentColors - uniqueColors);
	cout << points << '\n';
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
