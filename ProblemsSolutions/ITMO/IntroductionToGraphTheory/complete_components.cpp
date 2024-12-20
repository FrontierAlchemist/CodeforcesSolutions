// https://codeforces.com/edu/course/2/lesson/8/2/practice/contest/290940/problem/D?locale=en

#define _CRT_SECURE_NO_WARNINGS

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
	int verticesCount, edgesCount;
	cin >> verticesCount >> edgesCount;
	vector<int> degrees(verticesCount);
	for (int i = 0; i < edgesCount; ++i) {
		int firstVertex, secondVertex;
		cin >> firstVertex >> secondVertex;
		++degrees[firstVertex - 1];
		++degrees[secondVertex - 1];
	}

	vector<int> uniqueDegress(verticesCount);
	for (int i = 0; i < verticesCount; ++i) {
		++uniqueDegress[degrees[i]];
	}

	int componentsCount = 0;
	for (int i = 0; i < verticesCount; ++i) {
		componentsCount += uniqueDegress[i] / (i + 1);
	}
	cout << componentsCount << '\n';
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
