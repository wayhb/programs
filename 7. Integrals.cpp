#include <iostream>
#include <map>
using namespace std;
void polynomial();
void cosPol();
void arctg();
int main()
{
	cout << "Enter the command: ";
	int command;
	cin >> command;
	switch (command)
	{
	case 1:
		polynomial();
		break;
	case 2:
		cosPol();
		break;
	case 3:
		arctg();
		break;
	default:
		cout << "I don't have this command!";
		break;
	}

}

void polynomial()
{
	cout << "You chose the first command - polynomial. Enter a degree: ";
	int degree;
	cin >> degree;
	cout << "I(";
	for (int i = degree, c = 'a'; i >= 0; i--, c++)
	{
		if (i == 1)
			cout << char(c) << "x";
		else if (i == 0)
			cout << " + " << char(c) << ") = ";
		else
			cout << char(c) << "x^" << i << " + ";
	}
	map<char, unsigned> coefficients;
	char k;
	
	for (int i = degree+1, c = 'a'; i >= 0; i--, c++)
	{
		if (i == 1)
		{
			cout << char(c) << "x";
			coefficients[char(c)] = 0;
		}
		else if (i == 0)
		{
			cout << " + " << char(c);
			k = char(c);
			coefficients[char(c)] = 0;
		}
			
		else
		{
			cout << char(c) << "x^" << i << "/" << i << " + ";
			coefficients[char(c)] = 0;
		}
			
	}
	cout << endl;
	for (auto iter{ coefficients.begin() }; iter != coefficients.end(); iter++)
	{
		cout << "Enter ";
		cout << iter->first << ": ";
		cin >> iter->second;
	}
	cout << "\nEnter x: ";
	int x;
	cin >> x;

	double result = 0;
	for (int i = degree + 1, c = 'a'; i >= 0; i--, c++)
	{
		if (i == 1)
		{
			result += x* coefficients[char(c)];
		}
		else if (i == 0)
		{
			result += coefficients[char(c)];
		}

		else
		{
			result += coefficients[char(c)]*(pow(x,i))/double(i);
		}

	}
	cout << "\nresult: " << result;
}
void cosPol()
{
	cout << "You chose the second command - I(cos(ax+b)) = ";
	cout << "sin(ax+b)/a + c. Enter a, x, b, c: ";
	int a, x, b, c;
	cin >> a >> x >> b >> c;
	double result = sin(a * x + b) / a + c;
	cout << "result: " << result;
}
void arctg()
{
	cout << "You chose the third command - I(1/(ax^2+bx+c)) = ";
	cout << "(1/a)*I(1/(x^2+(b/a)x+c/a)) = (1/a)*I(1/(x^2+(b/a)x+b^2/(2a)^2+4ca/(2a)^2-b^2/(2a)^2)) = ";
	cout << "(1/a)*I(1/((x+(b/(2a)))^2+(4ca-b^2)/(2a)^2) = 2/sqrt(4ca-b^2)*arctg((2xa+b)/sqrt(4ca-b^2))";

	cout << "\nEnter coefficients - a, b, c: ";
	int a, b, c;
	cin >> a >> b >> c;
	double result1 = sqrt(4*c*a - pow(b, 2));
	cout << 2 / result1 << "*arctg(" << 2 * a << "*x + " << b << "/" << result1 << ")";
	cout << "\nEnter x and c: ";
	double x, C;
	cin >> x >>C;
	cout << "result: " << 2 / result1 * atan((2 * a * x + b) / result1)+C;
}