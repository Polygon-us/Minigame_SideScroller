using UnityEngine;

namespace Gameplay.Character
{
    public class StepSound : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        public void PlaySteps()
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
        }
    }
}