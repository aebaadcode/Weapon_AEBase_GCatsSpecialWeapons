datablock AudioProfile(GCats_M21FireSound)
{
   filename    = "./Sounds/M21.wav";
   description = MediumClose3D;
   preload = true;
};

AddDamageType("GCats_M21",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_M21> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_M21> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_M21Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./M21/M21.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: M21";
	iconName = "./Icons/icon_M21";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_M21Image;
	canDrop = true;

	AEAmmo = 10;
	AEType = AE_HeavyRAmmoItem.getID();
	AEBase = 1;

	RPM = 1200;
	recoil = "Medium"; 
	uiColor = "1 1 1";
	description = "Gangsta niggas, PMC mercs, and law enforcement. The Glock 19 is a reliable and popular handgun among many fields of combat.";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(GCats_M21Image)
{
   // Basic Item properties
	shapeFile = "./M21/M21.dts";
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
   item = GCats_M21Item;
   ammo = " ";
   projectile = AETrailedProjectile;
   projectileType = Projectile;

   casing = GCats_ShellLongDebris;
   shellExitDir        = "1 -1 0.5";
   shellExitOffset     = "0 0 0";
   shellExitVariance   = 25;	
   shellVelocity       = 5.0;
	
   //melee particles shoot from eye node for consistancy
	melee = false;
   //raise your arm up or not
	armReady = true;
	hideHands = false;
	safetyImage = GCats_M21SafetyImage;
    scopingImage = GCats_M21IronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_M21Item.colorShiftColor;//"0.400 0.196 0 1.000";

	shellSound = AEShellRifle;
	shellSoundMin = 700; //min delay for when the shell sound plays
	shellSoundMax = 800; //max delay for when the shell sound plays

	muzzleFlashScale = "1 1 1";
	bulletScale = "1 1 1";

	projectileDamage = 50;
	projectileCount = 1;
	projectileHeadshotMult = 2;
	projectileVelocity = 400;
	projectileTagStrength = 0.51;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate

	recoilHeight = 0.8;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 20;

	spreadBurst = 3; // how much shots it takes to trigger spread i think
	spreadReset = 600; // m
	spreadBase = 140;
	spreadMin = 140;
	spreadMax = 280;

    directDamageType = $DamageType::GCats_M21;
    directHeadDamageType = $DamageType::GCats_M21;

	screenshakeMin = "0.15 0 0"; 
	screenshakeMax = "0.3 0 0"; 

	farShotSound = RifleDDistantSound;
	farShotDistance = 40;
	
	projectileFalloffStart = 96;
	projectileFalloffEnd = 224;
	projectileFalloffDamage = 0.46;
	
	sonicWhizz = true;
	whizzSupersonic = true;
	whizzThrough = false;
	whizzDistance = 14;
	whizzChance = 100;
	whizzAngle = 80;

	staticHitscan = true;
	staticEffectiveRange = 160;
	staticTotalRange = 2000;
	staticGravityScale = 1.5;
	staticSwayMod = 0;
	staticEffectiveSpeedBonus = 0;
	staticSpawnFakeProjectiles = true;
	staticTracerEffect = ""; // defaults to AEBulletStaticShape
	staticScaleCalibre = 0.25;
	staticScaleLength = 0.25;
	staticUnitsPerSecond = $ae_SniperUPS;

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
	
	stateName[4]				= "LoadCheckA";
	stateScript[4]				= "AEMagLoadCheck";
	stateTimeoutValue[4]			= 0.1;
	stateTransitionOnTimeout[4]		= "LoadCheckB";
	
	stateName[5]				= "LoadCheckB";
	stateTransitionOnAmmo[5]		= "Ready";
	stateTransitionOnNotLoaded[5] = "Empty";
	stateTransitionOnNoAmmo[5]		= "Reload";

	stateName[6]				= "Reload";
	stateTimeoutValue[6]			= 1.25; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[6]				= "onReloadStart";
	stateTransitionOnTimeout[6]		= "ReloadEnd";
	stateWaitForTimeout[6]			= true;
    stateSound[6] = GCats_SMGReloadSound;
	
	stateName[7]				= "ReloadEnd";
	stateTimeoutValue[7]			= 0.25;
	stateScript[7]				= "onReloadEnd";
	stateTransitionOnTimeout[7]		= "Reloaded";
	stateWaitForTimeout[7]			= true;
	
	stateName[8]				= "FireLoadCheckA";
	stateScript[8]				= "AEMagLoadCheck";
	stateTimeoutValue[8]			= 0.3;
	stateTransitionOnTriggerUp[8]		= "FireLoadCheckB";
	
	stateName[9]				= "FireLoadCheckB";
	stateTransitionOnAmmo[9]		= "Ready";
	stateTransitionOnNoAmmo[9]		= "Reload";	
	stateTransitionOnNotLoaded[9]  = "Ready";
		
	stateName[10]				= "Reloaded";
	stateTimeoutValue[10]			= 0.1;
	stateScript[10]				= "AEMagReloadAll";
	stateTransitionOnTimeout[10]		= "Ready";
	
	stateName[11]				= "ReadyLoop";
	stateTransitionOnTimeout[11]		= "Ready";

	stateName[12]          = "Empty";
	stateTransitionOnTriggerDown[12]  = "Dryfire";
	stateTransitionOnLoaded[12] = "Reload";
	stateScript[12]        = "AEOnEmpty";

	stateName[13]           = "Dryfire";
	stateTransitionOnTriggerUp[13] = "Empty";
	stateWaitForTimeout[13]    = false;
	stateScript[13]      = "onDryFire";
};

// THERE ARE THREE STAGES OF VISUAL RECOIL, NONE, PLANT, JUMP

function GCats_M21Image::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_M21FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_M21Image::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

function GCats_M21Image::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

// MAGAZINE DROPPING

function GCats_M21Image::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_M21Image::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_M21Image::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_M21Image::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_M21IronsightImage : GCats_M21Image)
{
	recoilHeight = 0.1625;

	scopingImage = GCats_M21Image;
	sourceImage = GCats_M21Image;
	
	isScopedImage = true;
	
	offset = "0 0 0";
	eyeOffset = "0 -0.52 -0.3";
	rotation = eulerToMatrix( "0 -20 0" );

	spreadBase = 4;
	spreadMin = 4;
	spreadMax = 4;

	desiredFOV = 28;
	projectileZOffset = 1;
	R_MovePenalty = 0.5;
	
	stateName[6]				= "Reload";
	stateScript[6]				= "onDone";
	stateTimeoutValue[6]			= 1;
	stateTransitionOnTimeout[6]		= "";
	stateSound[6]				= "";
};

function GCats_M21IronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_M21IronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_M21IronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_M21FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_M21IronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_M21IronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_M21IronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}