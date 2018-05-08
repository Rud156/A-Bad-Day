using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleParentAfterPlaying : MonoBehaviour {

	private GameObject parent;
	private ParticleSystem particles;

	// Use this for initialization
	void Start () {
		parent = gameObject.transform.parent.gameObject;
		particles = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!particles.isPlaying)
            Destroy(parent);
	}
}
