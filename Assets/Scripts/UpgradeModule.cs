using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeModule : Module
{
    private void Update()
    {
        GameManager.Instance.generator.UpdateUpgradeBar(effectDelay, effectTimer);
    }
    public override void ModuleEffect()
    {
        //Debug.Log("Upgrade");
        GameManager.Instance.generator.GainUpgradeCoin();
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
