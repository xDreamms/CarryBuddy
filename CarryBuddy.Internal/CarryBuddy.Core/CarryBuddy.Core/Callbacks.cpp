#include "stdafx.h"
#include "Callbacks.h"


struct CreatedObjectInfo
{
	CObject* Object;
	bool found;
};

std::map<size_t, CreatedObjectInfo> CreatedObjectMap;
void Callbacks::CheckForCreatedObject(CObject* Object) {
	size_t netID = Object->GetNetworkID();

	if (CreatedObjectMap.find(netID) == CreatedObjectMap.end()) { //not Found
		CreatedObjectMap.insert({ netID, {Object, true} });
		Callbacks::CreateObject(Object);
	}
	else { //Found - already in list The object still exist
		CreatedObjectMap[netID].found = true;
	}
}

void Callbacks::CheckForDeletedObjects() {
	for (std::map<size_t, CreatedObjectInfo>::iterator it = CreatedObjectMap.begin(); it != CreatedObjectMap.end(); ++it) {
		if (!it->second.found) {
			Callbacks::DeleteObject(it->second.Object);
			CreatedObjectMap.erase(it->first);
		}
		else
			it->second.found = false;
	}
}

typedef void(__cdecl* fnCreateObject)(CObject* Object);
std::vector<fnCreateObject> CreateObjectCallbacks;
void Callbacks::CreateObject(CObject* Object) {

	for (auto const& Callback : CreateObjectCallbacks) {
		Callback(Object);
	}
	
}

typedef void(__cdecl* fnDeleteObject)(CObject* Object);
std::vector<fnDeleteObject> DeleteObjectCallbacks;
void Callbacks::DeleteObject(CObject* Object) {

	for (auto const& Callback : DeleteObjectCallbacks) {
		Callback(Object);
	}
	
}

typedef void(__cdecl* fnOnDraw)();
std::vector<fnOnDraw> OnDrawCallbacks;
void Callbacks::OnDraw() {
	Callbacks::CheckForDeletedObjects();

	for (auto const& Callback : OnDrawCallbacks) {
		Callback();
	}
}


typedef void(__cdecl* fnEnumObject)(CObject* Object);
std::vector<fnEnumObject> EnumObjectCallbacks;
void Callbacks::EnumObject(CObject* Object) {
	Callbacks::CheckForCreatedObject(Object);

	for (auto const& Callback : EnumObjectCallbacks) {
		Callback(Object);
	}
}

bool Callbacks::RegisterCallback(void* Callback, int CallbackType) {

	if (CallbackType == CALLBACK_ONDRAW) {
		OnDrawCallbacks.push_back((fnOnDraw)Callback);
		return true;
	}
	else if (CallbackType == CALLBACK_ENUMOBJECT) {
		EnumObjectCallbacks.push_back((fnEnumObject)Callback);
		return true;
	} 
	else if (CallbackType == CALLBACK_CREATEOBJECT) {
		CreateObjectCallbacks.push_back((fnCreateObject)Callback);
		return true;
	}
	else if (CallbackType == CALLBACK_DELETEOBJECT) {
		DeleteObjectCallbacks.push_back((fnDeleteObject)Callback);
		return true;
	}
	else {
		return false;
	}
}

bool Callbacks::UnRegisterCallback(void* Callback, int CallbackType) {
	if (CallbackType == CALLBACK_ONDRAW) {
		std::vector<fnOnDraw>::iterator it = std::find(OnDrawCallbacks.begin(), OnDrawCallbacks.end(), Callback);
		OnDrawCallbacks.erase(it);
	}
	else if (CallbackType == CALLBACK_ENUMOBJECT) {
		std::vector<fnEnumObject>::iterator it = std::find(EnumObjectCallbacks.begin(), EnumObjectCallbacks.end(), Callback);
		EnumObjectCallbacks.erase(it);
	}
	else if (CallbackType == CALLBACK_CREATEOBJECT) {
		std::vector<fnCreateObject>::iterator it = std::find(CreateObjectCallbacks.begin(), CreateObjectCallbacks.end(), Callback);
		CreateObjectCallbacks.erase(it);
	}
	else if (CallbackType == CALLBACK_DELETEOBJECT) {
		std::vector<fnDeleteObject>::iterator it = std::find(DeleteObjectCallbacks.begin(), DeleteObjectCallbacks.end(), Callback);
		DeleteObjectCallbacks.erase(it);
	}
	else {
		return false;
	}
}