using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    ParticleSystem System;
    ParticleSystem.Particle[] particles;
    private Vector3 MousePos;
    private float speed = 300f;

    private void LateUpdate()
    {
        InitializeIfNeeded();
        int countAliveParticles = System.GetParticles(particles);
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for(int i = 0; i < countAliveParticles; i++)
        {
            particles[i].position = Vector2.Lerp(particles[i].position, MousePos, (particles[i].startLifetime - particles[i].remainingLifetime) / speed);
            
        }
        System.SetParticles(particles, countAliveParticles);
    }

    void InitializeIfNeeded()
    {
        if (System == null)
            System = GetComponent<ParticleSystem>();

        if (particles == null || particles.Length < System.main.maxParticles)
            particles = new ParticleSystem.Particle[System.main.maxParticles];
        
    }
}
