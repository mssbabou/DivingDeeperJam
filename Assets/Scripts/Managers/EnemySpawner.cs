using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Target")]
    [SerializeField] Transform submarine;

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject meleePrefab;
    [SerializeField] GameObject rangedPrefab;

    [Header("Spawn Areas")]
    public Vector2[] areaPositions = new Vector2[2];
    public Vector2[] areaSizes = new Vector2[2];

    struct SpawnSettings
    {
        public float spawnFrequency;
        public float meleeChance;
        public float rangedChance;
    }
    SpawnSettings spawnSettings = new SpawnSettings();

    bool isSpawning;

    // Start is called before the first frame update

    void Awake()
    {
        GameManager.Singleton.OnNewTier += ChangeTier;
        GameManager.Singleton.OnGameWin += () => isSpawning = false;
    }

    void Start()
    {
        isSpawning = true;
        StartCoroutine(nameof(SpawnEnemies));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(areaPositions[0], areaSizes[0]);
        Gizmos.DrawWireCube(areaPositions[1], areaSizes[1]);
    }

    void ChangeTier(Difficulty newTier)
    {
        switch(newTier)
        {
            case Difficulty.Tier1:
                spawnSettings.spawnFrequency = .5f;
                spawnSettings.meleeChance = 1f;
                spawnSettings.rangedChance = 0f;
                    break;

            case Difficulty.Tier2:
                spawnSettings.spawnFrequency = 1f;
                spawnSettings.meleeChance = .7f;
                spawnSettings.rangedChance = .3f;
                break;

            case Difficulty.Tier3:
                spawnSettings.spawnFrequency = 2f;
                spawnSettings.meleeChance = .6f;
                spawnSettings.rangedChance = .4f;
                break;

            case Difficulty.Tier4:
                spawnSettings.spawnFrequency = 3.5f;
                spawnSettings.meleeChance = .4f;
                spawnSettings.rangedChance = .6f;
                break;

            case Difficulty.Tier5:
                spawnSettings.spawnFrequency = 5f;
                spawnSettings.meleeChance = .33f;
                spawnSettings.rangedChance = .67f;
                break;

            default:
                throw new UnityException("Changed to invalid tier in EnemySpawner\nTier: " + newTier);

        }
    }

    IEnumerator SpawnEnemies()
    {
        Vector2 spawnPos;
        byte areaIndex;
        GameObject spawnedObject;


        while (isSpawning)
        {
            areaIndex = (byte)Mathf.RoundToInt(Random.value);
            spawnPos = new Vector2(
                Random.Range(areaPositions[areaIndex].x - areaSizes[areaIndex].x / 2, areaPositions[areaIndex].x + areaSizes[areaIndex].x / 2),
                Random.Range(areaPositions[areaIndex].y - areaSizes[areaIndex].y / 2, areaPositions[areaIndex].y + areaSizes[areaIndex].y / 2));

            // Choose and spawn enemies
            float enemyValue = Random.value;
            if (enemyValue < spawnSettings.meleeChance)
                spawnedObject = Instantiate(meleePrefab, spawnPos, Quaternion.identity);

            else if (enemyValue < spawnSettings.meleeChance + spawnSettings.rangedChance)
                spawnedObject = Instantiate(rangedPrefab, spawnPos, Quaternion.identity);

            else
            {
                Debug.LogError("No enemy selected for spawning due to bad code, melee enemy chosen instead");
                spawnedObject = Instantiate(meleePrefab, spawnPos, Quaternion.identity);
            }

            if (areaIndex == 1)
                spawnedObject.GetComponent<SpriteRenderer>().flipX = true;

            yield return new WaitForSeconds(1f / spawnSettings.spawnFrequency);
        }
    }
}