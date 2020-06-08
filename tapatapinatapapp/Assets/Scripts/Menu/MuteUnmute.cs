using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour
{
    private bool muted = false;
    public Sprite MuteImage;
    public Sprite UnmuteImage;
    public Image image;
    void Start () {

    }
    public void ChangeMute () {
    	Debug.Log("Speaker pressed");
    	if(!muted) {
    		 AudioListener.volume = 0;
    		 muted = true;
             image.sprite = MuteImage;
    	} else {
    		 AudioListener.volume = 1;
    		 muted = false;
             image.sprite = UnmuteImage;
    	}
    }
}
