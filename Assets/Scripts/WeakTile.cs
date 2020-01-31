using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakTile : MonoBehaviour
{
    public float SecondsToCollapse;
    public Animator animator;
    public List<MonoBehaviour> scriptsToDisable;
    public List<Collider2D> collidersToDisable;
    bool IsAbused = false;
    bool IsFalling = false;
    float seconds;
    void Update()
    {
        if (IsAbused)
        {
            if (!IsFalling)
            {
                animator.Play("Crumble", 0, seconds / SecondsToCollapse);
                IsFalling = true;
            }
            if (seconds < SecondsToCollapse)
            {
                seconds += Time.deltaTime;
            }
            else
            {
                seconds = SecondsToCollapse;
            }
        }
        else
        {
            if (IsFalling)
            {
                animator.Play("Rest", 0, 0);
                IsFalling = false;
            }
            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
            }
            else
            {
                animator.speed = 1;
                seconds = 0;
            }
        }
    }

    private void OnCrumble()
    {
        foreach (var obj in scriptsToDisable)
        {
            obj.enabled = false;
        }
        foreach (var obj in collidersToDisable)
        {
            obj.enabled = false;
        }
    }

    private void OnRespawn()
    {

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
