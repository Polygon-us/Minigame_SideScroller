using UnityEngine.Events;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Triggerer : MonoBehaviour
    {
        [SerializeField] private TagHandle triggerTag;

        public UnityEvent TriggerEnter = new();
        public UnityEvent TriggerExit = new();
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(triggerTag))
               TriggerEnter.Invoke();
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(triggerTag))
                TriggerExit.Invoke();
        }
    }
}