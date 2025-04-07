using DG.Tweening;
using System;

namespace Utils
{
    [Serializable]
    public class TweenParams
    {
        public float duration = 0.2f;
        public Ease inEase = Ease.OutCubic;
        public Ease outEase = Ease.InCubic;
    }
}