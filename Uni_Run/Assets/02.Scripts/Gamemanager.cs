using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameoverUI;

    private int socre = 0;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {

            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�.");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddScore (int newScore)
    {


    }
    public void OnplayerDead()
    {

    }

}
