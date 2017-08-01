using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour {

    public float moveSpeed = 5;
    private HeadMove head;
    private Transform body;
    private snake m_snake;

    void Start()
    {
        head = GetComponent<HeadMove>();
        body = this.GetComponent<Transform>();
        m_snake.body = GetComponent<GameObject>();
    }

    void Update()
    {
        /*
        if(Vector3.Distance(head.oldPosition,body.position) >= 2)
            body.Translate(Vector3.Normalize(transform.position - head.oldPosition) * Time.deltaTime * moveSpeed);*/
        if (head.isCreate == true && m_snake.nextbody == null)
        {
            m_snake.nextbody = head.snakebody;
        }
        if (m_snake.nextbody != null)
        {
            if (Vector3.Distance(m_snake.body.transform.position, m_snake.nextbody.transform.position) >= 2)
            {
                m_snake.nextbody.transform.Translate(Vector3.Normalize(m_snake.nextbody.transform.position - m_snake.body.transform.position) * Time.deltaTime * moveSpeed);
            }
        }

    }
}
