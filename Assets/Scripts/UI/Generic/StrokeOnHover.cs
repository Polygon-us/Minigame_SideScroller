using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

namespace UI.Generic
{
    public class StrokeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TweenParams tweenParams;

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
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            LeanTween.cancel(_tweenId);
            _tweenId = LeanTween.value(0, 1, tweenParams.duration)
                .setEase(tweenParams.inType)
                .setOnUpdate(v =>
                {
                    _initialColor.a = v;
                    _fontMaterial.SetColor(colorProperty, _initialColor);
                })
                .uniqueId;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.cancel(_tweenId);
            _tweenId = LeanTween.value(1, 0, tweenParams.duration)
                .setOnUpdate(v =>
                {
                    _initialColor.a = v;
                    _fontMaterial.SetColor(colorProperty, _initialColor);
                })
                .setEase(tweenParams.outType)
                .uniqueId;
        }
    }
}