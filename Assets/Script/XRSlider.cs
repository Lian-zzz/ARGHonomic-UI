using System;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// An interactable that follows the position of the interactor on a single axis
    /// </summary>
    public class XRSlider : XRBaseInteractable
    {
        [Serializable]
        public class ValueChangeEvent : UnityEvent<float> { }

        [SerializeField]
        [Tooltip("The object that is visually grabbed and manipulated")]
        Transform m_Handle = null;

        [SerializeField]
        [Tooltip("The value of the slider")]
        [Range(0.0f, 1.0f)]
        float m_Value = 0.5f;

        [SerializeField]
        [Tooltip("The offset of the slider at value '1'")]
        float m_MaxPosition = 5.5f;

        [SerializeField]
        [Tooltip("The offset of the slider at value '0'")]
        float m_MinPosition = -5.5f;

        [SerializeField]
        [Tooltip("Events to trigger when the slider is moved")]
        ValueChangeEvent m_OnValueChange = new ValueChangeEvent();

        [SerializeField] 
        TextMeshProUGUI current_Value; 
        //[SerializeField] 
        //TextMeshProUGUI max_ValueUI; 
        //TextMeshProUGUI fineness_LevelUI; 
        [SerializeField] 
        int max_Value; 

        IXRSelectInteractor m_Interactor;

        private Outline outline; 

        [SerializeField] private GameObject[] targets;

        [SerializeField] private GameObject[] scales = new GameObject[3];

        /// <summary>
        /// The value of the slider
        /// </summary>
        public float value
        {
            get => m_Value;
            set
            {
                SetValue(value);
                SetSliderPosition(value);
            }
        }

        public int sliderIntValue;

        /// <summary>
        /// Events to trigger when the slider is moved
        /// </summary>
        public ValueChangeEvent onValueChange => m_OnValueChange;

        void Start()
        {
            //max_ValueUI.text = "Max: " + max_Value;

            SetValue(m_Value);
            SetSliderPosition(m_Value);

            if (m_Handle != null)
            {
                outline = m_Handle.GetComponent<Outline>(); 
                outline.enabled = false;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            selectEntered.AddListener(StartGrab);
            selectExited.AddListener(EndGrab);
        }

        protected override void OnDisable()
        {
            selectEntered.RemoveListener(StartGrab);
            selectExited.RemoveListener(EndGrab);
            base.OnDisable();
        }

        void Update()
        {
            if (outline != null)
            {
                outline.enabled = this.isHovered || this.isSelected ; 
            }
        }

        void StartGrab(SelectEnterEventArgs args)
        {
            m_Interactor = args.interactorObject;
            UpdateSliderPosition();
        }

        void EndGrab(SelectExitEventArgs args)
        {
            m_Interactor = null;
        }

        public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
        {
            base.ProcessInteractable(updatePhase);

            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            {
                if (isSelected)
                {
                    UpdateSliderPosition();
                }
            }
        }

        void UpdateSliderPosition()
        {
            // Put anchor position into slider space
            Debug.Log("current interactor " + m_Interactor);
            // get the transform from world space to local space
            var localPosition = transform.InverseTransformPoint(m_Interactor.GetAttachTransform(this).position);
            // note: the direction would be inversed without the -... 
            var sliderValue = Mathf.Clamp01((localPosition.x - m_MinPosition) / (m_MaxPosition - m_MinPosition));
            
            
            sliderIntValue = Mathf.RoundToInt(sliderValue * max_Value);            
            float fixedValue = (float)sliderIntValue / (float)max_Value;

            current_Value.text = "Current: " + sliderIntValue;

            SetValue(fixedValue);
            SetSliderPosition(fixedValue);
        }

        void SetSliderPosition(float value)
        {
            if (m_Handle == null)
                return;

            var handlePos = m_Handle.localPosition;
            handlePos.x = Mathf.Lerp(m_MinPosition, m_MaxPosition, value);
            m_Handle.localPosition = handlePos;
        }

        void SetValue(float value)
        {
            int old_int = Mathf.RoundToInt(m_Value * max_Value);
            int new_int = Mathf.RoundToInt(value * max_Value);
            m_Value = value;
            if (old_int !=new_int)
                m_OnValueChange.Invoke(m_Value);
        }

        void OnDrawGizmosSelected()
        {
            var sliderMinPoint = transform.TransformPoint(new Vector3(0.0f, 0.0f, m_MinPosition));
            var sliderMaxPoint = transform.TransformPoint(new Vector3(0.0f, 0.0f, m_MaxPosition));

            Gizmos.color = Color.green;
            Gizmos.DrawLine(sliderMinPoint, sliderMaxPoint);
        }

        public void UpdateFineness(FinenessLevel finenessLevel)
        {
            switch(finenessLevel)
            {
                case FinenessLevel.Low:
                    max_Value = 5;
                    UpdateScale(0); 
                    break;
                case FinenessLevel.Medium:
                    max_Value = 10;
                    UpdateScale(1); 
                    break;
                case FinenessLevel.High:
                    max_Value = 15;
                    UpdateScale(2); 
                    break;
                case FinenessLevel.Extreme: 
                    max_Value = 1000; 
                    UpdateScale(2); 
                    break;

            }
            //max_ValueUI.text = "Max: " + max_Value;
        }


        public void ResetTaskValue()
        {
            m_Value = 0.0f; 
            SetValue(m_Value);
            SetSliderPosition(m_Value);
            sliderIntValue = 0; 
            current_Value.text = "Current: 0"; 
        }

        public void UpdateTaskTarget(int id)
        {
            for (int i = 0; i < targets.Length ; i++)
            {
                if (i == id)
                {
                    targets[i].SetActive(true); 
                }
                else 
                    targets[i].SetActive(false); 
            }
        }

        public void UpdateScale(int id)
        {
            switch(id)
            {
                case(0): 
                    scales[0].SetActive(true); 
                    scales[1].SetActive(false); 
                    scales[2].SetActive(false); 
                    break; 
                case(1): 
                    scales[0].SetActive(true); 
                    scales[1].SetActive(true); 
                    scales[2].SetActive(false); 
                    break; 
                case(2): 
                    scales[0].SetActive(true); 
                    scales[1].SetActive(false); 
                    scales[2].SetActive(true); 
                    break; 
            }
        }

        void OnValidate()
        {
            SetSliderPosition(m_Value);
        }

    }
}
