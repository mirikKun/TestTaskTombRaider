using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
   private List<Transform> _obstacles=new List<Transform>();
   [SerializeField] private int _count=15;
   [SerializeField] private float _areaSize = 30;

   [SerializeField] private Transform _obstacle;
   [SerializeField] private FloatRange _lenghtRange;
   
   public void GenerateLevel()
   {
      for (int i = 0; i < _count; i++)
      {
         Transform newObstacle=Instantiate(_obstacle, RandomPosition(), Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
         newObstacle.localScale = new Vector3(_lenghtRange.RandomValueInRange, newObstacle.localScale.y,
            newObstacle.localScale.z);
         _obstacles.Add(newObstacle);
      }
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
