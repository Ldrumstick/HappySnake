using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFood : MonoBehaviour {

    public GameObject food;
    public float timer = 10;
    private float time = 0;

	void Start () {
        //Invoke("Create", 0.1f);
        //InvokeRepeating("Create", 1, timer);
	}
	
	
	void Update () {
		
	}

    public void Create()
    {
        float x = Random.Range(-48, 48);
        float z = Random.Range(-48, 48);
        Instantiate(food, new Vector3(x, 1, z), Quaternion.identity);
    }
}
