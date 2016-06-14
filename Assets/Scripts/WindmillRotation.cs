using UnityEngine;
using System.Collections;

public class WindmillRotation : MonoBehaviour {
	public float rotateSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.right * rotateSpeed* Time.deltaTime);
	}
}
