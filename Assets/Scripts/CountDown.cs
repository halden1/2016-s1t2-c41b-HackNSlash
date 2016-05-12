using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    #region Public Variables
        public float timeAlocated = 1f;//the number of minutes given to the player for each attempt
        public string textTag = ""; // the tag applied to the timer, which must be a text object
    #endregion

    #region Private Variables

        private float timeLeft = 60f;

    #endregion
    
    // Use this for initialization
    void Start () {
        timeLeft = 60 * timeAlocated;
	}
	


	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            //ref to player death script
            Destroy(this.gameObject);//remove this later
        }
        GameObject.FindGameObjectWithTag(textTag).GetComponent<Text>().text = timeLeft.ToString();//fint the text object and set its text to the time remaining in the game
	}

    public float GetTime() { return timeLeft; }

    public void AddTime(float tmp) { timeLeft += tmp; }
}
