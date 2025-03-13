using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    float speed = 0.6f;

    RectTransform m_RectTransform;
    // Start is called before the first frame update
    public void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            speed = 2.0f;
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            speed = 0.6f;
        }

        m_RectTransform.anchoredPosition = new Vector2(m_RectTransform.anchoredPosition.x,m_RectTransform.anchoredPosition.y+speed);
    }
}
