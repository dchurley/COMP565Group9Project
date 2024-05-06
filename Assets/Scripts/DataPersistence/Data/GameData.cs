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
    }

    public GameData(int deathC, int furthestL, int currncy, bool hasPl, bool hasSn, bool hasSG, bool hasRfl, int equippedW)
    {
        deathCount = deathC;
        furthestLevel = furthestL;
        currency = currncy;
        hasPistol = hasPl;
        hasShotgun = hasSn;
        hasSMG = hasSG;
        hasRifle = hasRfl;
        equippedWeapon = equippedW;
    }
}

