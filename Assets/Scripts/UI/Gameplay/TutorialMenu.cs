using GMTK.PlatformerToolkit;
using UnityEngine.UI;
using UnityEngine;

namespace UI.Gameplay
{
    public class TutorialMenu : MenuBase
    {
        [SerializeField] private Button closeButton;

        protected override void Awake()
        {
            base.Awake();
            closeButton.onClick.AddListener(Hide);

            OnHideComplete += CharacterMove;
        }

        private void CharacterMove()
        {
            movementLimiter.instance.CharacterCanMove = true;
        }
    }
}