using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRStateMonitor : MonoBehaviour
{

    [SerializedField] private TextMeshProUGUI currentPlayerUI; 
    [SerializedField] private TextMeshProUGUI currentPanelUI; 
    [SerializedField] private TextMeshProUGUI currentTaskUI; 
    [SerializedField] private TextMeshProUGUI currentControllerUI; 
    [SerializedField] private TextMeshProUGUI currentTimeUI; 
    [SerializedField] private TextMeshProUGUI currentValueUI;
    [SerializedField] private TextMeshProUGUI currentInteractionUI; 

    private string currentPlayer; 
    private string currentPanel; 
    private string currentTask; 
    private string currentController; 
    private string currentTime; 
    private string currentValue;
    private string currentInteraction; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
