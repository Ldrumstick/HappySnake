using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour {

    public float moveSpeed = 5;
    public GameObject bodyGameObject;
    public GameObject gameOver;
    List<Transform> body = new List<Transform>();
    private bool flag = false;
    private bool isOne = false;  //用于避免一次生成两个
    private CreatFood cFood;
    

	void Start () {
        //InvokeRepeating("Eatting", 0.5f, 0.1f);
        cFood = GetComponent<CreatFood>();
        cFood.Create();
	}
	

	void Update () {
        Move();
        Eatting();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (-moveSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * (-moveSpeed));
        }
    }
    void Eatting()
    {
        Vector3 oldPos = transform.position;
        if (flag)
        {
            GameObject bodyPrefab = Instantiate(bodyGameObject, oldPos, Quaternion.identity);
            body.Insert(0, bodyPrefab.transform);
            flag = false;
        }
        else if (body.Count > 0)
        {
            if ((body.First().position - oldPos).magnitude > 1)
            {
                body.Last().position = oldPos;
                body.Insert(0, body.Last());
                body.RemoveAt(body.Count - 1);
            }
                
            
            
        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
                Destroy(other.gameObject);
                cFood.Create();
                flag = true;
            
        }
        else if(other.gameObject.tag != "Floor")
        {
            gameOver.SetActive(true);
        }
    }

}
