using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using TMPro;
using HTC.UnityPlugin.Vive;

public class XRButton : MonoBehaviour
{
    public TextMeshProUGUI count;
    private Animation anim;
    private Outline outline; 

    private int countValue = 0;
    private bool isHovered = false;
    bool pressed = false;
    //private InputDevice rightHand;
    //public InputHelpers.Button button;
    public ViveRoleProperty role = ViveRoleProperty.New();

    void Start()
    {
        anim = GetComponent<Animation>();
        outline = GetComponent<Outline>(); 
        outline.enabled = false; 
        //rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        //InvokeRepeating("UpdatePerSecond", 0, 1.0f);
    }

    void Update()
    {
        //InputHelpers.IsPressed(rightHand, button, out pressed);
        pressed = ViveInput.GetPress(role, ControllerButton.Trigger);
        isHovered = gameObject.GetComponent<XRSimpleInteractable>().isHovered;

        outline.enabled = isHovered; 

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

    public void UpdateFineness(FinenessLevel finenessLevel)
    {
        switch(finenessLevel)
        {
            case FinenessLevel.Low:
                this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case FinenessLevel.Medium:
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case FinenessLevel.High:
                this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                break;
        }
    }

    public int GetCountValue()
    {
        return this.countValue; 
    }

    public void ResetTaskTarget()
    {

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
