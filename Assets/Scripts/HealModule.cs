using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealModule : Module
{
    private void Update()
    {
        GameManager.Instance.generator.UpdateGeneratorHeal(effectDelay, effectTimer);
    }

    public override void ModuleEffect()
    {
        //ad condition to keep effect in store if full health
        //if full life set timer to complete as module fct auto reset timer (maybe change that behavior)
        GameManager.Instance.generator.ChangeLife(1);
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
