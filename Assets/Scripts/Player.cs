using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent),typeof(Effects))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerView _view;

    public Action OnDestinationReach;
    public Action OnDeath;

    private Effects _effects;
    private NavMeshAgent _agent;
    private readonly float _minDistance = 0.1f;
    private Vector3 _destinationPoint;
    private float _defaultSpeed;

    private const int PlayerLayerMask = 7;
    private const int ShieldLayerMask = 9;
    public bool Dead { get; private set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _effects = GetComponent<Effects>();
    }

    private void Start()
    {
        _defaultSpeed = _agent.speed;
    }

    private void Update()
    {
        if (CheckOnDestinationReach())
        {
            _effects.PlayVictoryEffect();
            OnDestinationReach?.Invoke();
        }
    }

    public void SetupDestination(Vector3 position)
    {
        _destinationPoint = position;
        _agent.SetDestination(_destinationPoint);
    }

    public void InvokeDeath()
    {
        OnDeath?.Invoke();
        _view.HidePlayer();
        StopPlayer();
        _effects.PlayDeathEffect();
        Dead = true;
    }

    public void InvokeVictory()
    {
        OnDestinationReach?.Invoke();
        _effects.PlayVictoryEffect();
        StopPlayer();
    }

    public void StopPlayer()
    {
        _agent.speed = 0;
    }

    public void MovePlayer()
    {
        _agent.speed = _defaultSpeed;
    }

    public void RestartPlayer(Vector3 position)
    {
        _agent.enabled = false;
        transform.position = position;
        transform.rotation=Quaternion.identity;
        _view.ShowPlayer();
        Dead = false;
        _agent.enabled = true;
    }

    public void EnableShield()
    {
        gameObject.layer = ShieldLayerMask;
        _view.ChangeMaterialToShielded();
    }

    public void DisableShield()
    {
        gameObject.layer = PlayerLayerMask;
        _view.ChangeMaterialToDefault();
    }
 

    private bool CheckOnDestinationReach()
    {
        return Vector3.Distance(transform.position, _destinationPoint)<=_minDistance;
    }
}