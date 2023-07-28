using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using TMPro;

public class ball_animation : MonoBehaviour
{
    public TextMeshProUGUI count;
    private Animation anim;
    private int countValue = 0;
    private bool isHovered = false;
    public InputHelpers.Button button;
    bool pressed = false;
    private InputDevice rightHand;

    void Start()
    {
        anim = GetComponent<Animation>();
        rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        //InvokeRepeating("UpdatePerSecond", 0, 1.0f);
    }

    void Update()
    {
        
        InputHelpers.IsPressed(rightHand, button, out pressed);
        isHovered = gameObject.GetComponent<XRSimpleInteractable>().isHovered;
        if (pressed & isHovered)
        {
            if (! (anim.isPlaying))
            {
                anim.Play("ball_touch");
                countValue ++; 
                count.text = "Count: " + countValue; 
            }  
        }
    }

/*     void UpdatePerSecond()
    {
        isHovered = gameObject.GetComponent<XRSimpleInteractable>().isHovered;
        if (isHovered) {Debug.Log("Ball is hovered");}
    } */
    
    /* void OnMouseDown()
    {
        if (! (anim.isPlaying))
        {
            anim.Play("ball_touch");
            countValue ++; 
            count.text = "Count: " + countValue; 
        }   
    } */

    /* public void OnPointerDown(PointerEventData eventData)
    {
        if (! (anim.isPlaying))
        {
            anim.Play("ball_touch");
            countValue ++; 
            count.text = "Count: " + countValue; 
        }  
    } */


}
