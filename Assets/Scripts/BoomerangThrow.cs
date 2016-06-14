using UnityEngine;
using System.Collections;

public class BoomerangThrow : MonoBehaviour
{
    #region Public Variables
    public GameObject movingBoomerangPrefab = null;
	public GameObject target;
	public float offset = 20;
    public float range = 20f;
    public float projectileSpeed = 5;
    public float projectileDamage = 5;

    #endregion
    #region Private Variables

    public int numOfBoomerangs = 3;//the number of boomerangs the plater has

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
        target.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y , this.gameObject.transform.position.z + range);
    }

    void Update()
    {
        input();
		target.transform.position = this.transform.position + this.transform.forward * offset;
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
   



    private void throwBoomerang()
    {
        numOfBoomerangs--;
        GameObject thrownBoomerang = Instantiate(movingBoomerangPrefab, new Vector3(this.gameObject.transform.position.x , this.gameObject.transform.position.y +2f, this.gameObject.transform.position.z), Quaternion.identity) as GameObject;


        //

        thrownBoomerang.GetComponent<BoomerangProjectile>().setup(target.transform.position,this.gameObject, playerStats.getRangedAttackDamage(), projectileSpeed = playerStats.getRangedAttackSpeed());
    }
}