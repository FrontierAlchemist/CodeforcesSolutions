// https://codeforces.com/edu/course/2/lesson/8/1/practice/contest/290939/problem/C

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

void SolveProblem() {
	int verticesCount, edgesCount, sequenceLength;
	cin >> verticesCount >> edgesCount >> sequenceLength;
	vector<int> sequence(sequenceLength);
	for (int i = 0; i < sequenceLength; ++i) {
		cin >> sequence[i];
		--sequence[i];
	}
	vector<set<int>> adjacencyMatrix(verticesCount);
	for (int i = 0; i < edgesCount; ++i) {
		int firstVertex, secondVertex;
		cin >> firstVertex >> secondVertex;
		adjacencyMatrix[firstVertex - 1].insert(secondVertex - 1);
		adjacencyMatrix[secondVertex - 1].insert(firstVertex - 1);
	}

	int from = sequence[0];
	int to = -1;
	vector<short> isVisited(verticesCount);
	isVisited[from] = 1;
	bool isSimple = true;
	for (int i = 1; i < sequenceLength; ++i) {
		to = sequence[i];
		if (adjacencyMatrix[from].find(to) == adjacencyMatrix[from].end()) {
			cout << "none\n";
			return;
		}
		if (isVisited[to] == 1) {
			if (!(i == sequenceLength - 1 && sequence[0] == sequence[i])) {
				isSimple = false;
			}
		}
		isVisited[to] = 1;
		from = to;
	}
	if (isSimple) {
		cout << "simple ";
	}
	if (sequence[0] == sequence[sequenceLength - 1]) {
		cout << "cycle\n";
	}
	else {
		cout << "path\n";
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
