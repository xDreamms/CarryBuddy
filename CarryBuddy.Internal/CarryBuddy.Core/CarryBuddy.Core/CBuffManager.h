#pragma once
#include "CBuff.h"

class CBuffManager {
public:
	union {
		DEFINE_MEMBER_0(void* Base, 0x0);
		DEFINE_MEMBER_N(CBuff** BuffStart, 0x10);
		DEFINE_MEMBER_N(CBuff** BuffEnd, 0x14);
	};

	CBuff* FindBuff(const char* Name) {

		for (DWORD BuffPtr = (DWORD)BuffStart; BuffPtr != (DWORD)BuffEnd; BuffPtr += 0x8) {
			CBuff* Buff = *(CBuff**)BuffPtr;

			if (Buff == nullptr) {
				continue;
			}

			if (!Buff->NameC) {
				continue;
			}

			if (!Buff->NameC->Name) {
				continue;
			}

			if (!strcmp(Buff->GetName(), Name)) {
				return Buff;
			}
		}
		return 0;
	}
};