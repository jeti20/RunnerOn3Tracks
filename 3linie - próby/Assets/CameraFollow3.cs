using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow3 : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 5.5f, -5.5f);

    // Start is called before the first frame update
/*    void Start()
    {
        offset = transform.position - player.position;
    }*/

    // Update is called once per frame
    void Update()
    {
        Vector3 targetpos = player.position + offset;
        targetpos.x = 0;
        transform.position = targetpos;
    }
}
