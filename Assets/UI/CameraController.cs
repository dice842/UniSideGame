using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float leftLimit = 0;
    public float rightLimit = 0;

    float x;
    float y;
    float z;

    public GameObject subScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            x = player.transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
        }
        if (x < leftLimit)
        {
            x = leftLimit;
        }
        else if (x > rightLimit)
        {
            x = rightLimit;
        }

        Vector3 vector3 = new Vector3(x, y, z);
        transform.position = vector3;

        if (subScreen != null)
        {
            y = subScreen.transform.position.y;
            z = subScreen.transform.position.z;
            Vector3 v3 = new Vector3(x * 0.5f, y, z);

            subScreen.transform.position = v3;
        }
    }
}
