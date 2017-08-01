using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct snake
{
    public GameObject body;
    public GameObject nextbody;
}
public class HeadMove : MonoBehaviour {

    public float moveSpeed = 5;
    public Vector3 oldPosition;
    public GameObject snakebody;
    public bool isCreate = false;

    void Start()
    {
        oldPosition = transform.position;
    }

    void Update()
    {


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * moveSpeed);
        if (Vector3.Distance(oldPosition, transform.position) >= 2)
        {
            oldPosition = transform.position;
        }

        if(Input.GetMouseButtonDown(0))
        {
            //Instantiate(body, head.oldPosition, Quaternion.identity);
            Instantiate(snakebody, oldPosition, Quaternion.identity);
            isCreate = true;
        }
        isCreate = false;   
    }
}
