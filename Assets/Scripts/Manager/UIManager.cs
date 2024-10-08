using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Declaration
    [SerializeField] Sprite OnButton, OffButton, Upgrade;

    [SerializeField] Image VictoryMask;
    float originalVictorySize;
    [SerializeField] GameObject VictoryBar;

    public UpgradeSelectMenu upgradeMenu;
    #endregion

    public static UIManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        originalVictorySize = VictoryMask.rectTransform.rect.width;
    }

    void Update()
    {
        
    }

    void ActivateWinBar(bool nState)
    {
        VictoryBar.SetActive(nState);
    }
    public void UpdateWinBar(float total, float actual)
    {
        VictoryMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalVictorySize * (actual / total));
    }

    public void ActivateUpgradeMenu(bool nState, bool moduleState = false, bool towerState = false)
    {
        upgradeMenu.gameObject.SetActive(nState);
        if (moduleState)
            upgradeMenu.DisplayModule();
        if (towerState)
            upgradeMenu.DisplayTower();
    }
}
