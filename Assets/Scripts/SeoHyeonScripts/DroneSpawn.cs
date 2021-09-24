using UnityEngine;
using System.Collections;

public class DroneSpawn : MonoBehaviour {
	public GameObject drone;
	public float MIN_TIME = 4;
	public float MAX_TIME = 6;
	// Use this for initialization
	void Start () {
		StartCoroutine("CreateDrone");
	}
	
	IEnumerator CreateDrone()
	{
		while(Application.isPlaying)
		{
			float createTime = Random.Range(MIN_TIME, MAX_TIME);
			yield return new WaitForSeconds(createTime);

			Instantiate(drone, transform.position, Quaternion.identity);
		}
	}
}
