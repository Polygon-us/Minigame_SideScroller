using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenu : MenuBase
    {
        [SerializeField] private Button startButton;

        protected override void Awake()
        {
            base.Awake();
            
            startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}