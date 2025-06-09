using System;
using DG.Tweening;

namespace UI.Generic
{
    [Serializable]
    public class TweenParams
    {
        public float duration = 0.2f;
        public Ease inType = Ease.InCirc;
        public Ease outType = Ease.OutCirc;
    }
}