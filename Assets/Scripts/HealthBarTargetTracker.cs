using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarTargetTracker : MonoBehaviour {
    public GameObject target;//the enemy transform goes here

    public float enemyHeight = 2f;
    
    
    // Use this for initialization
	void Start ()
    {
	}
    public void Setup(GameObject _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update() 
    {

        if (target != null)
        {
            Vector3 wantedPos = Camera.main.WorldToScreenPoint(new Vector3(target.transform.position.x, target.transform.position.y + enemyHeight, target.transform.position.z));
            transform.position = wantedPos;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
