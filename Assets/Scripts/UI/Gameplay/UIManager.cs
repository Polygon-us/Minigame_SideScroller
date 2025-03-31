using UnityEngine;

namespace UI.Gameplay
{
    public class UIManager : MonoBehaviour
    { 
        [SerializeField] private TutorialMenu tutorialMenu;
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
    }
}