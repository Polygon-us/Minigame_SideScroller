using UnityEngine;
using System;

namespace UI.Gameplay.Question
{
    [Serializable]
    public struct QuestionInfo
    {
        [TextArea] public string questionMessage;
        public Answer[] answers; 
    }
}