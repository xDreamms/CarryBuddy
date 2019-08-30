#pragma once
#include "CSpellInfo.h"

#define oSCISStartTime 0x8
#define oSCILevel 0x58
#define oSCICasterIndex 0x5C
#define oSCIStartPos 0x74
#define oSCIEndPos 0x80
#define oSCIHasTarget 0xA4
#define oSCITargetIndex 0xA8
#define oSCICastDelay 0x4A8
#define oSCICoolDown 0x4BC
#define oSCIIsBasicAttack 0x4C8
#define oSCISpellIndex 0x4D0
#define oSCIManaCosts 0x4D8
#define oSCIRadius 0x528

class CSpellCastInfo
{
public:
	union {
		DEFINE_MEMBER_0(CSpellInfo* SpellInfo, 0x0);
		DEFINE_MEMBER_N(float StarTime, oSCISStartTime);
		DEFINE_MEMBER_N(int Level, oSCILevel);
		DEFINE_MEMBER_N(short CasterIndex, oSCICasterIndex);
		DEFINE_MEMBER_N(Vector StartPos, oSCIStartPos);
		DEFINE_MEMBER_N(Vector EndPos, oSCIEndPos);
		DEFINE_MEMBER_N(bool HasTarget, oSCIHasTarget);
		DEFINE_MEMBER_N(short TargetIndex, oSCITargetIndex);
		DEFINE_MEMBER_N(float CastDelay, oSCICastDelay);
		DEFINE_MEMBER_N(float CoolDown, oSCICoolDown);
		DEFINE_MEMBER_N(bool IsBasicAttack, oSCIIsBasicAttack);
		DEFINE_MEMBER_N(int SpellIndex, oSCISpellIndex);
		DEFINE_MEMBER_N(float ManaCosts, oSCIManaCosts);
		DEFINE_MEMBER_N(float Radius, oSCIRadius);
	};
};