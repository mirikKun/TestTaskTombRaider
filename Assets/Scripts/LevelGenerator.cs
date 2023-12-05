using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshSurface))]
public class LevelGenerator : MonoBehaviour
{
   private List<Transform> _obstacles=new List<Transform>();
   [SerializeField] private int _count=15;
   [SerializeField] private float _areaSize = 30;

   [SerializeField] private Transform _obstacle;
   [SerializeField] private FloatRange _lenghtRange;
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
       _navMeshSurface=GetComponent<NavMeshSurface>();
    }

    public void GenerateLevel()
   {
      for (int i = 0; i < _count; i++)
      {
         Transform newObstacle=Instantiate(_obstacle, RandomPosition(), Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
         GenerateObstacleScale(newObstacle);
         _obstacles.Add(newObstacle);
      }
      _navMeshSurface.BuildNavMesh();
   }

   private void GenerateObstacleScale(Transform newObstacle)
   {
      Vector3 newScale = newObstacle.localScale;
      newScale.x = _lenghtRange.RandomValueInRange;
      newObstacle.localScale=newScale;
   }

   private Vector3 RandomPosition()
   {
      return new Vector3(Random.Range(-_areaSize, _areaSize), 0.5f, Random.Range(-_areaSize, _areaSize));
   }

   public void ClearLevel()
   {
      for (int i = 0; i < _obstacles.Count; i++)
      {
         Destroy(_obstacles[i].gameObject);
      }
      _obstacles.Clear();
   }
   
}
