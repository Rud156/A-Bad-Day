using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjectOnStart : MonoBehaviour {

	public GameObject objectToDeactivate;

	// Use this for initialization
	void Start () {
		objectToDeactivate.SetActive(false);
	}
}
