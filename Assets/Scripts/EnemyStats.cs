using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (health < 1 ) {
            
            Destroy(gameObject);
            
        }
	}
}
