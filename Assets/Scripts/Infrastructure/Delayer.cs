using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
    public class Delayer
    {
        private readonly ICoroutineRunner _coroutineRunner;

        [Inject]
        public Delayer(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public Coroutine Wait(float time, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(WaitSeconds(time, onLoaded));

        public Coroutine WaitFrame(Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(WaitCoroutineFrame(onLoaded));

        public Coroutine Wait(Coroutine coroutine, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(WaitCoroutine(coroutine, onLoaded));

        private IEnumerator WaitSeconds(float time, Action onLoaded = null)
        {
            yield return new WaitForSeconds(time);
            onLoaded?.Invoke();
        }

        private IEnumerator WaitCoroutine(Coroutine coroutine, Action onLoaded = null)
        {
            yield return coroutine;
            onLoaded?.Invoke();
        }

        private IEnumerator WaitCoroutineFrame(Action onLoaded = null)
        {
            yield return null;
            onLoaded?.Invoke();
        }
    }
}