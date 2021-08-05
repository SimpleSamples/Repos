#include "pch.h"
#include <windows.h>
#include <iostream>
#include "../ClassLibraryWrapper/ClassLibraryWrapper.h"

int main()
{
	std::cout << "Hello world!\n";
	ShowValue(99);
	wchar_t order[100];
	GetOrder(order, _countof(order));
	std::wcout << "Got: " << (wchar_t *)order << '\n';
	wchar_t Something[](L"something");
	bool b = SendSomething(77, Something);
	return 0;
}
