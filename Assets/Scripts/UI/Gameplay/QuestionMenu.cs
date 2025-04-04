using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace UI.Gameplay
{
    public class QuestionMenu : MenuBase
    {
        [SerializeField] private TMP_Text messageTxt;
        [SerializeField] private TMP_Text impressionTxt;
        [SerializeField] private Button sendBtn;
    }
}