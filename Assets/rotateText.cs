using UnityEngine;
using System.Collections;

public class rotateText : MonoBehaviour {

	public float rotSpeed=5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotSpeed,0f,0f);
	}
}
