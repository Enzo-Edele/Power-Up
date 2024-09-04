using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSelectItem : MonoBehaviour
{
    [SerializeField] TMP_Text upgradeName;
    [SerializeField] TMP_Text upgradeDescription;

    [SerializeField] int upgradeType;

    public void UpgradeTypeSelection()
    {
        upgradeType = Random.Range(0, 4);
    }
    public void SelectButton()
    {
        switch (upgradeType)
        {
            case 0:
                GameManager.Instance.generator.UpgradeGenerator();
                break;
            case 1:
                GameManager.Instance.generator.UpgradeHealModule();
                break;
            case 2:
                GameManager.Instance.generator.UpgradeUpgradeModule();
                break;
            case 3:
                GameManager.Instance.generator.UpgradeWinModule();
                break;
        }

        UIManager.Instance.ActivateUpgradeMenu(false);
    }

    public void Activate(bool nState)
    {
        gameObject.SetActive(nState);
        if (nState)
        {
            switch (upgradeType)
            {
                case 0:
                    upgradeName.text = "Generator Upgrade";
                    break;
                case 1:
                    upgradeName.text = "Heal Upgrade";
                    break;
                case 2:
                    upgradeName.text = "Reinforcer Upgrade";
                    break;
                case 3:
                    upgradeName.text = "Reactor Builder Upgrade";
                    break;
            }
        }
    }
}
