using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Spawn;
using TowerDefense.UI;

public class WaveManager : MonoBehaviour
{
    #region Singleton
    public static WaveManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    //Data
    [SerializeField] private MatchWavesData matchWavesData;
    private EnemiesSpawner enemiesSpawnerInstance;
    private int currentWave = 0;
    private int remainingEnemies = 0;
    
    //Delegates
    private Action setWave;

    private WaveUIManager waveUIManager;

    private void Start()
    {
        waveUIManager = GetComponent<WaveUIManager>();
        enemiesSpawnerInstance = EnemiesSpawner.instance;
        setWave += SetInitialWave;
        setWave += waveUIManager.SetUIWave;
        setWave();
    }

    private void SetInitialWave()
    {
        enemiesSpawnerInstance.waveData = matchWavesData._initialWaves[currentWave];
        currentWave++;
        if(currentWave == matchWavesData._initialWaves.Count - 1)
        {
            setWave -= SetInitialWave;
            setWave += SetInfinitWave;
        }
    }

    private void SetInfinitWave()
    {
        enemiesSpawnerInstance.waveData = matchWavesData._initialWaves[
            UnityEngine.Random.Range(0, matchWavesData._initialWaves.Count)];
    }

    private void NextWave()
    {
        //10 seconds timer
        setWave();
    }
    
}
