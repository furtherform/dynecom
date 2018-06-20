using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttractor : MonoBehaviour {

    public ParticleSystem ps;
    public ParticleSystem.Particle[] particles;
    Transform t;

	// Use this for initialization
	void Start () {
        t = transform;
        ps = (ParticleSystem) GameObject.Find("FocusBeam1").GetComponent(typeof(ParticleSystem));
        ps.GetParticles(particles);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ps.isPlaying) {
            particles = new ParticleSystem.Particle[ps.particleCount];
            int length = ps.GetParticles(particles);
            //Debug.Log("Particle count: " + ps.particleCount + " - Particles get: " + length);
            for (int i = 0; i < particles.GetUpperBound(0); i++)
            {
                //float timeAlive = particles[i].startLifetime - particles[i].remainingLifetime;
                //Debug.Log(particles[i].startLifetime + " <-  ->" + particles[i].remainingLifetime);

                // function to attract particles towards this object
                particles[i].position = Vector3.MoveTowards(particles[i].position, transform.position, Time.deltaTime / 0.4f);
            }
            ps.SetParticles(particles, length );
        }
    }
}
