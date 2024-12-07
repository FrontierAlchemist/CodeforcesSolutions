// https://codeforces.com/edu/course/2/lesson/8/1/practice/contest/290939/problem/A

#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <map>
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
	vector<map<int, int>> adjacencyMatrix(verticesCount + 1, map<int, int>());
	for (int i = 0; i < edgesCount; ++i) {
		int firstVertex, secondVertex;
		cin >> firstVertex >> secondVertex;
		if (firstVertex > secondVertex) {
			swap(firstVertex, secondVertex);
		}
		if (adjacencyMatrix[firstVertex].find(secondVertex) == adjacencyMatrix[firstVertex].end()) {
			adjacencyMatrix[firstVertex][secondVertex] = 0;
		}
		++adjacencyMatrix[firstVertex][secondVertex];
	}

	bool isCorrectEdgesSet = true;
	for (int i = 1; i <= verticesCount; ++i) {
		for (auto it = adjacencyMatrix[i].begin(); it != adjacencyMatrix[i].end(); ++it) {
			if (it->first == i || it->second > 1) {
				isCorrectEdgesSet = false;
				break;
			}
		}
		if (!isCorrectEdgesSet) {
			break;
		}
	}
	cout << (isCorrectEdgesSet ? "YES\n" : "NO\n");
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
