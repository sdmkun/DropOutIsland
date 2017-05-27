using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPlacer : MonoBehaviour {

	public GameObject panel;
	public int floorSize = 20;
	public float panelScale = 1.0f;
	// Use this for initialization
	void Start () {
		for(int x = 0; x < floorSize; ++x){
			for(int z = 0; z < floorSize; ++z){
				Instantiate(panel,new Vector3(-floorSize/2.0f + x * panelScale, 0, -floorSize/2.0f + (z+0.5f*(x%2)) * panelScale), Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
