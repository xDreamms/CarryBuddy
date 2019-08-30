#pragma once
#include "stdafx.h"

#define oSDMissileSpeed 0x448

class CSpellData {
public:
	union {
		DEFINE_MEMBER_0(DWORD Base, 0x0);
		DEFINE_MEMBER_N(float MissileSped, oSDMissileSpeed);
	};
};