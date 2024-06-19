using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CargoSnake.Gameplay.Spawn
{
    [CreateAssetMenu(fileName = "TrailerPreset", menuName = "CargoSnake/Presets/TrailerPreset")]
    public class TrailerPreset : ScriptableObject
    {
        [SerializeField]
        private List<ITrailerComponent> _trailers = new List<ITrailerComponent>();
        public IEnumerable<ITrailerComponent> Trailers => _trailers;
    }
}