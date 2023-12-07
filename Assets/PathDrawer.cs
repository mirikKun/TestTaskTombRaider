using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PathDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_navMeshAgent.hasPath)
            DrawPath();
        else
            _lineRenderer.positionCount = 0;

    }

    private void DrawPath()
    {
        _lineRenderer.positionCount = _navMeshAgent.path.corners.Length;
        if (_lineRenderer.positionCount < 2)
            return;
        
        _lineRenderer.SetPosition(0,transform.position);
        if (_navMeshAgent.path.corners.Length < 2)
            return;
        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            NavMeshPath path = _navMeshAgent.path;
            Vector3 pointPosition = new Vector3(path.corners[i].x, path.corners[i].y,
                path.corners[i].z);
            _lineRenderer.SetPosition(i,pointPosition);

        }
    }
}
