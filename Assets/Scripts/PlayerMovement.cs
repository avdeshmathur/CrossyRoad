using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    public TerrainGenerator terrainGenerator;

    public TextMeshProUGUI ScoreUI;
    public int Score;

    [SerializeField] private bool IsHopping = false;
    [SerializeField] private GameObject staticMesh;
    [SerializeField] private Animator UIAnim;
    [SerializeField] private TextMeshProUGUI TouchToPlayText;

    private GameManager gameManager;
    private new AudioSource audio;
    private bool GameOver = false;
    private bool FirstTouch = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        audio = GetComponent<AudioSource>();
        Score = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirstTouch = true;
            TouchToPlayText.gameObject.SetActive(false);
            UIAnim.SetTrigger("Start");
        }

        if (!FirstTouch) return;

        ScoreUI.text = "Score: " + Score;

        if ((transform.position.x > 5 || transform.position.x < -5 ) && !GameOver)
        {
            gameManager.GameOver();
            GameOver = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.D) && !IsHopping)
        {                     
            MoveCharacter(new Vector3(1, 0, 0));
            RotateCharacter(new Vector3(0, 90, 0));
        }

        else if (Input.GetKeyDown(KeyCode.W) && !IsHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
            RotateCharacter(new Vector3(0, 0, 0));
            Score++;
        }

        else if (Input.GetKeyDown(KeyCode.A) && !IsHopping)
        {
            MoveCharacter(new Vector3(-1, 0, 0));
            RotateCharacter(new Vector3(0, -90f, 0));
        }
    }

    void MoveCharacter(Vector3 difference)
    {     
        IsHopping = true;
        anim.SetTrigger("Hop");    
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false, transform.position);
        audio.Play();
    }

    void RotateCharacter(Vector3 dir)
    {
        staticMesh.transform.rotation = Quaternion.Euler(dir);
    }

    public void FinishHopping()
    {
        IsHopping = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<MovingObject>() != null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.SetParent(collision.collider.transform);
            }
        }

        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovingObject>() != null)
        {
            other.gameObject.SetActive(false);
        }
    }
}
