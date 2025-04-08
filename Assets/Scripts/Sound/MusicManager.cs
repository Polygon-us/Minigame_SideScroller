using TweenParams = Utils.TweenParams;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

namespace Sound
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip mainClip;
        [SerializeField] private TweenParams tweenParams;
        
        private static MusicManager _instance;
        
        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            FadeIn();
        }

        private void OnSceneUnloaded(Scene scene)
        {
            FadeOut();
        }

        private void FadeIn()
        {
            audioSource.DOFade(1, tweenParams.duration)
                .SetEase(tweenParams.inEase);
        }

        private void FadeOut()
        {
            audioSource.DOFade(0, tweenParams.duration)
                .SetEase(tweenParams.outEase);
        }
    }
}