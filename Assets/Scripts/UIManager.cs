using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Button restart;
	public Button exit;
	public Button highscores;
	public Button HSExit;
	public Image HSscreen;
	public Text HighscoreText;
	private PlayerStats playerstas;

	// Use this for initialization
	void Start () {
		restart.gameObject.SetActive (false);
		exit.gameObject.SetActive (false);
		highscores.gameObject.SetActive (false);
		HSExit.gameObject.SetActive (false);
		HSscreen.gameObject.SetActive (false);
		HighscoreText.gameObject.SetActive (false);
	 
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	public void Restart()
	{
		Application.LoadLevel ("main");
	}
	public void Exit()
	{
		Application.Quit ();
	}
	public void Highscores()
	{
		restart.gameObject.SetActive (false);
		exit.gameObject.SetActive (false);
		highscores.gameObject.SetActive (false);
		HSExit.gameObject.SetActive (true);
		HSscreen.gameObject.SetActive (true);
		HighscoreText.gameObject.SetActive (true);
	}
	public void HighscoreExit()
	{
		restart.gameObject.SetActive (true);
		exit.gameObject.SetActive (true);
		highscores.gameObject.SetActive (true);
		HSExit.gameObject.SetActive (false);
		HSscreen.gameObject.SetActive (false);
		HighscoreText.gameObject.SetActive (false);
	}
}
