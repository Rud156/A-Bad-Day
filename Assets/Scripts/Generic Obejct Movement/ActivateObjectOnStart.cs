using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnStart : MonoBehaviour {

	public GameObject objectToActivate;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		objectToActivate.SetActive(true);
	}

}
