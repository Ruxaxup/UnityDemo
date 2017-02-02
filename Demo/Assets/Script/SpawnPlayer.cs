using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
    public GameObject playerPrefab;
	// Use this for initialization
	void Start () {
        Instantiate(playerPrefab, transform.position, transform.rotation);
	}
	
	
}
