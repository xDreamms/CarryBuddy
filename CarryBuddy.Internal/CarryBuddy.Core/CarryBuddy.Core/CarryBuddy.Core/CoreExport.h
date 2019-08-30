#pragma once
#include "stdafx.h"

struct Health {
	float Current;
	float Max;
	float Shield;
	float MagicShield;
	float PhysicalShield;
};

struct Penetration {
	float FlatMagic;
	float PercMagic;
	float Lethality;
	float PercPhysical;
};

class CSDKExports {
public:

	// Object related

	virtual CoreResponse GetLocalPlayer(CObject** Buffer);
	virtual CoreResponse GetObjectTeamID(CObject* Object, int* Buffer);
	virtual CoreResponse GetObjectSummonerName(CObject* Object, const char** Buffer);
	virtual CoreResponse GetObjectNetworkID(CObject* Object, DWORD* Buffer);
	virtual CoreResponse GetObjectPosition(CObject* Object, Vector* Buffer);
	virtual CoreResponse IsObjectVisible(CObject* Object, bool* Buffer);
	virtual CoreResponse GetObjectCurrentMana(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectMaxMana(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectHealth(CObject* Object, Health* Buffer);
	virtual CoreResponse GetObjectBaseAD(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectBonusAD(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectTotalAD(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectBonusAP(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectCurrentArmor(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectBonusArmor(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectCurrentMagicResistance(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectBonusMagicResistance(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectAttackRange(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectBoundingRadius(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectCombatType(CObject* Object, int* Buffer);
	virtual CoreResponse GetObjectAttackDelay(CObject* Object, float* Buffer);
	virtual CoreResponse GetObjectAttackCastDelay(CObject* Object, float* Buffer);
	virtual CoreResponse IsObjectAlive(CObject* Object, bool* Buffer);
	virtual CoreResponse IsObjectTargetable(CObject* Object, bool* Buffer);
	virtual CoreResponse IsObjectHero(CObject* Object, bool* Buffer);
	virtual CoreResponse IsObjectMinion(CObject* Object, bool* Buffer);
	virtual CoreResponse IsObjectTurret(CObject* Object, bool* Buffer);	
	virtual CoreResponse IsObjectMissile(CObject* Object, bool* Buffer);
	virtual CoreResponse GetObjectLevel(CObject* Object, int* Buffer);
	virtual CoreResponse GetObjectPenetration(CObject* Object, Penetration* Buffer);
	virtual CoreResponse GetAllHeroes(std::vector<CObject*> hList);
	virtual CoreResponse GetAllTurrets(std::vector<CObject*> tList);

	virtual CoreResponse GetObjectBasicAttack(CObject* Object, CSpellCastInfo** Buffer);
	virtual CoreResponse GetMissileSpellCastInfo(CObject* Object, CSpellCastInfo** Buffer);
	virtual CoreResponse GetObjectSpellByIndex(CObject* Object, CSpell** Buffer, int Index);
	virtual CoreResponse GetObjectBuffByName(CObject* Object, const char* BuffName, CBuff** Buffer);
public:

	//
	// Buff related
	//

	virtual CoreResponse GetBuffName(CBuff* Buff, char** Buffer);
	virtual CoreResponse GetBuffStartTime(CBuff* Buff, float* Buffer);
	virtual CoreResponse GetBuffExpireTime(CBuff* Buff, float* Buffer);
	virtual CoreResponse GetBuffAltStacks(CBuff* Buff, int* Buffer);
	virtual CoreResponse GetBuffIntStacks(CBuff* Buff, int* Buffer);
public:

	// Spell related

	virtual CoreResponse GetSpellData(CSpell* Spell, CSpellData** Buffer);
	virtual CoreResponse GetSpellLevel(CSpell* Spell, int* Buffer);
	virtual CoreResponse GetSpellTimer(CSpell* Spell, float* Buffer);
	virtual CoreResponse CastTargettedSpell(int SpellIndex, CObject* Target);
	virtual CoreResponse CastSelfSpell(int SpellIndex);
	virtual CoreResponse CastPositionedSpell(int SpellIndex, Vector TargetPos);
	virtual CoreResponse GetSpellState(int SpellIndex, int* Buffer);
public:

	// SpellCastInfo related

	virtual CoreResponse GetMissileSpellData(CSpellCastInfo* SpellCastInfo, CSpellData** Buffer);
	virtual CoreResponse GetMissileStartTime(CSpellCastInfo* SpellCastInfo, float* Buffer);
	virtual CoreResponse GetMissileSpellLevel(CSpellCastInfo* SpellCastInfo, int* Buffer);
	virtual CoreResponse GetMissileCaster(CSpellCastInfo* SpellCastInfo, CObject** Buffer);
	virtual CoreResponse GetMissileStartPos(CSpellCastInfo* SpellCastInfo, Vector* Buffer);
	virtual CoreResponse GetMissileEndPos(CSpellCastInfo* SpellCastInfo, Vector* Buffer);
	virtual CoreResponse IsMissileTargetted(CSpellCastInfo* SpellCastInfo, bool* Buffer);
	virtual CoreResponse GetMissileTarget(CSpellCastInfo* SpellCastInfo, CObject** Buffer);
	virtual CoreResponse GetMissileCastDelay(CSpellCastInfo* SpellCastInfo, float* Buffer);
	virtual CoreResponse GetMissileCoolDown(CSpellCastInfo* SpellCastInfo, float* Buffer);
	virtual CoreResponse IsMissileBasicAttack(CSpellCastInfo* SpellCastInfo, bool* Buffer);
	virtual CoreResponse GetMissileSpellIndex(CSpellCastInfo* SpellCastInfo, int* Buffer);
	virtual CoreResponse GetMissileSpellManaCosts(CSpellCastInfo* SpellCastInfo, float* Buffer);
	virtual CoreResponse GetMissileRadius(CSpellCastInfo* SpellCastInfo, float* Buffer);

	virtual CoreResponse GetMissileSpeed(CSpellCastInfo* SpellCastInfo, float* Buffer);
public:

	// Drawing related

	virtual CoreResponse DrawNative3DCircle(Vector Pos, float radius, int r, int g, int b, int alpha);
public:

	// IssueOrder related

	virtual CoreResponse IssueMove(Vector Pos);
	virtual CoreResponse IssueAttack(CObject* Target);

public:

	// Game related

	virtual CoreResponse GetGameTime(float* Buffer);
	virtual CoreResponse GetGameVersion(char** Buffer);
	virtual CoreResponse GetGamePing(int* Buffer);
	virtual CoreResponse GetMousePosition(Vector* Buffer);
	virtual CoreResponse PrintChat(const char* Message, DWORD ChatFlags);
	virtual CoreResponse SetMinZoom(float Value);
	virtual CoreResponse SetMaxZoom(float Value);
public:

	// Core related

	virtual CoreResponse SendDebugMessage(const char* Message, ...);
	virtual CoreResponse RegisterCallback(void* Callback, int CallbackType);
	virtual CoreResponse UnRegisterCallback(void* Callback, int CallbackType);
};
extern CSDKExports SDKExports;