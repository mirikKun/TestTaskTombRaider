using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelRestartAnimator : MonoBehaviour
    {
        [SerializeField] private float _timeOfAnimation;
        [SerializeField] private Image _background;
        private float _maxColorFade;
        private float _fadeFrom;
        private float _fadeTo;
        private Color _backgroundColor;
        private float _currentAnimationTime;
        private bool _fading;
        private bool _turnOffBackground;

        private void Start()
        {
            _maxColorFade = _background.color.a;
        }

        private void Update()
        {
            if (!_fading)
                return;
            UpdateFading();
            if (_currentAnimationTime >= _timeOfAnimation)
            {
                StopAnimation();
            }
        }

        public void StartFadeIn()
        {
            _background.gameObject.SetActive(true);
            _fadeFrom = 0;
            _fadeTo = _maxColorFade;
            BeginAnimation();
            UpdateFading();
        }

        public void StartFadeOut()
        {
            _fadeFrom = _maxColorFade;
            _fadeTo = 0;
            _turnOffBackground = true;
            BeginAnimation();
        }

        private void BeginAnimation()
        {
            _fading = true;
            _currentAnimationTime = 0;
        }

        private void UpdateFading()
        {
            _currentAnimationTime += Time.deltaTime;
            _backgroundColor.a = Mathf.Lerp(_fadeFrom, _fadeTo, _currentAnimationTime / _timeOfAnimation);
            _background.color = _backgroundColor;
        }

        private void StopAnimation()
        {
            _backgroundColor.a = _fadeTo;
            _fading = false;
            if (_turnOffBackground)
            {
                _background.gameObject.SetActive(false);
                _turnOffBackground = false;
            }
        }
    }
}