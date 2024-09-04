using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarItem : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] Sprite cellFull, cellEmpty;

    [SerializeField] List<Image> cellsList = new List<Image>();

    [SerializeField] int powerUsage;
    [SerializeField] int maxUsage;

    Building owner = null;

    public void SetOwner(Building nOwner)
    {
        owner = nOwner;
    }

    public void SetMaxPower(int nMax, int nUsage)
    {
        for (int i = 0; i < maxUsage; i++)
            RemovePowerBar();

        maxUsage = nMax;

        for(int i = 0; i < maxUsage; i++)
            AddPowerBar();

        int use = 0;
        while(use < nUsage)
        {
            PlusPowerUsage();
            use++;
        }

        SortChild();
    }
    public void StartGenerator(int nMax)
    {
        for (int i = 0; i < maxUsage; i++)
            RemovePowerBar();

        maxUsage = nMax;

        for (int i = 0; i < maxUsage; i++)
            AddPowerBar();

        int use = 0;
        while (use < maxUsage)
        {
            MinusPowerUsageGenerator();
            use++;
        }
    }

    public void AddPowerBar()
    {
        cellsList.Add(Instantiate(cellPrefab, transform).GetComponent<Image>());

        SortChild();
    }
    public void RemovePowerBar()
    {
        Image toRemove = cellsList[cellsList.Count - 1];
        cellsList.Remove(toRemove);
        Destroy(toRemove.gameObject);

        SortChild();
    }
    void SortChild()
    {
        for(int i = 1; i < cellsList.Count + 1; i++)
        {
            cellsList[i - 1].transform.SetSiblingIndex(i);
        }
    }

    public void PlusPowerUsage()
    {
        if(powerUsage < maxUsage)
        {
            //bah ouais t'as un bug le cas null servais au generator clap clap
            if(owner != null)
            {
                if (owner.AddPower())
                {
                    cellsList[powerUsage].sprite = cellFull;
                    powerUsage++;
                    //Debug.Log("add power success");
                }
            }
        }
        SetDisplay();
    }
    public void PlusPowerUsageGenerator()
    {
        if (powerUsage > 0)
        {
            powerUsage--;
            cellsList[powerUsage].sprite = cellEmpty;
        }
        SetDisplay();
    }
    public void MinusPowerUsage()
    {
        if (powerUsage > 0)
        {
            powerUsage--;
            cellsList[powerUsage].sprite = cellEmpty;
            if (owner != null)
                owner.MinusPower();
        }
        SetDisplay();
    }
    public void MinusPowerUsageGenerator()
    {
        if(powerUsage < maxUsage)
        {
            cellsList[powerUsage].sprite = cellFull;
            powerUsage++;
        }
        SetDisplay();
    }
    void SetDisplay()
    {
        for(int i = 0; i < cellsList.Count; i++)
        {
            if (i >= powerUsage)
                cellsList[i].sprite = cellEmpty;
            else
                cellsList[i].sprite = cellFull;
        }
    }
}
