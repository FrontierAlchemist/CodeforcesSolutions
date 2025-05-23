#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1374/B problem.
/// </summary>
void SolveProblem() {
	int number;
	cin >> number;

	int twosCount = 0;
	while (number % 2 == 0) {
		number /= 2;
		++twosCount;
	}
	int threesCount = 0;
	while (number % 3 == 0) {
		number /= 3;
		++threesCount;
	}

	bool isAnswerExist = number == 1 && twosCount <= threesCount;
	int stepsCount = isAnswerExist ? threesCount - twosCount + threesCount : - 1;
	cout << stepsCount << '\n';
}

void RedirectIOStreams() {
	auto fin = freopen("input.txt", "r", stdin);
	auto fout = freopen("output.txt", "w", stdout);
}

void SpeedUpIO() {
	ios::sync_with_stdio(false);
	cin.tie(0);
	cout.tie(0);
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
