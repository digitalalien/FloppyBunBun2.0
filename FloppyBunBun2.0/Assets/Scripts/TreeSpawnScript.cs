using UnityEngine;
using System.Collections;

public class TreeSpawnScript : MonoBehaviour {

	public GameObject treePrefab;
	public int treePoolSize = 5; //How many trees to keep on standby
	public float spawnRate = 3f; //How quickly trees spawn
	public float treeMinY = -1f; //minimum y value of tree
	public float treeMaxY = 3.5f; //maximum y value of the tree

	GameObject[] trees; //collection of pooled trees
	int currentTree = 0; //index of the current tree in the collection

	// Use this for initialization
	void Start () {
		//initialize tree collection
		trees = new GameObject[treePoolSize];
		//loop through the collection and create individual trees
		for (int i = 0; i < treePoolSize; i++) {
			trees[i] = (GameObject)Instantiate(treePrefab);
		}
		StartCoroutine ("SpawnLoop");
	}

	public void StopSpawn()
	{
		//stops spawning function
		StopCoroutine ("SpawnLoop");
	}

	//this is a co-routine that manages tree spawning
	IEnumerator SpawnLoop()
	{
		while (true) {
			//to spawn a tree first get the current spawner position
			Vector3 pos = transform.position;
			//set random y position
			pos.y = Random.Range(treeMinY, treeMaxY);
			//set current column to position
			trees[currentTree].transform.position = pos;

			//increase the value of currentTree. If too big set back to 0
			if(++currentTree >= treePoolSize){
				currentTree = 0;
			}
			//leave co routine until spawn rat has elapsed
			yield return new WaitForSeconds(spawnRate);
		}
	}
}
