datablock AudioProfile(GCats_M79FireSound)
{
   filename    = "./Sounds/M79.wav";
   description = LightClose3D;
   preload = true;
};

datablock DebrisData(GCats_M79GrenadeDebris)
{
	shapeFile = "./M79/40mm.dts";
	lifetime = 2.0;
	minSpinSpeed = 800.0;
	maxSpinSpeed = 800.0;
	elasticity = 0.5;
	friction = 0.1;
	numBounces = 3;
	staticOnMaxBounce = true;
	snapOnMaxBounce = false;
	fade = true;

	gravModifier = 3;
};

//EXPLOSION EMITTERS N STUFF
datablock ParticleData(gc_GrenadeTrailParticle)
{
  dragCoefficient = 8;
  gravityCoefficient = 0;
  inheritedVelFactor = 0;
  constantAcceleration = 0;
  lifetimeMS = 500;
  lifetimeVarianceMS = 0;
  textureName = "base/data/particles/cloud";
  colors[0] = "1 1 1 0.2";
  colors[1] = "1 1 1 0";
  sizes[0] = 0.3;
  sizes[1] = 0.1;
  useInvAlpha = false;
};

datablock ParticleEmitterData(gc_GrenadeTrailEmitter)
{
  uiName = "";
  ejectionPeriodMS = 8;
  periodVarianceMS = 0;
  ejectionVelocity = 0;
  velocityVariance = 0;
  ejectionOffset = 0;
  thetaMin = 89;
  thetaMax = 90;
  phiReferenceVel = 0;
  phiVariance = 360;
  overrideAdvance = false;
  particles = "gc_GrenadeTrailParticle";
};

