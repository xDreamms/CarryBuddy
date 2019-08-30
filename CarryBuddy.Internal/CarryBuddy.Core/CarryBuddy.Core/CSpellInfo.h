#pragma once
#include "CSpellData.h"

#define oSISpellData 0x38

class CSpellInfo {
public:
	union {
		DEFINE_MEMBER_0(DWORD Base, 0x0);
		DEFINE_MEMBER_N(CSpellData* SpellData, oSISpellData);
	};
};