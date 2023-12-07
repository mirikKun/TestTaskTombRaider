using System;
using System.Linq;
using DefaultNamespace.Generation;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Extentions
    {
        public static Direction[] GetRandomDirections()
        {
            Direction[] enumValues = (Direction[])Enum.GetValues(typeof(Direction));
            Direction[] shuffledArray = enumValues.OrderBy(x => Guid.NewGuid()).ToArray();
            return shuffledArray;
        }
        public static Vector2Int GetVector(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return Vector2Int.left;
                case Direction.Forward:
                    return Vector2Int.up;
                case Direction.Right:
                    return Vector2Int.right;
                default:
                    return Vector2Int.down;
            }
        }

        public static int X(this Direction direction)
        {
            return direction.GetVector().x;
        }
        public static int Y(this Direction direction)
        {
            return direction.GetVector().y;
        }
    }
}