using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XRProgressManager : MonoBehaviour
{

    [SerializeField] private GameObject[] tasks;


    public void LightUpTask(int i)
    {
        if (tasks != null)
        {
            if ( (0 <= i) && (i < tasks.Length) )
            {
                // the finished task should be marked as light yellow color 
                tasks[i].GetComponent<Image>().color = new Color32(253, 197, 0, 255);
            }
        }
    }   
}
