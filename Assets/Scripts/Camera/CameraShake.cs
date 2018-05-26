using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public IEnumerator Shake (float duration, float magnitude) {
		Vector3 originalPosition = gameObject.transform.localPosition;
		float elapsedTime = 0;

		while (elapsedTime < duration)
		{
			float x = Random.Range(-1, 1) * magnitude;
			float y = Random.Range(-1, 1) * magnitude;

			gameObject.transform.localPosition = new Vector3(x, y, originalPosition.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		gameObject.transform.localPosition = originalPosition;
	}
}
