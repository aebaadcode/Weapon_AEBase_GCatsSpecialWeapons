//we need the base add-on for this, so force it to load
%error = ForceRequiredAddOn("Weapon_AEBase");

if(%error == $Error::AddOn_NotFound)
{
	//we don't have the base, so we're screwed =(
	error("ERROR: AEBase_GCatsSpecialWeapons - required add-on Weapon_AEBase not found");
}
else
{
	exec("./Sounds/Sounds.cs");
	exec("./Support_EffectDatablocks.cs");
	
	exec("./Weapon_XCR.cs");
	exec("./Weapon_XCRSD.cs");
	exec("./Weapon_Remington870.cs");
	exec("./Weapon_Glock19.cs");
	exec("./Weapon_Glock19SD.cs");
	exec("./Weapon_M21.cs");
	exec("./Weapon_M21SD.cs");
	exec("./Weapon_M79.cs");
	exec("./Weapon_SKS.cs");
	exec("./Weapon_SKSScoped.cs");
	exec("./Weapon_SPAS12.cs");
	exec("./Weapon_M1014.cs");
	exec("./Weapon_Jackhammer.cs");
	exec("./Weapon_Striker.cs");
	exec("./Weapon_SawnOffShotty.cs");
	exec("./Weapon_M249.cs");
	exec("./Weapon_MG3.cs");
	exec("./Weapon_G11.cs");
	exec("./Weapon_FG42.cs");
	exec("./Weapon_P90.cs");
	exec("./Weapon_P90SD.cs");
	exec("./Weapon_L85A2.cs");
	exec("./Weapon_L85A2SD.cs");
	exec("./Weapon_M1911.cs");
	exec("./Weapon_M1911SD.cs");
	exec("./Weapon_FNP45.cs");
	exec("./Weapon_FNP45SD.cs");
	exec("./Weapon_Scorpion.cs");
	exec("./Weapon_ScorpionSD.cs");
	exec("./Weapon_Veresk.cs");
	exec("./Weapon_VereskSD.cs");
	exec("./Weapon_AKS74u.cs");
	exec("./Weapon_AKS74uSD.cs");
	exec("./Weapon_C14.cs");
	exec("./Weapon_R700.cs");
	exec("./Weapon_R700SD.cs");
	exec("./Weapon_RPG7.cs");
}