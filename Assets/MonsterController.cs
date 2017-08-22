using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public Transform target;

    public float speed = 0.1f;

    private Vector3 vec;


	// Use this for initialization
	void Start () {

        target = GameObject.Find("unitychan").transform;

	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

        transform.position += transform.forward * speed;

		
	}
}
