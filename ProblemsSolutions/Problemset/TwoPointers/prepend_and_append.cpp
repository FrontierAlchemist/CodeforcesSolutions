#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <string>

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
	int modifiedStringLength;
	cin >> modifiedStringLength;
	string modifiedString;
	cin >> modifiedString;
	int leftPointer = 0;
	int rightPointer = modifiedStringLength - 1;
	while (leftPointer < rightPointer) {
		if (modifiedString[leftPointer] != modifiedString[rightPointer]) {
			++leftPointer;
			--rightPointer;
		}
		else {
			break;
		}
	}
	int sourceStringLength = rightPointer - leftPointer + 1;
	cout << sourceStringLength << endl;
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
