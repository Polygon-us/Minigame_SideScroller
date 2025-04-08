using ScriptableObjects.Character;
using UnityEngine;

namespace ScriptableObjects.Questions
{
    [CreateAssetMenu(fileName = "QuestionInfoSO", menuName = "Matias/Question Info")]
    public class QuestionInfoSO : ScriptableObject
    {
        public string impression;
        public CharacterPosesSO thinkingPoses;
        [TextArea] public string questionMessage;
        public Answer[] answers; 
    }
}