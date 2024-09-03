using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName ="Enemy Scriptable")]
public class EnemyScriptable : ScriptableObject
{
    public int life;
    public int speed;
    public GameObject enemyAtt;
    public int attackSpeed;

    public int range;
}
