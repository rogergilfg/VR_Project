using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SliderController : MonoBehaviour
{
    [SerializeField] private InputActionReference grabLeft, grabRight;
    [SerializeField] private float limiteSlider;
    [SerializeField] private Transform leftHand, rightHand;

    private Vector3 initialPos;
    private Vector3 handPos;
    private Transform usedHand;
    private bool isGrabbed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void SliderGrabbed(InputAction.CallbackContext context)
    {
        initialPos = transform.localPosition;
        handPos = usedHand.position;
        isGrabbed = true;
        StopAllCoroutines();
    }

    void SliderReleased(InputAction.CallbackContext context)
    {
        isGrabbed = false;
        //transform.localPosition = initialPos;
        StartCoroutine(ReturnToInitialPos());
        //grabLeft.action.canceled -= SliderReleased;
        //grabRight.action.canceled -= SliderReleased;
    }

    IEnumerator ReturnToInitialPos()
    {
        Vector3 startPos = transform.localPosition;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime*5;
            transform.localPosition = Vector3.Lerp(startPos, initialPos, t);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbed == true)
        {
            Vector3 newHandPos = usedHand.position;
            Vector3 deltaPos = newHandPos - handPos;
            float movementDistance = Mathf.Clamp(deltaPos.magnitude,0, limiteSlider) ;
            transform.localPosition = initialPos + new Vector3(0, 0, movementDistance);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftHand")
        {
            grabLeft.action.performed += SliderGrabbed;
            grabLeft.action.canceled += SliderReleased;
            usedHand = leftHand;
        }
        else if(other.gameObject.tag == "RightHand")
        {
            grabRight.action.performed += SliderGrabbed;
            grabRight.action.canceled += SliderReleased;
            usedHand = rightHand;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LeftHand")
        {
            grabLeft.action.performed -= SliderGrabbed;
        }
        else if (other.gameObject.tag == "RightHand")
        {
            grabRight.action.performed -= SliderGrabbed;
        }
    }
}
