using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using E7.Introloop;

public class IntroLoop : MonoBehaviour
{
    public IntroloopAudio myIntroloopAudio;

    void Start()
    {
        IntroloopPlayer.Instance.Play(myIntroloopAudio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
