#include "stdafx.h"
#include "Object.h"
#include "GameFunctions.h"
#include "Engine.h"


bool CObject::IsAlive() {
	return Functions.IsAlive(this) && GetCurrentHealth() > 0.0f;
}

bool CObject::IsMinion() {
	return Functions.IsMinion(this);
}

bool CObject::IsTurret() {
	return Functions.IsTurret(this);
}

bool CObject::IsHero() {
	return Functions.IsHero(this);
}

bool CObject::IsMissile() {
	return Functions.IsMissile(this);
}

bool CObject::IsTargetable() {
	return Functions.IsTargetable(this);
}

bool CObject::IsNexus() {
	return Functions.IsNexus(this);
}

bool CObject::IsInhibitor() {
	return Functions.IsInhibitor(this);
}

bool CObject::IsTroyEnt() {
	return Functions.IsTroyEnt(this);
}