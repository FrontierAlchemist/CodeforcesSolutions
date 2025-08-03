#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <vector>

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
	int modifiedArraySize;
	cin >> modifiedArraySize;
	vector<int> modifiedArray(modifiedArraySize);
	for (int i = 0; i < modifiedArraySize; ++i) {
		cin >> modifiedArray[i];
	}

	vector<int> sourceArray;
	sourceArray.push_back(modifiedArray[0]);
	for (int i = 1; i < modifiedArraySize; ++i) {
		if (modifiedArray[i - 1] > modifiedArray[i]) {
			sourceArray.push_back(modifiedArray[i] > 1 ? modifiedArray[i] - 1 : 1);
		}
		sourceArray.push_back(modifiedArray[i]);
	}

	int sourceArraySize = sourceArray.size();
	cout << sourceArraySize << endl;
	for (int i = 0; i < sourceArraySize - 1; ++i) {
		cout << sourceArray[i] << ' ';
	}
	cout << sourceArray[sourceArraySize - 1] << endl;
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
