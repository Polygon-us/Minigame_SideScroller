using UnityEngine.Events;
using UnityEngine;
using Utils;

namespace Gameplay
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Triggerer : MonoBehaviour
    {
        public UnityEvent TriggerEnter = new();
        public UnityEvent TriggerExit = new();
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
               TriggerEnter.Invoke();
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                TriggerExit.Invoke();
        }
    }
}