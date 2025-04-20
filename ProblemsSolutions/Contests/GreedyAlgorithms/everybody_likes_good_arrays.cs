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

void SolveProblem() {
	int arraySize;
	cin >> arraySize;
	int currentElement;
	cin >> currentElement;
	int previousElement = currentElement;
	int pairsCount = 0;
	for (int i = 1; i < arraySize; ++i) {
		cin >> currentElement;
		if (previousElement % 2 == currentElement % 2) {
			++pairsCount;
		}
		previousElement = currentElement;
	}
	cout << pairsCount << endl;
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
