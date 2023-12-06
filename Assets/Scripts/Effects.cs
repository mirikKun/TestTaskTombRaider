using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private ParticleSystem _victoryEffect;

    public void PlayDeathEffect()
    {
        _deathEffect.Play();
    }

    public void PlayVictoryEffect()
    {
        _victoryEffect.Play();
    }
}
