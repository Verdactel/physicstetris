using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class THEGAME : MonoBehaviour
{
    [SerializeField] List<Shape> shapes = new List<Shape>();
    [SerializeField] new AudioSource audio;
    [SerializeField] GameObject pausePanel = null;
    [SerializeField] GameObject gameoverPanel = null;
    [SerializeField] GameObject statsPanel = null;
    [SerializeField] Text scoreText = null;
    [SerializeField] Text finalscoreText = null;

    public Shape currentShape = null;
    public Shape nextShape = null;
    public int score = 0;
    private Rigidbody rb = null;

    public List<Shape> allShapes = new List<Shape>();

    private Vector3 currentShapeSpawn = new Vector3(1, 14.5f, -10);
    private Vector3 nextShapeSpawn = new Vector3(21, 8.5f, -10);
    private void Start()
    {
        score = 0;
        audio.Play();
        gameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        statsPanel.SetActive(true);
        Time.timeScale = 1;

        currentShape = Instantiate(shapes[Random.Range(0, shapes.Count)], currentShapeSpawn, Quaternion.identity);
        nextShape = Instantiate(shapes[Random.Range(0, shapes.Count)], nextShapeSpawn, Quaternion.identity);
        allShapes.Add(currentShape);
    }
    void Update()
    {
        scoreText.text = score.ToString("D5");
        if (currentShape != null && currentShape.m_collided == true)
        {
            if (currentShape.m_gameover == true)
            {
                Time.timeScale = 0;
                gameoverPanel.SetActive(true);
                statsPanel.SetActive(false);
                finalscoreText.text = score.ToString("D5");
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
            else
            {
                currentShape = null;
            }
        }

        if (currentShape == null)
        {
            currentShape = Instantiate(nextShape, currentShapeSpawn, Quaternion.identity);
            Destroy(nextShape.gameObject);
            while((nextShape = Instantiate(shapes[Random.Range(0, shapes.Count)], nextShapeSpawn, Quaternion.identity)) == currentShape)
            {
                Destroy(nextShape.gameObject);
            }
            allShapes.Add(currentShape);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (Shape shape in allShapes)
            {
                Destroy(shape.gameObject);
            }
            allShapes.Clear();
            currentShape = null;
            Destroy(nextShape.gameObject);
            nextShape = Instantiate(shapes[Random.Range(0, shapes.Count)], nextShapeSpawn, Quaternion.identity);
            score = 0;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb = currentShape.GetComponent<Rigidbody>();
            rb.AddForce(-10, 0, 0, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb = currentShape.GetComponent<Rigidbody>();
            rb.AddForce(10, 0, 0, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb = currentShape.GetComponent<Rigidbody>();
            rb.AddTorque(transform.forward * 4 * -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb = currentShape.GetComponent<Rigidbody>();
            rb.AddTorque(transform.forward * 4);
        }
    }

    private void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);

        }
        else if (Time.timeScale == 0)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
