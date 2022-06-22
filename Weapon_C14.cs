datablock AudioProfile(GCats_C14FireSound)
{
   filename    = "./Sounds/C14.wav";
   description = MediumClose3D;
   preload = true;
};

datablock AudioProfile(GCats_C14BoltSound)	
{
   filename    = "./Sounds/c14bolt.wav";
   description = AudioClose3d;
   preload = true;
};

AddDamageType("GCats_C14",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_C14> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_C14> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_C14Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./C14/C14.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: C14 Timberwolf";
	iconName = "./Icons/icon_C14";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_C14Image;
	canDrop = true;

	AEAmmo = 5;
	AEType = AE_MediumSRAmmoItem.getID();
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
datablock ShapeBaseImageData(GCats_C14Image)
{
   // Basic Item properties
	shapeFile = "./C14/C14.dts";
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
   item = GCats_C14Item;
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
	safetyImage = GCats_C14SafetyImage;
    scopingImage = GCats_C14IronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_C14Item.colorShiftColor;//"0.400 0.196 0 1.000";

	shellSound = AEShellRifle;
	shellSoundMin = 700; //min delay for when the shell sound plays
	shellSoundMax = 800; //max delay for when the shell sound plays

	muzzleFlashScale = "1 1 1";
	bulletScale = "1 1 1";

	projectileDamage = 70;
	projectileCount = 1;
	projectileHeadshotMult = 1.5;
	projectileVelocity = 400;
	projectileTagStrength = 0.51;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate

	recoilHeight = 0.8;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 20;

	spreadBurst = 3; // how much shots it takes to trigger spread i think
	spreadReset = 600; // m
	spreadBase = 300;
	spreadMin = 300;
	spreadMax = 600;

    directDamageType = $DamageType::GCats_C14;
    directHeadDamageType = $DamageType::GCats_C14;

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

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "SemiAutoCheck";
	stateEmitter[3]					= AEBaseSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateTimeoutValue[3]			= 0.4;
	stateWaitForTimeout[3]			= true;
	
	stateName[4]                    	= "Bolt";
	stateTimeoutValue[4]            	= 0.8;
	stateScript[4]                  	= "onBolt";
	stateTransitionOnTimeout[4]     	= "FireLoadCheckA";
	stateAllowImageChange[4]        	= false;
	stateSequence[4]			= "BoltAction";
	stateWaitForTimeout[4]		  	= true;
	stateEjectShell[4]                = true;
	
	stateName[5]				= "LoadCheckA";
	stateScript[5]				= "AEMagLoadCheck";
	stateTimeoutValue[5]			= 0.1;
	stateTransitionOnTimeout[5]		= "LoadCheckB";
	
	stateName[6]				= "LoadCheckB";
	stateTransitionOnAmmo[6]		= "Ready";
	stateTransitionOnNotLoaded[6] = "Empty";
	stateTransitionOnNoAmmo[6]		= "Reload2";

	stateName[7]				= "Reload";
	stateTimeoutValue[7]			= 1.25; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[7]				= "onReloadStart";
	stateTransitionOnTimeout[7]		= "ReloadEnd";
	stateWaitForTimeout[7]			= true;
    stateSound[7] = GCats_RevolverReloadSound;
	
	stateName[8]				= "ReloadEnd";
	stateTimeoutValue[8]			= 0.25;
	stateScript[8]				= "onReloadEnd";
	stateTransitionOnTimeout[8]		= "Reloaded";
	stateWaitForTimeout[8]			= true;
	
	stateName[9]				= "Reload2";
	stateTimeoutValue[9]			= 1.25; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[9]				= "onReloadStart";
	stateTransitionOnTimeout[9]		= "ReloadEnd2";
	stateWaitForTimeout[9]			= true;
    stateSound[9] = GCats_RevolverReloadSound;
	
	stateName[10]				= "ReloadEnd2";
	stateTimeoutValue[10]			= 0.8;
	stateScript[10]				= "onReloadEnd2";
	stateTransitionOnTimeout[10]		= "Reloaded";
	stateSequence[10]			= "BoltAction";
	stateWaitForTimeout[10]			= true;
	
	stateName[11]				= "FireLoadCheckA";
	stateScript[11]				= "AEMagLoadCheck";
	stateTimeoutValue[11]			= 0.05;
	stateTransitionOnTriggerUp[11]		= "FireLoadCheckB";
	
	stateName[12]				= "FireLoadCheckB";
	stateTransitionOnAmmo[12]		= "Ready";
	stateTransitionOnNoAmmo[12]		= "Reload2";	
	stateTransitionOnNotLoaded[12]  = "Ready";
		
	stateName[13]				= "Reloaded";
	stateTimeoutValue[13]			= 0.1;
	stateScript[13]				= "AEMagReloadAll";
	stateTransitionOnTimeout[13]		= "Ready";
	
	stateName[14]				= "ReadyLoop";
	stateTransitionOnTimeout[14]		= "Ready";

	stateName[15]          = "Empty";
	stateTransitionOnTriggerDown[15]  = "Dryfire";
	stateTransitionOnLoaded[15] = "Reload2";
	stateScript[15]        = "AEOnEmpty";

	stateName[16]           = "Dryfire";
	stateTransitionOnTriggerUp[16] = "Empty";
	stateWaitForTimeout[16]    = false;
	stateScript[16]      = "onDryFire";
	
	stateName[17]           = "SemiAutoCheck"; //heeeeeeeeeeeeey
	stateTransitionOnTriggerUp[17]	  	= "Bolt";
};

// THERE ARE THREE STAGES OF VISUAL RECOIL, NONE, PLANT, JUMP

function GCats_C14Image::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_C14FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(750, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_C14Image::onBolt(%this,%obj,%slot)
{
	schedule(300, 0, serverPlay3D, AEShellRifle @ getRandom(1,2) @ Sound, %obj.getPosition());
	serverPlay3D(GCats_C14BoltSound,%obj.getPosition());	
}

function GCats_C14Image::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

function GCats_C14Image::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

function GCats_C14Image::onReloadEnd2(%this,%obj,%slot)
{
	schedule(300, 0, serverPlay3D, AEShellRifle @ getRandom(1,2) @ Sound, %obj.getPosition());
	serverPlay3D(GCats_C14BoltSound,%obj.getPosition());	
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

// MAGAZINE DROPPING

function GCats_C14Image::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_C14Image::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_C14Image::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_C14Image::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	
	cancel(%obj.pumpSoundSchedule);

	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_C14IronsightImage : GCats_C14Image)
{
	recoilHeight = 0.1625;

	scopingImage = GCats_C14Image;
	sourceImage = GCats_C14Image;
	
	isScopedImage = true;
	
	offset = "0 0 0";
	eyeOffset = "0 0 -0.48";
	rotation = eulerToMatrix( "0 -20 0" );

	spreadBase = 1;
	spreadMin = 1;
	spreadMax = 1;

	desiredFOV = 14;
	projectileZOffset = 1;
	R_MovePenalty = 0.5;
	
	stateName[7]				= "Reload";
	stateScript[7]				= "onDone";
	stateTimeoutValue[7]			= 1;
	stateTransitionOnTimeout[7]		= "";
	stateSound[7]				= "";
	
	stateName[9]				= "Reload2";
	stateScript[9]				= "onDone";
	stateTimeoutValue[9]			= 1;
	stateTransitionOnTimeout[9]		= "";
	stateSound[9]				= "";
};

function GCats_C14IronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_C14IronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_C14IronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_C14FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(750, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_C14IronsightImage::onBolt(%this,%obj,%slot)
{
	schedule(300, 0, serverPlay3D, AEShellRifle @ getRandom(1,2) @ Sound, %obj.getPosition());
	serverPlay3D(GCats_C14BoltSound,%obj.getPosition());	
}


function GCats_C14IronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_C14IronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_C14IronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}