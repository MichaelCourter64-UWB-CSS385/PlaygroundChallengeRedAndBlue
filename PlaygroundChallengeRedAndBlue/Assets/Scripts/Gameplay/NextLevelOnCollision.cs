using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelOnCollision : MonoBehaviour {
    [SerializeField] string color;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.CompareTo(color) == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
