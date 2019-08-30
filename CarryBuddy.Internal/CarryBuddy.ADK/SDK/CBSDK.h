#pragma once
#include <Windows.h>
#include <math.h>
#include <vector>

#ifndef SDK_CUSTOM_VECTOR
typedef struct
{
	float x, y, z;
} Vector3;
static_assert(sizeof(Vector3) == 12, "Invalid size");
#endif

typedef DWORD CoreResponse;
typedef DWORD GameObject;
typedef DWORD SpellCastInfo;
typedef DWORD Spell;
typedef DWORD SpellData;
typedef DWORD Buff;

#define CB_ERROR_NOERROR 0x0
#define CB_ERROR_INVALIDOBJECT 0x1
#define CB_ERROR_INTERNALERROR 0x2
#define CB_ERROR_INVALIDCALLBACK 0x3

#define CALLBACK_ONDRAW 0x1
#define CALLBACK_ENUMOBJECT 0x2
#define CALLBACK_CREATEOBJECT 0x3
#define CALLBACK_DELETEOBJECT 0x4

class SDKInterface;
HMODULE CBModule;
static bool GetSDKInterface(__out SDKInterface** Interface) {
	if (!CBModule) {
		CBModule = LoadLibrary("CarryBuddy.Core.dll");
	}

	if (!CBModule) {
		return false;
	}

	typedef SDKInterface*(__cdecl* fnGetSDK)();
	fnGetSDK GetSDK = (fnGetSDK)GetProcAddress(CBModule, "GetCBSDK");
	*Interface = GetSDK();
	return true;
}

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

class SDKInterface {
public:

	// Object related

