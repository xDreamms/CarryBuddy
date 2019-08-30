// CarryBuddy.Core.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "HookManager.h"
#include "ChatColor.h"

HMODULE Module;
void Core::OnLoadCore(HMODULE DLLModule) {
	Module = DLLModule;
	DebugConsole.SendDebugMessage("Core Loaded\n");
	Engine::PrintChat("Current CarryBuddy Version: 0.0.development", CHAT_FLAG_GREEN);
}

void __stdcall Unload() {
	Sleep(5);
	DebugConsole.Deallocate();
	HookManager.UnhookFunctions();
	FreeLibraryAndExitThread(Module, 0);
}

void Core::OnUnloadCore() {
	DebugConsole.SendDebugMessage("Core Unloaded\n");
	Engine::PrintChat("Core Unloaded", CHAT_FLAG_GREEN);
	CreateThread(0, 0, (LPTHREAD_START_ROUTINE)Unload, 0, 0, 0);
}