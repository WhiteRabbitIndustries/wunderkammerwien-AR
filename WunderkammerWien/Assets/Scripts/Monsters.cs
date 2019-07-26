using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : MonoBehaviour
{
	private string inputS;
	public InputField inputF;
	public Text txt;
	private string monster;
	public Image img;
	public bool isActive;
	public GameObject Zone1;
	public Button enter;
	public bool GpsEnabled = true;
	public Text buttonText;
	 GameObject jsonManager;
	public GameObject buttons;
	public GameObject Zone3;
	public GameObject Zone4;
	public GameObject Zone5;
	public GameObject Zone6;
	// Start is called before the first frame update
	void Start()
    {
		jsonManager = FindObjectOfType<JsonManager>().gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
		if (isActive == true)
		{
			txt.enabled = true;
			inputF.gameObject.SetActive(true);
			img.gameObject.SetActive(true);
			buttons.SetActive(true);
			if (inputF.isFocused == false && inputF.text != ""||inputF.isFocused == true && Input.GetKeyDown(KeyCode.Return))
			{
				inputS = inputF.text.ToLower();
				inputF.text = "";
				print(inputS);
				
				if (inputS == "wwadler")
				{
					
					print("adler");
					monster = "Adler";
					Zone1.GetComponent<TwoZones>().Code(monster);
					if (GpsEnabled == true)
					{
						
						if (Zone1.GetComponent<TwoZones>().IsPlayerInZone() == true)
						{
							txt.text = "Das Doppelköpfige Biest";
							jsonManager.GetComponent<JsonManager>().Caught(monster);
						}
						else
						{
							txt.text = "You have to be in Zone 1&2 to unlock this Monster";
						}
					}
					else { txt.text = "Das Doppelköpfige Biest";
						jsonManager.GetComponent<JsonManager>().Caught(monster);
					}
				}
				else if (inputS == "wwsldat")
				{

					
					print("Soldat");
					monster = "Soldat";
					Zone1.GetComponent<TwoZones>().Code(monster);
					if (GpsEnabled == true)
					{

						if (Zone1.GetComponent<TwoZones>().IsPlayerInZone() == true)
						{
							jsonManager.GetComponent<JsonManager>().Caught(monster);
							txt.text = "Fratze der Vergangenheit";
						}
						else
						{
							txt.text = "You have to be in Zone 1&2 to unlock this Monster";
						}
					}
					else {
						txt.text = "Fratze der Vergangenheit";
						jsonManager.GetComponent<JsonManager>().Caught(monster);
					}
				}
				else if (inputS == "wwslnge")
				{

					
					print("Schlange");
					monster = "Schlange";
			
					Zone3.GetComponent<Zones>().Code(monster);
					if (GpsEnabled == true)
					{
						if (Zone3.GetComponent<Zones>().IsPlayerInZone() == true)
						{
							txt.text = "Acheloos der Flussgott";
							jsonManager.GetComponent<JsonManager>().Caught(monster);
						}
						else
						{
							txt.text = "You have to be at location 3 to unlock this Monster";
						}
					}
					else {
						txt.text = "Acheloos der Flussgott";
						jsonManager.GetComponent<JsonManager>().Caught(monster);
					}
				}
				else if (inputS == "wwrtter")
				{
					txt.text = "Der Tapfere Krieger";
					print("Ritter");
					monster = "Ritter";
					
					Zone4.GetComponent<Zones>().Code(monster);
					if (GpsEnabled == true)
					{
						if (Zone4.GetComponent<Zones>().IsPlayerInZone() == true)
						{
							txt.text = "Der Tapfere Krieger";
							jsonManager.GetComponent<JsonManager>().Caught(monster);
						}
						else
						{
							txt.text = "You have to be at location 4 to unlock this Monster";
						}
					}
					else {
						txt.text = "Der Tapfere Krieger";
						jsonManager.GetComponent<JsonManager>().Caught(monster);
					}
				}
				else if (inputS == "wwliftt")
				{
					
					print("Lift");
					monster = "Lift";
					
					Zone5.GetComponent<Zones>().Code(monster);
					if (GpsEnabled == true)
					{
						if (Zone5.GetComponent<Zones>().IsPlayerInZone() == true)
						{
							txt.text = "Die Mechanische Schlange";
							jsonManager.GetComponent<JsonManager>().Caught(monster);
						}
						else
						{
							txt.text = "You have to be at location 5 to unlock this Monster";

						}
					}
					else {
						txt.text = "Die Mechanische Schlange";
						jsonManager.GetComponent<JsonManager>().Caught(monster);
					}
				}
				else if (inputS == "wwrpblk")
				{
					
					print("Republik");
					monster = "Republik";
					
					Zone6.GetComponent<Zones>().Code(monster);
					if (GpsEnabled == true)
					{
						if (Zone6.GetComponent<Zones>().IsPlayerInZone() == true)
						{
							txt.text = "Die Kratzbürtsten";
							jsonManager.GetComponent<JsonManager>().Caught(monster);
						}
						else
						{
							txt.text = "You have to be at location 6 to unlock this Monster";

						}
					}
					else {
						txt.text = "Die Kratzbürtsten";
						jsonManager.GetComponent<JsonManager>().Caught(monster);
					}
				}
				else
				{

					txt.text = "404 not found";
					print("Wrong Input");
				}
			}
			
		}
		else
		{
			txt.enabled = false;
			inputF.gameObject.SetActive(false);
			img.gameObject.SetActive(false);
			buttons.SetActive(false);

		}
	}

	public void SwitchState()
	{
		isActive = !isActive;
	}
	public void SwitchGps() {
		GpsEnabled = !GpsEnabled;
		if (GpsEnabled == true) {
			buttonText.text = "GPS enabled";
		}
		else
		{
			buttonText.text = "GPS disabled";
		}
	}
	
	void ButtonPressed()
	{
	}
}
