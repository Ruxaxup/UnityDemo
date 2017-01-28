using UnityEngine;
using System.Collections;

public class DeadZoneController : MonoBehaviour {
    private Transform playerPosition;
    public GameObject timeController;
	// Use this for initialization
	void Start () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerPosition.position.x,transform.position.y, transform.position.z);
	}

    void OnTriggerEnter(Collider other)
    {
        playerPosition.position = new Vector3(0,0,0);
        timeController.GetComponent<TimeText>().ResetTime();
    }

}
