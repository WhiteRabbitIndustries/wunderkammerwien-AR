using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class DisplayGps : MonoBehaviour
{
	float longitude;
	float latitude;
	/*float xPixel = 3075;
	float yPixel = 2416;	
	Vector2 a;
	Vector2 b;
	Vector2 c;
	Vector2 d;
	*/
	public GameObject map;
	Vector3 location;
	float width;
	float height;
	float maxDistanceFromcenterX = 0.49636f;
	float maxDistanceFromcenterZ = 0.39011f;
	float minDistanceFromcenterX = -0.49636f;
	float minDistanceFromcenterZ = -0.39011f;
	//public GameObject cylinder;
	public Vector3 pos;
	float waitRequest;
	public float waitTime;
	private Vector3 middle = new Vector3(48.211111f, 16.369611f);
	private Vector3 coordinates;
		// Start is called before the first frame update
	void Start()
    {
		
		location = new Vector3(latitude, 0,longitude);
		#region unnessesary
		/*a = new Vector2(48.219197f, 16.386503f);
		b = new Vector2(48.219100f, 16.353474f);
		c = new Vector2(48.202341f, 16.386224f);
		d = new Vector2(48.202307f, 16.353630f);
		width = Vector2.Distance(a, b);
		height = Vector2.Distance(c, d);
		*/
		#endregion
	}
	int counter = 0;
    // Update is called once per frame
    void Update()
    {
		longitude = GPS.Instance.longitude;
		latitude = GPS.Instance.latitude;

		coordinates = new Vector3(longitude, latitude);
		if (waitRequest <= Time.time)
		{
			pos = TranslateGpsToGameUnits();
			waitRequest = Time.time + waitTime;
			UpdatePos();
			counter++;
			print(counter + " " + waitRequest);
		}
	}
	Vector3 TranslateGpsToGameUnits() {
		//translates gps data to units in relation to the map (center of map = 0,0,0)
		Vector3 inGameLocation;

		//inGameLocation = (coordinates - new Vector3(48.210615f, 16.369957f));

	    float inGameLatitude;
		float inGamelongitude;

		inGameLatitude =( latitude - 48.210615f) / 0.0216477403809182f  ;
		inGamelongitude = (longitude - 16.369957f  ) / 0.034887932503835f;

		inGameLocation = new Vector3(inGamelongitude, 0, inGameLatitude);
		print (inGameLocation + " " +coordinates);
		


		return inGameLocation;

	}
	private void UpdatePos()
	{
		//updates position, if the position is outside of the map it gets set to the border.

		if (pos.z > maxDistanceFromcenterZ)
		{
			pos.z = maxDistanceFromcenterZ;
		}
		if (pos.x > maxDistanceFromcenterX)
		{
			pos.x = maxDistanceFromcenterX;
		}
		if (pos.z < minDistanceFromcenterZ)
		{
			pos.z = minDistanceFromcenterZ;
		}
		if (pos.x < minDistanceFromcenterX)
		{
			pos.x = minDistanceFromcenterX;
		}

		transform.localPosition = pos;
		print("position updated");


	}
}
