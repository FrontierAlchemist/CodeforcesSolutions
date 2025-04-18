#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

void RedirectIOStreams() {
	auto fin = freopen("input.txt", "r", stdin);
	auto fout = freopen("output.txt", "w", stdout);
}

void SpeedUpIO() {
	ios::sync_with_stdio(false);
	cin.tie(0);
	cout.tie(0);
}

struct Point {
	int x;
	int y;

	friend istream& operator>>(istream& in, Point& point) {
		in >> point.x >> point.y;
		return in;
	}
};

void SolveProblem() {
	Point start, end;
	cin >> start >> end;

	int minimalMovesCount = 0;
	if (end.y < start.y) {
		minimalMovesCount = -1;
	}
	else {
		int height = end.y - start.y;
		if (end.x >= start.x) {
			int distance = end.x - start.x;
			minimalMovesCount = distance <= height ? height - distance + height : -1;
		}
		else {
			int distance = start.x - end.x;
			minimalMovesCount = distance + height + height;
		}
	}
	cout << minimalMovesCount << endl;
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
