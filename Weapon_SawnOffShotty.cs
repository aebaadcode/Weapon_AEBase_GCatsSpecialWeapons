datablock AudioProfile(GCats_SawnOffShottyOutSound)	
{
   filename    = "./Sounds/sawnoffout.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(GCats_SawnOffShottyInSound)	
{
   filename    = "./Sounds/sawnoffin.wav";
   description = AudioClose3d;
   preload = true;
};


AddDamageType("GCats_SawnOffShotty",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_SawnOffShotty> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_SawnOffShotty> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_SawnOffShottyItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./SawnOffShotty/SawnOffShotty.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: Sawn-Off Shotgun";
	iconName = "./Icons/icon_SawnOffShotty";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_SawnOffShottyImage;
	canDrop = true;

	AEAmmo = 2;
	AEType = AE_LightSAmmoItem.getID();
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
datablock ShapeBaseImageData(GCats_SawnOffShottyImage)
{
   // Basic Item properties
	shapeFile = "./SawnOffShotty/SawnOffShotty.dts";
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
   item = GCats_SawnOffShottyItem;
   ammo = " ";
   projectile = AETrailedProjectile;
   projectileType = Projectile;

   casing = GCats_Shell12GRedDebris;
   shellExitDir        = "1 0.2 0.5";
   shellExitOffset     = "0 0 0";
   shellExitVariance   = 25;	
   shellVelocity       = 5.0;
	
   //melee particles shoot from eye node for consistancy
	melee = false;
   //raise your arm up or not
	armReady = true;
	hideHands = false;
	safetyImage = GCats_SawnOffShottySafetyImage;
    scopingImage = GCats_SawnOffShottyIronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_SawnOffShottyItem.colorShiftColor;//"0.400 0.196 0 1.000";

	muzzleFlashScale = "1.5 1.5 1.5";
	bulletScale = "1 1 1";

	projectileDamage = 15;
	projectileCount = 8;
	projectileHeadshotMult = 1.4;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate

	projectileFalloffStart = 8;
	projectileFalloffEnd = 32;
	projectileFalloffDamage = 0.2;

	recoilHeight = 10;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 20;
	spreadBurst = 1; // how much shots it takes to trigger spread i think
	spreadBase = 400;
	spreadReset = 500; // m
	spreadMin = 400;
	spreadMax = 400;
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

    directDamageType = $DamageType::GCats_SawnOffShotty;
    directHeadDamageType = $DamageType::GCats_SawnOffShotty;

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
	stateEmitter[2]					= AEBaseShotgunFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
	stateFire[2]                       = true;
	stateEjectShell[2]                       = false;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "FireLoadCheckA";
	stateEmitter[3]					= AEBaseSmokeBigEmitter;
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
	stateTimeoutValue[7]			= 1.5; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[7]				= "onReloadStart";
	stateTransitionOnTimeout[7]		= "ReloadEnd";
	stateWaitForTimeout[7]			= true;
    stateSound[7] = GCats_SawnOffShottyOutSound;
	
	stateName[8]				= "ReloadEnd";
	stateTimeoutValue[8]			= 0.4;
	stateScript[8]				= "onReloadEnd";
	stateTransitionOnTimeout[8]		= "Reloaded";
	stateWaitForTimeout[8]			= true;
    stateSound[8] = GCats_SawnOffShottyInSound;
	
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

function GCats_SawnOffShottyImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
    %obj.playAudio(0, GCats_SPAS12FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_SawnOffShottyImage::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

function GCats_SawnOffShottyImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// MAGAZINE DROPPING

function GCats_SawnOffShottyImage::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_SawnOffShottyImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_SawnOffShottyImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_SawnOffShottyImage::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_SawnOffShottyIronsightImage : GCats_SawnOffShottyImage)
{
	recoilHeight = 2.5;

	scopingImage = GCats_SawnOffShottyImage;
	sourceImage = GCats_SawnOffShottyImage;
	
	isScopedImage = true;
	
	offset = "0 0 0";
	eyeOffset = "0 0.5 -0.2";
	rotation = eulerToMatrix( "0 -20 0" );

	desiredFOV = 80;
	projectileZOffset = 0;
	R_MovePenalty = 0.5;
	
	stateName[7]				= "Reload";
	stateScript[7]				= "onDone";
	stateTimeoutValue[7]			= 1;
	stateTransitionOnTimeout[7]		= "";
	stateSound[7]				= "";
};

function GCats_SawnOffShottyIronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_SawnOffShottyIronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_SawnOffShottyIronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
    %obj.playAudio(0, GCats_SPAS12FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(200, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_SawnOffShottyIronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_SawnOffShottyIronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_SawnOffShottyIronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}