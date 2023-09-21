using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XRStateMonitor : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI currentPlayerUI; 
    [SerializeField] private TextMeshProUGUI currentPanelUI; 
    [SerializeField] private TextMeshProUGUI currentTaskUI; 
    [SerializeField] private TextMeshProUGUI currentControllerUI; 
    [SerializeField] private TextMeshProUGUI currentTimeUI; 
    [SerializeField] private TextMeshProUGUI currentValueUI;
    [SerializeField] private TextMeshProUGUI currentInteractionUI; 

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
