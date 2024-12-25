// https://codeforces.com/contest/2009/problem/D

#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <set>
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

unsigned long long CalculateTrianglesCount(const set<int>& searchedSet, set<int>& oppositeSet) {
	unsigned long long trianglesCount = 0;
	int index = 0;
	int dotsCount = searchedSet.size();
	for (int x : searchedSet) {
		if (oppositeSet.find(x) != oppositeSet.end()) {
			trianglesCount += dotsCount - 1 - index;
			trianglesCount += index;
		}
		if (searchedSet.find(x + 2) != searchedSet.end() && oppositeSet.find(x + 1) != oppositeSet.end()) {
			++trianglesCount;
		}
		++index;
	}
	return trianglesCount;
}

void SolveProblem() {
	int dotsCount;
	cin >> dotsCount;
	set<int> topSet;
	set<int> botSet;
	for (int i = 0; i < dotsCount; ++i) {
		int x, y;
		cin >> x >> y;
		if (y == 1) {
			topSet.insert(x);
		}
		else {
			botSet.insert(x);
		}
	}

	if (topSet.empty() || botSet.empty()) {
		cout << "0\n";
		return;
	}

	unsigned long long trianglesCount =
		CalculateTrianglesCount(topSet, botSet) + CalculateTrianglesCount(botSet, topSet);
	cout << trianglesCount << '\n';
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
