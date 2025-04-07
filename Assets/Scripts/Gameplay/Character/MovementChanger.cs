using GMTK.PlatformerToolkit;
using UnityEngine;

namespace Gameplay.Character
{
    public class MovementChanger : MonoBehaviour
    {
        [SerializeField] private characterMovement characterMovement;
        [SerializeField] private FlyMovement flyMovement;

        private void Start()
        {
            characterMovement.enabled = true;
            flyMovement.enabled = false;
        }

        public void EnableFlyMovement()
        {
            characterMovement.enabled = false;
            flyMovement.enabled = true;
        }
    }
}