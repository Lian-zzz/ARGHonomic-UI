using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
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
    [SerializeField] private XRPointerHandler m_PointerHandler; 

    private string _currentPlayer; 
    private string _currentPanel; 
    private string _currentTask; 
    private string _currentController; 
    private string _currentTime; 
    private string _currentValue;
    private string _currentInteraction; 

    private InputData _inputData;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValues();
    }

    void UpdateValues()
    {
        // _currentPlayer = 
        
        //_currentPanel = m_PanelManager.GetCurrentPanel().ToString(); 
        //_currentTask = m_TaskManager.GetCurrentTask().ToString(); 
        //unscaled time so that it would not be affected by performance lag etc. 
        //_currentTime = Time.unscaledTime.ToString(); 
        //_currentValue = m_TaskManager.GetCurrentValue().ToString(); 

        //_currentController = m_PointerHandler.GetCurrentController();

        currentPanelUI.text = m_PanelManager.GetCurrentPanel().ToString(); 
        currentTaskUI.text = m_TaskManager.GetCurrentTask().ToString(); 
        currentTimeUI.text = Time.unscaledTime.ToString(); 
        currentValueUI.text = m_TaskManager.GetCurrentValue().ToString(); 
        currentControllerUI.text = m_PointerHandler.GetCurrentController();

    }



}
