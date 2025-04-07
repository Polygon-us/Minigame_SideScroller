using System.Collections;
using System.Collections.Generic;
using Attributes.ReadOnly;
using UnityEngine;


namespace GMTK.PlatformerToolkit {
    public class movementLimiter : MonoBehaviour {
        public static movementLimiter instance;

        [SerializeField] bool _initialCharacterCanMove = true;
        [ReadOnly] public bool CharacterCanMove;

        private void OnEnable() {
            instance = this;
        }

        private void Start() {
            CharacterCanMove = _initialCharacterCanMove;
        }
    }
}