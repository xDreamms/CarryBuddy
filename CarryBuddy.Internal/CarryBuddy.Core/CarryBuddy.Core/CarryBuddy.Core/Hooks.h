#pragma once
#include "stdafx.h"

HRESULT WINAPI HPresent(IDirect3DDevice9* Device, CONST RECT *pSrcRect, CONST RECT *pDestRect, HWND hDestWindow, CONST RGNDATA *pDirtyRegion);

typedef HRESULT(WINAPI* fnPresent)(IDirect3DDevice9*, CONST RECT*, CONST RECT*, HWND, CONST RGNDATA*);
extern fnPresent OPresent;