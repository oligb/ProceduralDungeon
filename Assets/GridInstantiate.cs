using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridInstantiate : MonoBehaviour {

	// Use this for initialization
	public GameObject floor;
	public GameObject wall;
	public GameObject pathInstantiate;
	public int maxOffshoots=5;
	public int gridSizeMin;
	public int gridSizeMax;
	public GameObject manager;
	public Color floorColor;
	public Color wallColor;
	public int numWalls;
	public int numFloors;
	public int numWallsMax;
	public int numWallsMin;
	public int numFloorsMax;
	public int numFloorsMin;


	void Start () {
		manager = GameObject.Find("RoomManager");
		manager.GetComponent<RoomManager>().grids.Add(gameObject);
		int numRooms = manager.GetComponent<RoomManager>().grids.Count;
		int gridSize=Random.Range(gridSizeMin,gridSizeMax);

		int numOffshoots=0;
		//col=new Color(0f,0f+.15f*numRooms,0f);
		int floorSequence=0;
		int wallSequence=0;
		bool spawningFloors=true;
		numWalls=Random.Range(numWallsMin,numWallsMax);
		numFloors=Random.Range(numFloorsMin,numFloorsMax);
		for(int i=0; i<gridSize;i++){
			for(int j=0; j<gridSize;j++){
				Vector3 pos= new Vector3(i*5,0,j*5)+transform.position;
				float randoInstantiate= Random.Range(0f,1f);

				if(spawningFloors){
				GameObject floorGuy=Instantiate(floor,pos+new Vector3(0f,.01f,0f),Quaternion.identity) as GameObject;
				floorGuy.GetComponent<MeshRenderer>().materials[0].color=floorColor;
					floorSequence++;
					if(floorSequence>numWalls){
						floorSequence=0;
						numWalls=Random.Range(numWallsMin,numWallsMax);
					spawningFloors=false;
					}
				}
				else{
					GameObject wallGuy=Instantiate(wall,pos+new Vector3(0f,.01f,0f),Quaternion.identity) as GameObject;
					wallGuy.GetComponent<MeshRenderer>().materials[0].color=wallColor;
					wallSequence++;
					if(wallSequence>numWalls){
						wallSequence=0;
						numFloors=Random.Range(numFloorsMin,numFloorsMax);
						spawningFloors=true;
					}
				}

				if(randoInstantiate>=.5 &&numOffshoots<maxOffshoots){	
					Instantiate(pathInstantiate,pos,Quaternion.identity);
					numOffshoots++;
				}

				/*
				if(randoInstantiate<=.7f){
					Instantiate(floor,pos,Quaternion.identity);
				}
				else if(randoInstantiate>=.7f &&randoInstantiate<=.8f){
					Instantiate(wall,pos,Quaternion.identity);
				}
				else{
					Instantiate(pathInstantiate,transform.position,Quaternion.identity);
					Destroy(gameObject);
				}
				*/

		}
		
	}
}
	
	// Update is called once per frame
	void Update () {
	
	}
}
