#include <iostream>
using namespace std;
void cvad()
{
	double a, b, c, x1, x2, d;
	bool di = true;
	cout << "����� ��� ������� ���������� ��-�. ������� ����-�� a, b �  c: ";

	cin >> a >> b >> c;
	if (a == 0 && b == 0 && c != 0)
		cout << "������� ���";
	else if ((c == 0 && a == 0 && b != 0) || (c == 0 && b == 0 && a != 0))
		cout << "�����: 0";
	else if ((c == 0 && b == 0 && a == 0))
		cout << "�����: ����� �����";
	else if (a == 0 && b != 0 && c != 0)
		cout << "�����: " << -c / b;
	else if (b == 0 && a != 0 && c != 0)
	{
		if (c > 0)
			cout << "�����: " << sqrt(c / a) << "i and " << -sqrt(c / a) << "i";
		else
			cout << "�����: " << sqrt(-c / a) << " and " << -sqrt(-c / a);
	}
	else
	{
		d = b * b - 4 * a * c;
		if (d < 0)
		{
			d = -d;
			di = false;
		}
		if (di)
		{
			x1 = (-b + sqrt(d)) / (2 * a);
			x2 = (-b - sqrt(d)) / (2 * a);
			if (x1 == x2)
				cout << "�����: " << x1;
			else
				cout << "�����: �1 = " << x1 << ", �2 =" << x2;
		}
		else
		{
			//x1 = -b / (2 * a) + sqrt(d) / (2 * a);
			//x2 = -b / (2 * a) - sqrt(d) / (2 * a);
			cout << "�����: �1 = " << -b / (2 * a) << " + (" << sqrt(d) / (2 * a) << "i), �2 =" << -b / (2 * a) << " - (" << sqrt(d) / (2 * a) << "i)";
		}
	}
}
void system()
{
	double a1, b1, c1, a2, b2, c2;
	cout << "a1 = ";
	cin >> a1;
	cout << "b1 = ";
	cin >> b1;
	cout << "c1 = ";
	cin >> c1;
	cout << "a2 = ";
	cin >> a2;
	cout << "b2 = ";
	cin >> b2;
	cout << "c2 = ";
	cin >> c2;
	cout << a1 << "x + " << b1 << " y = " << c1 << endl;
	cout << a2 << "x + " << b2 << " y = " << c2 << endl;
	double d0[2][2] = { { a1,b1 }, { a2,b2 } };
	double d1[2][2] = { {c1,b1} ,{c2,b2} };
	double d2[2][2] = { {a1,c1} ,{a2,c2} };
	double d_0[2][3] = { {a1,b1,c1} ,{a2,b2,c2} };
	double mass[4]{ a1,a2,b1,b2 };
	double rank0 = mass[0];
	for (int i = 1; i < 4; i++)
	{
		if (mass[i] > rank0)
			rank0 = mass[i];
	}
	double det0 = a1 * b2 - a2 * b1;
	double det1 = c1 * b2 - c2 * b1;
	double det2 = a1 * c2 - a2 * c1;
	if (0)
		cout << "������� �����������." << endl;
	else
	{
		if (!a1 && !a2 && !b1 && !b2 && !c1 && !c2)
			cout << "x, y- �����" << endl;
		else if (!a1 && !a2)
		{
			if (b1 == 0)
				cout << "x - ����� " << "y = " << c2 / b2 << endl;
			else if (b2 == 0)
				cout << "x-����� " << "y= " << c1 / b1 << endl;
			else
				cout << "x-����� " << "y= " << c1 / b1 << endl;
		}
		else if (!b1 && !b2)
		{
			if (a1 == 0)
				cout << "x = " << c2 / a2 << "y - �����" << endl;
			else if (a2 == 0)
				cout << "x= " << c1 / a1 << "y-�����" << endl;
			else
				cout << "x= " << c1 / a1 << "y-�����" << endl;
		}
		else if (!c1 && !c2)
			cout << "x, y = 0" << endl;
		else if ((!a1 && !b1 && !c1) || (!a2 && !b2 && !c2))
			cout << "��� �������";
		else
		{
			if (det0 != 0)
				cout << "x = " << det1 / det0 << " y = " << det2 / det0 << endl;
			else
				cout << "x = " << c1 / a1 << -b1 / a1 << "*y" << endl;
		}
	}

}
int main()
{
	setlocale(LC_ALL, "rus");
	int choose;
	cout << "������� ����� �����(1 - ���������� ���������, 2 - ������� ���������x ���������): ";
	cin >> choose;
	switch (choose)
	{
	case 1:
		cvad();
		break;
	case 2:
		system();
		break;
	}


	return 0;
}