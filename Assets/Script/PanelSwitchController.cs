using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelSwitchController : MonoBehaviour
{

    [SerializeField] private GameObject[] panels;
    [SerializeField] private Vector3[] positions;

    [SerializeField]
    [Tooltip("Moving speed of the panels")]
    float speed = 2.5f;

    //[SerializeField] private Vector3 endPos;    
    //Vector3 moveOffset = new Vector3(0.0f, 0.0f, 5.0f); 
    //public int currentPanel = 0;

    public Button nextButton;
    public Button lastButton; 

    [SerializeField] 
    TextMeshProUGUI currentTime; 

    
    private float timer = 0.0f;
    private bool timerOn = false;

    public bool reorderFinished = false;
    public bool resetFinished = false; 

    // Start is called before the first frame update
    void Start()
    {
        this.PanelOrderReset();
        
        //nextButton.onClick.AddListener(() => NextButtonOnClick());
        //lastButton.onClick.AddListener(() => LastButtonOnClick());
    }
    void FixedUpdate()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;

        }
        currentTime.text = "Time: " + timer.ToString("00.00") + "s"; 
    }

    public void NextButtonOnClick()
    {
        StartCoroutine( OnNext() );
    }

    public void LastButtonOnClick()
    {
        StartCoroutine( OnLast() );
    }
    public IEnumerator OnNext()
    {
        reorderFinished = false;
        nextButton.interactable = false; 

        this.ReorderOnNext(panels); 
        yield return new WaitUntil(() => reorderFinished);

        resetFinished = false; 
        this.PanelOrderReset();
        yield return new WaitUntil(() => resetFinished);

        nextButton.interactable = true; 
    }

    public IEnumerator OnLast()
    {
        reorderFinished = false;
        lastButton.interactable = false;

        this.ReorderOnLast(panels); 
        yield return new WaitUntil(() => reorderFinished);

        resetFinished = false; 
        this.PanelOrderReset();
        yield return new WaitUntil(() => resetFinished);

        lastButton.interactable = true;
    }

    public void PanelOrderReset()
    {
        timerOn = false;
        Debug.Log(panels.ToString());
        
        for (int i= 0; i < panels.Length; i++)
        {
            LeanTween.move(panels[i], positions[i], speed);
        }       
        timer = 0.0f;
        timerOn = true; 
        resetFinished = true; 
    }

    public void ReorderOnNext(GameObject[] obj)
    {
        int s = obj.Length - 1;
        var t = obj[0];

        for (int i = 0; i < s; i++)
        {
            obj[i] = obj[i+1];
        }
        obj[s] = t;

        reorderFinished = true;
    }

    public void ReorderOnLast(GameObject[] obj)
    {
        int s = obj.Length - 1;
        var t = obj[s];
        
        for (int i = s; i > 0; i--)
        {
            obj[i] = obj[i-1];
        }
        obj[0] = t;

        reorderFinished = true;
    }
}
