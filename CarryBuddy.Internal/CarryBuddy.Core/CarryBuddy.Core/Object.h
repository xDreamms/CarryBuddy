#pragma once
#include <Windows.h>
#include "Offsets.h"
#include "Modules.h"
#include "Vector.h"
#include "CSpellCastInfo.h"
#include "CSpell.h"
#include "CBuffManager.h"

class CObject {
public:
	bool IsTurret();
	bool IsMinion();
	bool IsAlive();
	bool IsHero();
	bool IsMissile();
	bool IsNexus();

	bool IsInhibitor();
	bool IsTroyEnt();
	bool IsTargetable();

	Vector GetPos() {
		return *(Vector*)((DWORD)this + oObjPos);
	}

	bool IsVisible() { //AIHeroClient
		return *(bool*)((DWORD)this + oObjVisibility);
	}

	int GetTeam() {
		return *(int*)((DWORD)this + oObjTeam);
	}

	float GetAttackRange() {
		return *(float*)((DWORD)this + oObjAtkRange);
	}

	float GetBoundingRadius() { //AIHeroClient
		typedef float(__thiscall* OriginalFn)(PVOID);
		return CallVirtual<OriginalFn>(this, 36)(this);
	}

	float GetCurrentHealth() {
		return *(float*)((DWORD)this + oObjHealth);
	}

	float GetMaxHealth() {
		return *(float*)((DWORD)this + oObjMaxHealth);
	}

	int GetLevel() {
		return *(int*)((DWORD)this + oObjLevel);
	}

	char* GetChampionName() {
		return GetStr((DWORD)this + oObjChampionName);
	}

	char* GetName() {
		return GetStr((DWORD)this + oObjName);
	}

	short GetIndex() {
		return *(short*)((DWORD)this + oObjIndex);
	}

	short GetTargetIndex() {
		return *(short*)((DWORD)this + oObjTargetID);
	}

	short GetSourceIndex() {
		return *(short*)((DWORD)this + oObjSourceIndex);
	}

	DWORD GetNetworkID() {
		return *(DWORD*)((DWORD)this + oObjNetworkID);
	}

	float GetCurrentMana() {
		return *(float*)((DWORD)this + oObjMana);
	}

	float GetMaxMana() {
		return *(float*)((DWORD)this + oObjMaxMana);
	}

	float GetBaseAD() {
		return *(float*)((DWORD)this + oObjBaseAtk);
	}

	float GetBonusAD() {
		return *(float*)((DWORD)this + oObjBonusAtk);
	}

	float GetTotalAD() {
		return GetBaseAD() + GetBonusAD();
	}

	float GetBonusAP() {
		return *(float*)((DWORD)this + oObjBonusAP);
	}

	float GetArmor() {
		return *(float*)((DWORD)this + oObjArmor);
	}

	float GetMagicResistance() {
		return *(float*)((DWORD)this + oObjMR);
	}

	int GetCombatType() {
		return *(int*)((DWORD)this + oObjCombatType);
	}

	CSpellCastInfo* GetSpellCastInfo() {
		return (CSpellCastInfo*)((DWORD)this + oObjSpellCastInfo);
	}

	float GetShield() {
		return *(float*)((DWORD)this + oObjShield);
	}

	float GetMagicShield() {
		return *(float*)((DWORD)this + oObjMagicShield);
	}

	float GetFlatMagicPen() {
		return *(float*)((DWORD)this + oObjFlatMagicPen);
	}

	float GetPercMagicPenMod() {
		return *(float*)((DWORD)this + oObjPercAbilityPowerMod);
	}

	float GetLethality() {
		return *(float*)((DWORD)this + oObjLethality);
	}

	float GetPercAttackDamageMod() {
		return *(float*)((DWORD)this + oObjPercAttackDamageMod);
	}

	float GetBonusArmor() {
		return *(float*)((DWORD)this + oObjBonusArmor);
	}

	float GetBonusMagicResistance() {
		return *(float*)((DWORD)this + oObjBonusAtk);
	}

	float GetPhysicalShield() {
		return *(float*)((DWORD)this + 0xE38);
	}

	CSpell* GetSpell(int Index) {
		return *(CSpell**)((DWORD)this + oObjSpellBook + 0x508 + (0x4 * Index));
	}

	DWORD GetSpellBook() {
		return ((DWORD)this + oObjSpellBook);
	}

	CBuffManager* GetBuffManager() {
		return (CBuffManager*)((DWORD)this + oObjBuffManager);
	}
};

