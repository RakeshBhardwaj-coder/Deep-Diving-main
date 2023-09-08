using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryParticles : MonoBehaviour
{
    ParticleSystem gamParticles;
    void Start()
    {
        gamParticles = Gam.Instance.gamParticles;
    }
    public void GamParticles()
    {
        // Check if the Particle System prefab is assigned.
        if (gamParticles != null)
        {
            // Play the Particle System (if it's not set to Auto Play).
            gamParticles.Play();

            // Get the duration of the Particle System to determine when to destroy it.
            float particleSystemDuration = gamParticles.main.duration + gamParticles.main.startLifetime.constantMax;

            // Destroy the Particle System after its duration.
            Destroy(gamParticles);
        }
        else
        {
            Debug.LogWarning("Particle System Prefab is not assigned.");
        }
    }
}
