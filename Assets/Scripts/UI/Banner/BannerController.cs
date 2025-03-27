using TMPro;
using UnityEngine;

namespace UI.Banner
{
    public class BannerController : MonoBehaviour
    {
        [SerializeField] private RectTransform panel;
        [SerializeField] private TMP_Text msgText;

        public void Open(string text)
        {
            panel.gameObject.SetActive(true);
            msgText.text = text;
        }

        public void Close()
        {
            panel.gameObject.SetActive(false);
        }
    }
}