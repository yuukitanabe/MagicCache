using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObjectGenerator : MonoBehaviour {

    public GameObject unitychan;

    public List<GameObject> objectlist;

    public List<GameObject> generateObjectList;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void GenerateObject()
    {
        for ( int i = 0; i < 10; i++)
        {
            Vector3 objectPos = new Vector3(Random.Range(-1, 3), Random.Range(0.5f, 6), 3f);
            Vector3 worldPos = unitychan.transform.TransformPoint(objectPos);
            GameObject go = Instantiate(objectlist[i]) as GameObject;

            go.transform.position = worldPos;

            generateObjectList.Add(go);

        }
    }
    public void RemoveAll()
    {
        for (int i = 0; i < generateObjectList.Count; i++)
        {
            GameObject go = generateObjectList[i];
            if(go != null)
            {
                Destroy(go);
            }
           
        }
        generateObjectList.Clear();
    }
}
