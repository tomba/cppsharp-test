#ifndef _NATIVE_H_
#define _NATIVE_H_

int addCpp(int a, int b);

extern "C" {
	int addC(int a, int b);
};

class TestClass
{
	int a, b;

	public:
	void set_values(int, int);
	int sum(void);
};

#endif

