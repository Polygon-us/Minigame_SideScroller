using UnityEngine;
using UI.Banner;
using UI.Gameplay;
using Utils;

namespace Gameplay
{
    public class BulletinBoard : Triggerer
    {
        [SerializeField, TextArea] private string bannerText;

        [SerializeField] private QuestionMenu questionMenu;
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                questionMenu.Show(bannerText);
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                questionMenu.Hide();
        }
    }
}