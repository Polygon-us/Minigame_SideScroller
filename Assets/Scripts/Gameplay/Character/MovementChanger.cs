using GMTK.PlatformerToolkit;
using UnityEngine;

namespace Gameplay.Character
{
    public class MovementChanger : MonoBehaviour
    {
        [SerializeField] private characterMovement characterMovement;
        [SerializeField] private FlyMovement flyMovement;
        [SerializeField] private characterJump characterJump;

        private void Start()
        {
            characterMovement.enabled = true;
            characterJump.enabled = true;
            flyMovement.enabled = false;
        }

        public void EnableFlyMovement()
        {
            characterMovement.enabled = false;
            characterJump.enabled = false;
            flyMovement.enabled = true;
        }
    }
}