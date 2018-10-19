using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class BathroomTalkTime : MonoBehaviour 
{

	public GameObject dialogueManager;

	public Text dialogueText;
	public Text speaker;

	public RigidbodyFirstPersonController player;

	public bool dialogueActive;
	public bool talkingToCapsule;

	public string speakerName;
	public string[] dialogueLines;

	public int currentLine;

	void Start ()
	{
		dialogueManager.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{

		speaker.text = speakerName;	
		dialogueText.text = dialogueLines [currentLine];

		if(dialogueActive && Input.GetKeyDown (KeyCode.Return))
			currentLine++;

		if (currentLine >= dialogueLines.Length && talkingToCapsule) 
		{
			dialogueManager.SetActive(false);
			talkingToCapsule = false;
			dialogueActive = false;

			player.movementSettings.BackwardSpeed = 4f;
			player.movementSettings.StrafeSpeed = 8f;
			player.movementSettings.ForwardSpeed = 4f;
			player.movementSettings.CurrentTargetSpeed = 4f;
			player.movementSettings.JumpForce = 50f;
		}

		if(currentLine >= dialogueLines.Length)
		{
			player.movementSettings.BackwardSpeed = 4f;
			player.movementSettings.StrafeSpeed = 8f;
			player.movementSettings.ForwardSpeed = 4f;
			player.movementSettings.CurrentTargetSpeed = 4f;
			player.movementSettings.JumpForce = 50f;

			currentLine = 0;
		}
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
}
