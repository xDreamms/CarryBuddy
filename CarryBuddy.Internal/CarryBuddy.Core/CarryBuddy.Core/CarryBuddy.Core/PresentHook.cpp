#include "stdafx.h"
#include "Hooks.h"
#include "Engine.h"


fnPresent OPresent;

HRESULT WINAPI HPresent(IDirect3DDevice9* Device, CONST RECT *pSrcRect, CONST RECT *pDestRect, HWND hDestWindow, CONST RGNDATA *pDirtyRegion) {
	static bool Init = false;

	if (GetAsyncKeyState(VK_F3)) {
		Core::OnUnloadCore();
	}


	if (ObjectManager) {

		for (int i = 0; i < 10000; i++) {
			CObject* Object = ObjectManager->pObjectArray[i];
			if (Object) {

				if (!Init) {
					Init = true;
					if (Object->IsHero()) {
						HeroList.push_back(Object);
					}
					else if (Object->IsTurret()) {
						const char* tmpObjName;
						tmpObjName = Object->GetName();
						std::string str = tmpObjName;
						if (str.find("TurretShrine") == std::string::npos)
						{
							if (Object->GetMaxHealth() > 1)
							{
								TurretList.push_back(Object);
							}
						}
					}

				}

				Callbacks::EnumObject(Object);
			}
		}
	}

	Callbacks::OnDraw();
	return OPresent(Device, pSrcRect, pDestRect, hDestWindow, pDirtyRegion);
}