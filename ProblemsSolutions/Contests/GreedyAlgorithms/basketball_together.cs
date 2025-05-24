#define _CRT_SECURE_NO_WARNINGS

#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

const bool IS_SEVERAL_TESTS = false;

/// <summary>
/// Solve https://codeforces.com/problemset/problem/1725/B problem.
/// </summary>
void SolveProblem() {
	int players_count, enemy_team_power;
	cin >> players_count >> enemy_team_power;
	vector<int> players_power(players_count);
	for (int i = 0; i < players_count; ++i) {
		cin >> players_power[i];
	}

	sort(players_power.begin(), players_power.end());

	int wons_count = 0;
	int free_players_left = players_count;
	for (int i = players_count - 1; i >= 0; --i) {
		int power_to_get = enemy_team_power - players_power[i] + 1;
		if (power_to_get > 0) {
			int players_need = power_to_get / players_power[i] + (power_to_get % players_power[i] > 0);
			if (players_need > free_players_left - 1) {
				break;
			}
			else {
				free_players_left -= players_need + 1;
				++wons_count;
			}
		}
		else {
			--free_players_left;
			++wons_count;
		}
		if (free_players_left == 0) {
			break;
		}
	}

	cout << wons_count << '\n';
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
