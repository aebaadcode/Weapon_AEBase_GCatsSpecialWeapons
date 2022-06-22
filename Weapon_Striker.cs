datablock AudioProfile(GCats_StrikerFireSound)
{
   filename    = "./Sounds/Striker.wav";
   description = HeavyClose3D;
   preload = true;
};

AddDamageType("GCats_Striker",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_Striker> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_Striker> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_StrikerItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./Striker/Striker.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: Striker";
	iconName = "./Icons/icon_Striker";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_StrikerImage;
	canDrop = true;
	
	AEAmmo = 12;
	AEType = AE_LightSAmmoItem.getID(); 
	AEBase = 1;

    RPM = 60;
    Recoil = "Heavy";
	uiColor = "1 1 1";
    description = "work in progress";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(GCats_StrikerImage)
{
   // Basic Item properties
	shapeFile = "./Striker/Striker.dts";
   emap = true;

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0;
   offset = "0 0 0";
   eyeOffset = 0; //"0.7 1.2 -0.5";
   rotation = eulerToMatrix( "0 0 0" );

   // When firing from a point offset from the eye, muzzle correction
   // will adjust the muzzle vector to point to the eye LOS point.
   // Since this weapon doesn't actually fire from the muzzle point,
   // we need to turn this off.  
   correctMuzzleVector = true;

   // Add the WeaponImage namespace as a parent, WeaponImage namespace
   // provides some hooks into the inventory system.
   className = "WeaponImage";

   // Projectile && Ammo.
   item = GCats_StrikerItem;
   ammo = " ";
   projectile = AETrailedProjectile;
   projectileType = Projectile;

   casing = GCats_Shell12GRedDebris;
   shellExitDir        = "1 0.3 0.5";
   shellExitOffset     = "0 0 0";
   shellExitVariance   = 25;	
   shellVelocity       = 5.0;

   //melee particles shoot from eye node for consistancy
   melee = false;
   //raise your arm up or not
   armReady = true;
   safetyImage = GCats_StrikerSafetyImage;
   scopingImage = GCats_StrikerIronsightImage;
   doColorShift = true;
   colorShiftColor = GCats_StrikerItem.colorShiftColor;
//   shellSound = AEShellRifle;
//   shellSoundMin = 450; //min delay for when the shell sound plays
//   shellSoundMax = 550; //max delay for when the shell sound plays
	muzzleFlashScale = "1.5 1.5 1.5";
	bulletScale = "1 1 1";

	shellSound = AEShellShotgun;
	shellSoundMin = 500; //min delay for when the shell sound plays
	shellSoundMax = 600; //max delay for when the shell sound plays

    directDamageType = $DamageType::GCats_Striker;
    directHeadDamageType = $DamageType::GCats_Striker;

	projectileDamage = 13;
	projectileCount = 8;
	projectileHeadshotMult = 1.2;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate

	projectileFalloffStart = 8;
	projectileFalloffEnd = 32;
	projectileFalloffDamage = 0.2;

	recoilHeight = 3;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 20;
	spreadBurst = 1; // how much shots it takes to trigger spread i think
	spreadBase = 300;
	spreadReset = 900; // m
	spreadMin = 300;
	spreadMax = 300;
	screenshakeMin = "0.25 0.25 0.25"; 
	screenshakeMax = "0.5 0.5 0.5"; 
	farShotSound = ShottyBDistantSound;
	farShotDistance = 40;

	sonicWhizz = true;
	whizzSupersonic = false;
	whizzThrough = false;
	whizzDistance = 12;
	whizzChance = 100;
	whizzAngle = 80;

   // Images have a state system which controls how the animations
   // are run, which sounds are played, script callbacks, etc. This
   // state system is downloaded to the client so that clients can
   // predict state changes and animate accordingly.  The following
   // system supports basic ready->fire->reload transitions as
   // well as a no-ammo->dryfire idle state.

   // Initial start up state
	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.1;
	stateTransitionOnTimeout[0]       	= "LoadCheckA";
	stateSequence[0]			= "root";

	stateName[1]                    	= "Ready";
	stateScript[1]				= "onReady";
	stateTransitionOnTriggerDown[1] 	= "preFire";
	stateTransitionOnNotLoaded[1]     = "Empty";
	stateTransitionOnNoAmmo[1]		= "Reload";
	stateAllowImageChange[1]		= true;

	stateName[2]                       = "preFire";
	stateTransitionOnTimeout[2]        = "Fire";
//	stateTransitionOnNoAmmo[2]       	= "FireEmpty";
	stateScript[2]                     = "AEOnFire";
	stateEmitter[2]					= AEBaseShotgunFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
	stateFire[2]                       = true;
	stateEjectShell[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "SemiAutoCheck";
	stateEmitter[3]					= AEBaseSmokeBigEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;
	
	stateName[5]				= "FireLoadCheckA";
	stateScript[5]				= "AEMagLoadCheck";
	stateTimeoutValue[5]			= 0.3;
	stateTransitionOnTimeout[5]		= "FireLoadCheckB";
	
	stateName[6]				= "FireLoadCheckB";
	stateTransitionOnAmmo[6]		= "Ready";
	stateTransitionOnNotLoaded[6]  = "Ready";
	stateTransitionOnNoAmmo[6]		= "ReloadStart2";	
	
	stateName[7]				= "LoadCheckA";
	stateScript[7]				= "AELoadCheck";
	stateTimeoutValue[7]			= 0.1;
	stateTransitionOnTimeout[7]		= "LoadCheckB";
						
	stateName[8]				= "LoadCheckB";
	stateTransitionOnAmmo[8]		= "Ready";
	stateTransitionOnNotLoaded[8] = "Empty";
	stateTransitionOnNoAmmo[8]		= "ReloadStart2";	
	
	stateName[9]			  	= "ReloadStart2";
	stateTransitionOnTimeout[9]	  	= "ReloadStart2B";
	stateTimeoutValue[9]			= 0.5;
	stateScript[9]				= "LoadEffect";
	
	stateName[11]				= "ReloadStart2B";
	stateScript[11]				= "AEShotgunAltLoadCheck";
	stateTimeoutValue[11]			= 0.1;
	stateWaitForTimeout[11]		  	= false;
	stateTransitionOnTriggerDown[11]	= "AnotherAmmoCheck";
	stateTransitionOnTimeout[11]	  	= "Reloaded";
	stateTransitionOnNotLoaded[11] = "LoadCheckA";
	
	stateName[12]				= "Reload";
	stateTransitionOnTimeout[12]     	= "Reloaded";
	stateTransitionOnTriggerDown[12]	= "AnotherAmmoCheck";
	stateWaitForTimeout[12]			= false;
	stateTimeoutValue[12]			= 0.5;
	stateScript[12]				= "LoadEffect";
	
	stateName[13]				= "Reloaded";
	stateTransitionOnTimeout[13]     	= "CheckAmmoA";
	stateTransitionOnTriggerDown[13]	= "AnotherAmmoCheck";
	stateWaitForTimeout[13]			= false;
	//stateTimeoutValue[13]			= 0.2;
	
	stateName[14]				= "CheckAmmoA";
	stateTransitionOnTriggerDown[14]	= "AnotherAmmoCheck";
	stateScript[14]				= "AEShotgunLoadCheck";
	stateTransitionOnTimeout[14]		= "CheckAmmoB";	
	
	stateName[15]				= "CheckAmmoB";
	stateTransitionOnTriggerDown[15]	= "AnotherAmmoCheck";
	stateTransitionOnNotLoaded[15]  = "Ready";
	stateTransitionOnAmmo[15]		= "Ready";
	stateTransitionOnNoAmmo[15]		= "Reload";

	stateName[16]          = "Empty";
	stateTransitionOnTriggerDown[16]  = "Dryfire";
	stateTransitionOnLoaded[16] = "ReloadStart2";
	stateScript[16]        = "AEOnEmpty";

	stateName[17]           = "Dryfire";
	stateTransitionOnTriggerUp[17] = "Empty";
	stateWaitForTimeout[17]    = false;
	stateScript[17]      = "onDryFire";
	
	stateName[18]           = "AnotherAmmoCheck"; //heeeey
	stateTransitionOnTimeout[18]	  	= "preFire";
	stateScript[18]				= "AELoadCheck";
	
	stateName[19]           = "SemiAutoCheck"; //heeeeeeeeeeeeey
	stateTransitionOnTriggerUp[19]	  	= "FireLoadCheckA";
};

function GCats_StrikerImage::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(750, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	cancel(%obj.plantshellSchedule);
	cancel(%obj.insertshellSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, GCats_StrikerFireSound);	

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_StrikerImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

function GCats_StrikerImage::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function GCats_StrikerImage::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function GCats_StrikerImage::onUnMount(%this, %obj, %slot)
{	
	%this.AEUnmountCleanup(%obj, %slot);

	cancel(%obj.reloadSoundSchedule);
	cancel(%obj.plantshellSchedule);
	cancel(%obj.insertshellSchedule);
	parent::onUnMount(%this,%obj,%slot);	
}

function GCats_StrikerImage::LoadEffect(%this,%obj,%slot)
{
    %obj.reloadSoundSchedule = schedule(250, %obj, serverPlay3D, "GCats_SPAS12ReloadSound", %obj.getPosition());
    %obj.plantshellSchedule = %obj.schedule(150, "aeplayThread", "3", "plant");
    %obj.insertshellSchedule = %this.schedule(250,AEShotgunLoadOne,%obj,%slot);
}

function GCats_StrikerImage::AEShotgunLoadOneEffectless(%this,%obj,%slot)
{
	Parent::AEShotgunLoadOne(%this, %obj, %slot);
}

datablock ShapeBaseImageData(GCats_StrikerIronsightImage : GCats_StrikerImage)
{
	recoilHeight = 0.5;

	scopingImage = GCats_StrikerImage;
	sourceImage = GCats_StrikerImage;
	
    offset = "0 0 0";
	eyeOffset = "0 0.2 -0.47";
	rotation = eulerToMatrix( "0 -20 0" );	

	desiredFOV = 73;
	projectileZOffset = 0;
	R_MovePenalty = 0.5;
	
	stateName[9]				= "ReloadStart2";
	stateScript[9]				= "onDone";
	stateTimeoutValue[9]			= 1;
	stateTransitionOnTimeout[9]		= "";
	stateSound[9]				= "";
	
	stateName[12]				= "Reload";
	stateScript[12]				= "onDone";
	stateTimeoutValue[12]			= 1;
	stateTransitionOnTimeout[12]		= "";
	stateSound[12]				= "";
};

function GCats_StrikerIronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_StrikerIronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_StrikerIronsightImage::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(750, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, GCats_StrikerFireSound);	

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_StrikerIronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_StrikerIronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_StrikerIronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}