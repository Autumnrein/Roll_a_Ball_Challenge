using UnityEngine;
using System.Collections;

public class MovingWalls : MonoBehaviour
     
{
    private Vector3 pos1 = new Vector3(4.73f, 0.5f, -1.3f);
    private Vector3 pos2 = new Vector3(-1.5f, 0.5f, -1.3f);
    public float speed = 1.0f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}

