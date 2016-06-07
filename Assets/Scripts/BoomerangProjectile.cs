using UnityEngine;
using System.Collections;

public class BoomerangProjectile : MonoBehaviour
{
    #region Public Variables
    public string enemyTag = "";
    public string playerTag = "";
    #endregion
    #region Private Variables
    private bool reachedTarget = false;//the number of boomerangs the plater has
    private Vector3 target;
    private GameObject player;
    private float damage = 5;
    private float speed = 5;

    #endregion
    // Use this for initialization
    void Start()
    {
        print("launch sucsessful");
        this.gameObject.tag = "Return";//need to update to reflect new use, now frevents the booomerangs from colliding with themselves
    }

    // Update is called once per frame
    void Update()
    {
        boomerangMovement();

    }

    public void setup(Vector3 _target, GameObject _player, float _damage, float _speed)
    {
        target = _target;
        player = _player;
        //speed = _speed;
        damage = _damage;
    }
    private void boomerangMovement()//the initial kick to launch the boomerang
    {
        if (reachedTarget) { this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position + transform.up, speed / 20); }
        else { this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed / 20); }
        if (this.transform.position == target)
        {
            reachedTarget = true;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag != playerTag && coll.gameObject.tag != "Return")
        {
            reachedTarget = true;
        }


        if (coll.gameObject.tag == enemyTag)
        {
            reachedTarget = true;
        }
    }
    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == playerTag && reachedTarget)
        {
            print("hitPlayer");
            FindObjectOfType<BoomerangThrow>().PickupBoomerang();
            Destroy(this.gameObject);
        }
    }
}
