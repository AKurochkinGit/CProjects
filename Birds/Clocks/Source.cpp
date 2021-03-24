#include<iostream>
#include<cmath>
#include<string>
using namespace std;
int main()
{
	int hh;
	double mm;
	cin >> hh;
	 cin.ignore();
	 cin >> mm;
	double angle = fabs(((hh*30)%360 + mm/2) - mm*6);
	if (angle > 180)
		angle = 360 - angle;
	cout << fixed << angle;
	return 0;
}