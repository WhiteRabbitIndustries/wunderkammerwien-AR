using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoZones : MonoBehaviour
{
	public enum State { locked = 0, unlocked = 1, captured = 2, capturedAll = 3 }
	public State state;
	public float radius;
	private float kmInLat = 0.009009009009009f;
	private float kmInLong = 0.0117647058823529f;
	public float MLatitude;
	public float MLongitude;
	public string monster;
	public string monster2;
	public Image img1;
	public Image img2;

	public ParticleSystem lockedParticle;
	public Light divineLight;
	public AudioSource audioS;
	public Material capturedMaterial;
	public AudioClip unlockedClip;
	public AudioClip unlockedClip2;
	public GameObject audioManager;
	public AudioClip capturedClip;
	public GameObject jsonMan;
	bool playerInZone;
	public AudioClip capturedClip2;
	public GameObject CardBackObject1;
	public GameObject CardBackObject2;
	public GameObject UiManager;
	public GameObject CardObject;
	public GameObject CardObject2;
	public GameObject hexagon;
	bool codeIsRight1;
	bool codeIsRight2;
	bool captured1 = false;
	bool captured2 = false;
	string capturedString;
	// Start is called before the first frame update
	void Start()
	{
		CardObject.SetActive(false);
		CardObject2.SetActive(false);
		CardBackObject1.SetActive(false);
		CardBackObject2.SetActive(false);
		audioS.clip = unlockedClip;
		divineLight.enabled = false;
		foreach (string item in jsonMan.GetComponent<JsonManager>().monstersCaught)
		{
			if (item == monster2)
			{
				captured2 = true;
			}
			if (item == monster)
			{
				captured1 = true;
			}
		}
		//JsonUtility.FromJsonOverwrite(capturedString, this);
		//print(capturedString);

	}

	// Update is called once per frame
	void Update()
	{
		if (captured1 == true)
		{
			CardObject.SetActive(true);
			CardBackObject1.SetActive(true);
			if (captured2 == true)
			{
				CardObject2.SetActive(true);
				CardBackObject2.SetActive(true);
			}
			playerInZone = IsPlayerInZone();

			switch (state)
			{
				#region locked
				case State.locked:



					if (UiManager.GetComponent<Monsters>().GpsEnabled == false && codeIsRight1 == true)
					{

						audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip);
						SwitchState(State.captured);
					}
					if (UiManager.GetComponent<Monsters>().GpsEnabled == false && codeIsRight2 == true)
					{
						SwitchState(State.capturedAll);
						audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip2);
						hexagon.GetComponent<Renderer>().material = capturedMaterial;
					}
					if (playerInZone == true)
					{

						lockedParticle.Stop();
						divineLight.gameObject.SetActive(true);
						audioManager.GetComponent<SoundManager>().PlayZone(unlockedClip, audioS);
						SwitchState(State.unlocked);
					}
					if (captured2 == true)
					{
						SwitchState(State.capturedAll);
						hexagon.GetComponent<Renderer>().material = capturedMaterial;
					}
					if (captured1 == true)
					{
						SwitchState(State.captured);
					}
					break;
				#endregion
				#region unlocked
				case State.unlocked:

					if (playerInZone == false)
					{
						lockedParticle.Play();
						divineLight.gameObject.SetActive(false);
						audioS.Stop();
						SwitchState(State.locked);

					}
					if (playerInZone == true && codeIsRight1 == true || captured1 == true)
					{

						audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip);
						audioManager.GetComponent<SoundManager>().PlayZone(unlockedClip2, audioS);
						SwitchState(State.captured);
					}

					break;
				#endregion
				#region captured
				case State.captured:
					//divineLight.enabled = true;
					if (img1.gameObject.activeSelf == false)
					{
						img1.gameObject.SetActive(true);
					}
					if (playerInZone == true)
					{
						//lockedParticle.Stop();
					}
					else
					{
						lockedParticle.Play();
					}
					audioS.clip = unlockedClip2;
					audioS.Play();

					captured1 = true;
					if (IsPlayerInZone() == true && codeIsRight1 == true && codeIsRight2 == true || captured2 == true || UiManager.GetComponent<Monsters>().GpsEnabled == false && codeIsRight2 == true)
					{

						audioManager.GetComponent<SoundManager>().PlayNarration(capturedClip2);
						hexagon.GetComponent<Renderer>().material = capturedMaterial;
						SwitchState(State.capturedAll);
					}

					break;
				#endregion
				#region capturedAll
				case State.capturedAll:
					if (img2.gameObject.activeSelf == false)
					{
						img2.gameObject.SetActive(true);
					}
					lockedParticle.Stop();
					captured2 = true;


					break;
					#endregion
			}
		}
	}
		void SwitchState(State newState)
		{
			state = newState;
		}
		public bool IsPlayerInZone()
		{
			//determenes if player is located with in the play area 
			bool inZone;

			if (GPS.Instance.latitude >= MLatitude - radius * kmInLat && GPS.Instance.latitude <= MLatitude + radius * kmInLat)
			{
				if (GPS.Instance.longitude >= MLongitude - radius * kmInLong && GPS.Instance.longitude <= MLongitude + radius * kmInLong)
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
		public void Code(string name)
		{
			if (name == monster)
			{
				codeIsRight1 = true;
			}
			else if (name == monster2)
			{
				codeIsRight2 = true;
			}
		}
	}


