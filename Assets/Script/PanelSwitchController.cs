using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelSwitchController : MonoBehaviour
{

    [SerializeField] private GameObject[] panels;
    [SerializeField] private Vector3 endPos;

    [SerializeField]
    [Tooltip("The offset of the slider at value '1'")]
    float speed = 2.5f;

    Vector3 moveOffset = new Vector3(0,0,5); 

    public Button nextButton;
    public Button lastButton; 

    private int currentPanel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNext()
    {
        // next button should only work when current panel is not the last one
        if ( currentPanel != 3 )
        {
            // loop to move the panels except current panel forward
            for (int i = 0; i < 4; i++)
            {
                if ( i != currentPanel)
                {
                    LeanTween.move( panels[i], panels[i].transform.position - moveOffset, speed);
                }
                // else move the current panel to the end 
                else 
                {
                    LeanTween.move( panels[i], endPos, speed);
                }
            }
        }
    }

    public void OnLast()
    {
        // last button should only work when current panel is not the first one
        if ( currentPanel != 0 )
        {
            // loop to move the panels except last panel backward 
            for (int i = 0; i < 4; i++)
            {
                if ( i != (currentPanel - 1))
                {
                    LeanTween.move( panels[i], panels[i].transform.position + moveOffset, speed);
                }
                // else move the last panel to the front
                else 
                {
                    LeanTween.move( panels[i], new Vector3(0,0,0), speed);
                }
            }
        }
    }
}
