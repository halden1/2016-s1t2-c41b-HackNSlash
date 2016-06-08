using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {
    [SerializeField]
    private NavMeshAgent myAgent;
    public Transform target;
    public GameObject rangeIndicator;            
    public GameObject attackIndicator;     
    public Transform home;                       //where they go back to idle
    public float playerDistance;
    public bool isAttacking = false;

    public float attackrange;
    public float NoticeRange;
    public float maxRange;

    //healthbar stuff
    public Slider healthBar;
    public Slider healthbarPrefab;
    public EnemyStats healthStat;
    public Transform canvasTransform;

    // Use this for initialization
    void Start () {
        rangeIndicator.SetActive(false);
        attackIndicator.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAgent = GetComponent<NavMeshAgent>();


        //store health
        healthStat = this.gameObject.GetComponent<EnemyStats>();
        CreateHealthBar();///move this later

    }
	
	// Update is called once per frame
	void Update () {
        healthBar.value = healthStat.Health;
        playerDistance = Vector3.Distance(transform.position, target.position); //Get distance to current target.
        if (playerDistance < attackrange)
        {
            WithInAttackRange();
        }
        else if (playerDistance < NoticeRange && isAttacking == false)
        {
            WithinNoticeRange();
        }
        else if (playerDistance >= maxRange)
        {
            OutSideAttackRange();
        }

        if (isAttacking == true)
        {
            Vector3 targetPos = target.transform.position;
            Vector3 dir = transform.position - target.transform.position;
            dir.y = 0;
            dir.Normalize();
            dir *= 2;
            targetPos += dir;
            myAgent.SetDestination(targetPos);
        }


        //update healthbar
        updateHealthbar(healthBar);
    }


    public void WithinNoticeRange()
    {
        transform.LookAt(target);
        rangeIndicator.SetActive(true);
       
    }
    public void WithInAttackRange()
    {
        rangeIndicator.SetActive(false);
        attackIndicator.SetActive(true);
        isAttacking = true;
        
    }
    public void OutSideAttackRange()
    {
        attackIndicator.SetActive(false);
        rangeIndicator.SetActive(false);
        isAttacking = false;
        myAgent.SetDestination(home.transform.position);
       
    }








    public void CreateHealthBar()
    {
        healthBar = Instantiate(healthbarPrefab) as Slider;
        healthBar.transform.Rotate(0, 0, 0, 0);
        healthBar.transform.SetParent(canvasTransform);
        healthBar.GetComponent<HealthBarTargetTracker>().Setup(this.gameObject);
        healthBar.maxValue = healthStat.Health;
    }


    public void updateHealthbar(Slider healthbar)
    {
        if(healthBar != null)
        {
            healthBar.value = healthStat.Health;
        }
    }
}
