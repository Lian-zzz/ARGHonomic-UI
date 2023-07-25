using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball_animation : MonoBehaviour
{
    public TextMeshProUGUI count;
    private Animation anim;
    private int countValue = 0;

    void Start()
    {
        anim = GetComponent<Animation>();
    }
    
    void OnMouseDown()
    {
        if (! (anim.isPlaying))
        {
            anim.Play("ball_touch");
            countValue ++; 
            count.text = "Count: " + countValue; 
        }   
    }
}
