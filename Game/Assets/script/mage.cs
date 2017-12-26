using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mage : MonoBehaviour {
    private Vector3 position;
    public experiense experiense;

    // Use this for initialization
    void Start () {
		
	}
    private void OnDestroy()
    {
        Instantiate(experiense, position, transform.rotation);
    }

    // Update is called once per frame
    private void Update()
    {
        position = transform.position;
        position = new Vector3(transform.position.x, transform.position.y + 1f);
    }
}
