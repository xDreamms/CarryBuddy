#include <Windows.h>
#include "CBSDK.h"

SDKInterface* SDK;
HMODULE DLLModule;

void OnCreate(DWORD Object) {

	SDK->SendDebugMessage("CreateOject: %x\n", Object);
}

void OnDelete(DWORD Object) {
}

void __stdcall Start() {

	while (!GetSDKInterface(&SDK)) {
		Sleep(1);
	}

	SDK->SendDebugMessage("Loaded Module\n");

	SDK->RegisterCallback((void*)OnCreate, CALLBACK_CREATEOBJECT);
	SDK->RegisterCallback((void*)OnDelete, CALLBACK_DELETEOBJECT);

	while (!GetAsyncKeyState(VK_F5)) {
		continue;
	}

	SDK->SendDebugMessage("Unloading Module\n");
	SDK->UnRegisterCallback((void*)OnCreate, CALLBACK_CREATEOBJECT);
	SDK->UnRegisterCallback((void*)OnDelete, CALLBACK_DELETEOBJECT);
	FreeLibraryAndExitThread(DLLModule, 0);
};


BOOL APIENTRY DllMain(HMODULE Module, DWORD  ul_reason_for_call, LPVOID lpReserved)
{

	if (ul_reason_for_call == DLL_PROCESS_ATTACH) {

		CreateThread(0, 0, (LPTHREAD_START_ROUTINE)Start, 0, 0, 0);
		DLLModule = Module;
		return TRUE;
	}

	else if (ul_reason_for_call == DLL_PROCESS_DETACH) {
		return TRUE;
	}
	return FALSE;
}
