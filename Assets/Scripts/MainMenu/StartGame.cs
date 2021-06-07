using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
