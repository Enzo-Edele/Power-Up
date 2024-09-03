using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    //life
    int life;
    [SerializeField] int maxLife;

    [SerializeField] Image GeneratorHealthMask;
    float originalGeneratorHealthSize;
    [SerializeField] GameObject generatorHealthBar;

    //energy
    public int energy;
    public int usedEnergy;
    public int remainingEnergy;

    [SerializeField] PowerBarItem mainPowerBar;

    int upgradeCoin = 0;

    //element
    [SerializeField] List<Tower> towers = new List<Tower>();

    [SerializeField] Module healModule;
    [SerializeField] Module upgradeModule;
    [SerializeField] Module winModule;

    [SerializeField] Image HealModuleMask;
    float originalHealModuleHealthSize;
    [SerializeField] GameObject HealModuleBar;

    [SerializeField] Image UpgradeModuleMask;
    float originalUpgradeModuleHealthSize;
    [SerializeField] GameObject UpgradeModuleBar;

    void Awake()
    {
        originalGeneratorHealthSize = GeneratorHealthMask.rectTransform.rect.width;
        originalHealModuleHealthSize = HealModuleMask.rectTransform.rect.width;
        originalUpgradeModuleHealthSize = UpgradeModuleMask.rectTransform.rect.width;
        life = maxLife;
        StartGame();
    }
    public void StartGame()
    {
        mainPowerBar.StartGenerator(energy);

        healModule.StartGame();
        upgradeModule.StartGame();
        winModule.StartGame();
        for(int i = 0; i < towers.Count; i++)
        {
            towers[i].StartGame();
        }
        
        //Debug.Log("energy : " + energy + " used : " + usedEnergy);
    }

    void Update()
    {
        
    }

    public void AddPowerBar()
    {
        mainPowerBar.AddPowerBar();
    }
    public void RemovePowerBar()
    {
        mainPowerBar.RemovePowerBar();
    }

    public void PlusPowerUsage()
    {
        mainPowerBar.PlusPowerUsageGenerator();
        usedEnergy++;
    }
    public void MinusPowerUsage()
    {
        mainPowerBar.MinusPowerUsageGenerator();
        usedEnergy--;
    }
    public bool HasEnergy()
    {
        return usedEnergy < energy;
    }

    public void ChangeLife(int modificator)
    {
        life += modificator;
        if(life < 0)
        {
            //lose
        }
        if (life > maxLife)
            life = maxLife;
        //Debug.Log(life + " / " + maxLife);
        UpdateGeneratorHealth(maxLife, life);
    }

    public void GainUpgradeCoin()
    {
        upgradeCoin++;
    }

    public void SpendUpgradeCoin()
    {
        upgradeCoin--;
    }

    void ActivateHealth(bool nState)
    {
        generatorHealthBar.SetActive(nState);
    }
    void UpdateGeneratorHealth(float total, float actual)
    {
        GeneratorHealthMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalGeneratorHealthSize * (actual / total));
    }

    public void ActivateHealTimer(bool nState)
    {
        HealModuleBar.SetActive(nState);
    }
    public void UpdateGeneratorHeal(float healDelay, float healTimer)
    {
        HealModuleMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalHealModuleHealthSize * (healTimer / healDelay));
    }
    public void ActivateUpgradeTimer(bool nState)
    {
        UpgradeModuleBar.SetActive(nState);
    }
    public void UpdateUpgradeBar(float upgradeDelay, float upgradeTimer)
    {
        UpgradeModuleMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalUpgradeModuleHealthSize * (upgradeTimer / upgradeDelay));
        //Debug.Log("upgrade update");
    }
}
