using UnityEngine;
using System.Collections;

public class BoomerangThrow : MonoBehaviour
{
    #region Public Variables
    public string boomerangTag = "";
    public GameObject movingBoomerangPrefab = null;
    public float range = 20f;
    public float projectileSpeed = 5;
    public float projectileDamage = 5;

    #endregion
    #region Private Variables
    private int currentLevel = 0;
    private int numOfBoomerangs = 3;//the number of boomerangs the plater has
    private GameObject target;

    private PlayerStats playerStats;

    #endregion
    // Use this for initialization

    // Update is called once per frame
    void Start()
    {
        // this might need to move
        playerStats = FindObjectOfType<PlayerStats>();
        range = playerStats.getRangedAttackRange();
        projectileDamage = playerStats.getRangedAttackDamage();
        numOfBoomerangs = playerStats.getRangedAttackAmmo();
        projectileSpeed = playerStats.getRangedAttackSpeed();
        target = GameObject.FindGameObjectWithTag("Target");
        target.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z + range);
    }

    void Update()
    {
        input();
    }


    private void input()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (numOfBoomerangs > 0) { throwBoomerang(); print("throw"); }//aim the ball n chain
        }
    }


    public void PickupBoomerang()
    {
        numOfBoomerangs ++;
    }
    private void OnCollisionEnter(Collision coll)//system recognises that the boomerang has returned to the player
    {
        if (coll.gameObject.tag == boomerangTag)
        {
            PickupBoomerang();
        }
    }



    private void throwBoomerang()
    {
        numOfBoomerangs--;
        GameObject thrownBoomerang = Instantiate(movingBoomerangPrefab, new Vector3(this.gameObject.transform.position.x , this.gameObject.transform.position.y + 2, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;


        //

        thrownBoomerang.GetComponent<BoomerangProjectile>().setup(target,this.gameObject, playerStats.getRangedAttackDamage(), projectileSpeed = playerStats.getRangedAttackSpeed());
    }
}