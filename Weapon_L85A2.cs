datablock AudioProfile(GCats_L85A2FireSound)
{
   filename    = "./Sounds/L85A2.wav";
   description = MediumClose3D;
   preload = true;
};

AddDamageType("GCats_L85A2",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_L85A2> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_L85A2> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_L85A2Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./L85A2/L85A2.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: L85A2";
	iconName = "./Icons/icon_L85A2";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_L85A2Image;
	canDrop = true;

	AEAmmo = 30;
	AEType = AE_LightRAmmoItem.getID();
	AEBase = 1;

	Auto = true; 
	RPM = 800;
	recoil = "Medium"; 
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
datablock ShapeBaseImageData(GCats_L85A2Image)
{
   // Basic Item properties
	shapeFile = "./L85A2/L85A2.dts";
   emap = true;

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0;
   offset = "0 0 0";
   eyeOffset = "0 0 0";
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
   item = GCats_L85A2Item;
   ammo = " ";
   projectile = AETrailedProjectile;
   projectileType = Projectile;

   casing = GCats_ShellLongDebris;
   shellExitDir        = "1 0.2 0.5";
   shellExitOffset     = "0 0 0";
   shellExitVariance   = 25;	
   shellVelocity       = 5.0;
	
   //melee particles shoot from eye node for consistancy
	melee = false;
   //raise your arm up or not
	armReady = true;
	hideHands = false;
	safetyImage = GCats_L85A2SafetyImage;
    scopingImage = GCats_L85A2IronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_L85A2Item.colorShiftColor;//"0.400 0.196 0 1.000";

	shellSound = AEShellRifle;
	shellSoundMin = 450; //min delay for when the shell sound plays
	shellSoundMax = 550; //max delay for when the shell sound plays

	muzzleFlashScale = "1 1 1";
	bulletScale = "1 1 1";

	projectileDamage = 23;
	projectileCount = 1;
	projectileHeadshotMult = 2.2;
	projectileVelocity = 500;
	projectileTagStrength = 0.51;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate

	recoilHeight = 0.25;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 20;

	spreadBurst = 3; // how much shots it takes to trigger spread i think
	spreadReset = 200; // m
	spreadBase = 140;
	spreadMin = 140;
	spreadMax = 280;

	screenshakeMin = "0.1 0 0"; 
	screenshakeMax = "0.2 0 0"; 

    directDamageType = $DamageType::GCats_L85A2;
    directHeadDamageType = $DamageType::GCats_L85A2;

	farShotSound = RifleADistantSound;
	farShotDistance = 40;
	
	projectileFalloffStart = 96;
	projectileFalloffEnd = 192;
	projectileFalloffDamage = 0.5;
	
	sonicWhizz = true;
	whizzSupersonic = true;
	whizzThrough = false;
	whizzDistance = 14;
	whizzChance = 100;
	whizzAngle = 80;

	staticHitscan = true;
	staticEffectiveRange = 110;
	staticTotalRange = 2000;
	staticGravityScale = 1.5;
	staticSwayMod = 2;
	staticEffectiveSpeedBonus = 5;
	staticSpawnFakeProjectiles = true;
	staticTracerEffect = ""; // defaults to AEBulletStaticShape
	staticScaleCalibre = 0.25;
	staticScaleLength = 0.25;
	staticUnitsPerSecond = $ae_RifleUPS;

   //casing = " ";

   // Images have a state system which controls how the animations
   // are run, which sounds are played, script callbacks, etc. This
   // state system is downloaded to the client so that clients can
   // predict state changes and animate accordingly.  The following
   // system supports basic ready->fire->reload transitions as
   // well as a no-ammo->dryfire idle state.
   // Initial start up state
	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.01;
	stateTransitionOnTimeout[0]       	= "LoadCheckA";
	stateSequence[0]			= "root";

	stateName[1]                     	= "Ready";
	stateScript[1]				= "onReady";
	stateTransitionOnNotLoaded[1]     = "Empty";
	stateTransitionOnNoAmmo[1]       	= "Reload";
	stateTransitionOnTriggerDown[1]  	= "preFire";
	stateAllowImageChange[1]         	= true;

	stateName[2]                       = "preFire";
	stateTransitionOnTimeout[2]        = "Fire";
	stateScript[2]                     = "AEOnFire";
	stateEmitter[2]					= AEBaseRifleFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
	stateFire[2]                       = true;
	stateEjectShell[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "FireLoadCheckA";
	stateEmitter[3]					= AEBaseSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;
	
	stateName[5]				= "LoadCheckA";
	stateScript[5]				= "AEMagLoadCheck";
	stateTimeoutValue[5]			= 0.1;
	stateTransitionOnTimeout[5]		= "LoadCheckB";
	
	stateName[6]				= "LoadCheckB";
	stateTransitionOnAmmo[6]		= "Ready";
	stateTransitionOnNotLoaded[6] = "Empty";
	stateTransitionOnNoAmmo[6]		= "Reload";

	stateName[7]				= "Reload";
	stateTimeoutValue[7]			= 1.25; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[7]				= "onReloadStart";
	stateTransitionOnTimeout[7]		= "ReloadEnd";
	stateWaitForTimeout[7]			= true;
    stateSound[7] = GCats_SMGReloadSound;
	
	stateName[8]				= "ReloadEnd";
	stateTimeoutValue[8]			= 0.25;
	stateScript[8]				= "onReloadEnd";
	stateTransitionOnTimeout[8]		= "Reloaded";
	stateWaitForTimeout[8]			= true;
	
	stateName[9]				= "FireLoadCheckA";
	stateScript[9]				= "AEMagLoadCheck";
	stateTimeoutValue[9]			= 0.1;
	stateTransitionOnTimeout[9]		= "FireLoadCheckB";
	
	stateName[10]				= "FireLoadCheckB";
	stateTransitionOnAmmo[10]		= "Ready";
	stateTransitionOnNoAmmo[10]		= "Reload";	
	stateTransitionOnNotLoaded[10]  = "Ready";
		
	stateName[11]				= "Reloaded";
	stateTimeoutValue[11]			= 0.1;
	stateScript[11]				= "AEMagReloadAll";
	stateTransitionOnTimeout[11]		= "Ready";

	stateName[12]				= "ReadyLoop";
	stateTransitionOnTimeout[12]		= "Ready";

	stateName[13]          = "Empty";
	stateTransitionOnTriggerDown[13]  = "Dryfire";
	stateTransitionOnLoaded[13] = "Reload";
	stateScript[13]        = "AEOnEmpty";

	stateName[14]           = "Dryfire";
	stateTransitionOnTriggerUp[14] = "Empty";
	stateWaitForTimeout[14]    = false;
	stateScript[14]      = "onDryFire";
};

// THERE ARE THREE STAGES OF VISUAL RECOIL, NONE, PLANT, JUMP

function GCats_L85A2Image::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
    %obj.playAudio(0, GCats_L85A2FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_L85A2Image::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

function GCats_L85A2Image::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// MAGAZINE DROPPING

function GCats_L85A2Image::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_L85A2Image::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_L85A2Image::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_L85A2Image::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_L85A2IronsightImage : GCats_L85A2Image)
{
	recoilHeight = 0.0625;

	scopingImage = GCats_L85A2Image;
	sourceImage = GCats_L85A2Image;
	
	isScopedImage = true;
	
	offset = "0 0 0";
	eyeOffset = "0 0.7 -0.47";
	rotation = eulerToMatrix( "0 -20 0" );

	spreadBase = 40;
	spreadMin = 40;
	spreadMax = 40;

	desiredFOV = 53;
	projectileZOffset = 0;
	R_MovePenalty = 0.5;
	
	stateName[7]				= "Reload";
	stateScript[7]				= "onDone";
	stateTimeoutValue[7]			= 1;
	stateTransitionOnTimeout[7]		= "";
	stateSound[7]				= "";
};

function GCats_L85A2IronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_L85A2IronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_L85A2IronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
    %obj.playAudio(0, GCats_L85A2FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_L85A2IronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_L85A2IronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_L85A2IronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}