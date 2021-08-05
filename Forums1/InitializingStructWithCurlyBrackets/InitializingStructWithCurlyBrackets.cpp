#include "pch.h"
#include <iostream>

// Is there a difference between initializing an empty struct with parenthesis and with curly brackets?
// https://social.msdn.microsoft.com/Forums/en-US/6d081b8b-8558-4465-9623-5e30825ceff7/is-there-a-difference-between-initializing-an-empty-struct-with-parenthesis-and-with-curly-brackets?forum=vclanguage

struct MyStruct
{
	int a;
	int b;
};

// with parenthesis
MyStruct F1(void)
{
	return MyStruct();
}

// with curly brackets
MyStruct F2(void)
{
	return MyStruct{};
}

int main()
{
	MyStruct s1 = F1();
	MyStruct s2 = F2();

	std::cout << "s1: " << "a=" << s1.a << ", b=" << s1.b << std::endl;
	std::cout << "s2: " << "a=" << s2.a << ", b=" << s2.b << std::endl;
}
