#include "pch.h"
#include "ClassLibraryWrapper.h"
using namespace System;
//using namespace ClassLibraryWrapper;

namespace ClassLibraryWrapper {
	ref class Class1
	{
	public:

		void static ShowValue(int value) {
			ClassLibrary1::Class1::ShowValue(value);
		}

		void static GetOrder(wchar_t *order, size_t z) {
			System::String^ s;
			ClassLibrary1::Class1::GetOrder(s);
			pin_ptr<const wchar_t> wch = PtrToStringChars(s);
			wcscpy_s(order, z, wch);
		}

		bool static SendSomething(int pos, wchar_t *serial) {
			System::String^ const s = gcnew System::String(serial);
			ClassLibrary1::Class1::SendResult(pos, s);
			return true;
		}
	};
}

void static ShowValueManaged(int value) {
	ClassLibraryWrapper::Class1::ShowValue(value);
}

void static GetOrderManaged(wchar_t *order, size_t z) {
	ClassLibraryWrapper::Class1::GetOrder(order, z);
}

bool static SendSomethingManaged(int pos, wchar_t *serial) {
	ClassLibraryWrapper::Class1::SendSomething(pos, serial);
	return true;
}

#pragma managed(push, off)

void ShowValue(int value) {
	ShowValueManaged(value);
}

void GetOrder(wchar_t *output, size_t bufsize) {
	GetOrderManaged(output, bufsize);
}

bool SendSomething(int pos, wchar_t *serial) {
	SendSomethingManaged(pos, serial);
	return true;
}

#pragma  managed(pop)
