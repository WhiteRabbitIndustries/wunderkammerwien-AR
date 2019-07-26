using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UptadeGPSText : MonoBehaviour
{
	public Text GPSCoordinates;
   
    // Update is called once per frame
    void Update()
    {
		GPSCoordinates.text = GPS.Instance.latitude.ToString()+ " , " + GPS.Instance.longitude.ToString(); 
    }
}