datablock ParticleData(GCats_M79BlastHazeParticle)
{
	dragCoefficient		= 2.5;
	windCoefficient		= 0.0;
	gravityCoefficient	= -0.5;
	inheritedVelFactor	= 0.0;
	constantAcceleration	= 0.0;
	lifetimeMS		= 850;
	lifetimeVarianceMS	= 0;
	spinSpeed		= 0.0;
	spinRandomMin		= -200.0;
	spinRandomMax		= 200.0;
	useInvAlpha		= false;
	animateTexture		= false;

	textureName		= "Add-Ons/Weapon_AEBase/Particles/genericflash2";

	//colors[0]	= "1 1 0.3 0.0";
	//colors[1]	= "0.9 0.6 0.0 1.0";
	//colors[2]	= "0.6 0.0 0.0 0.0";
	colors[0] = "1 0.6 0.5 0.0";
  colors[1] = "0.9 0.4 0.3 1";
  colors[2] = "0.9 0.4 0.3 0.0";

	sizes[0]	= 8.5;
	sizes[1]	= 7.35;
	sizes[2]	= 10.5;

	times[0]	= 0.0;
	times[1]	= 0.2;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(GCats_M79BlastHazeEmitter)
{
	ejectionPeriodMS = 8;
	periodVarianceMS = 0;
	ejectionVelocity = 13;
	velocityVariance = 3;
	ejectionOffset = 0.2;
	thetaMin         = 0.0;
	thetaMax         = 90.0;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;

  particles = "GCats_M79BlastHazeParticle";
};

datablock ParticleData(GCats_M79BlastSmokeParticle)
{
	dragCoefficient		= 2.5;
	windCoefficient		= 0.0;
	gravityCoefficient	= -0.3;
	inheritedVelFactor	= 0.0;
	constantAcceleration	= 0.0;
	lifetimeMS		= 3500;
	lifetimeVarianceMS	= 0;
	spinSpeed		= 0.0;
	spinRandomMin		= -200.0;
	spinRandomMax		= 200.0;
	useInvAlpha		= true;
	animateTexture		= false;

	textureName		= "base/data/particles/cloud";

	colors[0]	= "0.3 0.3 0.3 0.0";
	colors[1]	= "0.1 0.1 0.1 0.05";
	colors[2]	= "0.0 0.0 0.0 0.0";

	sizes[0]	= 0.5;
	sizes[1]	= 4.35;
	sizes[2]	= 3.1;

	times[0]	= 0.0;
	times[1]	= 0.3;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(GCats_M79BlastSmokeEmitter)
{
	ejectionPeriodMS = 2;
	periodVarianceMS = 0;
	ejectionVelocity = 10;
	velocityVariance = 5;
	ejectionOffset = 0.3;
	thetaMin         = 0.0;
	thetaMax         = 90.0;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;

  particles = "GCats_M79BlastSmokeParticle";
};

datablock ParticleData(GCats_M79BlastDebrisParticle)
{
	dragCoefficient = 0;
	gravityCoefficient = 5;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 500;
	textureName = "base/data/particles/chunk";
	spinSpeed = 10;
	spinRandomMin = -500;
	spinRandomMax = 500;
	colors[0] = "0 0 0 1";
	colors[1] = "0 0 0 0";
	sizes[0] = 0.35;
	sizes[1] = 0.35;
	useInvAlpha = true;
};

datablock ParticleEmitterData(GCats_M79BlastDebrisEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 25;
	velocityVariance = 6;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 90;//30;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = false;

  particles = "GCats_M79BlastDebrisParticle";
};

datablock ParticleData(GCats_M79BlastDebrisParticle)
{
     dragCoefficient		= 5.0;
     windCoefficient		= 1.0;
     gravityCoefficient	= 0;
     inheritedVelFactor	= 0.0;
     constantAcceleration	= 0.0;
     lifetimeMS		= 950;
     lifetimeVarianceMS	= 250;
     spinSpeed		= 5.0;
     spinRandomMin		= -5.0;
     spinRandomMax		= 5.0;
     useInvAlpha		= false;
     animateTexture		= false;
     //framesPerSec		= 1;

     textureName		= "Add-Ons/Weapon_AEBase/Particles/genericflash2";
     //animTexName		= "~/data/particles/cloud";

     // Interpolation variables
	colors[0] = "1 0.6 0.5 0.0";
  colors[1] = "0.9 0.4 0.3 0.8";
  colors[2] = "0.9 0.4 0.3 0.0";
  colors[3] = "0.9 0.4 0.3 0.0";

	sizes[0]	= 0.2;
	sizes[1]	= 0.4;
	sizes[2]	= 1.9;
	sizes[3]	= 2.8;

	times[0]	= 0.0;
	times[1]	= 0.1;
	times[2]	= 0.8;
	times[3]	= 1.0;
};

datablock ParticleEmitterData(GCats_M79BlastDebrisEmitter)
{
   ejectionPeriodMS = 8;
   periodVarianceMS = 0;
   ejectionVelocity = 0;
   velocityVariance = 2.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 1;
   phiReferenceVel  = 30;
   phiVariance      = 32;
   overrideAdvance = false;
   particles = "GCats_M79BlastDebrisParticle";
};

datablock DebrisData(GCats_M79BlastDebrisData)
{
	emitters = GCats_M79BlastDebrisEmitter;

	shapeFile = "base/data/shapes/empty.dts";
	lifetime = 0.3;
	minSpinSpeed = -1000.0;
	maxSpinSpeed = 1000.0;
	elasticity = 0;
	friction = 0;
	numBounces = 0;
	staticOnMaxBounce = false;
	snapOnMaxBounce = false;
	fade = false;

	gravModifier = 0.5;
};

datablock ExplosionData(GCats_M79Explosion)
{
   //explosionShape = "";
    explosionShape = "Add-Ons/Weapon_Rocket_Launcher/explosionSphere1.dts";
	soundProfile = GCats_ExplosionSound;

	lifeTimeMS = 350;

	particleEmitter = GCats_M79BlastDebrisEmitter;
	particleDensity = 60;
	particleRadius = 0.35;

	emitter[0] = GCats_M79BlastHazeEmitter;
	emitter[1] = GCats_M79BlastSmokeEmitter;

   playerBurnTime = 5000;

	debris = GCats_M79BlastDebrisData;
	debrisNum = 30;
	debrisNumVariance = 10;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisThetaMin = 0;
	debrisThetaMax = 180;
	debrisVelocity = 32;
	debrisVelocityVariance = 5;

	faceViewer     = true;
	explosionScale = "1 1 1";

	shakeCamera = true;
	camShakeFreq = "5 5 5";
	camShakeAmp = "8 8 8";
	camShakeDuration = 2;
	camShakeRadius = 16;

	damageRadius = 6;
	radiusDamage = 200;

	impulseRadius = 8;
	impulseForce = 200;
};


datablock ExplosionData(GCats_M79FailureExplosion : gunExplosion)
{
   emitter[0] = "";
   particleEmitter = "";
   lightStartRadius = 0;
   debris = GCats_M79GrenadeDebris;
   debrisNum = 1;
   debrisNumVariance = 0;
   debrisPhiMin = 0;
   debrisPhiMax = 360;
   debristhetamin = 0;//45;
   debrisThetaMax = 45;
   debrisVelocity = 10;
   debrisVelocityVariance = 5;
};

datablock ProjectileData(GCats_M79FailedProjectile)
{
	directDamage        = 0;
   projectileShapeName = "base/data/shapes/empty.dts";
   armingDelay         = 300;
   lifetime            = 300;
   explodeOnDeath = true;
   
   muzzleVelocity      = 100;
   gravityMod = 0.0;
   
   destroyOnBounce = false;
   deleteOnBounce = false;
   
   hasLight    = false;
   explosion           = GCats_M79FailureExplosion;
   particleEmitter     = "";
   uiName = "";
};

datablock ProjectileData(GCats_M79InactiveProjectile : GCats_M79Projectile)
{
   directDamage        = 50;
   directDamageType = $DamageType::GCats_M79;
	
   projectileShapeName = "./M79/40mm.dts";
   armingDelay         = 200;
   lifetime            = 200;
   explodeOnDeath = true;
   
   muzzleVelocity      = 100;
   gravityMod = 0.0;
   
   destroyOnBounce = true;
   deleteOnBounce = true;
   bounceDestroyProjectile = GCats_M79FailedProjectile;
   activatedProjectile = GCats_M79Projectile;
   
   particleEmitter     = gc_GrenadeTrailEmitter; 
   hasLight    = false;
   explosion           = "";
   uiName = "";
};

function GCats_M79InactiveProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal, %velocity)
{
	AETrailedProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal, %velocity);
}

