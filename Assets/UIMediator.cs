using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMediator : MonoBehaviour
{
    [SerializeField] private PopupAnimation _popupAnimation;

    public void OpenPauseMenu() => _popupAnimation.StartAnimationIn();

    public void ClosePauseMenu() => _popupAnimation.StartAnimationOut();
}
