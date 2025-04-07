using GMTK.PlatformerToolkit;
using ScriptableObjects.Messages;
using UnityEngine;

namespace UI.Gameplay
{
    public class UIManager : MonoBehaviour
    { 
        [SerializeField] private MessageMenu messageMenu;
        [SerializeField] private MobileInput.MobileInputMenu mobileInputMenuMenu;
        [SerializeField] private MessageInfoSO messageInfo;
        
        private void Start()
        {
            ToggleMobileInput(true);
        }

        public void ToggleMobileInput(bool enable)
        {
            if (enable)
            {
                movementLimiter.instance.CharacterCanMove = true;
                mobileInputMenuMenu.Show();
            }
            else
            {
                movementLimiter.instance.CharacterCanMove = false;
                mobileInputMenuMenu.Hide();
            }
        }

        public void ShowResult()
        {
            messageMenu.Show(messageInfo);
        }
    }
}