#pragma once
#include "stdafx.h"


typedef DWORD CoreResponse;
#define CB_ERROR_NOERROR 0x0
#define CB_ERROR_INVALIDOBJECT 0x1
#define CB_ERROR_INTERNALERROR 0x2
#define CB_ERROR_INVALIDCALLBACK 0x3

class Core {
public:
	static void OnLoadCore(HMODULE DLLModule);
	static void OnUnloadCore();
};