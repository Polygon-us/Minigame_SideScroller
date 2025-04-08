using TweenParams = Utils.TweenParams;
using UI.Gameplay;
using UnityEngine;
using DG.Tweening;

namespace Gameplay.Trigger
{
    public class QuestionTrigger : Trigger
    {
        [SerializeField] private QuestionMenu questionMenu;
        [SerializeField] private GameObject fence;
        [SerializeField] private TweenParams tweenParams;

    private void OnEnable()
        {
            TriggerEnter.AddListener(ShowQuestion);
        }

        private void OnDisable()
        {
            TriggerEnter.RemoveListener(ShowQuestion);
        }
        
        private void ShowQuestion()
        {
            questionMenu.Show();
            questionMenu.OnHideComplete += HideFence;
        }

        private void HideFence()
        {
            questionMenu.OnHideComplete -= HideFence;
            fence.transform.DOMoveY(-10f, tweenParams.duration)
                .SetEase(tweenParams.inEase);
        }
    }
}