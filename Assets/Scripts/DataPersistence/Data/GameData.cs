using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int deathCount;
    public int furthestLevel;
    public int currency;
    public bool hasPistol;
    public bool hasShotgun;
    public bool hasSMG;
    public bool hasRifle;
    public int equippedWeapon;
    public bool[] levels;

    public GameData()
    {
        deathCount = 0;
        furthestLevel = 0;
        currency = 150;
        hasPistol = true;
        hasShotgun = false;
        hasSMG = false;
        hasRifle = false;
        equippedWeapon = 0;
        levels = new bool[3];
    }
}

