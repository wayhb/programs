#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
using namespace std; 

void permutations(int& k, string s,int n, vector<string>& vector);

int main()
{
	cout << "Enter number of symbols: ";
	int number;
	cin >> number;

	string s;
	cout << "Enter a string: ";
	cin >> s;
	vector <string> vectorWithStrings;
	int k = 0;
	permutations(k, s, number, vectorWithStrings);
	for (string i : vectorWithStrings)
		std::cout << i << " ";
	cout << "\nNumber of permutations: " << vectorWithStrings.size()<< ", number of operations: " << k;
}
void permutations(int& k, string s, int n, vector<string>& vector)
{
	for (int i = 0; i < n-1 ; i++)
	{
		k++;
		swap(s[i], s[i+1]);
		sort(vector.begin(), vector.end());
		if (std::binary_search(vector.begin(), vector.end(), s) == false)
		{
			vector.push_back(s);
			permutations(k, s, n, vector);
		}	
	}
}