using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakTile : MonoBehaviour
{
    public float SecondsToCollapse;
    public Animator animator;
    bool IsAbused = false;
    bool IsFalling = false;
    float seconds;
    void Update()
    {
        if (IsAbused)
        {
            if (!IsFalling) animator.Play("Crumble", 0, seconds / SecondsToCollapse);
            if (seconds < SecondsToCollapse)
            {
                seconds += Time.deltaTime;
            }
            else
            {
                animator.speed = (float)1 / SecondsToCollapse;
                seconds = SecondsToCollapse;
                IsFalling = true;
            }
        }
        else
        {
            if (IsFalling) animator.Play("Rest");
            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
            }
            else
            {
                animator.speed = 1;
                seconds = 0;
                IsFalling = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IsAbused = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsAbused = false;
    }
}
