#pragma once

#ifdef DLL1_EXPORTS
#define DLL1_API __declspec(dllexport)
#else
#define DLL1_API __declspec(dllimport)
#endif

extern "C" DLL1_API void ShowValue(int);

extern "C" DLL1_API void GetOrder(wchar_t *, size_t);

extern "C" DLL1_API bool SendSomething(int, wchar_t *serial);
