#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

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
	unsigned long long degreesSum = 0ull;
	bool isTree = true;
	for (int i = 0; i < verticesCount; ++i) {
		int degree;
		cin >> degree;
		if (!isTree) {
			continue;
		}
		if ((degree == 0 && verticesCount != 1) || degree >= verticesCount) {
			isTree = false;
		}
		else {
			degreesSum += degree;
		}
	}
	if (degreesSum != 2 * (unsigned long long)(verticesCount - 1)) {
		isTree = false;
	}
	cout << (isTree ? "YES\n" : "NO\n");
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
