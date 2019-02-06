using UnityEngine;
using System.Collections;

public class MovingWalls2 : MonoBehaviour

{
    private Vector3 pos3 = new Vector3(-4.73f, 0.5f, 1.47f);
    private Vector3 pos4 = new Vector3(1.5f, 0.5f, 1.47f);
    public float speed1 = 1.0f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos3, pos4, Mathf.PingPong(Time.time * speed1, 1.0f));
    }
}
