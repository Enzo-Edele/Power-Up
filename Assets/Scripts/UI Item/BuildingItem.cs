using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingItem : MonoBehaviour
{
    [SerializeField] Image buildingIco;

    public PowerBarItem powerBar;

    //if needed force a size via script

    public void ChangeBuildingIco(Sprite nSprite)
    {
        buildingIco.sprite = nSprite;
    }
}
