using UnityEngine;
using System.Collections;

public class StartRotation : MonoBehaviour {
	public float startRotationRelativeToYRadians = 3.14f;
	public float yTranslate = 0.25f;
	public float zTranslate = 0.2f;

	void Start () {
		GetComponent<ParticleSystem>().startRotation = Mathf.Deg2Rad*this.transform.eulerAngles.y + startRotationRelativeToYRadians;
		transform.Translate(new Vector3(0,yTranslate,zTranslate),Space.Self);
	}
}
