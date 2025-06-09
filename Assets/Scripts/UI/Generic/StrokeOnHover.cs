using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

namespace UI.Generic
{
    public class StrokeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TweenParams tweenParams;
        [SerializeField] private bool startWithStroke;

        private int _tweenId;
        private TMP_Text _text;
        private Color _initialColor;
        private Material _fontMaterial;

        private readonly int colorProperty = Shader.PropertyToID("_OutlineColor");

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _fontMaterial = new Material(_text.fontSharedMaterial);
            _text.fontSharedMaterial = _fontMaterial;

            _initialColor = _fontMaterial.GetColor(colorProperty);

            _initialColor.a = startWithStroke ? 1f : 0f;
            _fontMaterial.SetColor(colorProperty, _initialColor);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _fontMaterial.DOFade(1, colorProperty, tweenParams.duration)
                .SetEase(tweenParams.inType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _fontMaterial.DOFade(0, colorProperty, tweenParams.duration)
                .SetEase(tweenParams.outType);
        }
    }
}