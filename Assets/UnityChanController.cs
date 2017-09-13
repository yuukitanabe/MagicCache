using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {

    private Animator myAnimator;

    NavMeshAgent agent;

    RaycastHit hit;

    Ray ray;

    public Camera BattleCamera;

    public Camera UnityChanCamera;

    public Create create;

    public int unitychanHP = 100;

    private Slider unitychanHPSlider;

    private MonsterDestroy monster;

    public BattleObjectGenerator battleObject;

    public BattleObjectController battleController;

    public MonsterController createmonster;

    GameObject Monster1Prefab;

    public GameObject Enemy;

    public Slider EnemyHPSlider;

    public float timeOut;

    private float timeElapsed;

    private int unitychanDamage = 20;

   

   
    

    // Use this for initialization
    void Start () {

        this.myAnimator = GetComponent<Animator>();

        this.agent = GetComponent<NavMeshAgent>();

        this.myAnimator.SetBool("Run", false);

        unitychanHPSlider = GameObject.Find("UnityChanHPSlider").GetComponent<Slider>();
        unitychanHPSlider.maxValue = unitychanHP;
        unitychanHPSlider.value = unitychanHP;

        unitychanHPSlider.gameObject.SetActive(false);

        Monster1Prefab = GameObject.Find("Monster1Prefab");

        


        createmonster = GetComponent<MonsterController>();

        timeElapsed = 0.0f;
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
        if (Input.GetMouseButtonDown(0))
        {
           
            
                Ray ray = BattleCamera.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit))
                {
                Debug.Log(hit.collider.gameObject.tag);
                    if (hit.collider.gameObject.tag == "Crystal"||
                        hit.collider.gameObject.tag == "Stone" ||
                        hit.collider.gameObject.tag == "BoulderStone"||
                        hit.collider.gameObject.tag == "Rock" ||
                        hit.collider.gameObject.tag == "Flower"||
                        hit.collider.gameObject.tag == "Grass")
                    {
                    Attack(hit.collider.gameObject.GetComponent<BattleObjectController>());
                    }
                    
                }
            
        }
        

    }
    public void Attack(BattleObjectController BattleObj)
    {
       if (BattleObj.Hit())
        {
            createmonster.GetComponent<ParticleSystem>().Play();
            Destroy(BattleObj.gameObject);
            if (createmonster.Damage(5))
            {
                BattleCamera.enabled = false;

                create.isGenerating = true;

                createmonster.isEncount = false;

                battleObject.RemoveAll();

                unitychanHPSlider.gameObject.SetActive(false);

                agent.speed = 3.5f;
            }
            
        }
        Debug.Log(BattleObj.hitCount);
    }

void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy")
        {
           BattleCamera.enabled = true;

            create.isGenerating = false;

            MonsterDestroy monster = gameObject.GetComponent<MonsterDestroy>();
            monster.DestroyAllMonster();
           

            Vector3 MonsterPos = transform.position + (transform.forward * 11.5f);

            createmonster = create.CreateMonster(MonsterPos);

            createmonster.isEncount = true;

            createmonster.transform.LookAt(transform);

            transform.LookAt(createmonster.transform);

            createmonster.transform.localScale *= 3.2f;


            unitychanHPSlider.gameObject.SetActive(true);

            
            battleObject.GenerateObject();

      
            Debug.Log(unitychanHPSlider.value = unitychanHP);

            

        }
        
    }

    
   
}
