using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManager : MonoBehaviour
{
	public string[] monstersCaught;
	int i = 0;
	string json;
	public float time;
	bool deleteJson;
    // Start is called before the first frame update
    void Start()
    {
    }
	private void Awake()
	{
		if (File.Exists(Application.persistentDataPath+ "/jsondata.txt") == true)
		{
			json = File.ReadAllText(Application.persistentDataPath + "/jsondata.txt");
			JsonUtility.FromJsonOverwrite(json, this);
		}
		print(json);
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		if (i < 5)
		{
			print(time);
			time += Time.deltaTime;
		}
		
    }
	private void OnApplicationQuit()
	{
		json = JsonUtility.ToJson(this);
		if (File.Exists(Application.persistentDataPath + "/jsondata.txt") == false)
		{
			File.Create(Application.persistentDataPath + "/jsondata.txt");
		}
		else if(File.Exists(Application.persistentDataPath + "/jsondata.txt") == true)
		{
			File.WriteAllText(Application.persistentDataPath + "/jsondata.txt", json);
		}
		else {print("JsonNotworkingbruh");}

	}
	public void Caught(string monster) {
		monstersCaught[i] = monster;
		i++;
	}
	public void DeleteJson() {
		System.Array.Clear(monstersCaught, 0, monstersCaught.Length);
		i = 0;
		time = 0;
		deleteJson = true;
	}
}
