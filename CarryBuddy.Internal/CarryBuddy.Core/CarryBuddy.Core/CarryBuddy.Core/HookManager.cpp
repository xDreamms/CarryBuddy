#include "stdafx.h"
#include "HookManager.h"
#include "detours.h"
#pragma comment(lib, "detours.lib")

// Copy and Pasted btw
DWORD FindDevice() {
	DWORD dwObjBase = 0;

	dwObjBase = (DWORD)LoadLibrary("d3d9.dll");
	while (dwObjBase++ < dwObjBase + 0x1280000)
	{
		if ((*(WORD*)(dwObjBase + 0x00)) == 0x06C7
			&& (*(WORD*)(dwObjBase + 0x06)) == 0x8689
			&& (*(WORD*)(dwObjBase + 0x0C)) == 0x8689
			) {
			dwObjBase += 2; break;
		}
	}

	return dwObjBase;
}

void CHookManager::HookFunctions() {
	D3DDevice = FindDevice();
	if (D3DDevice) {
		OPresent = (fnPresent)DetourFunction((PBYTE)GetVirtual((PVOID)D3DDevice, 17), (PBYTE)HPresent);
	}
}

void CHookManager::UnhookFunctions() {
	DetourRemove((PBYTE)OPresent, (PBYTE)HPresent);
}