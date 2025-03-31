using UnityEngine;
using UI.Banner;
using Utils;

namespace Gameplay
{
    public class BulletinBoard : Triggerer
    {
        [SerializeField, TextArea] private string bannerText;

        private BannerController _bannerController;
        
        private void Awake()
        {
            _bannerController = FindAnyObjectByType<BannerController>(FindObjectsInactive.Include);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                _bannerController.Show(bannerText);
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                _bannerController.Hide();
        }
    }
}