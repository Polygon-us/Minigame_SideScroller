using UnityEngine.Events;
using UnityEngine;
using Utils;

namespace Gameplay.Trigger
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Trigger : MonoBehaviour
    {
        [SerializeField] protected bool triggerOnce = false;
        
        public UnityEvent TriggerEnter = new();
        public UnityEvent TriggerExit = new();
        
        private bool _triggerEnter = false;
        private bool _triggerExit = false;
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerOnce && _triggerEnter)
                return;
            
            if (other.CompareTag(TagsTypes.PlayerTag))
            {
                TriggerEnter.Invoke();
                _triggerEnter = true;
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (triggerOnce && _triggerExit)
                return;
            
            if (other.CompareTag(TagsTypes.PlayerTag))
            {
                TriggerExit.Invoke();
                _triggerExit = true;
            }
        }
    }
}