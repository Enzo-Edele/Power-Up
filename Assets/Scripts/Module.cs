using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : Building
{
    public int effectDelay;
    public float effectTimer;

    [SerializeField] BuildingItem moduleItem;

    public int level { get; private set; } = 1;
    public int maxLevel;

    public void StartGame()
    {
        moduleItem.powerBar.SetOwner(this);
        moduleItem.powerBar.SetMaxPower(energyMax, energyUse);
        effectTimer = 0;
        level = 1;
    }

    public void UpdateBarUI()
    {
        moduleItem.powerBar.SetMaxPower(energyMax, energyUse);
    }
    private void FixedUpdate()
    {
        if (effectTimer < effectDelay && effectTimer >= 0 && GameManager.GameStates.InGame == GameManager.GameState && energyUse > 0)
        {
            effectTimer += Time.deltaTime * (1 +  energyUse / maxLevel);
        }
        else if(effectTimer > effectDelay)
        {
            effectTimer = 0;
            ModuleEffect();
        }
    }

    public virtual void ModuleEffect()
    {
        //code effect in module script
    }

    public virtual void Upgrade()
    {
        level++;
        energyMax = level;
        UpdateBarUI();
    }

    public override bool AddPower()
    {
        if (energyUse < energyMax && GameManager.Instance.generator.HasEnergy())
        {
            energyUse++;
            GameManager.Instance.generator.PlusPowerUsage();
            //Debug.Log("add power test pass");
            return true;
        }
        return false;
    }
    public override void MinusPower()
    {
        if (energyUse > 0)
        {
            energyUse--;
            GameManager.Instance.generator.MinusPowerUsage();
        }
    }
}
