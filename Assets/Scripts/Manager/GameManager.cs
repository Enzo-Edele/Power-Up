using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Declaration
    public Generator generator;

    [SerializeField]int minSpawnDelay, maxSpawnDelay;
    float spawnTimer;

    [SerializeField] List<Enemy> enemiesList = new List<Enemy>();

    [SerializeField] GameObject enemyPrefabContact, enemyPrefabBomber, enemyPrefabBoss;
    #endregion

    public enum GameStates { InMenu, InGame, PauseTime, PauseMenu, Credits }
    private static GameStates gameState;
    public static GameStates GameState;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        //change to mainMenu and move spawntimerInit
        ChangeGameState(GameStates.InGame);
        spawnTimer = minSpawnDelay;
    }

    public void ChangeGameState(GameStates newState)
    {
        gameState = newState;
        GameState = gameState;
        switch (gameState)
        {
            case GameStates.InMenu:
                break;
            case GameStates.InGame:
                Time.timeScale = 1.0f;
                break;
            case GameStates.PauseTime:
                Time.timeScale = 0.0f; //to replace by condition in individual Timers
                break;
            case GameStates.PauseMenu:
                Time.timeScale = 0.0f;
                break;
            case GameStates.Credits:
                break;
        }
    }

    void StartGame()
    {
        
    }

    public void AddEnemy(Enemy enemy)
    {
        for (int i = 0; i < enemiesList.Count; i++)
            if (enemiesList[i] == enemy)
                return;
        enemiesList.Add(enemy);
    }
    public void RemoveEnemy(Enemy enemy)
    {
        for (int i = 0; i < enemiesList.Count; i++)
            if (enemy == enemiesList[i])
                enemiesList.RemoveAt(i);
    }
    public Enemy GetClosest(Vector3 towerPos)
    {
        float distance = 9999;
        int closest = -1;
        float nDist;
        for (int i = 0; i < enemiesList.Count; i++)
        {
            nDist = Vector3.Distance(towerPos, enemiesList[i].transform.position);
            if (nDist < distance)
            {
                distance = nDist;
                closest = i;
            }
        }
        if (closest > -1)
            return enemiesList[closest];
        else
            return null;
    }

    void Update()
    {
        //inputs
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.GameState == GameStates.InGame)
        {
            ChangeGameState(GameStates.PauseTime);
            //UIManager.ActivatePauseMenu(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.GameState == GameStates.PauseTime)
        {
            ChangeGameState(GameStates.InGame);
            //UIManager.ActivatePauseMenu(false);
        }

        //timers
        if (spawnTimer > 0 && GameManager.GameStates.InGame == GameManager.GameState)
            spawnTimer -= Time.deltaTime;
        else if (spawnTimer < 0)
        {
            float rnd = Random.Range(minSpawnDelay, maxSpawnDelay + 1);
            spawnTimer = rnd;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()//addType
    {
        int upDown = Random.Range(1, 3);

        Vector2 spawn = new Vector2();
        if (upDown == 1)
        {
            if (Random.Range(1, 3) == 1)
                spawn.x = -7.5f;
            else
                spawn.x = 7.5f;
            spawn.y = Random.Range(-5.5f, 5.5f);
        }
        else if (upDown == 2)
        {
            spawn.x = Random.Range(-7.5f, 7.5f);
            if (Random.Range(1, 3) == 1)
                spawn.y = 5.5f;
            else
                spawn.y = -5.5f;
        }
        GameObject nEnemy = Instantiate(enemyPrefabContact, spawn, Quaternion.identity);
        AddEnemy(nEnemy.GetComponent<Enemy>());
    }
}
