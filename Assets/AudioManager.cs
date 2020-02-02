using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioPlayerMove;
    public AudioSource audioPlayerGrab;
    public AudioSource audioPlayerJump;

    public void PlayMove()
    {
        audioPlayerMove.pitch = Random.Range(0.4f, 0.7f);
        audioPlayerMove.Play();
    }

    public void MuteMove()
    { 
        audioPlayerMove.Stop();
    }

    public void PlayGrab()
    {
        audioPlayerGrab.Play();
    }

    public void MuteGrab()
    {
        audioPlayerGrab.Stop();
    }

    public void PlayJump()
    {
        audioPlayerJump.Play();
    }

    public void MuteJump()
    {
        audioPlayerJump.Stop();
    }

}
