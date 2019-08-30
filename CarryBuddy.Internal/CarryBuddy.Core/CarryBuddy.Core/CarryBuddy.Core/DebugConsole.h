#pragma once
#include <Windows.h>
#include <stdio.h>
#include <stdarg.h>

class CDebugConsole {
public:
	void Allocate(const char* WindowName) {
		AllocConsole();
		freopen("CONOUT$", "w", stdout);
		SetConsoleTitle(WindowName);
	}

	void Deallocate() {
		FreeConsole();
	}

	void _SendDebugMessage(const char* Message, va_list args) {
		std::string MSG = "[DEBUG]: ";
		MSG += Message;
		vprintf(MSG.c_str(), args);
	}

	void SendDebugMessage(const char* Message, ...) {
		va_list args;
		va_start(args, Message);
		_SendDebugMessage(Message, args);
		va_end(args);
	}
};
extern CDebugConsole DebugConsole;