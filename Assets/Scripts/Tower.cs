using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : Building
{
    public GameObject projectile;
    public int attackDelay;
    float attackTimer;
    public int range;
    public int life; //unuse

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer weaponRenderer;

    [SerializeField] Image Switchbutton;
    [SerializeField] Color buttonOn, ButtonOff;

    [SerializeField] Button UpgradeButton;

    [SerializeField] BuildingItem towerItemUI;

    bool isActive;

    Enemy target;

    public void StartGame()
    {
        attackTimer = attackDelay;
        isActive = false;
        //Switch();

        towerItemUI.powerBar.SetOwner(this);
        towerItemUI.powerBar.SetMaxPower(energyMax, energyUse);
        towerItemUI.powerBar.PlusPowerUsage();
    }

    private void Update()
    {
        if (attackTimer > 0 && GameManager.GameStates.InGame == GameManager.GameState && isActive)
            attackTimer -= Time.deltaTime;
        else if (attackTimer < 0)
        {
            attackTimer = attackDelay;
            Shoot();
        }
    }

    public override bool AddPower()
    {
        //Debug.Log(GameManager.Instance.generator.HasEnergy());
        //Debug.Log(energyUse < energyMax);
        if (energyUse < energyMax && GameManager.Instance.generator.HasEnergy())
        {
            if (energyUse == 0)
                SetOn(true);
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
            if (energyUse == 0)
                SetOn(false);
            GameManager.Instance.generator.MinusPowerUsage();
        }
    }

    public void Switch()
    {
        if (isActive)
            energyUse = 0;
        else
            energyUse = 1;
        SetOn(!isActive);
    }
    void SetOn(bool nState)
    {
        if (nState)
        {
            spriteRenderer.color = Color.white;
            weaponRenderer.color = Color.white;
            Switchbutton.color = buttonOn;
        }
        else
        {
            spriteRenderer.color = Color.gray;
            weaponRenderer.color = Color.gray;
            Switchbutton.color = ButtonOff;
        }
        towerItemUI.powerBar.SetMaxPower(energyMax, energyUse);
        isActive = nState;
    }

    void SelectTarget()
    {
        target = GameManager.Instance.GetClosest(transform.position);

        if (target != null)
        {
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.back));
            weaponRenderer.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }

    void Shoot()
    {
        if (target == null)
            SelectTarget();

        if (target != null)
        {
            Quaternion rotation = Quaternion.LookRotation((target.transform.position + target.transform.up) - transform.position, transform.TransformDirection(Vector3.back));
            Quaternion projectileRotation = new Quaternion(0, 0, rotation.z, rotation.w);
            Instantiate(projectile, transform.position, projectileRotation);
        }
    }

    public void ClickUpgradeButton()
    {
        Upgrade();
        ActivateUpgradeButton(true);
    }
    void ActivateUpgradeButton(bool nState)
    {
        UpgradeButton.gameObject.SetActive(nState);
    }

    public void Upgrade()
    {
        //pick 3 rnd Option
        //display on UI
        //Apply Upgrade

        //add power bar max++
        //call UI element
    }
}
