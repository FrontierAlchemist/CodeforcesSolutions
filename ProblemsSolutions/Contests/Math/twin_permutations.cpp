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
	int permutationSize;
	cin >> permutationSize;
	vector<int> sourcePermutation(permutationSize);
	for (int i = 0; i < permutationSize; ++i) {
		cin >> sourcePermutation[i];
	}
	
	int permutationLimit = permutationSize + 1;
	for (int i = 0; i < permutationSize - 1; ++i) {
		cout << permutationLimit - sourcePermutation[i] << ' ';
	}
	cout << permutationLimit - sourcePermutation[permutationSize - 1] << endl;
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
