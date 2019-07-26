using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TramButton : MonoBehaviour, IVirtualButtonEventHandler
{
	GameObject vbBtnObj;
	public GameObject UiMan;
	public GameObject TramStops;
	// Start is called before the first frame update
	void Start()
	{
		vbBtnObj = GameObject.Find("TramBtn");
		vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

		TramStops.SetActive(false);
	}
	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		TramStops.SetActive(true);
	}
	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		TramStops.SetActive(false);
	}

	// Update is called once per fr
}
