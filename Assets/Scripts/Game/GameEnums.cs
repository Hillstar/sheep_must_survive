﻿namespace Game
{
    public enum WeaponTypes
    {
        Pistol,
        Shotgun,
        Rifle,
        Laser
    }
    
    public enum GameStates
    {
        WaveRunning,
        WaveEnded,
        Break,
        BreakEnded,
        GameOver
    }
    
    public enum EnemyStates
    {
        ChaseSheep,
        ChasePlayer,
        Attacking,
        CarrySheep,
        Dead
    }
}