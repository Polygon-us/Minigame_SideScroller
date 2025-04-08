using UnityEngine.InputSystem;
using GMTK.PlatformerToolkit;
using UnityEngine;
using System;

namespace Gameplay.Character
{
    public class FlyMovement : MonoBehaviour, IMovementDataReceiver
    {
        [Header("Components")] 
        private Rigidbody2D _rb;

        [Header("Movement Stats")] 
        [field: SerializeField, Range(0f, 20f)] [Tooltip("Maximum movement speed")]
        public float maxSpeed { get; set; } = 10f;
       
        [field: SerializeField, Range(0f, 100f)] [Tooltip("How fast to reach max speed")]
        public float maxAcceleration { get; set; } = 52f;
      
        [field: SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop after letting go")]
        public float maxDecceleration { get; set; } = 52f;
       
        [field: SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop when changing direction")]
        public float maxTurnSpeed { get; set; } = 80f;
       
        [field: SerializeField, Range(0f, 100f)] [Tooltip("How fast to reach max speed when in mid-air")]
        public float maxAirAcceleration{ get; set; } 
      
        [field: SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop in mid-air when no direction is used")]
        public float maxAirDeceleration{ get; set; } 
      
        [field: SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop when changing direction when in mid-air")]
        public float maxAirTurnSpeed { get; set; } = 80f;
      
        [SerializeField] [Tooltip("Friction to apply against movement on stick")]
        private float friction;
        
        [Header("Calculations")] 
        public Vector2 direction;
        private Vector2 desiredVelocity;
        public Vector2 velocity;
        private float maxSpeedChange;

        [Header("Current State")] 
        public bool pressingKey;

        private void OnEnable()
        {
            _rb.gravityScale = 0f;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void OnFly(InputAction.CallbackContext context)
        {
            if (movementLimiter.instance.CharacterCanMove)
            {
                direction = context.ReadValue<Vector2>();
            }
        }

        private void Update()
        {
            if (!movementLimiter.instance.CharacterCanMove)
            {
                direction = Vector2.zero;
            }

            //Used to flip the character's sprite when she changes direction
            //Also tells us that we are currently pressing a direction button
            if (!Mathf.Approximately(direction.sqrMagnitude, 0))
            {
                transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);
                pressingKey = true;
            }
            else
            {
                pressingKey = false;
            }

            //Calculate's the character's desired velocity - which is the direction you are facing, multiplied by the character's maximum speed
            //Friction is not used in this game
            desiredVelocity = direction * Mathf.Max(maxSpeed - friction, 0f);
        }

        private void FixedUpdate()
        {
            //Get the Rigidbody's current velocity
            velocity = _rb.linearVelocity;

            FlyWithAcceleration();
        }

        private void FlyWithAcceleration()
        {
            if (pressingKey)
            {
                //If the sign (i.e. positive or negative) of our input direction doesn't match our movement, it means we're turning around and so should use the turn speed stat.
                if (Mathf.Sign(direction.x) * Mathf.Sign(velocity.x) > 0 || 
                    Mathf.Sign(direction.y) * Mathf.Sign(velocity.y) > 0)
                {
                    maxSpeedChange = maxAirTurnSpeed * Time.deltaTime;
                }
                else
                {
                    //If they match, it means we're simply running along and so should use the acceleration stat
                    maxSpeedChange = maxAirAcceleration * Time.deltaTime;
                }
            }
            else
            {
                //And if we're not pressing a direction at all, use the deceleration stat
                maxSpeedChange = maxAirDeceleration * Time.deltaTime;
            }

            //Move our velocity towards the desired velocity, at the rate of the number calculated above
            velocity = Vector2.MoveTowards(velocity, desiredVelocity, maxSpeedChange);

            //Update the Rigidbody with this new velocity
            _rb.linearVelocity = velocity;
        }
    }
}