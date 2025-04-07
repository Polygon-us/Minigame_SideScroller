using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

namespace UI.Gameplay.Question
{
    public class AnswerComponent : MonoBehaviour
    {
        [SerializeField] private TMP_Text answerText;
        [SerializeField] private Toggle toggle;
        
        private Answer _answer;
        
        public Action<Answer> OnClick; 
        public Toggle Toggle => toggle;
        
        public void Initialize(Answer answer, ToggleGroup group)
        {
            _answer = answer;
            answerText.text = answer.answer;
            toggle.onValueChanged.AddListener(CheckOnClick);
            toggle.group = group;
        }

        private void CheckOnClick(bool value)
        {
            if (value)
                OnClick?.Invoke(_answer);
        }
    }
}