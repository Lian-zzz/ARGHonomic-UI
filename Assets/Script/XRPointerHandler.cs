using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class XRPointerHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool left = false; 
    private bool right = false; 
    private XRUIInputModule GetXRUIInputModule() => EventSystem.current.currentInputModule as XRUIInputModule; 

    private bool TryGetXRRayInteractor(int pointerID, out XRRayInteractor rayInteractor)
    {
        var inputModule = GetXRUIInputModule(); 
        if (inputModule == null)
        {
            rayInteractor = null; 
            return false;
        }

        rayInteractor = inputModule.GetInteractor(pointerID) as XRRayInteractor; 
        return rayInteractor != null; 

    }

    public string GetCurrentController()
    {
        // there should be only one input module active at a time, 
        // so left and right should not be active at the same time 
        if (right == true && left == true)
            Debug.LogError("Both active!!"); 
        if (right) return "Right"; 
        else if (left) return "Left"; 
        else return "-";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if ( TryGetXRRayInteractor(eventData.pointerId, out var rayInteractor) )
        {
            switch (rayInteractor.tag)
            {
                case("Left"): 
                    left = true; 
                    break;
                case("Right"):
                    right = true;
                    break;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if ( TryGetXRRayInteractor(eventData.pointerId, out var rayInteractor) )
        {
            switch (rayInteractor.tag)
            {
                case("Left"):
                    left = false; 
                    break;
                case("Right"):
                    right = false;
                    break;
            }
        }
    }
}
