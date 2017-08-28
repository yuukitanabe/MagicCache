using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestroy : MonoBehaviour {

    public Camera BattleCamera;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        
		
	}
    public void DestroyAllMonster()
    {
        if (BattleCamera.enabled == true)
        {
            if (gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
            var clones = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
        }
    }

}
