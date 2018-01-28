using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    BatteryBehavior camTimer;
    public AudioMixerSnapshot BlueSong, NoSong;
    public AudioMixerSnapshot RedSong;
    public AudioSource greenSong;
    public float transistionTime = 0.02f;
    public float fadeVolume = .5f;


	// Use this for initialization
	void Start () {
        camTimer = GameObject.FindGameObjectWithTag("Player").GetComponent<BatteryBehavior>();
    }
	
	// Update is called once per frame
	void Update () {

        if (AIPatrol.bluePlaying)
        {
            BlueSong.TransitionTo(transistionTime);
        }
        else if (AIPatrol.redPlaying)
        {
            RedSong.TransitionTo(transistionTime);
        }
        else if (AIPatrol.greenPlaying)
        {
            greenSong.volume = Mathf.Lerp(AudioListener.volume, fadeVolume, 3.4f);

            if (camTimer.timerGreen <= 1.5f)
            {
                greenSong.volume = Mathf.Lerp(greenSong.volume, AudioListener.volume, 1.5f);
            }
        }
        else
        {
            greenSong.volume = 1f;
            NoSong.TransitionTo(transistionTime);
            greenSong.spatialBlend = 0;
        }



	}
}
