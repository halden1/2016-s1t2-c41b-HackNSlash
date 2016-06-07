using UnityEngine;
using System.Collections;

public class BoomerangProjectile : MonoBehaviour {
    #region Public Variables
    public string enemyTag = "";
    public string playerTag = "";
    #endregion
    #region Private Variables
    private bool reachedTarget = false;//the number of boomerangs the plater has
    private GameObject target;
    public GameObject player;
    private float damage = 5;
    private float speed = 5;

    #endregion
    // Use this for initialization
    void Start () {
        print("launch sucsessful");
    }

    // Update is called once per frame
    void Update () {
        boomerangMovement();

    }

    public void setup(GameObject _target, GameObject _player, float _damage, float _speed)
    {
        target = _target;
        player = _player;
       // speed = _speed;
       // damage = _damage;
    }
    private void boomerangMovement()//the initial kick to launch the boomerang
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,target.transform.position,speed/20) ;     
    }
    
    private void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag != playerTag)
        {
            target = player;
            this.tag = "Return";
        }


        if (coll.gameObject.tag == enemyTag )
        {
            target = player;
            this.tag = "Return";

        }

        if (coll.gameObject.tag == playerTag && target == player.gameObject)
        {
            print("hitPlayer");
            FindObjectOfType<BoomerangThrow>().PickupBoomerang();
            target = null;
        }

        if (coll.gameObject.tag == "Target")
        {
            target = player;
            reachedTarget = true;
        }
    }
}
