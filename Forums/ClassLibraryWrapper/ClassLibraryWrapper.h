#pragma once

#ifdef CLASSLIBRARYWRAPPER_EXPORTS
#define CLASSLIBRARYWRAPPER_API __declspec(dllexport)
#else
#define CLASSLIBRARYWRAPPER_API __declspec(dllimport)
#endif

extern "C" CLASSLIBRARYWRAPPER_API void ShowValue(int);

extern "C" CLASSLIBRARYWRAPPER_API void GetOrder(wchar_t *, size_t);

extern "C" CLASSLIBRARYWRAPPER_API bool SendSomething(int, wchar_t *serial);
