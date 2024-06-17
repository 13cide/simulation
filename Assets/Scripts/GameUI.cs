using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    internal int timeScale = 1;
    public void ChangeSimulationSpeed() {
        timeScale = Math.Clamp(Int32.Parse(inputField.text), 0, 1000);
        inputField.text = timeScale.ToString();
    }
}
