using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakTile : MonoBehaviour
{
    public float SecondsToCollapse;
    public float TimeToRespawn;
    public Animator animator;
    public List<MonoBehaviour> scriptsToDisable;
    public List<Collider2D> collidersToDisable;
    bool IsAbused = false;
    bool IsFalling = false;
    bool Crumbled = false;
    float crumbleTime;
    float respawnTime;
    void Update()
    {
        if (IsAbused)
        {
            if (!IsFalling)
            {
                animator.Play("Crumble", 0, crumbleTime / SecondsToCollapse);
                IsFalling = true;
            }
            if (crumbleTime < SecondsToCollapse)
            {
                crumbleTime += Time.deltaTime;
            }
            else
            {
                crumbleTime = SecondsToCollapse;
            }
        }
        else
        {
            if (IsFalling)
            {
                animator.Play("Rest", 0, 0);
                IsFalling = false;
            }
            if (crumbleTime > 0)
            {
                crumbleTime -= Time.deltaTime;
            }
            else
            {
                animator.speed = 1;
                crumbleTime = 0;
            }
        }
        if (Crumbled)
        {
            respawnTime += Time.deltaTime;
            if (respawnTime > TimeToRespawn)
            {
                OnRespawn();
                respawnTime = 0;
            }
        }
    }

    private void OnCrumble()
    {
        crumbleTime = 0;
        IsAbused = false;
        Crumbled = true;
        SetEnabled(false);
    }

    private void OnRespawn()
    {
        SetEnabled(true);
        Crumbled = false;
    }

    private void SetEnabled(bool state)
    {
        foreach (var obj in scriptsToDisable)
        {
            obj.enabled = state;
        }
        foreach (var obj in collidersToDisable)
        {
            obj.enabled = state;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsAbused = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsAbused = false;
    }

}
