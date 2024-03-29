
// CenterMFC.h : main header file for the CenterMFC application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'pch.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CCenterMFCApp:
// See CenterMFC.cpp for the implementation of this class
//

class CCenterMFCApp : public CWinApp
{
public:
	CCenterMFCApp() noexcept;


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation

public:
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CCenterMFCApp theApp;
