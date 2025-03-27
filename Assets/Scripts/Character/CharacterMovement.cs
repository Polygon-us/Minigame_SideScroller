using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(GroundChecker))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravityMultiplier;

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
            _moveActions.Player.Jump.performed += OnJump;
        }

        private void Update()
        {
            if (_moveActions.Player.Jump.IsInProgress())
                Move();
        }

        private void Move()
        {
            _rb.linearVelocityX += moveSpeed * _moveActions.Player.Move.ReadValue<Vector2>().x * Time.deltaTime;
            _rb.linearVelocityX = MathF.Clamp(_rb.linearVelocityX, 0, maxSpeed);
        }
        
        private void OnJump(InputAction.CallbackContext context)
        {
            if (_groundChecker.IsGrounded)
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}