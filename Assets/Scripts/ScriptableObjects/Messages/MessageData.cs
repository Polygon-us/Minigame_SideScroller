using System;
using ScriptableObjects.Character;
using UnityEngine;

namespace ScriptableObjects.Messages
{
    [Serializable]
    public class MessageData
    {
        public string impression;
        public CharacterPosesSO poses;
        [TextArea] public string message;
    }
}