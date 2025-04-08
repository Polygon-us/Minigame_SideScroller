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
            DOVirtual.Float(0, 1, tweenParams.duration, v =>
                {
                    _initialColor.a = v;
                    _fontMaterial.SetColor(colorProperty, _initialColor);
                })
                .SetEase(tweenParams.inType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DOVirtual.Float(1, 0, tweenParams.duration, v =>
                {
                    _initialColor.a = v;
                    _fontMaterial.SetColor(colorProperty, _initialColor);
                })
                .SetEase(tweenParams.outType);
        }
    }
}