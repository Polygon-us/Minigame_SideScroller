using UnityEngine;
using TMPro;

namespace UI.Banner
{
    public class BannerController : MenuBase
    {
        [SerializeField] private TMP_Text msgText;

        public void Show(string text)
        {
            base.Show();
            
            msgText.text = text;
        }
    }
}