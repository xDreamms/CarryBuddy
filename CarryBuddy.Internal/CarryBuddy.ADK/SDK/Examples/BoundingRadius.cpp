#include <Windows.h>
#include "CBSDK.h"

SDKInterface* SDK;
DWORD LocalPlayer;

void EnumObjectCallback(DWORD Object) {
    bool IsHero;
    SDK->IsObjectHero(Object, &IsHero);

    if (IsHero) {
        Vector Pos;
        SDK->GetObjectPosition(Object, &Pos);
        float BoundingRadius;
        SDK->GetObjectBoundingRadius(Object, &BoundingRadius);

        SDK->DrawNative3DCircle(Pos, BoundingRadius, 0, 255, 0, 255);
    }
}

void __stdcall Start() {
    while (!GetSDKInterface(&SDK)) {
        Sleep(1);
    }

    SDK->GetLocalPlayer(&LocalPlayer);
    SDK->RegisterCallback((void*)EnumObjectCallback, CALLBACK_ENUMOBJECT);
};

BOOL APIENTRY DllMain(HMODULE Module, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    if (ul_reason_for_call == DLL_PROCESS_ATTACH) {
        CreateThread(0, 0, (LPTHREAD_START_ROUTINE)Start, 0, 0, 0);
        return TRUE;
    }

    else if (ul_reason_for_call == DLL_PROCESS_DETACH) {
        return TRUE;
    }
    return FALSE;
}
