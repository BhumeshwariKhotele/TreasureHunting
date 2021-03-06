using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Slider healthSlider;
    public Text healthText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        healthSlider.maxValue = 10.0f;
    }
}
