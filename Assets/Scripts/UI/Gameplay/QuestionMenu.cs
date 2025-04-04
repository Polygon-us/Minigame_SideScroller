using GMTK.PlatformerToolkit;
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
        [SerializeField] private movementLimiter movementLimiter;
        [SerializeField] private UIManager uiManager;
        
        protected override void Awake()
        {
            base.Awake();
            
            sendBtn.onClick.AddListener(Hide);
        }

        public void Show(string text)
        {
            base.Show();

            uiManager.ToggleMobileInput(false);
            messageTxt.text = text;
            movementLimiter.CharacterCanMove = false;
        }

        public override void Hide()
        {
            base.Hide();

            uiManager.ToggleMobileInput(true);
            movementLimiter.CharacterCanMove = true;
        }
    }
}