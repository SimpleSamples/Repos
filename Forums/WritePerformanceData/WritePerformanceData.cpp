
#include "pch.h"
#include <iostream>
#pragma comment(lib, "pdh.lib")

CONST ULONG SAMPLE_INTERVAL_MS = 1000;

void Show(wchar_t *argv[], PDH_STATUS pdhStatus, HQUERY hQuery, HLOG hLog) {
	DWORD dwLogType = PDH_LOG_TYPE_CSV;
	HCOUNTER hCounter;
	DWORD dwCount;

	std::wcout << L"Showing counter" << L"\\User Input Delay per Session(Max)\\Max Input Delay" << "\n";

	// Add one counter that will provide the data.
	pdhStatus = PdhAddCounter(hQuery,
		//COUNTER_PATH,
		//L"\\Processor(0)\\% Processor Time",
		L"\\User Input Delay per Session(1)\\Max Input Delay",
		0,
		&hCounter);

	if (pdhStatus != ERROR_SUCCESS)
	{
		std::wcout << L"PdhAddCounter failed with " << pdhStatus << L'\n';
		return;
	}

	// Open the log file for write access.
	pdhStatus = PdhOpenLog(argv[1],
		PDH_LOG_WRITE_ACCESS | PDH_LOG_CREATE_ALWAYS,
		&dwLogType,
		hQuery,
		0,
		NULL,
		&hLog);

	if (pdhStatus != ERROR_SUCCESS)
	{
		std::wcout << L"PdhOpenLog failed with " << pdhStatus << L'\n';
	}

	// Write 10 records to the log file.
	for (dwCount = 0; dwCount < 10; dwCount++)
	{
		std::wcout << L"Writing record " << dwCount << L'\n';

		pdhStatus = PdhUpdateLog(hLog, NULL);
		if (ERROR_SUCCESS != pdhStatus)
		{
			std::wcout << L"PdhUpdateLog failed with " << pdhStatus << L'\n';
		}

		// Wait one second between samples for a counter update.
		Sleep(SAMPLE_INTERVAL_MS);
	}
}

int wmain(int argc, wchar_t *argv[])
//int main(int argc, WCHAR **argv)
{
	{
		PDH_STATUS pdhStatus;
		HQUERY hQuery = NULL;
		HLOG hLog = NULL;

		// Open a query object.
		pdhStatus = PdhOpenQuery(NULL, 0, &hQuery);

		if (pdhStatus == ERROR_SUCCESS)
			Show(argv, pdhStatus, hQuery, hLog);
		else
			std::wcout << L"PdhOpenQuery failed with " << pdhStatus << L'\n';

		// Close the log file.
		if (hLog)
			PdhCloseLog(hLog, 0);

		// Close the query object.
		if (hQuery)
			PdhCloseQuery(hQuery);
	}
}