function GCats_M79InactiveProjectile::onExplode(%this, %obj, %col, %fade, %pos, %normal, %velocity)
{
	AETrailedProjectile::onExplode(%this, %obj, %col, %fade, %pos, %normal, %velocity);
}

function GCats_M79InactiveProjectile::Damage(%this, %obj, %col, %fade, %pos, %normal)
{
	AETrailedProjectile::Damage(%this, %obj, %col, %fade, %pos, %normal);
}

datablock ProjectileData(GCats_M79Projectile)
{
   projectileShapeName = "./M79/40mm.dts";
   directDamage        = 100;
   directDamageType = $DamageType::GCats_M79;
   radiusDamageType = $DamageType::GCats_M79;
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
   gravityMod = 1;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "1 0.5 0.0";

   uiName = "M79 Grenade";
};

function GCats_M79Projectile::onCollision(%this, %obj, %col, %fade, %pos, %normal, %velocity)
{
	AETrailedProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal, %velocity);
}

function GCats_M79Projectile::onExplode(%this, %obj, %col, %fade, %pos, %normal, %velocity)
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

function GCats_M79Projectile::Damage(%this, %obj, %col, %fade, %pos, %normal)
{
	AETrailedProjectile::Damage(%this, %obj, %col, %fade, %pos, %normal);
}

AddDamageType("GCats_M79",'<bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_40mm> %1','%2 <bitmap:Add-ons/Weapon_AEBase_GCatsSpecialWeapons/Icons/CI_40mm> %1',0.2,1);

