#include "pch.h"
#include <iostream>

// How to get Process ID of running application?
// https://social.msdn.microsoft.com/Forums/en-US/5d362a31-0a83-45a5-9bf3-3d3ac9cd2564/how-to-get-process-id-of-running-application?forum=vcgeneral

int main()
{
    std::cout << "Hello World!\n";
	HANDLE hProcessSnap;
	HANDLE hProcess;
	PROCESSENTRY32 pe32;
	bool processFound = 0;
	TCHAR fileName[] = TEXT("FileAshAndBen.exe");

	// ------------ Getting List of Running Processes ------------//

	hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

	if (hProcessSnap == INVALID_HANDLE_VALUE)
	{
		std::cout << "CreateToolhelp32Snapshot (of process) is failed\n";
		return 0;
	}

	// ---------------- Getting FIle Process ID ----------------//

	// Set the size of the pe32 structure before using it
	pe32.dwSize = sizeof(PROCESSENTRY32);

	if (!Process32First(hProcessSnap, &pe32));
	{
		std::cout << "Process32First failed \n";
		// clean the snapshot object
		CloseHandle(hProcessSnap);
	}

	// Go through all the processes looking for FileAshAndBen.exe
	do
	{
		// print out the process name
		std::cout << "\nProcess name is " << pe32.szExeFile << std::endl;

		// if the process name is FileAshAndBen.exe
		if (_tcscmp(pe32.szExeFile, fileName) == 0)
		{
			std::cout << "File process is found \n";
			processFound = 1;
			break;
		}
	} while (Process32Next(hProcessSnap, &pe32));
}
