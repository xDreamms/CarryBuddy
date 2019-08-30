#define oObjIndex 0x1C
#define oObjTeam 0x0044
#define oObjName 0x0060
#define oObjNetworkID 0xB8
#define oObjSpellCastInfo 0x1F0
#define oObjPos 0x019C
#define oObjCampIndex 0x1F8
#define oObjSourceIndex 0x24C
#define oObjTargetID 0x298 
#define oObjVisibility 0x39C // Needs Pattern
#define oObjMana 0x03F8
#define oObjMaxMana 0x0408
#define oObjAmmo 0x0458
#define oObjRecallState 0xDA4 // Needs Pattern
#define oObjHealth 0xDC4 // Needs Pattern
#define oObjMaxHealth 0xDD4 // Needs Pattern
#define oObjShield 0xE28
#define oObjMagicShield 0xE48
#define oObjFlatArmorPen 0x1184 
#define oObjFlatMagicPen 0x1188
#define oObjPercAttackDamageMod 0x118C
#define oObjBonusArmorPenetration 0x2A0 // ???
#define oObjPercAbilityPowerMod 0x1190
#define oObjLethality 0x11A4
#define oObjBonusAtk 0x11C0 // Needs Pattern
#define oObjBonusAP 0x11D0 // Needs Pattern
#define oObjBaseAtk 0x1240 // Needs Pattern
#define oObjCritMod 0x1264 // Needs Pattern
#define oObjArmor 0x1268 // Needs Pattern
#define oObjBonusArmor 0x128C
#define oObjMR 0x1270 // Needs Pattern
#define oObjBonusMR 0x1274 // Needs Pattern
#define oObjMoveSpeed 0x1280 // Needs Pattern
#define oObjAtkRange 0x1288 // Needs Pattern
#define oObjDirection 0x1B34 // Needs Pattern
#define oObjCombatType 0x2000

#define oObjBuffManager 0x20F0 // Needs Pattern
#define oObjSpellBook 0x28A8 // Needs Pattern
#define oObjChampionName 0x3158 // Needs Pattern
#define oObjLevel 0x49CC // Needs Pattern
#define oObjInventory 0x4998 // 9.9 s
#define oLocalPlayer 0x2F57094 // Needs Pattern

#define oRenderer 0x2F76560 // Needs Pattern Needs Testing
#define oChatClient 0x16B5EC4 // Needs Pattern
#define oGameVersion 0x2F63598 // Needs Pattern Needs Testing
#define oObjManager 0x1678568 // Needs Pattern
#define oGameTime 0x2F534D8 // GameTime = ["edgeTintPoint", +0x31, r+0x04] // search for the string -> xref, go +0x31 there should be a dword, take the address and add 0x04.
#define oZoomClass 0x2F533C8 // Needs Pattern
#define oHudInstance 0x16B866C // Needs Pattern
#define oNetClient 0x2F5D6BC // Needs Pattern Needs Testing
#define oUnderMouseObject 0x2308e74 // Needs Pattern
#define oGameInfo 0x2F54650 // Needs Pattern Needs Testing

#define oCastSpell 0x5BEBE0 // E8 ? ? ? ? 8B 7C 24 10 5D

#define oIsTroy 0x224FD0 // E8 ? ? ? ? 8B F0 83 C4 04 85 F6 74 50 8B 0E  Function Just Above IsTroy E8 ? ? ? ? 83 C4 04 85 C0 74 1B 50
#define oIsMissile 0x224D50 // "E8 ? ? ? ? 83 C4 04 84 C0 74 53 6A 20", sub
#define oIsNotWall 0x770170 // "E8 ? ? ? ? 57 8A D8", sub
#define oIsTargetable 0x21D920 // "idlein" || "56 8B F1 E8 ? ? ? ? 84 C0 74 2E", -0x4f7 || 0x00
#define oIsNexus 0x224C70 // "E8 ? ? ? ? 53 88 45 00", sub
#define oIsHero 0x224CF0 // "E8 ? ? ? ? 83 C4 04 84 C0 75 22", sub
#define oIsDragon 0x212B90 // "Dragon", -0x3c
#define oIsMinion 0x224D30 // "E8 ? ? ? ? 83 C4 04 80 7F 4E 06", sub
#define oIsBaron 0x213740 // "SRU_Baron", -0x28
#define oIsAlive 0x1E0750 // "BUFFBONE_GLB_LAYOUT_LOC", -0x103
#define oIsInhib 0x224B70 // "E8 ? ? ? ? 8B 4C 24 30 53", sub
#define oIsTurret 0x224EE0 // "E8 ? ? ? ? 83 C4 04 84 C0 75 7D", sub

#define oDrawCircle 0x5B7B10 // Needs Pattern

#define oUpdateChargeableSpell 0x5C0DB0 // Needs Pattern
#define oPrintChat 0x5EF810 // 83 EC 38 A1 ? ? ? ? 33 C4 89 44 24 34 53 8B 5C 24 44 56
#define oGetBasicAttack 0x1B15C0 // Needs Pattern
#define oIssueOrder 0x1BC510 // Needs Pattern
#define oGetAttackDelay 0x5C52B0 // Needs Pattern
#define oGetAttackCastDelay 0x5C51D0 // Needs Pattern
#define oGetSpellState 0x5B28A0 // Needs Pattern
#define oWorldToScreen 0x7FE0B0 // Needs Pattern
#define oGetCharacterPointer 0x2A1670 // 9.9 f
#define oSetModel 0x21DFB0 // 9.9 f
#define oFindCamp 0x1B24A0 // 9.7 f
#define oGetPing 0x3609C0 // E8 ? ? ? ? 66 89 44 24 ? 8D 74 24 1E
#define oDoEmote 0x63E850 // E8 ? ? ? ? 84 C0 0F 85 ? ? ? ? 8B 0D ? ? ? ? 85 C9 0F 84 ? ? ? ? 8B 81 ? ? ? ? 81 C1 ? ? ? ? FF 50 04 80 B8 ? ? ? ? ? 0F 85 ? ? ? ? 8A 5C 24 14 loc at top
