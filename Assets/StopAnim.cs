using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class StopAnim : MonoBehaviour
{

    [SerializeField]
    GameObject playerControl;

    PlayableDirector playableDirector;
    private float lastTime;

    void Start() {
        playableDirector = playerControl.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update() {
        //if (playableDirector.time >= 4f){
         //   playableDirector.Pause();
        //}
    }
}
