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
            LeanTween.cancel(_tweenId);
            _tweenId = LeanTween.scale(RectTransform, Vector3.one * scale, tweenParams.duration)
                .setEase(tweenParams.inType)
                .uniqueId;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.cancel(_tweenId);
            _tweenId = LeanTween.scale(RectTransform, Vector3.one, tweenParams.duration)
                .setEase(tweenParams.outType)
                .uniqueId;
        }
    }
}