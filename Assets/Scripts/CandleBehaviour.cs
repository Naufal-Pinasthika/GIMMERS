using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CandleBehaviour : MonoBehaviour
{
    private Vector3 upScaled;
    private Vector3 normalScale;
    private Vector3 offsetToCenter;
    private Vector3 mousepos;
    public bool isDragging;
    private float TimeToHold;
    public int HealthPoints = 10;
    private void Start()
    {   upScaled = transform.localScale * 1.2f;
        normalScale = transform.localScale;
    }

    private void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isDragging)
        {
            TimeToHold += Time.deltaTime;
            if (TimeToHold > 2) { isDragging = false; TimeToHold = 0; }
            transform.localScale = upScaled;
            transform.position =  mousepos + offsetToCenter;
        }
        else transform.localScale = normalScale;
    }

    private void OnMouseDown()
    {
        offsetToCenter = transform.position - mousepos;
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
}
