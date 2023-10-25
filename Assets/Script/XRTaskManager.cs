using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XRTaskManager : MonoBehaviour 
{
    [SerializeField] private XRPanelManager m_PanelManager;
    [SerializeField] private XRProgressManager m_ProgressManager; 
    [SerializeField] private TextMeshProUGUI taskTitle; 
    [SerializeField] private TextMeshProUGUI taskContent; 
    [SerializeField] private Button nextButton; 

    //[SerializeField] private XRButton m_Button; 
    [SerializeField] private UnityEngine.XR.Content.Interaction.XRSlider m_Slider;
    [SerializeField] private UnityEngine.XR.Content.Interaction.XRKnob m_Knob; 
 
    private int currentTask; 
    private bool currentTaskFinished; 

    //private int buttonTargetCount; 
    private int sliderTargetValue = -2; 
    private int knobTargetValue = -3; 
    //private float knobTargetTolerance; 
    private int targetTolerance = 0; 

    void Start()
    {
        
        currentTaskFinished = false;
        nextButton.onClick.AddListener(() => NextTask());
        currentTask = 1;
        DisplayTask(currentTask);

        //buttonTargetCount = 5; 
        //sliderTargetValue = -2; 
        //knobTargetValue = -3;
    }

    void Update()
    {
        UpdateTaskStatus();

        nextButton.enabled = currentTaskFinished;
    }

    public void UpdateTaskStatus()
    {
        if ( //m_Slider.sliderIntValue == sliderTargetValue || 
             //m_Knob.knobIntValue == knobTargetValue )
             //m_Button.GetCountValue() >= buttonTargetCount
             ( (1 <= currentTask && currentTask <= 12) && 
             Math.Abs(m_Slider.sliderIntValue - sliderTargetValue) <= targetTolerance ) ||
             ( (13 <= currentTask && currentTask <= 24) && 
             Math.Abs(m_Knob.knobIntValue - knobTargetValue) <= targetTolerance ) )  
            currentTaskFinished = true; 
        else 
            currentTaskFinished = false; 
    }
    public void DisplayTask(int i)
    {
        switch(i)
        {
            case 1: // slider fl: low, target: 0,6 
                sliderTargetValue = 3;  
                taskTitle.text = "Task 1 - Slider Fineness Level Low"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Low);
                m_Slider.UpdateTaskTarget(0); 
                break; 
            case 2: // slider fl: m, target: 0,6 
                taskTitle.text = "Task 2 - Slider Fineness Level Medium"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Medium);
                sliderTargetValue = 6; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 3: // slider fl: h, target: 0,6     
                taskTitle.text = "Task 3 - Slider Fineness Level High"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.High);
                sliderTargetValue = 9; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 4:  // slider fl: e, target: 0,6    
                taskTitle.text = "Task 4 - Slider Fineness Level Extreme"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Extreme);
                sliderTargetValue = 600; 
                targetTolerance = 3; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 5: // slider fl: low, target: 0,2 
                targetTolerance = 0; 
                taskTitle.text = "Task 5 - Slider Fineness Level Low"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Low);
                sliderTargetValue = 1; 
                m_Slider.UpdateTaskTarget(1); 
                break; 
            case 6: // slider fl: m, target: 0,2 
                taskTitle.text = "Task 6 - Slider Fineness Level Medium"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Medium);
                sliderTargetValue = 2; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 7: // slider fl: h, target: 0,2     
                taskTitle.text = "Task 7 - Slider Fineness Level High"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.High);
                sliderTargetValue = 3; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 8:  // slider fl: e, target: 0,2   
                taskTitle.text = "Task 8 - Slider Fineness Level Extreme"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Extreme);
                sliderTargetValue = 200; 
                targetTolerance = 3; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 9: // slider fl: low, target: 0,8 
                targetTolerance = 0; 
                taskTitle.text = "Task 9 - Slider Fineness Level Low"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Low);
                sliderTargetValue = 4; 
                m_Slider.UpdateTaskTarget(2); 
                break; 
            case 10: // slider fl: m, target: 0,8 
                taskTitle.text = "Task 10 - Slider Fineness Level Medium"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Medium);
                sliderTargetValue = 8; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 11: // slider fl: h, target: 0,8     
                taskTitle.text = "Task 11 - Slider Fineness Level High"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.High);
                sliderTargetValue = 12; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 12:  // slider fl: e, target: 0,8   
                taskTitle.text = "Task 12 - Slider Fineness Level Extreme"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Extreme);
                sliderTargetValue = 800; 
                targetTolerance = 3; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            
            case 13: // knob fl: low, target: 2/4   
                targetTolerance = 0; 
                taskTitle.text = "Task 13 - Knob Fineness Level Low"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Low);
                knobTargetValue = 2; 
                m_Knob.UpdateTaskTarget(0); 
                break; 
            case 14: // knob fl: m, target: 2/4        
                taskTitle.text = "Task 14 - Knob Fineness Level Medium"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Medium);
                knobTargetValue = 4; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 15: // knob fl: h, target: 2/4        
                taskTitle.text = "Task 15 - Knob Fineness Level High"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.High);
                knobTargetValue = 10; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 16: // knob fl: e, target: 2/4        
                taskTitle.text = "Task 16 - Knob Fineness Level Extreme"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Extreme);
                knobTargetValue = 160;  // consider the distance? 
                targetTolerance = 3; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            
            case 17: // knob fl: low, target: 1/4    
                targetTolerance = 0; 
                taskTitle.text = "Task 17 - Knob Fineness Level Low"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Low);
                knobTargetValue = 1; 
                m_Knob.UpdateTaskTarget(1); 
                break; 
            case 18: // knob fl: m, target: 1/4        
                taskTitle.text = "Task 18 - Knob Fineness Level Medium"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Medium);
                knobTargetValue = 2; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 19: // knob fl: h, target: 1/4        
                taskTitle.text = "Task 19 - Knob Fineness Level High"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.High);
                knobTargetValue = 5; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 20: // knob fl: e, target: 1/4        
                taskTitle.text = "Task 20 - Knob Fineness Level Extreme"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Extreme);
                knobTargetValue = 80; // consider the distance? 
                targetTolerance = 3; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            
            case 21: // knob fl: low, target: 3/4   
                targetTolerance = 0; 
                taskTitle.text = "Task 21 - Knob Fineness Level Low"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Low);
                knobTargetValue = 3; 
                m_Knob.UpdateTaskTarget(2); 
                break; 
            case 22: // knob fl: m, target: 3/4        
                taskTitle.text = "Task 22 - Knob Fineness Level Medium"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Medium);
                knobTargetValue = 6; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 23: // knob fl: h, target: 3/4        
                taskTitle.text = "Task 23 - Knob Fineness Level High"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.High);
                knobTargetValue = 15; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 24: // knob fl: e, target: 3/4        
                taskTitle.text = "Task 24 - Knob Fineness Level Extreme"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Extreme);
                knobTargetValue = 240; // consider the distance? 
                targetTolerance = 3; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 

            case 25: // for final panel  
                taskTitle.text = "Congratulations!"; 
                taskContent.text = "You have successfully finished all the tasks."; 
                break; 
        }   
    }
    
    
    public void NextTask()
    {
        if (currentTaskFinished == true && currentTask <= 24)
        {
            // check currentTask finished before -> binding with button state? 
            DiscardTask(currentTask); 
            // task id starts from 1, while in tasks array-id starts from 0
            m_ProgressManager.LightUpTask(currentTask - 1 );
            currentTask++; 
            if (currentTask == 13)
                m_PanelManager.SetActivePanel(1); 
            if (currentTask == 25)
                m_PanelManager.SetActivePanel(2); 
            DisplayTask(currentTask); 
        }
    }

    public void DiscardTask(int i)
    {
        taskTitle.text = ""; 
        taskContent.text = ""; 
        if (i >= 1 & i <= 12)
        {
            m_Slider.ResetTaskValue(); 
            sliderTargetValue = -1; 
        }
        if (i >= 13 & i <= 24)
        {
            m_Knob.ResetTaskValue(); 
            knobTargetValue = -1; 
        }
    }

    public int GetCurrentTask()
    {
        return currentTask; 
    }
    
    public int GetCurrentValue()
    {
        if (1 <= currentTask && currentTask <= 12)
        {
            return m_Slider.sliderIntValue; 
        }
        if (13 <= currentTask && currentTask <=  24)
        {
            return m_Knob.knobIntValue;
        }
        else 
            return -1; 
    }

    public int GetCurrentTarget()
    {
        if (1 <= currentTask && currentTask <= 12)
        {
            return sliderTargetValue; 
        }
        if (13 <= currentTask && currentTask <=  24)
        {
            return knobTargetValue;
        }
        else 
            return -1; 
    }

    public bool GetCurrentTaskState()
    {
        return currentTaskFinished; 
    }

}