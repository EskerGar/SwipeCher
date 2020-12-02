using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Settings;
using UnityEngine;
using UnityEngine.UI;

public class GameDesignView : MonoBehaviour
{
    [SerializeField] private Text delayBetweenShots;
    [SerializeField] private Text archerSpeed;
    [SerializeField] private Text enemySpeed;
    [SerializeField] private Text enemyAttackDelay;
    [SerializeField] private Text enemySpawnDelay;
    [SerializeField] private Text barrierSpawnDelay;
    [SerializeField] private ArcherSettings archerSettings;
    [SerializeField] private LevelSettings levelSettings;

    public void ChangeSettingValues()
    {
        float.TryParse(delayBetweenShots.text, out var archerDelayBetweenShots);
        float.TryParse(archerSpeed.text, out var speedArcher);
        float.TryParse(enemySpeed.text, out var speedEnemy);
        float.TryParse(enemyAttackDelay.text, out var attackEnemyDelay);
        float.TryParse(enemySpawnDelay.text, out var spawnEnemyDelay);
        float.TryParse(barrierSpawnDelay.text, out var spawnBarrierDelay);
        archerSettings.DelayBetweenShot = archerDelayBetweenShots;
        levelSettings.ArcherSpeed = speedArcher;
        levelSettings.EnemySpeed = speedEnemy;
        levelSettings.BarriersSpawnDelay = spawnBarrierDelay;
        levelSettings.EnemyAttackDelay = attackEnemyDelay;
        levelSettings.EnemySpawnDelay = spawnEnemyDelay;
    }

    private void Start()
    {
        delayBetweenShots.transform.parent.GetComponent<InputField>().text = archerSettings.DelayBetweenShot.ToString(CultureInfo.CurrentCulture);
        archerSpeed.transform.parent.GetComponent<InputField>().text = levelSettings.ArcherSpeed.ToString(CultureInfo.CurrentCulture);
        enemySpeed.transform.parent.GetComponent<InputField>().text = levelSettings.EnemySpeed.ToString(CultureInfo.CurrentCulture);
        enemyAttackDelay.transform.parent.GetComponent<InputField>().text = levelSettings.EnemyAttackDelay.ToString(CultureInfo.CurrentCulture);
        enemySpawnDelay.transform.parent.GetComponent<InputField>().text = levelSettings.EnemySpawnDelay.ToString(CultureInfo.CurrentCulture);
        barrierSpawnDelay.transform.parent.GetComponent<InputField>().text = levelSettings.BarriersSpawnDelay.ToString(CultureInfo.CurrentCulture);
    }
}
