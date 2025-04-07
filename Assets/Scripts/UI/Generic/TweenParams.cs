using System;

namespace UI.Generic
{
    [Serializable]
    public class TweenParams
    {
        public float duration = 0.2f;
        public LeanTweenType inType = LeanTweenType.easeOutCubic;
        public LeanTweenType outType = LeanTweenType.easeInCirc;
    }
}