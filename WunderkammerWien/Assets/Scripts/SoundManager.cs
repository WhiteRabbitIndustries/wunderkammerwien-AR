using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
	public AudioSource narrationSource;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void PlayNarration(AudioClip clip) {
		narrationSource.clip = clip;
		if (narrationSource.isPlaying == false)
		{
			narrationSource.PlayOneShot(clip);
		}
	}
	public void PlayZone(AudioClip zClip,AudioSource zSource) {
		zSource.clip = zClip;
		if (narrationSource.isPlaying == false)
		{
			zSource.PlayOneShot(zClip);
		}

	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
