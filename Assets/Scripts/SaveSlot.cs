using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]

    [SerializeField] private string profileId = "";

    [Header("Content")]

    [SerializeField] private GameObject noDataContent;
    
    [SerializeField] private GameObject hasDataContent;

    [SerializeField] private TextMeshProUGUI percentageCompleteText;

    [SerializeField] private TextMeshProUGUI deathCountText;

    [SerializeField] private GameObject trashIcon;



    public void SetData(GameData data)
    {
        if (data.furthestLevel == 0 && data.deathCount == 0)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            trashIcon.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            trashIcon.SetActive(true);

            percentageCompleteText.text = data.furthestLevel + "/3 LEVELS COMPLETE";
            deathCountText.text = "DEATH COUNT: " + data.deathCount;

        }


    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void DeleteSave()
    {
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        noDataContent.SetActive(true);
        hasDataContent.SetActive(false);
        trashIcon.SetActive(false);
    }

    public void SetProfileId()
    {
        DataPersistenceManager.instance.SetProfileID(profileId);
    }
}
