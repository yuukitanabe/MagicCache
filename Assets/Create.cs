using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour {

    public GameObject Monster1Prefab;

    private float nowTime;

    public float timeOut;

    private float timeElapsed;

    public Camera BattleCamera;

    public bool isGenerating = false;


    GameObject unitychan;

    UnityChanController unitychanController;

    

	// Use this for initialization
	void Start () {

        StartCoroutine("CreateCoroutine");

        timeElapsed = 0.0f;

        isGenerating = true;

        unitychan = GameObject.Find("unitychan");

        unitychanController = unitychan.GetComponent<UnityChanController>();

        
	}
	
	// Update is called once per frame
	void Update () {

        timeElapsed += Time.deltaTime;
    }

    private IEnumerator CreateCoroutine()
    {
        while (true) {

            yield return new WaitForSeconds(2.0f);

            if (timeElapsed >= timeOut && isGenerating == true)
            {
                GameObject obj;

                obj = (GameObject)Instantiate(Monster1Prefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-220, -240)), Quaternion.identity);
                Destroy(obj, 10);

                timeElapsed = 0.0f;
            }
            else { 
                yield return 0;
            }
        }

    }

    public MonsterController CreateMonster(Vector3 pos)
    {
        
        
            GameObject obj = Instantiate(Monster1Prefab, pos, Quaternion.identity);
        unitychanController.Enemy = obj;
        

        return obj.GetComponent<MonsterController>();

           
    }
    



}
