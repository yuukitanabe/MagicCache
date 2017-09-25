using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour {

    public Transform target;

    public float speed = 0.1f;

    private Vector3 vec;

    private Animator animator;

    public float enemyHP = 30;

    private Slider EnemyHPSlider;

    private float damage = 5;

    GameObject unitychan;

    UnityChanController unitychanController;

    private float EnemyDamage = 5;

    private float timeCount;

    private Slider unitychanHPSlider;

    private float unitychanDamage = 10;

    private float unitychanHP = 100;

    

    // Use this for initialization
    void Start() {

        target = GameObject.Find("unitychan").transform;

        EnemyHPSlider = GameObject.Find("EnemyHPSlider").GetComponent<Slider>();
        EnemyHPSlider.maxValue = enemyHP;
        EnemyHPSlider.value = enemyHP;

        EnemyHPSlider.gameObject.SetActive(false);

        unitychan = GameObject.Find("unitychan");

        unitychanController = unitychan.GetComponent<UnityChanController>();


        


    }
    public bool isEncount;

    

// Update is called once per frame
void Update () {

        if (isEncount)
        {           
            timeCount += Time.deltaTime;
            if (timeCount > 3f)
            {
                Attack();
                timeCount = 0;

                if (unitychanHPSlider.value <= 0)
                {
                    GameObject.Find("GameOverCanvas").GetComponent<UIController>().GameOver();
                }

            }

        }

        if (isEncount == true)
        {
            EnemyHPSlider.gameObject.SetActive(true);

            return;
        }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

            Vector3 direction = transform.forward;
            direction.y = 0;
            transform.position += direction * speed;

     
    }
    public bool Damage(float damage)
    {
        Debug.Log(
        enemyHP -= damage);
        EnemyHPSlider.value -= EnemyDamage;
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
        return enemyHP <= 0;
    }
    private void Attack()
    {
        unitychanHPSlider = GameObject.Find("UnityChanHPSlider").GetComponent<Slider>();
        unitychanHPSlider.maxValue = unitychanHP;
        unitychanHPSlider.value = unitychanHP;

        unitychanHP -= unitychanDamage;
        unitychanHPSlider.value -= unitychanDamage;
        unitychanHPSlider.value = unitychanHP;

        
    }
    
        
    
    
}
