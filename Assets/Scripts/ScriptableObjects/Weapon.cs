using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public string weaponID;
    public int cost;
    public int damage;
    public bool unlocked;

}