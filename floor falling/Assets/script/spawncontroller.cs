using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncontroller : MonoBehaviour {
    public int maxPlatforms = 20;
    public GameObject platfrom;
    public float horizontalmin= 6.5f;
    public float horizontalmax = 14f;
    public float verticalmin = -6f;
    public float verticalmax = 6f;
    // Use this for initialization
    private Vector2 originPosition;
	void Start () {
        originPosition = transform.position;
        spawn();
	}
	
	// Update is called once per frame
	void spawn () {
		for(int i=0;i<maxPlatforms;i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalmin, horizontalmax), Random.Range(verticalmin, verticalmax));
            Instantiate(platfrom, randomPosition, Quaternion.identity);
            originPosition = randomPosition;

        }
	}
}
