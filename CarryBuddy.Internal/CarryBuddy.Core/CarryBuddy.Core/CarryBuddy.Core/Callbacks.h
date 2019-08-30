#pragma once
#include "stdafx.h"

#define CALLBACK_ONDRAW 0x1
#define CALLBACK_ENUMOBJECT 0x2
#define CALLBACK_CREATEOBJECT 0x3
#define CALLBACK_DELETEOBJECT 0x4

class Callbacks {
public:
	static void OnDraw();
	static void EnumObject(CObject* Object);
	static void CreateObject(CObject* Object);
	static void DeleteObject(CObject* Object);
	static void CheckForCreatedObject(CObject* Object);
	static void CheckForDeletedObjects();
	static bool RegisterCallback(void* Callback, int CallbackType);
	static bool UnRegisterCallback(void* Callback, int CallbackType);
};