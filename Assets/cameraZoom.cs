using UnityEngine;
using System.Collections;

public class cameraZoom : MonoBehaviour {

	// Use this for initialization
	public float startZoom=100f;
	public float endZoom=400f;
	public float speed=5f;
	void Start () {
		StartCoroutine(ZoomOutCam(speed));
	}

	// Update is called once per frame
	void Update () {
	
	}


IEnumerator ZoomOutCam(float speed){
		float currentZoom=startZoom;
		gameObject.GetComponent<Camera>().orthographicSize=startZoom;
	while(currentZoom<endZoom){
		currentZoom=gameObject.GetComponent<Camera>().orthographicSize;
		gameObject.GetComponent<Camera>().orthographicSize+=speed;
		yield return 0;
	}
}

}
