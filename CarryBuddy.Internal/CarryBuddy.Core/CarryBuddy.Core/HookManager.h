#pragma once
#include "stdafx.h"
#include "Hooks.h"

class CHookManager {
public:
	void HookFunctions();
	void UnhookFunctions();

private:
	DWORD D3DDevice;
};
extern CHookManager HookManager;