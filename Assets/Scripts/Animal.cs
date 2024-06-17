using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    internal Color animalColor;
    private GameObject food;
    private FoodGenerator foodGenerator;
    internal Vector2Int foodCell;
    private int n, v;
    private GameUI gameUI;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SimulationManager simulationManager = GameObject.FindAnyObjectByType<SimulationManager>();
        n = simulationManager.n;
        v = simulationManager.v;
        foodGenerator = GameObject.FindAnyObjectByType<FoodGenerator>();
        gameUI = GameObject.FindAnyObjectByType<GameUI>();
        animalColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<Renderer>().material.color = animalColor;
    }

    void Update() {
        if (food == null) {
            food = Instantiate(foodPrefab);
            food.GetComponent<Renderer>().material.color = animalColor;
            food.GetComponent<Food>().animal = GetComponent<Animal>();
            FoodNextPosition(true);
        }

        agent.speed = v*gameUI.timeScale;
    }

    internal void FoodNextPosition(bool firstGenerate = false) {
        foodCell = foodGenerator.GenerateFood(foodCell, v, firstGenerate);
        food.transform.position = Utils.CellToCord(foodCell, n, foodPrefab.transform.position.y);
        agent.destination = food.transform.position;
    }
}
