///////////////////////////////////////////////////////////////////////////
///////////////////////// FIRE MISC EXPLOSIONS IDK/////////////////////////
///////////////////////////////////////////////////////////////////////////

datablock AudioProfile(GCats_ExplosionSound)	
{
   filename    = "./explosion.wav";
   description = ExplosionClose3D;
   preload = true;
};

datablock AudioProfile(GCats_SDFireSound)	
{
   filename    = "./gunsd.wav";
   description = LightClose3D;
   preload = true;
};

///////////////////////////////////////////////////////////////////
///////////////////////// RELOADING SOUNDS/////////////////////////
///////////////////////////////////////////////////////////////////

datablock AudioProfile(GCats_SMGReloadSound)	
{
   filename    = "./smgreload.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(GCats_PistolReloadSound)	
{
   filename    = "./pistolreload.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(GCats_RevolverReloadSound)	
{
   filename    = "./revolverreload.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(GCats_HeavyReloadSound)	
{
   filename    = "./heavyreload.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(GCats_EmptySound)	
{
   filename    = "./empty.wav";
   description = AudioClose3d;
   preload = true;
};
