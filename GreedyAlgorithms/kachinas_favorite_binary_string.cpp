#include <iostream>
#include <vector>

using namespace std;

void Solve() {
	int lengthSize = 0;
	cin >> lengthSize;

	vector<char> answer(lengthSize, '0');

	cout << '?' << ' ' << 1 << ' ' << lengthSize << '\n' << flush;
	int pairsCount = 0;
	cin >> pairsCount;

	if (pairsCount == 0) {
		cout << "! IMPOSSIBLE\n" << flush;
		return;
	}

	for (int i = 1; i < lengthSize - 1; ++i) {
		cout << '?' << ' ' << i + 1 << ' ' << lengthSize << '\n' << flush;
		int response = 0;
		cin >> response;

		if (response == 0) {
			for (int j = 0; j < pairsCount; ++j) {
				answer[i + j] = '1';
			}
			pairsCount = response;
			break;
		}
		if (response == pairsCount) {
			answer[i - 1] = '1';
		}
		pairsCount = response;
	}
	if (pairsCount == 1) {
		answer[lengthSize - 1] = '1';
	}

	cout << '!' << ' ';
	for (int i = 0; i < lengthSize; ++i) {
		cout << answer[i];
	}
	cout << '\n' << flush;
}

void RunTests() {
	int testsCount;
	cin >> testsCount;
	for (int i = 0; i < testsCount; ++i) {
		Solve();
	}
}

int main() {
	RunTests();

	return 0;
}
