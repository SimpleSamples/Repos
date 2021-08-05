#include "pch.h"
#include <iostream>
#pragma comment(lib, "pdh.lib")


VOID FormatPDHError(PDH_STATUS status)
{
	HANDLE hPdhLibrary = NULL;
	LPWSTR pMessage = NULL;

	hPdhLibrary = LoadLibrary(L"pdh.dll");
	if (NULL == hPdhLibrary) {
		std::wcout << "LoadLibrary failed with " << GetLastError() << '\n';
		return;
	}

	if (!FormatMessage(FORMAT_MESSAGE_FROM_HMODULE | FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_ARGUMENT_ARRAY,
		hPdhLibrary, status, 0, (LPWSTR)&pMessage, 0, NULL)) {
		std::wcout << "Format message failed with " << std::hex << GetLastError() << '\n';
		return;
	}

	std::wcout << pMessage << '\n';
	LocalFree(pMessage);
}

bool Show(DWORD dwBufferLength, PDH_STATUS status) {
	DWORD c = 0;
	LPWSTR mszObjectList = new WCHAR[dwBufferLength + 2];
	status = PdhEnumObjects(NULL, NULL, mszObjectList,
		// &dwBufferLength, PERF_DETAIL_WIZARD, FALSE);
		&dwBufferLength, PERF_DETAIL_EXPERT, FALSE);
	if (FAILED(status)) {
		FormatPDHError(status);
		return false;
	}
	std::wcout << dwBufferLength << L" characters\n";
	while (++c < dwBufferLength) {
		if (mszObjectList[c] == '\0')
			std::wcout << '\n';
		else
			std::wcout << mszObjectList[c];
	}
	delete[]mszObjectList;
	return true;
}

int main()
{
	LPWSTR szDataSource = NULL, szMachineName = NULL, mszObjectList = NULL;
	DWORD dwBufferLength = 0;
	std::cout << "Hello World!\n";
	PDH_STATUS status =
		PdhEnumObjects(szDataSource, szMachineName, NULL,
			&dwBufferLength, PERF_DETAIL_WIZARD, TRUE);
	if (status != PDH_MORE_DATA)
		FormatPDHError(status);
	else
		Show(dwBufferLength, status);
	delete[] mszObjectList;
}
