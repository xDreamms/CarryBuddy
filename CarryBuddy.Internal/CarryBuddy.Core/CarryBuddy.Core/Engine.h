#pragma once
#include "stdafx.h"
#include "GameFunctions.h"
#include "Vector.h"
#include "Offsets.h"
#include "Modules.h"
#include "ObjectManager.h"
#include "Object.h"


#define me Engine::GetLocalObject()

extern std::vector<CObject*> HeroList;
extern std::vector<CObject*> TurretList;

class Engine {
public:
	
	static Vector GetMouseWorldPosition() {
		DWORD MousePtr = (DWORD)GetModuleHandle(NULL) + oHudInstance;
		auto aux1 = *(DWORD*)MousePtr;
		aux1 += 0x14;
		auto aux2 = *(DWORD*)aux1;
		aux2 += 0x1C;

		float X = *(float*)(aux2 + 0x0);
		float Y = *(float*)(aux2 + 0x4);
		float Z = *(float*)(aux2 + 0x8);

		return Vector{ X, Y, Z };
	}

	static float GetGameTime() {
		return *(float*)(baseAddr + oGameTime);
	}

	static CObject* GetLocalObject() {
		auto retaddr = *(DWORD*)(baseAddr + 0x2F2AFA4);
		if (retaddr == NULL)
			return NULL;

		return (CObject*)retaddr;
	}

	static CObject* GetObjectByID(int ID)
	{
		if (ObjectManager && ID >= 0 && ID <= 10000) {
			return ObjectManager->pObjectArray[ID];
		}
		return NULL;
	}

	static void MoveTo(Vector* pos) {
		Functions.IssueOrder(GetLocalObject(), 2, pos, NULL, false, false, false);
	}

	static float GetAttackSpeed(CObject* obj)
	{
		return 1.0f / Functions.GetAttackDelay(obj);
	}

	static void PrintChat(const char* Message, DWORD ChatFlags) 
	{
		static DWORD ChatClient = *(DWORD*)((DWORD)GetModuleHandle(NULL) + oChatClient);
		Functions.PrintChat(ChatClient, Message, ChatFlags);
	}

	static int GetPing() {
		static DWORD Base = (DWORD)GetModuleHandle(NULL);
		return Functions.GetPing(*(void**)(Base + oNetClient));
	}

	static char* GetGameVersion() {
		static DWORD Base = (DWORD)GetModuleHandle(NULL);
		return (char*)(Base + oGameVersion);
	}

	static void SetMinZoom(float Value) {
		static DWORD Base = (DWORD)GetModuleHandle(NULL);
		static DWORD ZoomClass = *(DWORD*)(Base + oZoomClass);
		*(float*)(ZoomClass + 0x24) = Value;
	}

	static void SetMaxZoom(float Value) {
		static DWORD Base = (DWORD)GetModuleHandle(NULL);
		static DWORD ZoomClass = *(DWORD*)(Base + oZoomClass);
		*(float*)(ZoomClass + 0x28) = Value;
	}

	static void DoEmote(unsigned int Emote) {
		Functions.DoEmote(Emote);
	}
};