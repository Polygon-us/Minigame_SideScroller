using UnityEngine;

namespace ScriptableObjects.Character
{
    [CreateAssetMenu(fileName = "CharacterPosesSo", menuName = "Matias/Character Poses")]
    public class CharacterPosesSO : ScriptableObject
    {
        public Sprite[] poses;

        public Sprite GetRandom()
        {
            return poses[Random.Range(0, poses.Length)];
        }
    }
}
