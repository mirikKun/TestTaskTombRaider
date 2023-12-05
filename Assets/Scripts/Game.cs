using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game:MonoBehaviour
    {
        [SerializeField] private LevelGenerator _levelGenerator;

        private void Start()
        {
            _levelGenerator.GenerateLevel();
        }

        [ContextMenu("Generate")]
        private void RegenerateLevel()
        {
            _levelGenerator.ClearLevel();
            _levelGenerator.GenerateLevel();

        }
    }
}