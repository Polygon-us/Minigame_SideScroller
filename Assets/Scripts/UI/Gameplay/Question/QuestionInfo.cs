using UnityEngine;
using System;

namespace UI.Gameplay.Question
{
    [Serializable]
    public struct QuestionInfo
    {
        public string impression;
        [TextArea] public string questionMessage;
        public Answer[] answers; 
    }
}