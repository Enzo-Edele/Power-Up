using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public int energyMax;
    public int energyUse;

    public virtual bool AddPower()
    {
        /*if(energyUse < energyMax)
        {
            energyUse++;
            return true;
        }*/
        return false;
    }

    public virtual void MinusPower()
    {
        if(energyUse > 0)
        {
            energyUse--;
        }
    }
}
