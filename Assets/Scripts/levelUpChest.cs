using UnityEngine;
using System.Collections;

public class levelUpChest : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter(Collision coll)
    {

        print("hit");
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponentInParent<LevelUp>().forceLevelup();
            Destroy(this.gameObject);
        }
    }

}
