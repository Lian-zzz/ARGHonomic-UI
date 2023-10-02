using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XRPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Button[] buttons;

    [SerializeField]
    [Tooltip("Moving speed of the panels")]
    float speed = 0.5f;

    private Vector3 activePosition = new Vector3 (0.0f, 0.0f, 0.0f); 
    private Vector3 inactivePosition = new Vector3 (0.0f, 0.0f, 10.0f); 

    private Color inactiveColor = Color.grey;

    private int currentPanel;
    

    void Start()
    {
        SetActivePanel(0);
    }



    public void SetActivePanel(int i)
    {
        LeanTween.move(panels[i], activePosition, speed); // if i < panels.length
        buttons[i].colors = ColorBlock.defaultColorBlock; // test color change 

        for (int j= 0; j < panels.Length; j++)
        {
            if ( j != i )
            {
                LeanTween.move(panels[j], inactivePosition, speed); 

                ColorBlock cb = buttons[j].colors;
                cb.normalColor = inactiveColor;
                buttons[j].colors = cb;
            }
        }

        currentPanel = i;
    }

    public int GetCurrentPanel() 
    {
        return currentPanel; 
    }


    
}
