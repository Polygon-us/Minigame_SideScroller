using UnityEngine.InputSystem;
using Attributes.ReadOnly;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(GroundChecker))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float deceleration;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float jumpForce;
        [ReadOnly, SerializeField] private float velocity;
        
        private GroundChecker _groundChecker;
        private Rigidbody2D _rb;
        private MoveActions _moveActions;
        
        private void OnEnable()
        {
            _moveActions.Enable();
        }

        private void OnDisable()
        {
            _moveActions.Disable();
        }

        private void OnDestroy()
        {
            _moveActions.Dispose();
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _groundChecker = GetComponent<GroundChecker>();
            
            _moveActions = new MoveActions();
            _moveActions.Player.Jump.performed += OnJumpPerformed;
        }

        private void Update()
        {
            if (_moveActions.Player.Move.IsInProgress())
                Move();
            else
                Decelerate();
        }
        
        private void Move()
        {
            _rb.linearVelocityX += acceleration * _moveActions.Player.Move.ReadValue<Vector2>().x * Time.deltaTime;
            _rb.linearVelocityX = Mathf.Clamp(_rb.linearVelocityX, -maxSpeed, maxSpeed);
            
            velocity = _rb.linearVelocityX;
        }

        private void Decelerate()
        {
            _rb.linearVelocityX -= Mathf.Sign(_rb.linearVelocityX) * deceleration * Time.deltaTime;
            if (Mathf.Approximately(_rb.linearVelocityX, 0.0f))
                _rb.linearVelocityX = 0;
        }
        
        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            if (_groundChecker.IsGrounded)
                _rb.linearVelocityY = jumpForce * _moveActions.Player.Jump.ReadValue<float>();
        }
    }
}