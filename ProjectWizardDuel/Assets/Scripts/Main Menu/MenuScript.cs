using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button hostButton;
	public Button opponentsButton;
	public Button optionsButton;
	public Button creditsButton;
	public Button quitButton;
	public Button debugButton;	//FOR DEBUGGING

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas>();
		hostButton = hostButton.GetComponent<Button>();
		opponentsButton = opponentsButton.GetComponent<Button>();
		optionsButton = optionsButton.GetComponent<Button>();
		creditsButton = creditsButton.GetComponent<Button>();
		quitButton = quitButton.GetComponent<Button>();
		debugButton = debugButton.GetComponent<Button>();

		quitMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Event for exit button press
	public void ExitPress() {
		quitMenu.enabled = true;
		hostButton.enabled = false;
		opponentsButton.enabled = false;
		optionsButton.enabled = false;
		creditsButton.enabled = false;
		quitButton.enabled = false;
		debugButton.enabled = false;
	}

	// Event for no button press in exit prompt
	public void NoPress() {
		quitMenu.enabled = false;
		hostButton.enabled = true;
		opponentsButton.enabled = true;
		optionsButton.enabled = true;
		creditsButton.enabled = true;
		quitButton.enabled = true;
		debugButton.enabled = true;
	}

	// Event for yes button press in exit prompt
	public void YesPress() {
		Application.Quit();
	}

	// Event for debug press *FOR NOW*
	public void DebugPress() {
		SceneManager.LoadScene("Arena");
	}
}