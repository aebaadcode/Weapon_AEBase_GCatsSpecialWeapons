datablock AudioProfile(GCats_RPG7FireSound)
{
   filename    = "./Sounds/stinger.wav";
   description = LightClose3D;
   preload = true;
};

datablock ProjectileData(GCats_RPG7Projectile)
{
   projectileShapeName = "./Stinger/stingermissile.dts";
   directDamage        = 100;
   directDamageType = $DamageType::GCats_RPG7;
   radiusDamageType = $DamageType::GCats_RPG7;
   impactImpulse	   = 1;
   verticalImpulse	   = 1000;
   explosion           = GCats_M79Explosion;
   particleEmitter     = gc_GrenadeTrailEmitter;

   brickExplosionRadius = 3;
   brickExplosionImpact = false;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 30;             
   brickExplosionMaxVolume = 30;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 60;  //max volume of bricks that we can destroy if they aren't connected to the ground (should always be >= brickExplosionMaxVolume)

   muzzleVelocity      = 100;
   velInheritFactor    = 0;

   armingDelay         = 0;
   lifetime            = 5000;
   fadeDelay           = 4500;
   bounceElasticity    = 0.5;
   bounceFriction       = 0.20;
   isBallistic         = true;
   gravityMod = 0.5;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "1 0.5 0.0";

   uiName = "RPG7 Grenade";
};

function GCats_RPG7Projectile::onCollision(%this, %obj, %col, %fade, %pos, %normal, %velocity)
{
	AETrailedProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal, %velocity);
}

function GCats_RPG7Projectile::onExplode(%this, %obj, %col, %fade, %pos, %normal, %velocity)
{
	%src = %obj.getTransform();
	for(%i = 0; %i < ClientGroup.getCount(); %i++)
	{
		%cc = ClientGroup.getObject(%i);
		%targ = %cc.getControlObject();
		if(!isObject(%targ))
			continue;

		if(vectorDist(%targ.getTransform(), %src) > 50)
			%cc.play3D(ExplosionLightDistantSound, %src);
	}
	AETrailedProjectile::onExplode(%this, %obj, %col, %fade, %pos, %normal, %velocity);
}

function GCats_RPG7Projectile::Damage(%this, %obj, %col, %fade, %pos, %normal)
{
	AETrailedProjectile::Damage(%this, %obj, %col, %fade, %pos, %normal);
}

AddDamageType("GCats_RPG7",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_RPG7> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_RPG7> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_RPG7Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./RPG7/RPG7.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: RPG-7";
	iconName = "./Icons/icon_RPG7";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_RPG7Image;
	canDrop = true;

	AEAmmo = 1;
	AEType = AE_RocketLAmmoItem.getID();
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
datablock ShapeBaseImageData(GCats_RPG7Image)
{
   // Basic Item properties
	shapeFile = "./RPG7/RPG7.dts";
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
   item = GCats_RPG7Item;
   ammo = " ";
   projectile = GCats_RPG7Projectile;
   projectileType = Projectile;
	
   //melee particles shoot from eye node for consistancy
	melee = false;
   //raise your arm up or not
	armReady = true;
	hideHands = false;
    scopingImage = GCats_RPG7IronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_RPG7Item.colorShiftColor;//"0.400 0.196 0 1.000";

	muzzleFlashScale = "0.5 0.5 0.5";
	bulletScale = "1 1 1";

    directDamageType = $DamageType::GCats_RPG7;
    directHeadDamageType = $DamageType::GCats_RPG7;

	projectileDamage = 100;
	projectileCount = 1;
	projectileHeadshotMult = 2;
	projectileVelocity = 100;
	projectileTagStrength = 1;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate
    alwaysSpawnProjectile = true;
	projectileVehicleDamageMult = 2;

	recoilHeight = 0.65;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 20;

	spreadBurst = 3; // how much shots it takes to trigger spread i think
	spreadReset = 250; // m
	spreadBase = 200;
	spreadMin = 200;
	spreadMax = 400;

	screenshakeMin = "0.1 0.1 0.1"; 
	screenshakeMax = "1 1 1"; 

	staticTotalRange = 100;	
	sonicWhizz = false;
	whizzSupersonic = false;
	whizzThrough = false;
	whizzDistance = 14;
	whizzChance = 100;
	whizzAngle = 80;

	projectileFalloffStart = 16;
	projectileFalloffEnd = 50;
	projectileFalloffDamage = 0.55;

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
	stateSequence[0]			= "Ready";

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
	stateTimeoutValue[6]			= 3.5; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[6]				= "onReloadStart";
	stateTransitionOnTimeout[6]		= "ReloadEnd";
	stateWaitForTimeout[6]			= true;
    stateSound[6] = GCats_HeavyReloadSound;
	
	stateName[7]				= "ReloadEnd";
	stateTimeoutValue[7]			= 0.25;
	stateScript[7]				= "onReloadEnd";
	stateTransitionOnTimeout[7]		= "Reloaded";
	stateSequence[7]                = "Reload";
	stateWaitForTimeout[7]			= true;
	
	stateName[8]				= "FireLoadCheckA";
	stateScript[8]				= "AEMagLoadCheck";
	stateTimeoutValue[8]			= 0.5;
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

function GCats_RPG7Image::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_RPG7FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_RPG7Image::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

function GCats_RPG7Image::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

// MAGAZINE DROPPING

function GCats_RPG7Image::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_RPG7Image::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_RPG7Image::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_RPG7Image::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_RPG7IronsightImage : GCats_RPG7Image)
{
	recoilHeight = 0.1625;

	scopingImage = GCats_RPG7Image;
	sourceImage = GCats_RPG7Image;
	
	offset = "0 0 0";
	eyeOffset = "0 0.12 -0.58";
	rotation = eulerToMatrix( "0 -20 0" );

	spreadBase = 1;
	spreadMin = 1;
	spreadMax = 1;

	desiredFOV = 80;
	projectileZOffset = 2;
	R_MovePenalty = 0.5;
	
	stateName[6]				= "Reload";
	stateScript[6]				= "onDone";
	stateTimeoutValue[6]			= 1;
	stateTransitionOnTimeout[6]		= "";
	stateSound[6]				= "";
};

function GCats_RPG7IronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_RPG7IronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_RPG7IronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_RPG7FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_RPG7IronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_RPG7IronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_RPG7IronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}