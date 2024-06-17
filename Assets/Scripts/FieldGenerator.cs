using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class FieldGenerator : MonoBehaviour
{

    [SerializeField] private GameObject borderPrefab;
    [SerializeField] private GameObject animalPrefab;

    void Awake()
    {
        SimulationManager simulationManager = GameObject.FindAnyObjectByType<SimulationManager>();
        int n = simulationManager.n;
        int m = simulationManager.m;

        GameObject field_base = transform.GetChild(0).gameObject;
        field_base.transform.localScale = new Vector3(n, 0.1f, n);
        field_base.GetComponent<NavMeshSurface>().BuildNavMesh();

        Camera.main.transform.position = new Vector3(0, n, 0);

        GameObject border;
        for (int i = 0; i < n - 1; ++i) {
            border = Instantiate(borderPrefab, transform);
            border.transform.localScale = new Vector3(n+0.05f, 0.15f, 0.1f);
            border.transform.Translate(0, 0, i - (float)n/2 + 1);

            border = Instantiate(borderPrefab, transform);
            border.transform.localScale = new Vector3(0.1f, 0.15f, n+0.05f);
            border.transform.Translate(i - (float)n/2 + 1, 0, 0);
        }

        List<Vector2Int> cells = new List<Vector2Int>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                cells.Add(new Vector2Int(i, j));
            }
        }
        cells = cells.OrderBy( x => Random.value ).ToList( );

        GameObject animal;
        for (int i = 0; i < m; ++i) {
            animal = Instantiate(animalPrefab);
            animal.GetComponent<Animal>().foodCell = cells[i];
            animal.transform.position = Utils.CellToCord(cells[i], n, animalPrefab.transform.position.y);
        }
    }
}
