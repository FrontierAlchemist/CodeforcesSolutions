// https://codeforces.com/contest/2009/problem/D

#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <iostream>
#include <vector>

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
	int dotsCount;
	cin >> dotsCount;
	vector<int> topDots;
	vector<int> botDots;
	int topDotsCount = 0;
	int botDotsCount = 0;
	for (int i = 0; i < dotsCount; ++i) {
		int x, y;
		cin >> x >> y;
		if (y == 1) {
			topDots.push_back(x);
			topDotsCount++;
		}
		else {
			botDots.push_back(x);
			botDotsCount++;
		}
	}

	if (topDotsCount == 0 || botDotsCount == 0) {
		cout << "0\n";
		return;
	}

	sort(topDots.begin(), topDots.end());
	sort(botDots.begin(), botDots.end());

	unsigned long long pairsCount = 0;
	int topIndex = 0;
	int botIndex = 0;
	while (topIndex < topDotsCount - 1 && botIndex < botDotsCount) {
		int a = topDots[topIndex];
		int b = topDots[topIndex + 1];
		int c = botDots[botIndex];
		if (c < a) {
			if (++botIndex == botDotsCount) {
				break;
			}
		}
		else if (c > b) {
			if (++topIndex == topDotsCount - 1) {
				break;
			}
		}
		else if (c == a) {
			pairsCount += topDotsCount - 1 - topIndex;
			if (topIndex < topDotsCount - 2) {
				int d = topDots[topIndex + 2];
				if (d - a == 2 && c - a == 1) {
					++pairsCount;
				}
			}
			if (++botIndex == botDotsCount) {
				break;
			}
		}
		else if (c == b) {
			pairsCount += topIndex + 1;
			if (topIndex < topDotsCount - 2) {
				int d = topDots[topIndex + 2];
				if (d - a == 2 && c - a == 1) {
					++pairsCount;
				}
			}
			if (++topIndex == topDotsCount - 1) {
				break;
			}
		}
		else if (b - a == 2 && c - a == 1) {
			++pairsCount;
			if (++botIndex == botDotsCount) {
				break;
			}
		}
		else {
			if (++botIndex == botDotsCount) {
				break;
			}
		}
	}

	topIndex = 0;
	botIndex = 0;
	while (topIndex < topDotsCount && botIndex < botDotsCount - 1) {
		int a = botDots[botIndex];
		int b = botDots[botIndex + 1];
		int c = topDots[topIndex];
		if (c < a) {
			if (++topIndex == topDotsCount) {
				break;
			}
		}
		else if (c > b) {
			if (++botIndex == botDotsCount - 1) {
				break;
			}
		}
		else if (c == a) {
			pairsCount += botDotsCount - 1 - botIndex;
			if (botIndex < botDotsCount - 2) {
				int d = botDots[botIndex + 2];
				if (d - a == 2 && c - a == 1) {
					++pairsCount;
				}
			}
			if (++topIndex == topDotsCount) {
				break;
			}
		}
		else if (c == b) {
			pairsCount += botIndex + 1;
			if (botIndex < botDotsCount - 2) {
				int d = botDots[botIndex + 2];
				if (d - a == 2 && c - a == 1) {
					++pairsCount;
				}
			}
			if (++botIndex == botDotsCount - 1) {
				break;
			}
		}
		else if (b - a == 2 && c - a == 1) {
			++pairsCount;
			if (++topIndex == topDotsCount) {
				break;
			}
		}
		else {
			if (++topIndex == topDotsCount) {
				break;
			}
		}
	}

	cout << pairsCount << '\n';
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
