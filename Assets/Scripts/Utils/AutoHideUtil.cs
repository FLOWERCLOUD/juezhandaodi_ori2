using UnityEngine;
using System.Collections;

public class AutoHideUtil : MonoBehaviour {
	public float autoHideTime = 5f;
	private float recordHideTime;
	void Start()
	{
		recordHideTime = autoHideTime;
	}
	void Update () {
		if(gameObject.activeSelf)
		{
			autoHideTime -= Time.deltaTime;
			if(autoHideTime<=0)
			{
				autoHideTime = recordHideTime;
				gameObject.SetActive(false);
			}
		}
	}
}
