using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Generation;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshSurface))]
public class LevelGenerator : MonoBehaviour
{
    private List<Transform> _obstacles = new List<Transform>();
    [SerializeField] private int _sizeOfLevel = 26;
    [SerializeField] private int _quantityPerRow = 16;
    private float _obstacleSize;

    [SerializeField] private Transform _wallPrefab;
    [SerializeField] private Vector2Int _startCell;
    [SerializeField] private Vector2Int _endCell;
    [SerializeField] private int _locationSize = 3;
    [SerializeField] private float _chanceToBreakWall = 0.1f;
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
        _obstacleSize = _sizeOfLevel / (float)_quantityPerRow;
    }

    public void GenerateLevel()
    {
        GenerateMaze();
        _navMeshSurface.BuildNavMesh();
    }

    public void ClearLevel()
    {
        for (int i = 0; i < _obstacles.Count; i++)
        {
            Destroy(_obstacles[i].gameObject);
        }

        _obstacles.Clear();
    }




    void GenerateMaze()
    {
        bool[,] visited = new bool[_quantityPerRow, _quantityPerRow];
        for (int i = 1; i < _quantityPerRow-1; i++)
        {
            for (int j = 1; j < _quantityPerRow-1; j++)
            {
                visited[i, j] = false;
            }
        }

        RecursiveBacktracking(new Vector2Int(1,1), visited);

        ClearLocation(_startCell,visited);
        ClearLocation(_endCell,visited);
        
        PlaceWalls(visited);
        
        

    }

    private void ClearLocation(Vector2Int location,bool[,] visited)
    {
        int startX=location.x-Mathf.FloorToInt(_locationSize/2f);
        int startY=location.y-Mathf.FloorToInt(_locationSize/2f);;
        for (int x = startX; x < startX+_locationSize; x++)
        {
            for (int y = startY; y < startY+_locationSize; y++)
            {
                visited[x, y] = true;
            }
        }
    }

    private void PlaceWalls(bool[,] visited)
    {
        for (int i = 0; i < _quantityPerRow; i++)
        {
            for (int j = 0; j < _quantityPerRow; j++)
            {
                if (!visited[i, j])
                {
                    Transform wall=Instantiate(_wallPrefab,
                        transform.position + new Vector3((i+0.5f)*_obstacleSize, 0.5f, (j+0.5f)*_obstacleSize),
                        Quaternion.identity, transform);
                    wall.localScale = new Vector3(_obstacleSize, 1, _obstacleSize);
                }
            }
        }
    }

    void RecursiveBacktracking(Vector2Int currentCell, bool[,] visited)
    {
        visited[currentCell.x, currentCell.y] = true;
        Direction[] directions = Extentions.GetRandomDirections();

        foreach (Direction direction in directions)
        {
            Vector2Int nextCell = currentCell + direction.GetVector();

            if (IsInBounds(nextCell) && (ChanceToBreakWall()||CanBePlaced(nextCell, visited, direction)))
            {//
                visited[nextCell.x, nextCell.y] = true;

                RecursiveBacktracking(nextCell, visited);
            }
        }
    }

    private bool ChanceToBreakWall()
    {
        float chance = Random.Range(0, 1f);
        return chance <= _chanceToBreakWall;
    }
    private bool IsInBounds(Vector2Int cell)
    {
        return cell.x >= 1 && cell.x < _quantityPerRow-1 && cell.y >= 1 && cell.y < _quantityPerRow-1;
    }

    private bool CanBePlaced(Vector2Int cell, bool[,] visited, Direction direction)
    {
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                if (visited[cell.x + x, cell.y + y] &&((direction.X()!=0&&Mathf.Abs(x + direction.X()) >0)||
                                                       (direction.Y()!=0&&Mathf.Abs(y + direction.Y()) >0) ))
                {
                    return false;
                }
            }
        }

        return true;
    }
    
}