using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinModule : Module
{
    private void Update()
    {
        UIManager.Instance.UpdateWinBar (effectDelay, effectTimer);
        //Debug.Log("Update vic : " + effectDelay + " / " + effectTimer);
    }
    public override void ModuleEffect()
    {
        Debug.Log("WIN CONGRATS !!!");
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
