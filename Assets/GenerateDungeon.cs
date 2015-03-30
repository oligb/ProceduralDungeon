using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateDungeon : MonoBehaviour {
	public GameObject pathInstantiate;
	// Use this for initialization
	void Start () {
		for(int i=0;i<4;i++){
			Instantiate(pathInstantiate,new Vector3(0f,0f,0f),Quaternion.Euler(0f,i*90f,0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)){
			Application.LoadLevel("scene1");

		}
	
	}
}
