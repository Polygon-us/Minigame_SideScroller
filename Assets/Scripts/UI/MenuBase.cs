using TweenParams = Utils.TweenParams;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using System;

namespace UI
{
    [RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
    [RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
    public abstract class MenuBase : MonoBehaviour
    {
        [SerializeField] protected TweenParams tweenParams;
        [SerializeField] protected bool startOpened;

        protected CanvasGroup CanvasGroup;
        protected RectTransform RectTransform => transform as RectTransform;

        public Action OnShowComplete;
        public Action OnHideComplete;
        
        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            
            CanvasGroup.alpha = startOpened ? 1 : 0;
            SetInteractable(startOpened);
        }

        protected virtual void Start() {}

        public virtual void Show()
        {
            CanvasGroup.DOFade(1, tweenParams.duration)
                .SetEase(tweenParams.inEase)
                .OnComplete(() =>
                {
                    SetInteractable(true);
                    OnShowComplete?.Invoke();
                });
        }

        public virtual void Hide()
        {
            SetInteractable(false);
            CanvasGroup.DOFade(0, tweenParams.duration)
                .SetEase(tweenParams.outEase)
                .OnComplete(() => OnHideComplete?.Invoke());
        }

        public void Internal_Show()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.alpha = 1;
            SetInteractable(true);
        }

        public void Internal_Hide()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.alpha = 0;
            SetInteractable(false);
        }

        protected void SetInteractable(bool interactable)
        {
            CanvasGroup.interactable = interactable;
            CanvasGroup.blocksRaycasts = interactable;
        }
    }
}