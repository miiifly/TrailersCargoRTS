using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CargoSnake.Gameplay.Spawn
{
    public class SpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform _trailerParent;
        [SerializeField]
        private TrailerPreset _trailerPreset;

        public override void InstallBindings()
        {
            Container.BindInstance(_trailerPreset);

            var trailerSpawner = new TrailerSpawner(_trailerParent, Container, _trailerPreset.Trailers);
        }
    }
}

