// https://codeforces.com/contest/2042/problem/A

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
	int chestsCount, tribute;
	cin >> chestsCount >> tribute;
	vi chests(chestsCount);
	READV(chests);
	sort(chests.begin(), chests.end(), greater<int>());
	long sum = 0;
	for (int i = 0; i < chestsCount; ++i) {
		if (sum + chests[i] <= tribute) {
			sum += chests[i];
		}
		else {
			break;
		}
	}
	cout << tribute - sum << '\n';
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
