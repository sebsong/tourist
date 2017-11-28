using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed;

	private bool interacting;
	private Animator anim;
	private Text proficiencyLevelText;

	// Use this for initialization
	void Start () {
		transform.position = DataController.Instance.ExitPosition;
		interacting = false;
		anim = GetComponent<Animator> ();
		anim.SetFloat ("speed", speed);
		proficiencyLevelText = GameObject.FindGameObjectWithTag ("proficiency_level_ui").GetComponent<Text> ();
		proficiencyLevelText.text = "Proficiency: " + DataController.Instance.PlayerData.ProficiencyLevel.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (!interacting) {
			Move ();
		}

		//DEBUG Inventory
		if (Input.GetKeyDown (KeyCode.I)) {
			foreach (Item item in DataController.Instance.PlayerData.PlayerInventory) {
				print (item.GetItemName ());
			}
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			Application.OpenURL ("https://goo.gl/forms/X5CdkcfDjdNclGy72");
		}
	}

	// Handle player movement
	void Move() {
		Vector3 dir;

		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		if (horizontal != 0) {
			vertical = 0f;
		} else if (vertical != 0) {
			horizontal = 0f;
		} else {
            print(anim);
			anim.SetBool ("isMoving", false);
			return;
		}

		dir = new Vector2 (horizontal, vertical);

		anim.SetFloat ("xDir", horizontal);
		anim.SetFloat ("yDir", vertical);
		anim.SetBool ("isMoving", true);

		transform.position += dir * speed * Time.deltaTime;
	}

	public void Interact() {
		interacting = true;
	}

	public void InteractEnd() {
		proficiencyLevelText.text = "Proficiency: " + DataController.Instance.PlayerData.ProficiencyLevel;
		interacting = false;
	}


}
