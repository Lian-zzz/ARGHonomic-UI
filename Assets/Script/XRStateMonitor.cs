using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class XRStateMonitor : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI currentPlayerUI; 
    [SerializeField] private TextMeshProUGUI currentPanelUI; 
    [SerializeField] private TextMeshProUGUI currentTaskUI; 
    //[SerializeField] private TextMeshProUGUI currentControllerUI; 
    [SerializeField] private TextMeshProUGUI currentLeftControllerStateUI; 
    [SerializeField] private TextMeshProUGUI currentRightControllerStateUI; 
    [SerializeField] private TextMeshProUGUI currentTimeUI; 
    [SerializeField] private TextMeshProUGUI currentValueUI;
    [SerializeField] private TextMeshProUGUI currentInputUI; 

    [SerializeField] private XRTaskManager m_TaskManager; 
    [SerializeField] private XRPanelManager m_PanelManager; 
    [SerializeField] private XRDatabase m_Database; 

    //[SerializeField] private XRPointerHandler m_PointerHandler; 
    /*
    private string _currentPlayer; 
    private string _currentPanel; 
    private string _currentTask; 
    private string _currentController; 
    private string _currentTime; 
    private string _currentValue;
    private string _currentInput; 
    */
    private bool leftGrip = false; 
    private bool rightGrip = false; 
    private bool leftTrigger = false; 
    private bool rightTrigger = false; 
    private InputData _inputData;

    private StreamWriter writer; 
    private string[] log; 


    // Start is called before the first frame update
    void Start()
    { 
        // time format should be with point instead of comma -> could be problematic in .csv files
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        _inputData = GetComponent<InputData>();
        
        writer = new StreamWriter(GetPath(), true);
        writer.WriteLine("Current Player" + "," + 
                        "Current Panel" + "," +
                        "Current Task" + "," +
                        "Current Left Controller State" + "," +
                        "Current Right Controller State" + "," +
                        "Current Time" + "," +
                        "Current Value" + "," +
                        "Current Input" );
        log = new string[8]; 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValues();
        if (leftGrip || leftTrigger || rightGrip || rightTrigger)
        { 
            WriteValues();
        }
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

        currentPlayerUI.text = m_Database.playerID.ToString(); 

        currentPanelUI.text = m_PanelManager.GetCurrentPanel().ToString(); 
        currentTaskUI.text = m_TaskManager.GetCurrentTask().ToString(); 
        currentTimeUI.text = Time.unscaledTime.ToString(); 
        currentValueUI.text = m_TaskManager.GetCurrentValue().ToString(); 

        _inputData._leftController.TryGetFeatureValue(CommonUsages.isTracked, out bool leftState); 
        _inputData._rightController.TryGetFeatureValue(CommonUsages.isTracked, out bool rightState); 
        currentLeftControllerStateUI.text = (_inputData._leftController.isValid && leftState) ? "is tracked" : "not tracked"; 
        currentRightControllerStateUI.text = (_inputData._rightController.isValid && rightState) ? "is tracked" : "not tracked"; 

        currentInputUI.text = GetCurrentInput();

    }

    void WriteValues()
    {
        log[0] = currentPlayerUI.text; 
        log[1] = currentPanelUI.text;
        log[2] = currentTaskUI.text;
        log[3] = currentLeftControllerStateUI.text;
        log[4] = currentRightControllerStateUI.text;
        log[5] = currentTimeUI.text;
        log[6] = currentValueUI.text;
        log[7] = currentInputUI.text;

        string line = string.Join(",", log); 
        writer.WriteLine(line, true);
        writer.Flush();  
    }

    private string GetCurrentInput()
    {
        _inputData._leftController.TryGetFeatureValue(CommonUsages.gripButton, out leftGrip); 
        _inputData._rightController.TryGetFeatureValue(CommonUsages.gripButton, out rightGrip); 
        _inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out leftTrigger); 
        _inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out rightTrigger); 

        string leftGripChecker = (leftGrip) ? "Left Grip ":"";
        string rightGripChecker = (rightGrip) ? "Right Grip ":"";
        string leftTriggerChecker = (leftTrigger) ? "Left Trigger ":"";
        string rightTriggerChecker = (rightTrigger) ? "Right Trigger":"";

        return leftGripChecker + rightGripChecker + leftTriggerChecker + rightTriggerChecker;
    }


    private string GetPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/"  + "Saved_Log.csv";
        //"Participant " + "   " + DateTime.Now.ToString("dd-MM-yy   hh-mm-ss") + ".csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_Log.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_Log.csv";
#else
        return Application.dataPath +"/"+"Saved_Log.csv";
#endif
    }



}
