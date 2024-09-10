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
    public bool CheckModuleUpgrade(int toCheck)
    {
        int equal = 0;
        for(int i = 0; i < moduleUpgradeItem.Count; i++)
        {
            if (moduleUpgradeItem[i].upgradeType == toCheck)
            {
                equal++;
            }
        }

        //if equal > 1 :: return false
        if(equal > 1)
        {
            return false;
        }
        return true;
    }

    public void DisplayModule()
    {
        List<int> moduleTypes = new List<int>();
        //deactivate tower
        
        //randomise module
        //activate module
        
        moduleTypes.Clear();
        int loopCount = 0;
        for (int i = 0; i < moduleUpgradeItem.Count; i++)
        {
            moduleUpgradeItem[i].Activate(false);
        }
        while (moduleTypes.Count < moduleUpgradeItem.Count && loopCount < 500)
        {
            bool equal = false;
            int nType = Random.Range(0, 4);
            for(int i = 0; i < moduleTypes.Count; i++)
            {
                if (moduleTypes[i] == nType)
                {
                    equal = true;
                    break;
                }
            }
            if (!equal && moduleUpgradeItem[moduleTypes.Count].CheckIsNotMax(nType))
            {
                moduleTypes.Add(nType);
            }
            loopCount++;
        }

        for(int i = 0; i < moduleTypes.Count; i++)
        {
            moduleUpgradeItem[i].UpgradeTypeSelection(moduleTypes[i]);
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
