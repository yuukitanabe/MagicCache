using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    public GameObject Monster1Prefab;

    private float nowTime;

    public float createTime;


	// Use this for initialization
	void Start () {

        nowTime = 0f;

	}
	
	// Update is called once per frame
	void Update () {

        if (nowTime >= createTime)
        {
            GameObject obj;

            obj = (GameObject)Instantiate(Monster1Prefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-220, -240)), Quaternion.identity);
            Destroy(obj, 10);
            nowTime = 0f;

        }
        nowTime += Time.deltaTime;
		
	}
}
