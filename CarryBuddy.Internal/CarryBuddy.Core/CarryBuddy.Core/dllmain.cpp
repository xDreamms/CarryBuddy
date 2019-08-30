#include "stdafx.h"
#include "CarryBuddy.Core.h"
#include "Engine.h"
#include "AIHeroClient.h"
#include "Object.h"
#include <Windows.h>
#include <time.h>
#include "GameFunctions.h"
#include <string>
#include "StaticEnums.h"
#include "Vector.h"
#include "HookManager.h"

HMODULE DLLModule;


CObjectManager* ObjectManager;
CFunctions Functions;
CDebugConsole DebugConsole;
CHookManager HookManager;
DWORD BaseAddress;
std::vector<CObject*> HeroList;
std::vector<CObject*> TurretList;

void __stdcall Start() {
	BaseAddress = (DWORD)GetModuleHandle(NULL);

	ObjectManager = (CObjectManager*)(BaseAddress + oObjManager);
	Functions.PrintChat = (Typedefs::fnPrintChat)(BaseAddress + oPrintChat);
	Functions.IsTargetable = (Typedefs::fnIsTargetable)(BaseAddress + oIsTargetable);
	Functions.IsAlive = (Typedefs::fnIsAlive)(BaseAddress + oIsAlive);
	Functions.IsMinion = (Typedefs::fnIsMinion)(BaseAddress + oIsMinion);
	Functions.IsTurret = (Typedefs::fnIsTurret)(BaseAddress + oIsTurret);
	Functions.IsHero = (Typedefs::fnIsHero)(BaseAddress + oIsHero);
	Functions.IsMissile = (Typedefs::fnIsMissile)(BaseAddress + oIsMissile);
	Functions.IsNexus = (Typedefs::fnIsNexus)(BaseAddress + oIsNexus);
	Functions.IsInhibitor = (Typedefs::fnIsInhibitor)(BaseAddress + oIsInhib);
	Functions.IsTroyEnt = (Typedefs::fnIsTroyEnt)(BaseAddress + oIsTroy);
	Functions.CastSpell = (Typedefs::fnCastSpell)(BaseAddress + oCastSpell);
	Functions.IssueOrder = (Typedefs::fnIssueOrder)(BaseAddress + oIssueOrder);
	Functions.DrawCircle = (Typedefs::fnDrawCircle)(BaseAddress + oDrawCircle);
	Functions.GetAttackCastDelay = (Typedefs::fnGetAttackCastDelay)(BaseAddress + oGetAttackCastDelay);
	Functions.GetAttackDelay = (Typedefs::fnGetAttackDelay)(BaseAddress + oGetAttackDelay);
	Functions.GetPing = (Typedefs::fnGetPing)(BaseAddress + oGetPing);
	Functions.WorldToScreen = (Typedefs::fnWorldToScreen)(BaseAddress + oWorldToScreen);
	Functions.GetBasicAttack = (Typedefs::fnGetBasicAttack)(BaseAddress + oGetBasicAttack);
	Functions.GetSpellState = (Typedefs::fnGetSpellState)(BaseAddress + oGetSpellState);
	Functions.DoEmote = (Typedefs::fnDoEmote)(BaseAddress + oDoEmote);
	
	DebugConsole.Allocate("Debug Console");
	HookManager.HookFunctions();
	Core::OnLoadCore(DLLModule);
}






BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
	if (ul_reason_for_call == DLL_PROCESS_ATTACH) {
		CreateThread(0, 0, (LPTHREAD_START_ROUTINE)Start, 0, 0, 0);
		DLLModule = hModule;
		return TRUE;
	}
	return FALSE;
}