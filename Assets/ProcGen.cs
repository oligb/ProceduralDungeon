using UnityEngine;
using System.Collections;

public class ProcGen : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab;
	void Start () {
		Instantiate(prefab, new Vector3(Random.Range(-100f,100f),0f,Random.Range(-50f,50f)), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
