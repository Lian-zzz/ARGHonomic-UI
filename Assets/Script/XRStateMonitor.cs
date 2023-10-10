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

    [SerializeField] private XRTaskManager m_TaskManager; 
    [SerializeField] private XRPanelManager m_PanelManager; 

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

    void UpdateValues()
    {
        
        currentPanel = m_PanelManager.GetCurrentPanel().ToString(); 
        currentTask = m_TaskManager.GetCurrentTask().ToString(); 
        //unscaled time so that it would not be affected by performance lag etc. 
        currentTime = Time.unscaledTime.ToString(); 
        currentValue = m_TaskManager.GetCurrentValue().ToString(); 

    }
}
