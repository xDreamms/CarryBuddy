#pragma once
#include "stdafx.h"

class CBuffNameContainer {
public:
	union {
		DEFINE_MEMBER_0(void* Base, 0x0);
		DEFINE_MEMBER_N(char Name, 0x8);
	};
};

class CBuff {
public:
	union {
		DEFINE_MEMBER_0(void* Base, 0x0);
		DEFINE_MEMBER_N(CBuffNameContainer* NameC, 0x8);
		DEFINE_MEMBER_N(float StartTime, 0xC);
		DEFINE_MEMBER_N(float ExpireTime, 0x10);
		DEFINE_MEMBER_N(CBuff* thisptr, 0x1C);
		DEFINE_MEMBER_N(int BaseStacksAlt, 0x20);
		DEFINE_MEMBER_N(int StacksAlt, 0x24);
		DEFINE_MEMBER_N(int StacksI, 0x74);
		DEFINE_MEMBER_N(bool ShowStacks, 0x78);
	};

	char* GetName() {
		if (!NameC) {
			return 0;
		}

		return &NameC->Name;
	}


	int GetStacksAlt() {
		return (StacksAlt - BaseStacksAlt) >> 3;
	}
};