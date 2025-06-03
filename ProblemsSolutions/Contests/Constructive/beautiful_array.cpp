#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

const bool IS_SEVERAL_TESTS = true;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1715/B problem.
/// </summary>
void SolveProblem() {
	long long array_size, divisor, array_beauty, array_sum;
	cin >> array_size >> divisor >> array_beauty >> array_sum;

	long long min_sum = array_beauty * divisor;
	long long max_sum = min_sum + array_size * (divisor - 1);
	if (min_sum > array_sum || max_sum < array_sum) {
		cout << "-1";
	}
	else {
		long long remain_sum = array_sum - min_sum;
		long long minor_element = divisor - 1LL;
		for (int i = 0; i < array_size - 1; ++i) {
			if (remain_sum >= minor_element) {
				cout << minor_element << ' ';
				remain_sum -= minor_element;
			}
			else if (remain_sum > 0LL) {
				cout << remain_sum << ' ';
				remain_sum = 0LL;
			}
			else {
				cout << 0 << ' ';
			}
		}
		cout << min_sum + remain_sum;
	}
	cout << '\n';
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
