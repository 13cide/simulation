using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    internal int n;
    internal int m;
    internal int v;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
