AddDamageType("GCats_R700SD",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_R700SD> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_R700SD> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_R700SDItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./R700/R700SD.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: R700 SD";
	iconName = "./Icons/icon_R700SD";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_R700SDImage;
	canDrop = true;

	AEAmmo = 4;
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
datablock ShapeBaseImageData(GCats_R700SDImage)
{
   // Basic Item properties
	shapeFile = "./R700/R700SD.dts";
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
   item = GCats_R700SDItem;
   ammo = " ";
   projectile = AERifleProjectile;
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
	safetyImage = GCats_R700SDSafetyImage;
    scopingImage = GCats_R700SDIronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_R700SDItem.colorShiftColor;//"0.400 0.196 0 1.000";

	shellSound = AEShellRifle;
	shellSoundMin = 700; //min delay for when the shell sound plays
	shellSoundMax = 800; //max delay for when the shell sound plays

	muzzleFlashScale = "1 1 1";
	bulletScale = "1 1 1";

	projectileDamage = 40;
	projectileCount = 1;
	projectileHeadshotMult = 2.5;
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

    directDamageType = $DamageType::GCats_R700SD;
    directHeadDamageType = $DamageType::GCats_R700SD;

	screenshakeMin = "0.15 0 0"; 
	screenshakeMax = "0.3 0 0"; 
	
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
	staticSpawnFakeProjectiles = false;
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
	stateFire[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "SemiAutoCheck";
	stateEmitter[3]					= AEBaseSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateTimeoutValue[3]			= 0.3;
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
	stateTransitionOnNoAmmo[6]		= "ReloadStart2";

	stateName[7]			  	= "ReloadStart2";
	stateTransitionOnTimeout[7]	  	= "ReloadStart2A";
	stateTimeoutValue[7]			= 0.5;
	stateScript[7]				= "LoadEffect";
	
	stateName[8]			  	= "ReloadStart2A";
	stateScript[8]				= "onBolt";
	stateTransitionOnTimeout[8]	  	= "ReloadStart2B";
	stateTimeoutValue[8]		  	= 0.8;
	stateSequence[8]			= "BoltAction";
	stateWaitForTimeout[8]		  	= true;
	
	stateName[9]				= "ReloadStart2B";
	stateScript[9]				= "AEShotgunAltLoadCheck";
	stateTimeoutValue[9]			= 0.1;
	stateWaitForTimeout[9]		  	= false;
	stateTransitionOnTriggerDown[9]	= "AnotherAmmoCheck";
	stateTransitionOnTimeout[9]	  	= "Reloaded";
	stateTransitionOnNotLoaded[9] = "LoadCheckA";
	
	stateName[10]				= "Reload";
	stateTransitionOnTimeout[10]     	= "Reloaded";
	stateTransitionOnTriggerDown[10]	= "AnotherAmmoCheck";
	stateWaitForTimeout[10]			= false;
	stateTimeoutValue[10]			= 0.5;
	stateScript[10]				= "LoadEffect";
	
	stateName[11]				= "Reloaded";
	stateTransitionOnTimeout[11]     	= "CheckAmmoA";
	stateTransitionOnTriggerDown[11]	= "AnotherAmmoCheck";
	stateWaitForTimeout[11]			= false;
	//stateTimeoutValue[11]			= 0.2;
	
	stateName[12]				= "CheckAmmoA";
	stateTransitionOnTriggerDown[12]	= "AnotherAmmoCheck";
	stateScript[12]				= "AEShotgunLoadCheck";
	stateTransitionOnTimeout[12]		= "CheckAmmoB";	
	
	stateName[13]				= "CheckAmmoB";
	stateTransitionOnTriggerDown[13]	= "AnotherAmmoCheck";
	stateTransitionOnNotLoaded[13]  = "Ready";
	stateTransitionOnAmmo[13]		= "Ready";
	stateTransitionOnNoAmmo[13]		= "Reload";
	
	stateName[14]				= "FireLoadCheckA";
	stateScript[14]				= "AEMagLoadCheck";
	stateTimeoutValue[14]			= 0.05;
	stateTransitionOnTriggerUp[14]		= "FireLoadCheckB";
	
	stateName[15]				= "FireLoadCheckB";
	stateTransitionOnAmmo[15]		= "Ready";
	stateTransitionOnNoAmmo[15]		= "ReloadStart2";	
	stateTransitionOnNotLoaded[15]  = "Ready";

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
	stateTransitionOnTriggerUp[19]	  	= "Bolt";
};

// THERE ARE THREE STAGES OF VISUAL RECOIL, NONE, PLANT, JUMP

function GCats_R700SDImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_SDFireSound);
  
  	cancel(%obj.reloadSoundSchedule);
	cancel(%obj.plantshellSchedule);
	cancel(%obj.insertshellSchedule);
	%obj.blockImageDismount = true;
	%obj.schedule(750, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_R700SDImage::onBolt(%this,%obj,%slot)
{
	schedule(300, 0, serverPlay3D, AEShellRifle @ getRandom(1,2) @ Sound, %obj.getPosition());
	serverPlay3D(GCats_R700BoltSound,%obj.getPosition());	
}

function GCats_R700SDImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

function GCats_R700SDImage::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

function GCats_R700SDImage::onReloadEnd2(%this,%obj,%slot)
{
	schedule(300, 0, serverPlay3D, AEShellRifle @ getRandom(1,2) @ Sound, %obj.getPosition());
	serverPlay3D(GCats_R700BoltSound,%obj.getPosition());	
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

// MAGAZINE DROPPING

function GCats_R700SDImage::LoadEffect(%this,%obj,%slot)
{
    %obj.reloadSoundSchedule = schedule(250, %obj, serverPlay3D, "GCats_R700ReloadSound", %obj.getPosition());
    %obj.plantshellSchedule = %obj.schedule(150, "aeplayThread", "3", "plant");
    %obj.insertshellSchedule = %this.schedule(250,AEShotgunLoadOne,%obj,%slot);
}

function GCats_R700SDImage::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_R700SDImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_R700SDImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_R700SDImage::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	
	cancel(%obj.reloadSoundSchedule);
	cancel(%obj.plantshellSchedule);
	cancel(%obj.insertshellSchedule);

	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_R700SDIronsightImage : GCats_R700SDImage)
{
	recoilHeight = 0.1625;

	scopingImage = GCats_R700SDImage;
	sourceImage = GCats_R700SDImage;
	
	isScopedImage = true;
	
	offset = "0 0 0";
	eyeOffset = "0 -0.1 -0.3";
	rotation = eulerToMatrix( "0 -20 0" );

	spreadBase = 2;
	spreadMin = 2;
	spreadMax = 2;

	desiredFOV = 14;
	projectileZOffset = 1;
	R_MovePenalty = 0.5;
	
	stateName[10]				= "Reload";
	stateScript[10]				= "onDone";
	stateTimeoutValue[10]			= 1;
	stateTransitionOnTimeout[10]		= "";
	stateSound[10]				= "";
	
	stateName[7]				= "ReloadStart2";
	stateScript[7]				= "onDone";
	stateTimeoutValue[7]			= 1;
	stateTransitionOnTimeout[7]		= "";
	stateSound[7]				= "";
};

function GCats_R700SDIronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_R700SDIronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_R700SDIronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_SDFireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(750, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_R700SDIronsightImage::onBolt(%this,%obj,%slot)
{
	schedule(300, 0, serverPlay3D, AEShellRifle @ getRandom(1,2) @ Sound, %obj.getPosition());
	serverPlay3D(GCats_R700BoltSound,%obj.getPosition());	
}


function GCats_R700SDIronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_R700SDIronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_R700SDIronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}