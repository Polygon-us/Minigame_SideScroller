using GMTK.PlatformerToolkit;
using UI.Gameplay.Question;
using UI.Gameplay.Message;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace UI.Gameplay
{
    public class MessageMenu : MenuBase
    {
        [SerializeField] private TMP_Text messageTxt;
        [SerializeField] private TMP_Text impressionTxt;
        [SerializeField] private Button sendBtn;
        [SerializeField] private movementLimiter movementLimiter;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private MessageInfo messageInfo;
        
        private Answer _selectedAnswer;

        protected override void Awake()
        {
            base.Awake();

            sendBtn.onClick.AddListener(Hide);
        }

        public override void Show()
        {
            base.Show();

            uiManager.ToggleMobileInput(false);
            movementLimiter.CharacterCanMove = false;
            messageTxt.text = messageInfo.message;
            impressionTxt.text = messageInfo.impression;
        }

        public override void Hide()
        {
            base.Hide();

            uiManager.ToggleMobileInput(true);
            movementLimiter.CharacterCanMove = true;
        }
    }
}