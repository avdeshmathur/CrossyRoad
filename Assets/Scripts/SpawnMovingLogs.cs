using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovingLogs : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float minSeprationTime;
    [SerializeField] private float maxSeprationTime;
    [SerializeField] private bool IsRightSide;
 
    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeprationTime, maxSeprationTime));

            GameObject obj = LogPooling.SharedInstance.GetPooledObject();
            if (obj != null)
            {

                obj.transform.position = spawnPoint.transform.position;
                obj.transform.rotation = spawnPoint.transform.rotation;
                obj.SetActive(true);
            }
        }
    }
}
