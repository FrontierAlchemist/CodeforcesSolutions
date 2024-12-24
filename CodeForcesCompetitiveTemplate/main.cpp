#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <cmath>
#include <iostream>
#include <iomanip>
#include <map>
#include <queue>
#include <deque>
#include <set>
#include <stack>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <utility>
#include <vector>

using namespace std;

#define READV(v) for (int i = 0; i < v.size(); ++i) { cin >> v[i]; }
#define WRITEV(v) for (int i = 0; i < v.size(); ++i) { cout << v[i] << ' '; } cout << '\n';
#define READVP(v) for (int i = 0; i < v.size(); ++i) { cin >> v[i].first >> v[i].second; }
#define FOR(i, n) for (i = 0; i < n; ++i)
#define FORD(i, n) for (i = n; i >= 0; --i)
#define FORIN(i, s, e) for (i = s; i <= e; ++i)
#define FORIND(i, s, e) for (i = e; i >= s; --i)

typedef unsigned long long ull;
typedef long long ll;
typedef vector<int> vi;
typedef pair<int, int> pii;
typedef vector<long> vl;
typedef vector<double> vd;
typedef vector<string> vs;

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
