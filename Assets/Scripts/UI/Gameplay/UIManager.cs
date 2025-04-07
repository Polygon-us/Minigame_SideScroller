using UnityEngine;

namespace UI.Gameplay
{
    public class UIManager : MonoBehaviour
    { 
        [SerializeField] private TutorialMenu tutorialMenu;
        [SerializeField] private MessageMenu messageMenu;
        [SerializeField] private EndMenu endMenu;
        [SerializeField] private MobileInput.MobileInputMenu mobileInputMenuMenu;

        private void Start()
        {
            tutorialMenu.Show();
            tutorialMenu.OnHideComplete += ShowMobileInput;
        }

        private void ShowMobileInput()
        {
            mobileInputMenuMenu.Show();
        }

        public void ToggleMobileInput(bool enable)
        {
            if (enable)
                mobileInputMenuMenu.Show();
            else
                mobileInputMenuMenu.Hide();
        }

        public void ShowResult()
        {
            messageMenu.Show();
        }
    }
}