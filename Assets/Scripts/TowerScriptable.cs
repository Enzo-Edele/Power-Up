using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Tower Scriptable")]
public class TowerScriptable : ScriptableObject
{
    public int life;
    public GameObject projectile;
    public int attackSpeed;
    public int range;
}
