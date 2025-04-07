using UnityEngine;
using UI.Gameplay;
using Utils;

namespace Gameplay
{
    public class BulletinBoard : Triggerer
    {
        [SerializeField] private QuestionMenu questionMenu;
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                questionMenu.Show();
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            // if (other.CompareTag(TagsTypes.PlayerTag))
            //     questionMenu.Hide();
        }
    }
}