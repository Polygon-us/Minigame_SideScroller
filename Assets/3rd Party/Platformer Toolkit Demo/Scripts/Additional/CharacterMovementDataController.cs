using Gameplay.Character;
using UnityEngine;

namespace GMTK.PlatformerToolkit
{
    public class CharacterMovementDataController : MonoBehaviour
    {
        [SerializeField] PresetObject _preset;

        IMovementDataReceiver[] _moveReceivers;
        IJumpDataReceiver[] _jumpReceivers;

        PresetObject _installedPreset;

        void Awake()
        {
            _moveReceivers = GetComponents<IMovementDataReceiver>();
            _jumpReceivers = GetComponents<IJumpDataReceiver>();

            InstallPresetData();
        }

        private void OnValidate()
        {
            Awake();
        }

        private void FixedUpdate()
        {
            if (_installedPreset != _preset)
            {
                InstallPresetData();
            }
        }

        private void InstallPresetData()
        {
            //MOVE
            foreach (var receiver in _moveReceivers)
            {
                receiver.maxAcceleration = _preset.Acceleration;
                receiver.maxSpeed = _preset.TopSpeed;
                receiver.maxDecceleration = _preset.Deceleration;
                receiver.maxTurnSpeed = _preset.TurnSpeed;
                receiver.maxAirDeceleration = _preset.AirBrake;
                receiver.maxAirAcceleration = _preset.AirControl;
                receiver.maxAirTurnSpeed = _preset.AirControlActual;
            }

            //JUMP
            foreach (var receiver in _jumpReceivers)
            {
                receiver.jumpHeight = _preset.JumpHeight;
                receiver.timeToJumpApex = _preset.TimeToApex;
                receiver.downwardMovementMultiplier = _preset.DownwardMovementMultiplier;
                receiver.jumpCutOff = _preset.JumpCutoff;
                receiver.maxAirJumps = _preset.DoubleJump;
                receiver.variablejumpHeight = _preset.VariableJumpHeight;
            }

            _installedPreset = _preset;
        }
    }
}