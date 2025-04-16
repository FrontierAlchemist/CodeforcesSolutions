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
	int elementsCount;
	cin >> elementsCount;
	
	int positive = 0;
	int negative = 0;
	for (int i = 0; i < elementsCount; ++i) {
		int element;
		cin >> element;
		if (element > 0) {
			++positive;
		}
		else {
			++negative;
		}
	}

	int minimalOperationsCount = 0;
	if (positive < negative) {
		int difference = elementsCount / 2 - positive;
		if (elementsCount % 2 == 1) {
			++difference;
		}
		minimalOperationsCount = difference;
		positive += difference;
		negative -= difference;
	}
	if (negative % 2 == 1) {
		++minimalOperationsCount;
		++positive;
		--negative;
	}

	cout << minimalOperationsCount << endl;
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
