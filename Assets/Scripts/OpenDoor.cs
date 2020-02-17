using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public float smooth = 2.0f;
	public float DoorOpenAngle = 90.0f;

	public AudioClip OpenAudio;
	public AudioClip CloseAudio;

	private Vector3 defaultRot;
	private Vector3 openRot;
	private bool open;

	// Use this for initialization
	void Start () {
		
			defaultRot = transform.eulerAngles;
			openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
		}
	
	// Update is called once per frame
	void Update () 
	{
		if (open) 
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		} 
		else 
		{
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

		}
	}

	public void ChangeOpenDoor()
	{
		open = !open;
	}
}