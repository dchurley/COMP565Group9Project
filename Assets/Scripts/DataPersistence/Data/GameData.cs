using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public int deathCount;
    public int furthestLevel;
    public int currency;
    public bool hasPistol;
    public bool hasShotgun;
    public bool hasSMG;
    public bool hasRifle;
    public int equippedWeapon;
}