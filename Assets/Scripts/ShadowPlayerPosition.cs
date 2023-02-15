using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlayerPosition : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    private Queue<Vector3> data;
    private Queue<float> times;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = player.GetComponent<Rigidbody>().position;
        data = new Queue<Vector3>();
        times = new Queue<float>();
    }

    void Update()
    {
        data.Enqueue(player.transform.position);
        times.Enqueue(Time.time);
        while(times.Peek() < Time.time - 2) {
            data.Dequeue();
            times.Dequeue();
        }
        rb.position = data.Peek();
    }
}
