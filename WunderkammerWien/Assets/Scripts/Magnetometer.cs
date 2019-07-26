using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Magnetometer : MonoBehaviour
{
	public float offset;
	public Text txt;
	public GameObject dot;
	public float compassHeading;
	//float smoothHeading;
float[] compass = new float[10];
	int i;
	//float sum;
	float CurrentRotation;
	// Start is called before the first frame update
	void Start()
	{

		Input.compass.enabled = true;

		Input.gyro.enabled = true;
	}

    // Update is called once per frame
    void Update()
    {
		//compass[i] = Input.compass.trueHeading;
	//	i++;
	//	if (i == compass.Length) { i = 0; }
		/*for (int i = 0; i < compass.Length; i++)
		{
			sum += compass[i];
		}*/
	//	smoothHeading = compass.Sum()/ compass.Length;
		//still not 100% true 
		float rotDiff = (Input.compass.trueHeading - dot.transform.localRotation.y);
		while (rotDiff < 180)
			rotDiff += 360;
		while (rotDiff > 180)
			rotDiff -= 360;
		CurrentRotation = rotDiff ;
		dot.transform.localRotation = Quaternion.RotateTowards(dot.transform.localRotation,Quaternion.Euler(0, CurrentRotation +offset, 0),30+Time.deltaTime).normalized;
/*
		transform.rotation = Quaternion.Euler(0, 0, CurrentRotation);
		var desiredRot	= Quaternion.Euler(0, smoothHeading+offset, 0);
		dot.transform.localRotation = Quaternion.Lerp(dot.transform.rotation, desiredRot, Time.deltaTime * 10);
		Vector3 forwardVector = (smoothHeading + offset) * Vector3.forward;
		float radianAngle = Mathf.Atan2(forwardVector.z, forwardVector.x);
		float degreeAngle = radianAngle * Mathf.Rad2Deg;
		*/
		//dot.transform.localRotation = Quaternion.Euler(0, degreeAngle,0);
		print(dot.transform.localRotation);
		txt.text = Input.compass.trueHeading + "   " + Input.compass.magneticHeading + "    ";//+ smoothHeading + "  ";//+ degreeAngle;

	}
}
