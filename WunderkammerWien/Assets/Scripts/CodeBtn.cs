using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CodeBtn : MonoBehaviour, IVirtualButtonEventHandler
{
	public GameObject vbBtnObj;
	public GameObject UiMan;
    // Start is called before the first frame update
    void Start()
    {
		vbBtnObj = GameObject.Find("CodeBtn");
		vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        

	}
	public void OnButtonPressed(VirtualButtonBehaviour vb) {
		print("Button pressed");
		UiMan.GetComponent<Monsters>().SwitchState();

	}
	public void OnButtonReleased(VirtualButtonBehaviour vb) {
		print("Button released");
	}

    // Update is called once per frame
    void Update()
    {
       
    }
}
