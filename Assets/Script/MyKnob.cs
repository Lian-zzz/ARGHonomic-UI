using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyKnob : MonoBehaviour
{
    [SerializeField] Transform handle; 
    [SerializeField] Image fill; 
    [SerializeField] TextMeshProUGUI value; 
    [SerializeField] Transform knob;
    Vector3 mousePos;
    Quaternion startRotation;

    public void Start() 
    {
        startRotation = knob.rotation; 
    }

    public void onHandleDrag()
    {
        // Debug.Log("Drag"); 
        mousePos = Input.mousePosition; 
        // Debug.Log(mousePos);
        Vector2 dir = mousePos - handle.position; 
        float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg; 
        angle = (angle <= 0) ? (360 + angle) : angle;
        //Debug.Log(angle);
        if (angle <= 135 || angle >= 225) 
        {
            Quaternion r = Quaternion.AngleAxis (angle - 135f, Vector3.up); 
            // handle.rotation = r; 
            knob.rotation = startRotation*r;
            angle = ( (angle >= 225) ? (angle - 360) : angle) + 135; 
            fill.fillAmount = 0.75f - (angle / 360f); 
            value.text = Mathf.Round ( (fill.fillAmount*100) / 0.75f ).ToString();
        }
    }
}
