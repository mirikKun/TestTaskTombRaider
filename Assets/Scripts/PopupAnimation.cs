using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupAnimation : MonoBehaviour
{
    [SerializeField] private float _timeOfAnimation;
    [SerializeField] private float _maxColorFade;
    [SerializeField] private Image _background;
    [SerializeField] private Transform _popup;

    [SerializeField] private Transform _firstOutPosition;
    [SerializeField] private Transform _destinationPosition;
    [SerializeField] private Transform _secondOutPosition;

    private AnimationState _state = AnimationState.None;

    private Vector3 _from;
    private Vector3 _to;

    private float _fadeFrom;
    private float _fadeTo;
    private float _currentAnimationTime;
    private Color _backgroundColor;

    private bool _animationGoing;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _maxColorFade = _background.color.a;
        _backgroundColor = _background.color;
    }

    private void Update()
    {
        if (!_animationGoing)
            return;
        UpdateAnimation();
        if (_currentAnimationTime >= _timeOfAnimation)
        {
            StopAnimation();
        }
    }

    private void UpdateAnimation()
    {
        _currentAnimationTime += Time.deltaTime;
        _popup.position = Vector3.Lerp(_from, _to, _currentAnimationTime / _timeOfAnimation);
        _backgroundColor.a = Mathf.Lerp(_fadeFrom, _fadeTo, _currentAnimationTime / _timeOfAnimation);
        _background.color = _backgroundColor;
    }

    public void StartAnimationIn()
    {
        if (_state != AnimationState.None)
        {
            return;
        }
        _state = AnimationState.In;

        _from = _firstOutPosition.position;
        _to = _destinationPosition.position;

        _fadeTo = _maxColorFade;
        _fadeFrom = 0;

        StartAnimation();
    }

    public void StartAnimationOut()
    {
        if (_state != AnimationState.None)
        {
            return;
        }

        _state = AnimationState.Out;

        _from = _destinationPosition.position;
        _to = _secondOutPosition.position;

        _fadeTo = 0;
        _fadeFrom = _maxColorFade;

        StartAnimation();
    }

    private void StartAnimation()
    {
        _background.gameObject.SetActive(true);
        _popup.gameObject.SetActive(true);
        _animationGoing = true;
        _currentAnimationTime = 0;

        _popup.position = _from;
        _backgroundColor.a = _fadeFrom;
        _background.color = _backgroundColor;
    }

    private void StopAnimation()
    {
        if (_state == AnimationState.Out)
        {
            _background.gameObject.SetActive(false);
            _popup.gameObject.SetActive(false);
        }
        _popup.position = _to;
        _backgroundColor.a = _maxColorFade;
        _animationGoing = false;
        _state = AnimationState.None;
    }

    private enum AnimationState
    {
        In,
        Out,
        None
    }
}