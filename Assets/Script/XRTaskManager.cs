using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XRTaskManager : MonoBehaviour 
{
    [SerializeField] private XRPanelManager m_PanelManager;
    [SerializeField] private TextMeshProUGUI taskTitle; 
    [SerializeField] private TextMeshProUGUI taskContent; 
    [SerializeField] private Button nextButton; 

    private int currentTask; 
    private bool currentTaskFinished = false; 

    
    

}