	virtual CoreResponse GetLocalPlayer(GameObject* Buffer) = 0;
	virtual CoreResponse GetObjectTeamID(GameObject Object, int* Buffer) = 0;
	virtual CoreResponse GetObjectSummonerName(GameObject Object, const char** Buffer) = 0;
	virtual CoreResponse GetObjectNetworkID(GameObject Object, DWORD* Buffer) = 0;
	virtual CoreResponse GetObjectPosition(GameObject Object, Vector3* Buffer) = 0;
	virtual CoreResponse IsObjectVisible(GameObject Object, bool* Buffer) = 0;
	virtual CoreResponse GetObjectCurrentMana(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectMaxMana(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectHealth(GameObject Object, Health* Buffer) = 0;
	virtual CoreResponse GetObjectBaseAD(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectBonusAD(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectTotalAD(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectBonusAP(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectCurrentArmor(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectBonusArmor(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectCurrentMagicResistance(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectBonusMagicResistance(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectAttackRange(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectBoundingRadius(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectCombatType(GameObject Object, int* Buffer) = 0;
	virtual CoreResponse GetObjectAttackDelay(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse GetObjectAttackCastDelay(GameObject Object, float* Buffer) = 0;
	virtual CoreResponse IsObjectAlive(GameObject Object, bool* Buffer) = 0;
	virtual CoreResponse IsObjectTargetable(GameObject Object, bool* Buffer) = 0;
	virtual CoreResponse IsObjectHero(GameObject Object, bool* Buffer) = 0;
	virtual CoreResponse IsObjectMinion(GameObject Object, bool* Buffer) = 0;
	virtual CoreResponse IsObjectTurret(GameObject Object, bool* Buffer) = 0;
	virtual CoreResponse IsObjectMissile(GameObject Object, bool* Buffer) = 0;
	virtual CoreResponse GetObjectLevel(GameObject Object, int* Buffer) = 0;
	virtual CoreResponse GetObjectPenetration(GameObject Object, Penetration* Buffer) = 0;
	virtual CoreResponse GetAllHeroes(std::vector<GameObject> hList) = 0;
	virtual CoreResponse GetAllTurrets(std::vector<GameObject> tList) = 0;

	virtual CoreResponse GetObjectBasicAttack(GameObject Object, SpellCastInfo* Buffer) = 0;
	virtual CoreResponse GetMissileSpellCastInfo(GameObject Object, SpellCastInfo* Buffer) = 0;
	virtual CoreResponse GetObjectSpellByIndex(GameObject Object, Spell* Buffer, int Index) = 0;
	virtual CoreResponse GetObjectBuffByName(GameObject Object, const char* BuffName, Buff* Buffer) = 0;
public:

	//
	// Buff related
	//

	virtual CoreResponse GetBuffName(Buff Buff, char** Buffer) = 0;
	virtual CoreResponse GetBuffStartTime(Buff Buff, float* Buffer) = 0;
	virtual CoreResponse GetBuffExpireTime(Buff Buff, float* Buffer) = 0;
	virtual CoreResponse GetBuffAltStacks(Buff Buff, int* Buffer) = 0;
	virtual CoreResponse GetBuffIntStacks(Buff Buff, int* Buffer) = 0;

public:

	// Spell related

	virtual CoreResponse GetSpellData(Spell Spell, SpellData* Buffer) = 0;
	virtual CoreResponse GetSpellLevel(Spell Spell, int* Buffer) = 0;
	virtual CoreResponse GetSpellTimer(Spell Spell, float* Buffer) = 0;
	virtual CoreResponse CastTargettedSpell(int SpellIndex, GameObject Target) = 0;
	virtual CoreResponse CastSelfSpell(int SpellIndex) = 0;
	virtual CoreResponse CastPositionedSpell(int SpellIndex, Vector3 TargetPos) = 0;
	virtual CoreResponse GetSpellState(int SpellIndex, int* Buffer) = 0;
public:

	// SpellCastInfo related

	virtual CoreResponse GetMissileSpellData(SpellCastInfo SpellCastInfo, SpellData* Buffer) = 0;
	virtual CoreResponse GetMissileStartTime(SpellCastInfo SpellCastInfo, float* Buffer) = 0;
	virtual CoreResponse GetMissileSpellLevel(SpellCastInfo SpellCastInfo, int* Buffer) = 0;
	virtual CoreResponse GetMissileCaster(SpellCastInfo SpellCastInfo, GameObject* Buffer) = 0;
	virtual CoreResponse GetMissileStartPos(SpellCastInfo SpellCastInfo, Vector3* Buffer) = 0;
	virtual CoreResponse GetMissileEndPos(SpellCastInfo SpellCastInfo, Vector3* Buffer) = 0;
	virtual CoreResponse IsMissileTargetted(SpellCastInfo SpellCastInfo, bool* Buffer) = 0;
	virtual CoreResponse GetMissileTarget(SpellCastInfo SpellCastInfo, GameObject* Buffer) = 0;
	virtual CoreResponse GetMissileCastDelay(SpellCastInfo SpellCastInfo, float* Buffer) = 0;
	virtual CoreResponse GetMissileCoolDown(SpellCastInfo SpellCastInfo, float* Buffer) = 0;
	virtual CoreResponse IsMissileBasicAttack(SpellCastInfo SpellCastInfo, bool* Buffer) = 0;
	virtual CoreResponse GetMissileSpellIndex(SpellCastInfo SpellCastInfo, int* Buffer) = 0;
	virtual CoreResponse GetMissileSpellManaCosts(SpellCastInfo SpellCastInfo, float* Buffer) = 0;
	virtual CoreResponse GetMissileRadius(SpellCastInfo SpellCastInfo, float* Buffer) = 0;

	virtual CoreResponse GetMissileSpeed(SpellCastInfo SpellCastInfo, float* Buffer) = 0;
public:

	// Drawing related

	virtual CoreResponse DrawNative3DCircle(Vector3 Pos, float radius, int r, int g, int b, int alpha) = 0;
public:

	// IssueOrder related

	virtual CoreResponse IssueMove(Vector3 Pos) = 0;
	virtual CoreResponse IssueAttack(GameObject Target) = 0;

public:

	// Game related

	virtual CoreResponse GetGameTime(float* Buffer) = 0;
	virtual CoreResponse GetGameVersion(char** Buffer) = 0;
	virtual CoreResponse GetGamePing(int* Buffer) = 0;
	virtual CoreResponse GetMousePosition(Vector3* Buffer) = 0;
	virtual CoreResponse PrintChat(const char* Message, DWORD ChatFlags) = 0;
	virtual CoreResponse SetMinZoom(float Value) = 0;
	virtual CoreResponse SetMaxZoom(float Value) = 0;
public:

	// Core related

	virtual CoreResponse SendDebugMessage(const char* Message, ...) = 0;
	virtual CoreResponse RegisterCallback(void* Callback, int CallbackType) = 0;
	virtual CoreResponse UnRegisterCallback(void* Callback, int CallbackType) = 0;
};
