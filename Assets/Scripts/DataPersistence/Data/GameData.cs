using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData : MonoBehaviour
{
    public int deathCount;
     

    public GameData() 
    {
        // start a new game with deathcount 0
        this.deathCount = 0;
    }

    public int GetPercentageComplete()
    {
        int Bosses = 3;
        int percentageCompleted = -1;
        if (Bosses == 3)
        {
            percentageCompleted = 0;
        }

        else if (Bosses == 2)
        {
            percentageCompleted = 33;
        }

        else if (Bosses == 1)
        {
            percentageCompleted = 66;
        }
        return percentageCompleted;
    }

}