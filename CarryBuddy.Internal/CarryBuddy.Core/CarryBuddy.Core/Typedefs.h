#pragma once
#include "afx.h"
#include "Offsets.h"

//Needs offset referening in the callings

typedef void(__thiscall* fnUpdateChargeableSpell)(SpellBook* pSpellBook, Spell* pSpellslot, int slot, Vector3* pPosition, bool ReleaseCast);
typedef void(__thiscall* fnPrintChat)(DWORD ChatClient, const char* Message, int Color);
typedef int*(__thiscall* fnIssueOrder)(void *thisPtr, int Order, Vector *Loc, CObject *Target, bool IsAttackMove, bool IsMinion, DWORD Unknown);
typedef float(__cdecl* fnGetAttackCastDelay)(CObject* pObj);
typedef float(__cdecl* fnGetAttackDelay)(CObject* pObj);
typedef void(__cdecl* fnDrawCircle)(Vector* position, float range, int* color, int a4, float a5, int a6, float alpha);
typedef int*(__thiscall *fnCastSpell)(DWORD spellbook_addr, SpellSlot* spellslot, int SlotID, Vector* targetpos, Vector* startpos, DWORD NetworkID);

typedef bool(__cdecl* fnIsHero)(CObject* pObj);
typedef bool(__cdecl* fnIsMissile)(CObject* pObj);
typedef bool(__cdecl* fnIsMinion)(CObject* pObj);
typedef bool(__cdecl* fnIsTurret)(CObject* pObj);
typedef bool(__cdecl* fnIsInhibitor)(CObject* pObj);
typedef bool(__cdecl* fnIsTroyEnt)(CObject* pObj);
typedef bool(__cdecl* fnIsNexus)(CObject* pObj);

typedef bool(__thiscall* fnIsDragon)(CObject* pObj);
typedef bool(__thiscall* fnIsBaron)(CObject* pObj);
typedef bool(__thiscall* fnIsAlive)(CObject* pObj);
typedef bool(__thiscall* fnIsTargetable)(CObject* pObj);