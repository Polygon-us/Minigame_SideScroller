using ScriptableObjects.Messages;
using GMTK.PlatformerToolkit;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace UI.Gameplay
{
    public class MessageMenu : MenuBase
    {
        [SerializeField] private TMP_Text messageTxt;
        [SerializeField] private TMP_Text impressionTxt;
        [SerializeField] private Image characterImage;
        [SerializeField] private Button sendBtn;
        [SerializeField] private movementLimiter movementLimiter;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private MessageInfoSO messageInfo;

        protected override void Awake()
        {
            base.Awake();

            sendBtn.onClick.AddListener(Hide);
        }

        public void Show(MessageInfoSO info)
        {
            messageInfo = info;

            Show();
        }

        public override void Show()
        {
            base.Show();

            uiManager.ToggleMobileInput(false);
            movementLimiter.CharacterCanMove = false;

            SetMessage(true);
        }

        private void SetMessage(bool first = false)
        {
            if (first)
                messageInfo.Reset();
            
            if (!messageInfo.GetNext(out var info))
                return;

            messageTxt.text = info.message;
            impressionTxt.text = info.impression;
            characterImage.sprite = info.poses.GetRandom();
        }

        public override void Hide()
        {
            if (messageInfo.HasNext)
            {
                SetMessage();
            }
            else
            {
                base.Hide();

                uiManager.ToggleMobileInput(true);
                movementLimiter.CharacterCanMove = true;
            }
        }
    }
}