using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnityChanController : MonoBehaviour {

    private Animator myAnimator;

    NavMeshAgent agent;

    RaycastHit hit;

    Ray ray;

    public Camera BattleCamera;

    public Camera UnityChanCamera;

    public Create create;


	// Use this for initialization
	void Start () {

        this.myAnimator = GetComponent<Animator>();

        this.agent = GetComponent<NavMeshAgent>();

        this.myAnimator.SetBool("Run", false);

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                agent.SetDestination(hit.point);

                this.myAnimator.SetBool("Run", true);

            }
        }

        if (Vector3.Distance(hit.point, transform.position) < 1.0f)
        {
            this.myAnimator.SetBool("Run", false);
        }
        if (BattleCamera.enabled == true)
        {
            agent = GetComponent<NavMeshAgent>();

            agent.speed = 0f;

            myAnimator.SetBool("Run", false);
        }

    }
void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy")
        {
           BattleCamera.enabled = true;

            create.isGenerating = false;

            MonsterDestroy monster = GetComponent<MonsterDestroy>();
            monster.DestroyAllMonster();


            Vector3 MonsterPos = transform.position+(transform.forward * 3);

            create.CreateMonster(MonsterPos);
                
        }


    }
}
