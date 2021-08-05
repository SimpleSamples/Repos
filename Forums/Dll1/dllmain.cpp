// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include "dllmain.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

#pragma managed(push, on)

void ShowValueManaged(int value) {
}

void GetOrderManaged(wchar_t *, size_t) {
}

bool SendSomethingManaged(int, wchar_t *serial) {
	return true;
}

#pragma  managed(pop)

extern "C" DLL1_API void ShowValue(int value) {
	//std::cout << "Value is: " << value << '\n';
}

extern "C" DLL1_API void GetOrder(wchar_t *output, size_t bufsize) {
	//wcscpy_s(output, bufsize, L"[ORDER_RES]|2424245|0793|1000|2421Ad");
}

extern "C" DLL1_API bool SendSomething(int pos, wchar_t *serial) {
	//std::wcout << "Sent " << (wchar_t *)serial << " at " << pos << "\n";
	return TRUE;
}
