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

    [SerializeField] private MatchData matchData;
    [SerializeField] private EnemiesSpawner enemiesSpawner;
    [SerializeField] private UIHandler _UIHandler;
    private int currentWave = 0;
    private int enemiesRemaining = 1;
    private int randomWaveNumber = 0;
    
    //Delegates
    private Action setWave;


    private void Start()
    {
        enemiesRemaining = matchData._initialWaves[0]._enemiesNumber;
        setWave += SetInitialWave;
        setWave += SetWaveText;
        setWave();
    }

    private void SetInitialWave()
    {
        enemiesSpawner.waveData = matchData._initialWaves[currentWave];
        enemiesRemaining = matchData._initialWaves[currentWave]._enemiesNumber;
        enemiesSpawner.ResetEnemiesCount();
        if (currentWave == matchData._initialWaves.Count - 1)
        {
            setWave -= SetInitialWave;
            setWave = SetInfinitWave;
            setWave += SetWaveText;
        }
        
    }

    private void SetInfinitWave()
    {
        randomWaveNumber = GetRandomNumber(matchData._infinitWaves.Count);
        enemiesRemaining = matchData._infinitWaves[randomWaveNumber]._enemiesNumber;
        enemiesSpawner.waveData = matchData._infinitWaves[randomWaveNumber];    
        enemiesSpawner.ResetEnemiesCount();      
    }

    private int GetRandomNumber(int number)
    {
        return UnityEngine.Random.Range(0, number);
    }

    private void SetWaveText()
    {
        _UIHandler.SetWave(currentWave + 1);
        _UIHandler.SetEnemiesRemaining(enemiesRemaining);
    }

    public void DecreaseEnemiesRemaining()
    {
        enemiesRemaining--;
        _UIHandler.SetEnemiesRemaining(enemiesRemaining);
        if (enemiesRemaining <= 0)
        {
            NextWave();
        }
    }

    private void NextWave()
    {
        enemiesSpawner.enabled = false;
        StartCoroutine(TimerBetweenWaves());
        
    }

    private IEnumerator TimerBetweenWaves()
    {
        _UIHandler.SetBetweenRounds();
        for (int i = matchData._secondsBetweenWaves; i >= 0; i--)
        {
            _UIHandler.SetTimeBetweenRounds(i);
            yield return new WaitForSeconds(1f);
        }
        currentWave++;
        enemiesSpawner.enabled = true;
        setWave();
    }
    
}
