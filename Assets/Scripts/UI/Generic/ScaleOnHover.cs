using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine;

namespace UI.Generic
{
    public class ScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float scale = 1.2f;
        [SerializeField] private TweenParams tweenParams;

        private int _tweenId;
        
        private RectTransform RectTransform => (RectTransform)transform;

        public void OnPointerEnter(PointerEventData eventData)
        {
            DOTween.Kill(_tweenId);
            _tweenId = RectTransform.DOScale(Vector3.one * scale, tweenParams.duration)
                .SetEase(tweenParams.inType)
                .intId;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DOTween.Kill(_tweenId);
            _tweenId = RectTransform.DOScale(Vector3.one, tweenParams.duration)
                .SetEase(tweenParams.outType)
                .intId;
        }
    }
}