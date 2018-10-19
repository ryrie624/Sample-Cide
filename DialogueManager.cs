using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour 
{
	public bool objComp;

	public GameObject dialogueManager;
	public GameObject hud;

	public Playerplayer playerPlay;

	public Text dialogueText;
	public Text speaker;

	public RigidbodyFirstPersonController player;

	public bool dialogueActive;
	public bool talkingToCapsule;

	public string speakerName;
	public string[] dialogueLines;
	public string[] completedLines;

	public int currentLine;
	public int pickups;

	void Start ()
	{
		
		dialogueManager.SetActive (false);
		hud.SetActive (false);
		objComp = false;
		pickups = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		speaker.text = speakerName;
		if (!objComp) {
			dialogueText.text = dialogueLines [currentLine];

			if (dialogueActive && Input.GetKeyDown (KeyCode.Return))
				currentLine++;

			if (currentLine >= dialogueLines.Length && talkingToCapsule) {
				dialogueManager.SetActive (false);
				talkingToCapsule = false;
				dialogueActive = false;

				player.movementSettings.BackwardSpeed = 4f;
				player.movementSettings.StrafeSpeed = 8f;
				player.movementSettings.ForwardSpeed = 4f;
				player.movementSettings.CurrentTargetSpeed = 4f;
				player.movementSettings.JumpForce = 50f;

				hud.SetActive (true);
			}

			if (currentLine >= dialogueLines.Length) {
				player.movementSettings.BackwardSpeed = 4f;
				player.movementSettings.StrafeSpeed = 8f;
				player.movementSettings.ForwardSpeed = 4f;
				player.movementSettings.CurrentTargetSpeed = 4f;
				player.movementSettings.JumpForce = 50f;

				currentLine = 0;
			}
		} else 
		{
			dialogueText.text = completedLines [currentLine];

			if (dialogueActive && Input.GetKeyDown (KeyCode.Return))
				currentLine++;

			if (currentLine >= completedLines.Length && talkingToCapsule) {
				dialogueManager.SetActive (false);
				talkingToCapsule = false;
				dialogueActive = false;

				StartCoroutine (WaitToEnd ());

				SceneManager.LoadScene ("UnityEnd");

				player.movementSettings.BackwardSpeed = 4f;
				player.movementSettings.StrafeSpeed = 8f;
				player.movementSettings.ForwardSpeed = 4f;
				player.movementSettings.CurrentTargetSpeed = 4f;
				player.movementSettings.JumpForce = 50f;

			}

			if (currentLine >= completedLines.Length) {
				player.movementSettings.BackwardSpeed = 4f;
				player.movementSettings.StrafeSpeed = 8f;
				player.movementSettings.ForwardSpeed = 4f;
				player.movementSettings.CurrentTargetSpeed = 4f;
				player.movementSettings.JumpForce = 50f;

				currentLine = 0;
			}
		}

		checkComp ();
	}

	IEnumerator WaitToEnd()
	{
		yield return new WaitForSecondsRealtime (3);
	}
	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.tag == "Player")
		{
			dialogueActive = true;
			dialogueManager.SetActive(true);
			talkingToCapsule = true;

			player.movementSettings.BackwardSpeed = 0f;
			player.movementSettings.StrafeSpeed = 0f;
			player.movementSettings.ForwardSpeed = 0f;
			player.movementSettings.CurrentTargetSpeed = 0f;
			player.movementSettings.JumpForce = 0f;
		}
	}

	void checkComp()
	{
		if (pickups > 3)
			objComp = true;
	}

}
