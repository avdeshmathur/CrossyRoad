using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] public GameObject DieEffect;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Splash");
            Instantiate(DieEffect, collision.gameObject.transform.position, Quaternion.identity);
            gameManager.GameOver();
            Destroy(collision.gameObject);
        }
    }
}
