using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject BloodSplash;
    public bool isLog;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.x >15 || transform.position.x < -15)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerMovement>() != null && !isLog)
        {
            Instantiate(BloodSplash, collision.collider.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
