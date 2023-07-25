using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MySlider : MonoBehaviour
{
    private float maxValue;
    [SerializeField] protected GameObject dot;
    [SerializeField] protected Slider slider;
    public float start = -1.35f;
    public float end = 1.4f;
    public TextMeshProUGUI currentValue; 

    // Start is called before the first frame update
    void Start()
    {
        maxValue = slider.maxValue;
        GenerateDots();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(dropdown.value);
        //Debug.Log(dropdown.options[dropdown.value].text);
        currentValue.text = "Current: " + slider.value;
    }

    public void GenerateDots()
    {
        float interval = (end - start) / maxValue;
        for (int i=0; i<=maxValue; ++i)
        {
            var myDot = Instantiate(dot, this.transform);
            myDot.transform.localPosition = new Vector3(0.15f, -0.55f, start + i*interval);
            // Instantiate(dot, new Vector3(0.15f, -0.55f, start + i*interval), Quaternion.identity, this.transform);
        }
    }
}
