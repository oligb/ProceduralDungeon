using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathInstantiate : MonoBehaviour {

	// Use this for initialization
	public GameObject floor;
	public GameObject wall;
	public GameObject gridPrefab;
	public int numberOfSteps;
	public int counter=0;
	public float chanceOfGridInstantiate=50f;
	public float distanceBetweenRooms=100f;
	public List<GameObject> grids;
	public bool verticalStepping=false;
	public float verticalAmt=.5f;
	public float colorScale=100f;

	void Start () {
		grids = GameObject.Find("RoomManager").GetComponent<RoomManager>().grids;
	
	}

	void OnTriggerEnter(){
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {

		if(counter<=numberOfSteps){
			float rando=Random.Range(0f,1f);
			if(rando<.05f){
				transform.Rotate(0f,90f,0f);
			}
			else if(rando>=.05f &&rando<.1f){
				transform.Rotate(0f,-90f,0f);
			}
			else if(rando>=.5f&& rando<=.5f+chanceOfGridInstantiate/100){
				bool canSpawnRoom=true;
				foreach(GameObject gridPos in grids){
					if(Vector3.Distance(transform.position,gridPos.transform.position)<=distanceBetweenRooms){
						canSpawnRoom=false;
					}
				}
				if(canSpawnRoom){
				Instantiate(gridPrefab,transform.position,Quaternion.identity);
				}
				Destroy(gameObject);
					}

			if(verticalStepping){
			if(rando<.5f){
					transform.Translate(0f,verticalAmt,0f);
			}
			else{
				transform.Translate(0f,-verticalAmt,0f);
			}
			}




			Color col= new Color(0f,1-counter/colorScale,0f);



			if(rando>=.9){
				int randoSteps=Random.Range(1,5);
				for(int i=0;i<=randoSteps;i++){
				transform.Translate(Vector3.forward*5f);
			
					GameObject floorGuy= Instantiate(floor,transform.position,Quaternion.identity) as GameObject;
					floorGuy.GetComponent<MeshRenderer>().materials[0].color=col;
				}
			}




			else{
			transform.Translate(Vector3.forward*5f);
				GameObject floorGuy= Instantiate(floor,transform.position,Quaternion.identity) as GameObject;
				floorGuy.GetComponent<MeshRenderer>().materials[0].color=col;
			}
			counter++;
		}
	
	}
}
