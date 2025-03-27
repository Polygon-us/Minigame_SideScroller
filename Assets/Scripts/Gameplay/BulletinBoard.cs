using UnityEngine;
using UI.Banner;
using Utils;

namespace Gameplay
{
    [RequireComponent(typeof(Collider2D))]
    public class BulletinBoard : MonoBehaviour
    {
        [SerializeField, TextArea] private string bannerText;

        private BannerController _bannerController;
        
        private void Awake()
        {
            _bannerController = FindAnyObjectByType<BannerController>(FindObjectsInactive.Include);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                _bannerController.Open(bannerText);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                _bannerController.Close();
        }
    }
}