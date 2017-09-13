using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObjectController : MonoBehaviour {

    RaycastHit hit;

    Ray ray;

    public Camera BattleCamera;

    public int hitCount;

    public int MaxhitCount;



    public bool Hit()
    {
        hitCount += 1;
        return hitCount >= MaxhitCount;
    }

    // Use this for initialization
    void Start () {

       BattleCamera = GameObject.Find("BattleCamera").GetComponent<Camera>();



        MaxhitCount = 3;

        hitCount = 0;

    }

    // Update is called once per frame
    void Update() { 


            
        
		
	}
}
