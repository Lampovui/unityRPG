using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daytime : MonoBehaviour {
	
	public float secondInDay = 120;
	[Range(0,1)]
	private float daytime = 0;

	//этот код обновялет день и ночь
	void Update() {
		daytime += Time.deltaTime / secondInDay;
		transform.localRotation = Quaternion.Euler((daytime * 360) -90, 170, 0);
	}
}
