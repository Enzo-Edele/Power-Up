using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelectMenu : MonoBehaviour
{
    [SerializeField] List<UpgradeSelectItem> moduleUpgradeItem;

    //list of tower upgrades

    //2 fct
        //1 to display module upgrade
        //1 to display tower upgrade

    public void DisplayModule()
    {
        //deactivate tower

        //randomise module
        //activate module
        for (int i = 0; i < moduleUpgradeItem.Count; i++)
        {
            moduleUpgradeItem[i].UpgradeTypeSelection();
            moduleUpgradeItem[i].Activate(true);
        }
    }
    public void DisplayTower()
    {
        //deactivate module
        for (int i = 0; i < moduleUpgradeItem.Count; i++)
        {
            moduleUpgradeItem[i].Activate(false);
        }

        //randomise tower
        //activate tower
    }
}
