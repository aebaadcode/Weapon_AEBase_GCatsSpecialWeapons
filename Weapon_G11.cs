datablock AudioProfile(GCats_G11FireSound)
{
   filename    = "./Sounds/G11.wav";
   description = MediumClose3D;
   preload = true;
};

AddDamageType("GCats_G11",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_G11> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_G11> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_G11Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./G11/G11.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: G11";
	iconName = "./Icons/icon_G11";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_G11Image;
	canDrop = true;

	AEAmmo = 45;
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
datablock ShapeBaseImageData(GCats_G11Image)
{
   // Basic Item properties
	shapeFile = "./G11/G11.dts";
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
   item = GCats_G11Item;
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
	safetyImage = GCats_G11SafetyImage;
    scopingImage = GCats_G11IronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_G11Item.colorShiftColor;//"0.400 0.196 0 1.000";

	muzzleFlashScale = "1 1 1";
	bulletScale = "1 1 1";

	projectileDamage = 18;
	projectileCount = 1;
	projectileHeadshotMult = 2;
	projectileVelocity = 500;
	projectileTagStrength = 0.51;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate

	recoilHeight = 0.25;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 20;

	spreadBurst = 3; // how much shots it takes to trigger spread i think
	spreadReset = 500; // m
	spreadBase = 150;
	spreadMin = 150;
	spreadMax = 300;

	screenshakeMin = "0.1 0 0"; 
	screenshakeMax = "0.2 0 0"; 

    directDamageType = $DamageType::GCats_G11;
    directHeadDamageType = $DamageType::GCats_G11;

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

// burst fire

	stateName[2]                       = "preFire";
	stateTransitionOnTimeout[2]        = "Fire";
	stateScript[2]                     = "AEOnFire";
	stateEmitter[2]					= AEBaseRifleFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
	stateFire[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "FireLoadCheckA";
	stateEmitter[3]					= AEBaseSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;
	
	stateName[4]				= "FireLoadCheckA";
	stateScript[4]				= "AEMagLoadCheck";
	stateTimeoutValue[4]			= 0.03;
	stateTransitionOnTimeout[4]		= "FireLoadCheckB";
	
	stateName[5]				= "FireLoadCheckB";
	stateTransitionOnAmmo[5]		= "preFire2";
	stateTransitionOnNoAmmo[5]		= "Reload";	
	stateTransitionOnNotLoaded[5]  = "Ready";
	
	stateName[6]                       = "preFire2";
	stateTransitionOnTimeout[6]        = "Fire2";
	stateScript[6]                     = "AEOnFire";
	stateEmitter[6]					= AEBaseRifleFlashEmitter;
	stateEmitterTime[6]				= 0.05;
	stateEmitterNode[6]				= "muzzlePoint";
	stateFire[6]                       = true;

	stateName[7]                    = "Fire2";
	stateTransitionOnTimeout[7]     = "FireLoadCheckA2";
	stateEmitter[7]					= AEBaseSmokeEmitter;
	stateEmitterTime[7]				= 0.05;
	stateEmitterNode[7]				= "muzzlePoint";
	stateAllowImageChange[7]        = false;
	stateSequence[7]                = "Fire";
	stateWaitForTimeout[7]			= true;
	
	stateName[8]				= "FireLoadCheckA2";
	stateScript[8]				= "AEMagLoadCheck";
	stateTimeoutValue[8]			= 0.03;
	stateTransitionOnTimeout[8]		= "FireLoadCheckB2";
	
	stateName[9]				= "FireLoadCheckB2";
	stateTransitionOnAmmo[9]		= "preFire3";
	stateTransitionOnNoAmmo[9]		= "Reload";	
	stateTransitionOnNotLoaded[9]  = "Ready";
	
	stateName[10]                       = "preFire3";
	stateTransitionOnTimeout[10]        = "Fire3";
	stateScript[10]                     = "AEOnFire";
	stateEmitter[10]					= AEBaseRifleFlashEmitter;
	stateEmitterTime[10]				= 0.05;
	stateEmitterNode[10]				= "muzzlePoint";
	stateFire[10]                       = true;

	stateName[11]                    = "Fire3";
	stateTransitionOnTimeout[11]     = "FireLoadCheckA3";
	stateEmitter[11]					= AEBaseSmokeEmitter;
	stateEmitterTime[11]				= 0.05;
	stateEmitterNode[11]				= "muzzlePoint";
	stateAllowImageChange[11]        = false;
	stateSequence[11]                = "Fire";
	stateWaitForTimeout[11]			= true;
	
	stateName[12]				= "FireLoadCheckA3";
	stateScript[12]				= "AEMagLoadCheck";
	stateTimeoutValue[12]			= 0.4;
	stateTransitionOnTimeout[12]		= "FireLoadCheckB3";
	
	stateName[13]				= "FireLoadCheckB3";
	stateTransitionOnAmmo[13]		= "Ready";
	stateTransitionOnNoAmmo[13]		= "Reload";	
	stateTransitionOnNotLoaded[13]  = "Ready";
	
// end of burst
	
	stateName[14]				= "LoadCheckA";
	stateScript[14]				= "AEMagLoadCheck";
	stateTimeoutValue[14]			= 0.1;
	stateTransitionOnTimeout[14]		= "LoadCheckB";
	
	stateName[15]				= "LoadCheckB";
	stateTransitionOnAmmo[15]		= "Ready";
	stateTransitionOnNotLoaded[15] = "Empty";
	stateTransitionOnNoAmmo[15]		= "Reload";

	stateName[16]				= "Reload";
	stateTimeoutValue[16]			= 3.25; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[16]				= "onReloadStart";
	stateTransitionOnTimeout[16]		= "ReloadEnd";
	stateWaitForTimeout[16]			= true;
    stateSound[16] = GCats_HeavyReloadSound;
	
	stateName[17]				= "ReloadEnd";
	stateTimeoutValue[17]			= 0.25;
	stateScript[17]				= "onReloadEnd";
	stateTransitionOnTimeout[17]		= "Reloaded";
	stateWaitForTimeout[17]			= true;
		
	stateName[18]				= "Reloaded";
	stateTimeoutValue[18]			= 0.1;
	stateScript[18]				= "AEMagReloadAll";
	stateTransitionOnTimeout[18]		= "Ready";

	stateName[19]				= "ReadyLoop";
	stateTransitionOnTimeout[19]		= "Ready";

	stateName[20]          = "Empty";
	stateTransitionOnTriggerDown[20]  = "Dryfire";
	stateTransitionOnLoaded[20] = "Reload";
	stateScript[20]        = "AEOnEmpty";

	stateName[21]           = "Dryfire";
	stateTransitionOnTriggerUp[21] = "Empty";
	stateWaitForTimeout[21]    = false;
	stateScript[21]      = "onDryFire";
};

// THERE ARE THREE STAGES OF VISUAL RECOIL, NONE, PLANT, JUMP

function GCats_G11Image::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
    %obj.playAudio(0, GCats_G11FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_G11Image::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

function GCats_G11Image::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// MAGAZINE DROPPING

function GCats_G11Image::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_G11Image::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_G11Image::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_G11Image::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_G11IronsightImage : GCats_G11Image)
{
	recoilHeight = 0.0625;

	scopingImage = GCats_G11Image;
	sourceImage = GCats_G11Image;
	
	isScopedImage = true;
	
	offset = "0 0 0";
	eyeOffset = "0 -0.1 -0.59";
	rotation = eulerToMatrix( "0 -20 0" );

	spreadBase = 20;
	spreadMin = 20;
	spreadMax = 20;

	desiredFOV = 28;
	projectileZOffset = 0;
	R_MovePenalty = 0.5;
	
	stateName[16]				= "Reload";
	stateScript[16]				= "onDone";
	stateTimeoutValue[16]			= 1;
	stateTransitionOnTimeout[16]		= "";
	stateSound[16]				= "";
};

function GCats_G11IronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_G11IronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_G11IronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
    %obj.playAudio(0, GCats_G11FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_G11IronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_G11IronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_G11IronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}