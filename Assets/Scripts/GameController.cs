using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject coinPrefab;
    public GameObject gameOverScreen;
    public List<GameObject> coins = new List<GameObject>();
    private float spawnTimeGoal = 3, spawnTime = 0;
    public int score;
    public float fuel = 1000;
    public TextMeshProUGUI scoreText, fuelText;
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        fuelText.text = "Fuel: " + (int)fuel;
        spawnTime += Time.deltaTime;
        if(spawnTime > spawnTimeGoal)
        {
            spawnTime = 0;
            if (coins.Count < 5)
            {
                int scenario = Random.Range(0, 100);
                var amount = 1;
                if(scenario >= 99)
                {
                    amount = 10;
                } else if(scenario >= 90)
                {
                    amount = 5;
                } else if(scenario >= 60)
                {
                    amount = 2;
                }
                print(scenario);
                for (int i = 0; i < amount; i++)
                {
                    var newCoin = Instantiate(coinPrefab);
                    newCoin.transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f), -0.5f);
                    coins.Add(newCoin);
                }
            }
        }
    }
    public void ScoreChange(int amt)
    {
        score += amt;
    }
    public void UsingFuel()
    {
        fuel -= 25 * Time.deltaTime;
    }
}
