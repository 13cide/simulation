using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Slider NSlider;
    [SerializeField] private Slider MSlider;
    [SerializeField] private Slider VSlider;
    [SerializeField] private TextMeshProUGUI NCounter;
    [SerializeField] private TextMeshProUGUI MCounter;
    [SerializeField] private TextMeshProUGUI VCounter;
    [SerializeField] private SimulationManager simulationManager;

    public void NSliderChange() {
        NCounter.text = NSlider.value.ToString();
        MSlider.maxValue = NSlider.value * NSlider.value / 2;
    }

    public void MSliderChange() {
        MCounter.text = MSlider.value.ToString();
    }

    public void VSliderChange() {
        VCounter.text = VSlider.value.ToString();
    }

    public void GameStart() {
        simulationManager.m = (int)MSlider.value;
        simulationManager.n = (int)NSlider.value;
        simulationManager.v = (int)VSlider.value;

        SceneManager.LoadScene("GameScene");
    }
}
