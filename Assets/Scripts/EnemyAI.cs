using UnityEngine;
using System.Collections;

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


    // Use this for initialization
    void Start () {
        rangeIndicator.SetActive(false);
        attackIndicator.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAgent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
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
            myAgent.SetDestination(target.transform.position);
        }
        
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
        myAgent.SetDestination(target.transform.position);
        
    }
    public void OutSideAttackRange()
    {
        attackIndicator.SetActive(false);
        rangeIndicator.SetActive(false);
        isAttacking = false;
        myAgent.SetDestination(home.transform.position);
       
    }
}
