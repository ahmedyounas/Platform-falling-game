using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
 
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
      
            Destroy(gameObject);
        }
    }
}
