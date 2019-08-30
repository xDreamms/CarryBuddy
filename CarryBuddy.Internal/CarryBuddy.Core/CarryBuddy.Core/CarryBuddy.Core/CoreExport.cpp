#include "stdafx.h"

CSDKExports SDKExports;

extern "C" __declspec(dllexport) CSDKExports* GetCBSDK() {
	return &SDKExports;
}

//
// Object related
//

CoreResponse CSDKExports::GetLocalPlayer(CObject** Buffer) {
	CObject* LocalObject = Engine::GetLocalObject();
	if (!LocalObject) {
		return CB_ERROR_INTERNALERROR;
	}

	*Buffer = LocalObject;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectTeamID(CObject* Object, int* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetTeam();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectSummonerName(CObject* Object, const char** Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetName();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectNetworkID(CObject* Object, DWORD* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetNetworkID();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectPosition(CObject* Object, Vector* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetPos();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsObjectVisible(CObject* Object, bool* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->IsVisible();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectCurrentMana(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetCurrentMana();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectMaxMana(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetMaxMana();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectHealth(CObject* Object, Health* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	Buffer->Current = Object->GetCurrentHealth();
	Buffer->Max = Object->GetMaxHealth();
	Buffer->Shield = Object->GetShield();
	Buffer->MagicShield = Object->GetMagicShield();
	Buffer->PhysicalShield = Object->GetPhysicalShield();
	return CB_ERROR_NOERROR;
}


CoreResponse CSDKExports::GetObjectBaseAD(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetBaseAD();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectBonusAD(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetBonusAD();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectTotalAD(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetTotalAD();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectBonusAP(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetBonusAP();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectCurrentArmor(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetArmor();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectBonusArmor(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetBonusArmor();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectCurrentMagicResistance(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetMagicResistance();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectBonusMagicResistance(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetBonusMagicResistance();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectAttackRange(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetAttackRange();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectBoundingRadius(CObject* Object, float* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetBoundingRadius();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectCombatType(CObject* Object, int* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetCombatType();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectAttackDelay(CObject* Object, float* Buffer) 
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Functions.GetAttackDelay(Object);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectAttackCastDelay(CObject* Object, float* Buffer) 
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Functions.GetAttackCastDelay(Object);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsObjectAlive(CObject* Object, bool* Buffer) 
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->IsAlive();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsObjectTargetable(CObject* Object, bool* Buffer) 
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Functions.IsTargetable(Object);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsObjectHero(CObject* Object, bool* Buffer) 
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->IsHero();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsObjectMinion(CObject* Object, bool* Buffer) 
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->IsMinion();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsObjectMissile(CObject* Object, bool* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->IsMissile();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsObjectTurret(CObject* Object, bool* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->IsTurret();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectLevel(CObject* Object, int* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetLevel();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectPenetration(CObject* Object, Penetration* Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	Buffer->FlatMagic = Object->GetFlatMagicPen();
	Buffer->PercMagic = Object->GetPercMagicPenMod();
	Buffer->Lethality = Object->GetLethality();
	Buffer->PercPhysical = Object->GetPercAttackDamageMod();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetAllHeroes(std::vector<CObject*> hList)
{
	hList = HeroList;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetAllTurrets(std::vector<CObject*> tList)
{
	tList = TurretList;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectBasicAttack(CObject* Object, CSpellCastInfo** Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Functions.GetBasicAttack(Object, 0);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileSpellCastInfo(CObject* Object, CSpellCastInfo** Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetSpellCastInfo();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectSpellByIndex(CObject* Object, CSpell** Buffer, int Index)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	*Buffer = Object->GetSpell(Index);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetObjectBuffByName(CObject* Object, const char* BuffName, CBuff** Buffer)
{
	if (!Object) {
		return CB_ERROR_INVALIDOBJECT;
	}

	CBuff* ret = Object->GetBuffManager()->FindBuff(BuffName);

	if (!ret || (DWORD)ret == 0xCCCCCCCC) {
		*Buffer = 0;
		return CB_ERROR_INTERNALERROR;
	}

	*Buffer = ret;
	return CB_ERROR_NOERROR;
}

// 
// Buff related
//

CoreResponse CSDKExports::GetBuffName(CBuff* Buff, char** Buffer)
{
	*Buffer = Buff->GetName();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetBuffStartTime(CBuff* Buff, float* Buffer)
{
	*Buffer = Buff->StartTime;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetBuffExpireTime(CBuff* Buff, float* Buffer)
{
	*Buffer = Buff->ExpireTime;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetBuffAltStacks(CBuff* Buff, int* Buffer)
{
	*Buffer = Buff->GetStacksAlt();
	return CB_ERROR_NOERROR;
}
CoreResponse CSDKExports::GetBuffIntStacks(CBuff* Buff, int* Buffer)
{
	*Buffer = Buff->StacksI;
	return CB_ERROR_NOERROR;
}

//
// Spell related
//

CoreResponse CSDKExports::GetSpellData(CSpell* Spell, CSpellData** Buffer)
{
	*Buffer = Spell->SpellInfo->SpellData;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetSpellLevel(CSpell* Spell, int* Buffer)
{
	*Buffer = Spell->Level;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetSpellTimer(CSpell* Spell, float* Buffer)
{
	*Buffer = Spell->Timer;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::CastTargettedSpell(int SpellIndex, CObject* Target)
{
	static DWORD SpellBook = me->GetSpellBook();
	Functions.CastSpell(SpellBook, me->GetSpell(SpellIndex), SpellIndex, &Target->GetPos(), &Target->GetPos(), Target->GetNetworkID());
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::CastSelfSpell(int SpellIndex) {
	static DWORD SpellBook = me->GetSpellBook();
	Functions.CastSpell(SpellBook, me->GetSpell(SpellIndex), SpellIndex, &me->GetPos(), &me->GetPos(), 0);
	return CB_ERROR_NOERROR;
}
CoreResponse CSDKExports::CastPositionedSpell(int SpellIndex, Vector TargetPos)
{
	static DWORD SpellBook = me->GetSpellBook();
	Functions.CastSpell(SpellBook, me->GetSpell(SpellIndex), SpellIndex, &TargetPos, &me->GetPos(), 0);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetSpellState(int SpellIndex, int* Buffer)
{
	static DWORD SpellBook = me->GetSpellBook();
	static byte t = 0;
	*Buffer = Functions.GetSpellState(SpellBook, SpellIndex, &t);
	return CB_ERROR_NOERROR;
}

//
// SpellCastInfo related
//

CoreResponse CSDKExports::GetMissileSpellData(CSpellCastInfo* SpellCastInfo, CSpellData** Buffer)
{
	*Buffer = SpellCastInfo->SpellInfo->SpellData;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileStartTime(CSpellCastInfo* SpellCastInfo, float* Buffer)
{
	*Buffer = SpellCastInfo->StarTime;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileSpellLevel(CSpellCastInfo* SpellCastInfo, int* Buffer)
{
	*Buffer = SpellCastInfo->Level;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileCaster(CSpellCastInfo* SpellCastInfo, CObject** Buffer)
{
	*Buffer = ObjectManager->pObjectArray[SpellCastInfo->CasterIndex];
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileStartPos(CSpellCastInfo* SpellCastInfo, Vector* Buffer)
{
	*Buffer = SpellCastInfo->StartPos;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileEndPos(CSpellCastInfo* SpellCastInfo, Vector* Buffer)
{
	*Buffer = SpellCastInfo->EndPos;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsMissileTargetted(CSpellCastInfo* SpellCastInfo, bool* Buffer)
{
	*Buffer = SpellCastInfo->HasTarget;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileTarget(CSpellCastInfo* SpellCastInfo, CObject** Buffer)
{
	if (!SpellCastInfo->HasTarget) {
		return CB_ERROR_INTERNALERROR;
	}

	*Buffer = ObjectManager->pObjectArray[SpellCastInfo->TargetIndex];
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileCastDelay(CSpellCastInfo* SpellCastInfo, float* Buffer)
{
	*Buffer = SpellCastInfo->CastDelay;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileCoolDown(CSpellCastInfo* SpellCastInfo, float* Buffer)
{
	*Buffer = SpellCastInfo->CoolDown;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IsMissileBasicAttack(CSpellCastInfo* SpellCastInfo, bool* Buffer)
{
	*Buffer = SpellCastInfo->IsBasicAttack;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileSpellIndex(CSpellCastInfo* SpellCastInfo, int* Buffer)
{
	*Buffer = SpellCastInfo->SpellIndex;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileSpellManaCosts(CSpellCastInfo* SpellCastInfo, float* Buffer)
{
	*Buffer = SpellCastInfo->ManaCosts;
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMissileRadius(CSpellCastInfo* SpellCastInfo, float* Buffer)
{
	*Buffer = SpellCastInfo->Radius;
	return CB_ERROR_NOERROR;
}


CoreResponse CSDKExports::GetMissileSpeed(CSpellCastInfo* SpellCastInfo, float* Buffer)
{
	*Buffer = SpellCastInfo->SpellInfo->SpellData->MissileSped;
	return CB_ERROR_NOERROR;
}

//
// Drawing related
//

CoreResponse CSDKExports::DrawNative3DCircle(Vector Pos, float radius, int r, int g, int b, int alpha) 
{
	int Color = createRGB(r, g, b);
	Functions.DrawCircle(&Pos, radius, &Color, 0, 0.0f, 0, alpha / 255);
	return CB_ERROR_NOERROR;
}

// 
// IssueOrder related
//

CoreResponse CSDKExports::IssueMove(Vector Pos)
{
	Functions.IssueOrder(me, 2, &Pos, 0, false, false, false);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::IssueAttack(CObject* Target)
{
	if (Target->IsMinion()) {
		Functions.IssueOrder(me, 3, &Target->GetPos(), Target, true, true, false);
		return CB_ERROR_NOERROR;
	}
	else if (Target->IsHero()) {
		Functions.IssueOrder(me, 3, &Target->GetPos(), Target, true, false, false);
		return CB_ERROR_NOERROR;
	}
	else if (Target->IsTurret()) {
		Functions.IssueOrder(me, 7, &Target->GetPos(), Target, true, true, false);
		return CB_ERROR_NOERROR;
	}
	else {
		return CB_ERROR_INTERNALERROR;
	}
}

// 
// Game related
//

CoreResponse CSDKExports::GetGameTime(float* Buffer) 
{
	*Buffer = Engine::GetGameTime();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetGameVersion(char** Buffer) 
{
	*Buffer = Engine::GetGameVersion();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetGamePing(int* Buffer) 
{
	*Buffer = Engine::GetPing();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::GetMousePosition(Vector* Buffer) 
{
	*Buffer = Engine::GetMouseWorldPosition();
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::PrintChat(const char* Message, DWORD ChatFlags)
{
	Engine::PrintChat(Message, ChatFlags);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::SetMinZoom(float Value)
{
	Engine::SetMinZoom(Value);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::SetMaxZoom(float Value)
{
	Engine::SetMaxZoom(Value);
	return CB_ERROR_NOERROR;
}

// 
// Core related
//

CoreResponse CSDKExports::SendDebugMessage(const char* Message, ...) 
{
	va_list args;
	va_start(args, Message);
	DebugConsole._SendDebugMessage(Message, args);
	va_end(args);
	return CB_ERROR_NOERROR;
}

CoreResponse CSDKExports::RegisterCallback(void* Callback, int CallbackType) 
{
	if (Callbacks::RegisterCallback(Callback, CallbackType)) {
		return CB_ERROR_NOERROR;
	}
	return CB_ERROR_INVALIDCALLBACK;
}

CoreResponse CSDKExports::UnRegisterCallback(void* Callback, int CallbackType)
{
	if (Callbacks::UnRegisterCallback(Callback, CallbackType)) {
		return CB_ERROR_NOERROR;
	}
	return CB_ERROR_INVALIDCALLBACK;
}