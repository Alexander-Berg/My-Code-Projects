#include <iostream>

using namespace std;

int main()
{
	int a, b, c;
	cout << "Enter value of a: ";
	cin >> a;
	cout << "Enter value of b: ";
	cin >> b;
	c = a;
	a = b;
	b = c;
	cout << "After swaping a: " << a << " b: " << b;
	return 0;
}

/*
OUTPUT:
Enter value of a: 5
Enter value of b: 3
After swaping a: 3 b: 5
*/