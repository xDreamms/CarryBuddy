#pragma once
#include "Modules.h"
#include "Object.h"

class CObjectManager {
public:
	union {
		DEFINE_MEMBER_0(void *base, 0x0);
		DEFINE_MEMBER_N(CObject** pObjectArray, 0x4);
		DEFINE_MEMBER_N(int pMaxObjects, 0x8);
		DEFINE_MEMBER_N(int pCurrentObjects, 0xC);
		DEFINE_MEMBER_N(int pHighestIndex, 0x10);
	};
};
extern CObjectManager* ObjectManager;