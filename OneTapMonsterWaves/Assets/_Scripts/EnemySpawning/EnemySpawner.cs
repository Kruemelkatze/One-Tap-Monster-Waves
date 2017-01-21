using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public AnimationCurve enemiesDistribution = new AnimationCurve();
    public AnimationCurve avgLevelDistribution = new AnimationCurve();
    public int probabilityQuantizationSize = 100;

    public int MinLevel = 1;
    public int MaxLevel = 50;
    public int NumberOfEnemies = 20;

    public float avgLevelDeviation = 2f;

    private float[] deviationLookupTable = new float[30] { 0, 0, 0, 0.333333333f, 0.333333333f, 0.333333333f, 0.666666667f, 0.666666667f, 0.666666667f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

    private List<float> enemiesDistributionValues;
    private List<float> avgLevelDistributionValues;

    public GameObject enemyPrefab;
    public GameObject enemyHolderObject;


    private System.Random rand = new System.Random();

    // private List<float> 
    // Use this for initialization
    void Start()
    {
        //Create DistretePropabilities
        CreateDiscreteProbabilities();
    }

    private void CreateDiscreteProbabilities()
    {
        enemiesDistributionValues = new List<float>(probabilityQuantizationSize);
        avgLevelDistributionValues = new List<float>(probabilityQuantizationSize);

        float step = 1f / probabilityQuantizationSize;
        for (int i = 0; i < probabilityQuantizationSize; i++)
        {
            enemiesDistributionValues.Add(enemiesDistribution.Evaluate(step * i));
            avgLevelDistributionValues.Add(avgLevelDistribution.Evaluate(step * i));
        }

        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        //Position
        float randomYIndex = RandomFromDistribution.RandomChoiceFollowingDistribution(enemiesDistributionValues); //It's actually an index
        float randomYPos = Grid.World.worldHeight * (randomYIndex / probabilityQuantizationSize);
        randomYPos = InRange(3, randomYPos, Grid.World.worldHeight - 3);

        float randomX = GetRandomNumber(0, Grid.World.worldWidth);
        randomX = InRange(1, randomX, Grid.World.worldWidth - 1);

        Vector2 position = new Vector2(randomX, randomYPos);

        //Level

        float avgLevel = avgLevelDistribution.Evaluate(randomYIndex / probabilityQuantizationSize);
        int level = (int)((MaxLevel - MinLevel) * avgLevel) + MinLevel;
        int before = level;
        float deviation = deviationLookupTable[level] * avgLevelDeviation;
		level = (int)RandomFromDistribution.RandomNormalDistribution(level, deviation);

        //Debug.Log(before + " --> " + level);


        var newEnemy = GameObject.Instantiate(enemyPrefab, position, Quaternion.identity);
        newEnemy.transform.parent = enemyHolderObject.transform;
        newEnemy.name = "" + level;
    }

    public float GetRandomNumber(float minimum, float maximum)
    {
        return (float)rand.NextDouble() * (maximum - minimum) + minimum;
    }

    public float InRange(float min, float val, float max)
    {
        if (val > max)
        {
            return max;
        }
        else if (val < min)
        {
            return min;
        }
        else
        {
            return val;
        }
    }

    struct EnemyType
    {
        GameObject prefab;
        int levelFrom;
        int levelTo;
    }
}
