using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenu : MenuBase
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Image blackScreen;
        
        protected override void Awake()
        {
            base.Awake();
            
            startButton.onClick.AddListener(Hide);
        }

        public override void Hide()
        {
            SetInteractable(false);
            blackScreen.DOColor(Color.black, tweenParams.duration).OnComplete(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}