//////////
// item //
//////////
datablock ItemData(GCats_M79Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "./M79/M79.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SW: M79";
	iconName = "./Icons/icon_M79";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	 // Dynamic properties defined by the scripts
	image = GCats_M79Image;
	canDrop = true;

	AEAmmo = 1;
	AEType = AE_GrenadeLAmmoItem.getID();
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
datablock ShapeBaseImageData(GCats_M79Image)
{
   // Basic Item properties
	shapeFile = "./M79/M79.dts";
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
   item = GCats_M79Item;
   ammo = " ";
   projectile = GCats_M79InactiveProjectile;
   projectileType = Projectile;
	
   //melee particles shoot from eye node for consistancy
	melee = false;
   //raise your arm up or not
	armReady = true;
	hideHands = false;
    scopingImage = GCats_M79IronsightImage;
	doColorShift = true;
	colorShiftColor = GCats_M79Item.colorShiftColor;//"0.400 0.196 0 1.000";

	muzzleFlashScale = "0.5 0.5 0.5";
	bulletScale = "1 1 1";

    directDamageType = $DamageType::GCats_M79;
    directHeadDamageType = $DamageType::GCats_M79;

	projectileDamage = 50;
	projectileCount = 1;
	projectileHeadshotMult = 2;
	projectileVelocity = 100;
	projectileTagStrength = 1;  // tagging strength
	projectileTagRecovery = 0.03; // tagging decay rate
    alwaysSpawnProjectile = true;
	projectileVehicleDamageMult = 0.1;

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
	stateTimeoutValue[6]			= 1.05; //-0.15 for magazine weps since reloadend is now 0.25 instead of 0.1
	stateScript[6]				= "onReloadStart";
	stateTransitionOnTimeout[6]		= "ReloadEnd";
	stateWaitForTimeout[6]			= true;
    stateSound[6] = GCats_RevolverReloadSound;
	
	stateName[7]				= "ReloadEnd";
	stateTimeoutValue[7]			= 0.25;
	stateScript[7]				= "onReloadEnd";
	stateTransitionOnTimeout[7]		= "Reloaded";
	stateWaitForTimeout[7]			= true;
	
	stateName[8]				= "FireLoadCheckA";
	stateScript[8]				= "AEMagLoadCheck";
	stateTimeoutValue[8]			= 0.4;
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

function GCats_M79Image::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_M79FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_M79Image::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

function GCats_M79Image::onReloadEnd(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	Parent::AEMagReloadAll(%this, %obj, %slot);
}

// MAGAZINE DROPPING

function GCats_M79Image::onReloadStart(%this,%obj,%slot)
{
   %obj.aeplayThread(2, shiftRight);
}

function GCats_M79Image::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);

	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
}

// HIDES ALL HAND NODES

function GCats_M79Image::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_M79Image::onUnMount(%this,%obj,%slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

///////// IRONSIGHTS?

datablock ShapeBaseImageData(GCats_M79IronsightImage : GCats_M79Image)
{
	recoilHeight = 0.1625;

	scopingImage = GCats_M79Image;
	sourceImage = GCats_M79Image;
	
	offset = "0 0 0";
	eyeOffset = "0 0.1 -0.21";
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

function GCats_M79IronsightImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

function GCats_M79IronsightImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function GCats_M79IronsightImage::AEOnFire(%this,%obj,%slot)
{	
	%obj.stopAudio(0); 
  %obj.playAudio(0, GCats_M79FireSound);
  
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	Parent::AEOnFire(%this, %obj, %slot);
}

function GCats_M79IronsightImage::onDryFire(%this, %obj, %slot)
{
	serverPlay3D(GCats_EmptySound, %obj.getHackPosition());
}

// HIDES ALL HAND NODES

function GCats_M79IronsightImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn3Sound);
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

// APLLY BODY PARTS IS LIKE PRESSING CTRL O AND ESC, IT APPLIES THE AVATAR COLORS FOR YOU

function GCats_M79IronsightImage::onUnMount(%this,%obj,%slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut3Sound);
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}