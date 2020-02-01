using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInRange : MonoBehaviour
{
    public Vector2 offset = Vector2.zero;
    public float moveTime = 1;
    Vector2 last = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        var pos = Vector2.Lerp(Vector2.zero, offset, Mathf.PingPong(Time.time, 1 * moveTime) * (1 / moveTime));
        var transform = last - pos;
        last = pos;

        this.gameObject.transform.Translate(transform);
    }
}
