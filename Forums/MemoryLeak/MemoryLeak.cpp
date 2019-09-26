#include "pch.h"
#include <iostream>

int main()
{
	//_CrtSetDbgFlag(_CRTDBG_LEAK_CHECK_DF);
	//int DbgFlags;
	//DbgFlags = _CrtSetDbgFlag(_CRTDBG_REPORT_FLAG);
	//DbgFlags |= _CRTDBG_LEAK_CHECK_DF;
	//_CrtSetDbgFlag(DbgFlags);
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	//std::cout << "Hello!\n";
	void *v = malloc(5000);
	//std::cout << "Bye!\n";
}
