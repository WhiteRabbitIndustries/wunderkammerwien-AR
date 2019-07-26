using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zones : MonoBehaviour
{
	public enum State { locked = 0, unlocked = 1, captured = 2 }
	private State state;
	public float radius;
	private float kmInLat = 0.009009009009009f;
	private float kmInLong = 0.0117647058823529f;
	public float MLatitude;
	public float MLongitude;
	public string monster;
	public Image img;
	public ParticleSystem lockedParticle;
	public Light divineLight;
	public AudioSource audioS;
	public AudioClip unlockedClip;
	public GameObject UiManager;
	public AudioClip capturedClip;
	public GameObject audioManager;
	public GameObject jsonManager;
	public Material capturedMaterial;
	public GameObject hexagon;
	public GameObject CardObject;
	public GameObject CardBackObject;
	bool codeIsRight;
	bool captured = false;
	string capturedString;
//	public float fakeGpsLat;
//	public float fakeGpsLon;
	bool playerInZone;
	// Start is called before the first frame update
	void Start()
	{
		CardObject.SetActive(false);
		CardBackObject.SetActive(false);
		audioS.clip = unlockedClip;
		foreach (string item in jsonManager.GetComponent<JsonManager>().monstersCaught) {
			if (item == monster) {
				captured = true;
			}
		}
		//JsonUtility.FromJsonOverwrite(capturedString,this);
		//captured = System.Convert.ToBoolean(capturedString);
	}

	// Update is called once per frame
	void Update()
	{
		playerInZone = IsPlayerInZone();
			
		switch (state)
		{
			#region locked
			case State.locked:
				//lockedParticle.Play()
				if(codeIsRight == true && UiManager.GetComponent<Monsters>().GpsEnabled == false){
					SwitchState(State.captured);
					audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip);
					hexagon.GetComponent<Renderer>().material = capturedMaterial;
				}

				if (playerInZone == true)
				{
					audioManager.GetComponent<SoundManager>().PlayZone(unlockedClip, audioS);

					divineLight.gameObject.SetActive(true);
					SwitchState(State.unlocked);

					
				}
				if (captured == true) {
				//	audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip);
					SwitchState(State.captured);
					hexagon.GetComponent<Renderer>().material = capturedMaterial;

				}

				break;
			#endregion
			#region unlocked
			case State.unlocked:
				
				lockedParticle.Stop();
				if (playerInZone == false)
				{
					lockedParticle.Play();
					audioS.Stop();
					divineLight.gameObject.SetActive(false);
					SwitchState(State.locked);
				}
				if (codeIsRight == true && UiManager.GetComponent<Monsters>().GpsEnabled == false)
				{
					hexagon.GetComponent<Renderer>().material = capturedMaterial;
					audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip);
					SwitchState(State.captured);
					
				}
				if (playerInZone == true && codeIsRight == true||captured == true)
				{
					audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip);
					SwitchState(State.captured);
					
				}

				break;
			#endregion
			#region captured
			case State.captured:
				divineLight.enabled = true;
				if (img.gameObject.activeSelf == false) {
					img.gameObject.SetActive(true);
				}
				lockedParticle.Stop();
				captured = true;
				
				break;
				#endregion
			
		}
		if (captured == true) {
			CardObject.SetActive(true);
			CardBackObject.SetActive(true);
		}
	}
	private void OnApplicationQuit()
	{
		//JsonUtility.ToJson(captured);
	}
	void SwitchState(State newState)
	{
		state = newState;
	}
	public bool IsPlayerInZone()
	{
		//determenes if player is located with in the play area 
		bool inZone;

		if (GPS.Instance.latitude /*fakeGpsLat*/ >= MLatitude - radius * kmInLat && GPS.Instance.latitude/*fakeGpsLat*/ <= MLatitude + radius * kmInLat)
		{
			if (GPS.Instance.longitude/*fakeGpsLon*/ >= MLongitude - radius * kmInLong && GPS.Instance.longitude/*fakeGpsLon*/ <= MLongitude + radius * kmInLong)
			{

				inZone = true;
			}
			else
			{
				inZone = false;
			}
		}
		else
		{
			inZone = false;
		}


		return inZone;

	}
	public void Code(string name) {
		if (name == monster) {
			codeIsRight = true;
		}
	}
}
