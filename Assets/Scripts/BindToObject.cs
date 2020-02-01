using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindToObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(this.gameObject.transform);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
