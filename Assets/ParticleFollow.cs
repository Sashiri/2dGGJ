using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;
    private Vector3 MousePos;
    private float speed = 250f;

    private void LateUpdate()
    {
        InitializeIfNeeded();
        int countAliveParticles = particleSystem.GetParticles(particles);
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for(int i = 0; i < countAliveParticles; i++)
        {
            particles[i].position = Vector2.Lerp(particles[i].position, MousePos, particles[i].remainingLifetime / speed);
            
        }
        particleSystem.SetParticles(particles, countAliveParticles);
    }

    void InitializeIfNeeded()
    {
        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();

        if (particles == null || particles.Length < particleSystem.main.maxParticles)
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        
    }
}
