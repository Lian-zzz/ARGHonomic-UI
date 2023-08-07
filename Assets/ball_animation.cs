using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using TMPro;
using HTC.UnityPlugin.Vive;

public class ball_animation : MonoBehaviour
{
    public TextMeshProUGUI count;
    private Animation anim;
    private int countValue = 0;
    private bool isHovered = false;
    bool pressed = false;
    //private InputDevice rightHand;
    //public InputHelpers.Button button;
    public ViveRoleProperty role = ViveRoleProperty.New();

    void Start()
    {
        anim = GetComponent<Animation>();
        //rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        //InvokeRepeating("UpdatePerSecond", 0, 1.0f);
    }

    void Update()
    {
        //InputHelpers.IsPressed(rightHand, button, out pressed);
        pressed = ViveInput.GetPress(role, ControllerButton.Trigger);
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
        //if (pressed) {Debug.Log(button + "is pressed");}
        //if (isHovered) {Debug.Log("Ball is hovered");}
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
