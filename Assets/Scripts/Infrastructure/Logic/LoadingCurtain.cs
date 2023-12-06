using System.Collections;
using UnityEngine;

namespace Infrastructure.Logic
{
  public class LoadingCurtain : MonoBehaviour
  {
    public CanvasGroup Curtain;

    private float _fadingSpeed = 0.2f;
    private void Awake()
    {
      DontDestroyOnLoad(this);
    }

    public void Show()
    {
      gameObject.SetActive(true);
      Curtain.alpha = 1;
    }

    public void StartHiding() => StartCoroutine(DoFadeIn());

    public void StartShowing() => StartCoroutine(DoFadeOut());

    private void Hide()
    {
      gameObject.SetActive(true);
      Curtain.alpha = 0;
    }

    private IEnumerator DoFadeIn()
    {
      while (Curtain.alpha > 0)
      {
        Curtain.alpha -= _fadingSpeed;
        yield return new WaitForSeconds(_fadingSpeed);
      }

      gameObject.SetActive(false);
    }

    private IEnumerator DoFadeOut()
    {
      Hide();
      while (Curtain.alpha <1)
      {
        Curtain.alpha += _fadingSpeed;
        yield return new WaitForSeconds(_fadingSpeed);
      }
    }
  }
}