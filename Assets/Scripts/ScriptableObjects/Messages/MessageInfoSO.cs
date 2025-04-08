using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Messages
{
    [CreateAssetMenu(fileName = "MessageInfoSo", menuName = "Matias/Message Info")]
    public class MessageInfoSO : ScriptableObject
    {
        [SerializeField] List<MessageData> messages;

        public bool HasNext => index < messages.Count;
        
        private int index;

        public bool GetNext(out MessageData info)
        {
            if (index >= messages.Count)
            {
                info = null;
                return false;
            }
            
            info = messages[index++];
            return true;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}