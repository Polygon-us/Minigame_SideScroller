using UnityEngine;

public class ParticlesPlayback : MonoBehaviour
{
    public ParticleSystem myParticle;

    public void PlayParticles()
    {
        myParticle.Play();
    }

    public void StopParticles()
    {
        myParticle.Stop();
    }
}
