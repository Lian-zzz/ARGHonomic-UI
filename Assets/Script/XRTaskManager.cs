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

    [SerializeField] private XRButton m_Button; 
    [SerializeField] private UnityEngine.XR.Content.Interaction.XRSlider m_Slider;
    [SerializeField] private UnityEngine.XR.Content.Interaction.XRKnob m_Knob; 
 
    private int currentTask; 
    private bool currentTaskFinished; 

    private int buttonTargetCount; 
    private int sliderTargetValue; 
    private int knobTargetValue; 

    void Start()
    {
        currentTaskFinished = false;
        currentTask = 1;
        DisplayTask(currentTask);

        buttonTargetCount = 5; 
        sliderTargetValue = -1; 
        knobTargetValue = -1;
    }

    void Update()
    {
        UpdateTaskStatus();

        nextButton.enabled = currentTaskFinished;
    }

    public void UpdateTaskStatus()
    {
        if ( m_Button.GetCountValue() >= buttonTargetCount || 
             m_Slider.sliderIntValue == sliderTargetValue || 
             m_Knob.value == (float)knobTargetValue / m_Knob.GetAngleIncrement() )
            currentTaskFinished = true; 
        else 
            currentTaskFinished = false; 
    }
    public void DisplayTask(int i)
    {
        switch(i)
        {
            case 1: 
                taskTitle.text = "Task 1 - Button Fineness Level Low"; 
                taskContent.text = "Please click the button below for five times."; 
                m_Button.UpdateFineness(FinenessLevel.Low); 
                break; 
            case 2: 
                taskTitle.text = "Task 2 - Button Fineness Level Medium"; 
                taskContent.text = "Please click the button below for five times."; 
                m_Button.UpdateFineness(FinenessLevel.Medium); 
                break; 
            case 3: 
                taskTitle.text = "Task 3 - Button Fineness Level High"; 
                taskContent.text = "Please click the button below for five times."; 
                m_Button.UpdateFineness(FinenessLevel.High); 
                break; 
            case 4: 
                taskTitle.text = "Task 4 - Slider Fineness Level Low"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Low);
                sliderTargetValue = 3; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 5: 
                taskTitle.text = "Task 5 - Slider Fineness Level Medium"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.Medium);
                sliderTargetValue = 6; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 6:     
                taskTitle.text = "Task 6 - Slider Fineness Level High"; 
                taskContent.text = "Please move the slider to the highlighted target."; 
                m_Slider.UpdateFineness(FinenessLevel.High);
                sliderTargetValue = 9; 
                //m_Slider.UpdateTaskTarget(sliderTargetValue); 
                break; 
            case 7:     
                taskTitle.text = "Task 7 - Knob Fineness Level Low"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Medium);
                knobTargetValue = 2; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 8:     
                taskTitle.text = "Task 8 - Knob Fineness Level Medium"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.Medium);
                knobTargetValue = 4; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
            case 9:     
                taskTitle.text = "Task 9 - Knob Fineness Level High"; 
                taskContent.text = "Please turn the pointer of the knob to the highlighted target."; 
                m_Knob.UpdateFineness(FinenessLevel.High);
                knobTargetValue = 6; 
                //m_Knob.UpdateTaskTarget(knobTargetValue); 
                break; 
        }   
    }
    
    
    public void NextTask()
    {
        // check currentTask finished before -> binding with button state? 
        DiscardTask(currentTask); 
        currentTask++; 
        if (currentTask == 4)
            m_PanelManager.SetActivePanel(1); 
        if (currentTask == 7)
            m_PanelManager.SetActivePanel(2); 
        DisplayTask(currentTask); 
    }

    public void DiscardTask(int i)
    {
        taskTitle.text = ""; 
        taskContent.text = ""; 
        if (i >= 1 & i <= 3)
            m_Button.ResetTaskValue(); 
        if (i >= 4 & i <= 6)
        {
            m_Slider.ResetTaskValue(); 
            sliderTargetValue = -1; 
        }
        if (i >= 7 & i <= 9)
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
        if (currentTask >= 1 & currentTask <= 3)
            return m_Button.GetCountValue(); 
        if (currentTask >= 4 & currentTask <= 6)
        {
            return m_Slider.sliderIntValue; 
        }
        if (currentTask >= 7 & currentTask <= 9)
        {
            return (int)m_Knob.value;
        }
        return -1; 
    }

}