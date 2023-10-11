using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject coinPrefab;
    public List<GameObject> coins = new List<GameObject>();
    private float spawnTimeGoal = 5, spawnTime = 0;
    public int score;
    void Start()
    {

    }

    void Update()
    {
        spawnTime += Time.deltaTime;
        if(spawnTime > spawnTimeGoal)
        {
            spawnTime = 0;
            if (coins.Count < 5)
            {
                var newCoin = Instantiate(coinPrefab);
                newCoin.transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f), -0.5f);
                coins.Add(newCoin);
            }
        }
    }
    public void ScoreChange(int amt)
    {
        score += amt;
    }
}
