using UnityEngine.SceneManagement;
using ScriptableObjects.Messages;
using GMTK.PlatformerToolkit;
using UnityEngine;
using UnityEngine.Playables;

namespace UI.Gameplay
{
    public class UIManager : MonoBehaviour
    { 
        [SerializeField] private MessageMenu messageMenu;
        [SerializeField] private MobileInput.MobileInputMenu mobileInputMenuMenu;
        [SerializeField] private MessageInfoSO messageInfo;
        [SerializeField] private MessageInfoSO endMessageInfo;
        [SerializeField] private PlayableDirector playableDirector;
        [SerializeField] private MessageInfoSO rhythmInfo;
        
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

        public void ShowDirector()
        {
            messageMenu.Show(rhythmInfo);
            messageMenu.OnHideComplete += StartTimeline;
        }

        private void StartTimeline()
        {
            messageMenu.OnHideComplete -= StartTimeline;
            playableDirector.Play();
        }

        public void ShowResult()
        {
            messageMenu.Show(messageInfo);
        }

        public void ShowEndPanel()
        {
            messageMenu.Show(endMessageInfo);
            messageMenu.OnHideComplete += () => SceneManager.LoadScene(0);
        }
    }
}