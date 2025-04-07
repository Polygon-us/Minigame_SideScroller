using UnityEngine;
using System;

namespace UI.Gameplay.Message
{
    [Serializable]
    public struct MessageInfo
    {
        [TextArea] public string message;
        public string impression;
    }
}