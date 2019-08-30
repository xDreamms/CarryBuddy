#pragma once
#include "CSpellInfo.h"

#define oSpellLevel 0x20
#define oSpellTimer 0x28
#define oSpellSpellInfo 0x134

class CSpell {
public:
	union {
		DEFINE_MEMBER_0(void* Base, 0x0);
		DEFINE_MEMBER_N(int Level, oSpellLevel);
		DEFINE_MEMBER_N(float Timer, oSpellTimer);
		DEFINE_MEMBER_N(CSpellInfo* SpellInfo, oSpellSpellInfo);
	};
};