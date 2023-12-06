using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _maxPressingTime;
    [SerializeField] private Image _pressingProgressImage;
    private float _currentPressingTime;
    private bool _pressing;

    public Action OnButtonDown;
    public Action OnButtonUp;


    private void Update()
    {
        if (_pressing)
        {
            _currentPressingTime += Time.deltaTime;
            _pressingProgressImage.fillAmount = 1-_currentPressingTime / _maxPressingTime;

            if (_currentPressingTime >= _maxPressingTime)
            {
                EndPressing();
            }
        }
    }
    
    private void StartPressing()
    {
        _pressingProgressImage.enabled = true;

        _pressing = true;
        _currentPressingTime = 0;
        OnButtonDown?.Invoke();
    }

    private void EndPressing()
    {
        _pressingProgressImage.enabled = false;

        _pressing = false;
        OnButtonUp?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartPressing();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_pressing)
            EndPressing();
    }
}
