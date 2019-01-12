#include "Stdafx.h"

/****************************************************************************/

class CWindow {
	static const TCHAR * m_AppName;
	static LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
	RECT m_WindowRectangle;
	SIZE m_TextSize;
	const TCHAR * m_Message;
	HWND m_hWnd;
	HINSTANCE m_hInstance;
public:
	CWindow(HINSTANCE hInstance = NULL) {
		m_WindowRectangle.left = m_WindowRectangle.right = m_WindowRectangle.top = m_WindowRectangle.bottom = 0;
		m_hWnd = NULL; m_Message = NULL; m_TextSize.cx = m_TextSize.cy = 0; m_hInstance = hInstance;
	};
	CWindow(HINSTANCE hInstance, const TCHAR * Message, const TCHAR * ClassName)
	{
		m_WindowRectangle.left = m_WindowRectangle.right = m_WindowRectangle.top = m_WindowRectangle.bottom = 0;
		m_hInstance = hInstance; m_hWnd = NULL; m_Message = Message; m_TextSize.cx = m_TextSize.cy = 0;
		m_ClassName = ClassName;
	};
	const TCHAR * m_ClassName;
	BOOL RegisterClass();
	BOOL Create();
	void Center();
};

const TCHAR * CWindow::m_AppName = _T("DrawHello Program");

/****************************************************************************/

LRESULT CALLBACK CWindow::WndProc(HWND hWnd, UINT message,
	WPARAM wParam, LPARAM lParam) {
	switch (message) {
	case WM_PAINT: {
		HDC hDC;
		SIZE Size;
		PAINTSTRUCT ps;
		CWindow *pWindow; // pointer to us (this)
		POINT TextPosition;
		pWindow = (CWindow *)GetWindowLong(hWnd, GWL_USERDATA);
		hDC = BeginPaint(hWnd, &ps);
		// Calculate position for centering text
		GetTextExtentPoint(hDC, pWindow->m_Message, lstrlen(pWindow->m_Message), &Size);
		TextPosition.x = (pWindow->m_WindowRectangle.right - Size.cx) >> 1;
		TextPosition.y = (pWindow->m_WindowRectangle.bottom - Size.cy) >> 1;
		// Display the message
		TextOut(hDC, TextPosition.x, TextPosition.y,
			pWindow->m_Message, lstrlen(pWindow->m_Message));
		EndPaint(hWnd, &ps);
		return 0;
	}
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	case WM_CREATE: {
		CWindow *pWindow; // pointer to us (this)
		CREATESTRUCT *lpcs = (CREATESTRUCT FAR*) lParam;
		pWindow = (CWindow *)lpcs->lpCreateParams;
		SetWindowLong(hWnd, GWL_USERDATA, (LONG)pWindow);
		HDC hDC;
		TEXTMETRIC tm;
		hDC = GetDC(hWnd);
		GetTextMetrics(hDC, &tm);
		ReleaseDC(hWnd, hDC);
		pWindow->m_TextSize.cx = tm.tmMaxCharWidth;
		pWindow->m_TextSize.cy = tm.tmHeight + tm.tmExternalLeading;
		return 0;
	}
	default:
		return (DefWindowProc(hWnd, message, wParam, lParam));
	}
	return (NULL);
}

/****************************************************************************/

void CWindow::Center() {
	LONG Width, Height;
	BOOL rv;
	// Get the limits of the 'workarea'
	rv = SystemParametersInfo(SPI_GETWORKAREA, sizeof(RECT), &m_WindowRectangle, 0);
	if (!rv) { // Not work?
		m_WindowRectangle.left = m_WindowRectangle.top = 0;
		m_WindowRectangle.right = GetSystemMetrics(SM_CXSCREEN);
		m_WindowRectangle.bottom = GetSystemMetrics(SM_CYSCREEN);
	}
	Width = m_WindowRectangle.right - m_WindowRectangle.left;
	Height = m_WindowRectangle.bottom - m_WindowRectangle.top;
	m_WindowRectangle.left = Width >> 2; // x
	m_WindowRectangle.top = Height >> 2; // y
	m_WindowRectangle.right = Width >> 1; // width
	m_WindowRectangle.bottom = Height >> 1; // height
}

/****************************************************************************/

BOOL CWindow::RegisterClass() {
	WNDCLASSEX wcex;
	wcex.style = CS_DBLCLKS;
	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = m_hInstance;
	wcex.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hIconSm = NULL;
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = NULL;
	wcex.lpszClassName = m_ClassName;
	if (!::RegisterClassEx(&wcex)) {
		DWORD ErrorCode = GetLastError();
		MessageBox(NULL, _T("RegisterClassEx failed"), m_AppName,
			MB_OK | MB_ICONEXCLAMATION | MB_SETFOREGROUND);
		return (FALSE);
	}
	return (TRUE);
}

/****************************************************************************/

BOOL CWindow::Create() {
	m_hWnd = ::CreateWindow(m_ClassName, m_AppName, WS_OVERLAPPEDWINDOW | WS_VISIBLE,
		m_WindowRectangle.left, m_WindowRectangle.top,
		m_WindowRectangle.right, m_WindowRectangle.bottom,
		NULL, NULL, m_hInstance, this);
	if (m_hWnd)
		return (TRUE);
	MessageBox(NULL, _T("CreateWindow failed"), m_AppName,
		MB_OK | MB_ICONEXCLAMATION | MB_SETFOREGROUND);
	return (FALSE);
}

/****************************************************************************/

DWORD WINAPI ThreadProc(LPVOID lpParameter) {
	CWindow Window(NULL, _T("Other thread"), _T("DrawHelloClass2"));
	MSG Msg;
	BOOL rv;
	if (!Window.RegisterClass())
		return 999;
	Window.Center(); // not necessary but nice
	if (!Window.Create())
		return 999;
	// Main message loop:
	while ((rv = GetMessage(&Msg, NULL, 0, 0)) > 0) {
		TranslateMessage(&Msg);
		DispatchMessage(&Msg);
	}
}

/****************************************************************************/

int PASCAL WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, char * lpCmdLine, int nCmdShow) {
	CWindow Window(hInstance, _T("Hello"), _T("DrawHelloClass"));
	MSG Msg;
	BOOL rv;
	if (!Window.RegisterClass())
		return 999;
	Window.Center(); // not necessary but nice
	if (!Window.Create())
		return 999;
	DWORD ThreadId;
	CreateThread(NULL, 0, ThreadProc, NULL, 0, &ThreadId);
	// Main message loop:
	while ((rv = GetMessage(&Msg, NULL, 0, 0)) > 0) {
		TranslateMessage(&Msg);
		DispatchMessage(&Msg);
	}
	return (Msg.wParam);
}
