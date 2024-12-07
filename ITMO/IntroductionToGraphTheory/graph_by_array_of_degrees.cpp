// https://codeforces.com/edu/course/2/lesson/8/1/practice/contest/290939/problem/F

#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <iostream>
#include <utility>
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
	int verticesCount;
	cin >> verticesCount;
	int degreesSum = 0;
	vector<pair<int, int>> verticesDegrees(verticesCount);
	for (int i = 0; i < verticesCount; ++i) {
		cin >> verticesDegrees[i].first;
		degreesSum += verticesDegrees[i].first;
		verticesDegrees[i].second = i + 1;
	}

	sort(verticesDegrees.begin(), verticesDegrees.end(), greater<pair<int, int>>());

	int edgesCount = degreesSum / 2;
	int nextEdgeIndex = 0;
	vector<pair<int, int>> edges(edgesCount);
	for (int i = 0; i < verticesCount; ++i) {
		if (verticesDegrees[0].first == 0) {
			break;
		}
		for (int j = 1; j < verticesCount; ++j) {
			if (verticesDegrees[j].first == 0) {
				continue;
			}
			edges[nextEdgeIndex++] = { verticesDegrees[0].second, verticesDegrees[j].second };
			--verticesDegrees[0].first;
			--verticesDegrees[j].first;
			if (verticesDegrees[0].first == 0) {
				break;
			}
		}
		sort(verticesDegrees.begin(), verticesDegrees.end(), greater<pair<int, int>>());
	}

	cout << edgesCount << "\n";
	for (int i = 0; i < edgesCount; ++i) {
		cout << edges[i].first << ' ' << edges[i].second << '\n';
	}
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
