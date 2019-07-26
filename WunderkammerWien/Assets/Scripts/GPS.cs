using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GPS : MonoBehaviour
{
	public static GPS Instance { get; set; }

	public float latitude;
	public float longitude;
	//public Text txt;

    // Start is called before the first frame update
    void Start()
    {
		Input.location.Start();
		Instance = this;
		DontDestroyOnLoad(gameObject);
		StartCoroutine(StartLocationService());
		
    }

	private IEnumerator StartLocationService()
	{
		if (!Input.location.isEnabledByUser)
		{
			print("GPS Signal is disabled");
			yield break;
		}

		Input.location.Start();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		if (maxWait <= 0)
		{
			Debug.Log("Timed OUT");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.Log("Unable to Find LOCATION");
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.latitude;

		yield break;
	}
	
	// Update is called once per frame
	void Update()
    {
		if (Input.location.status != LocationServiceStatus.Failed)
		{
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
		}
		else { Debug.Log("GPS Tracking Failed"); }

    }
}
