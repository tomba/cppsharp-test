#include "native.h"

int addCpp(int a, int b)
{
	return a + b;
}

int addC(int a, int b)
{
	return a + b;
}

TestClass::TestClass()
{
}

void TestClass::set_values(int a, int b)
{
	this->a = a;
	this->b = b;
}

int TestClass::sum(void)
{
	return this->a + this->b;
}
