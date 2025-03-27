using UnityEngine;

namespace Character
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Vector3 position;
        [SerializeField] private float checkRadius;
        [SerializeField] private LayerMask groundLayer;
        
        private bool _isGrounded;
        
        public bool IsGrounded => _isGrounded;

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.CircleCast( transform.position + position, checkRadius, Vector2.down, checkRadius, groundLayer);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = _isGrounded ? Color.red : Color.green;
            Gizmos.DrawWireSphere(transform.position + position, checkRadius);
        }
#endif
    }
}