using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer fondo;
    public GameObject columna;
    public GameObject piedra1;
    public GameObject piedra2;
    public float velocidad = 2;
    public bool gameOver = false;
    public bool gameStart = false;
    public GameObject menuStart;
    public GameObject menuOver;

    public List<GameObject> columnas;
    public List<GameObject> piedras;

    void Start()
    {
       for (int i=0; i < 21; i++)
        {
            columnas.Add(Instantiate(columna, new Vector2(-10 + i, -3), Quaternion.identity));
        }
        piedras.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
        piedras.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                gameStart = true;
            }
        }
        if (gameStart == true && gameOver == true)
        {
            menuOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        //para que se ejecute en todo
        if (gameStart==true && gameOver == false)
        {
            menuStart.SetActive(false);
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;
            for (int i = 0; i < columnas.Count; i++)
            {
                if (columnas[i].transform.position.x <= -10)
                {
                    columnas[i].transform.position = new Vector3(10, -3, 0);
                }
                columnas[i].transform.position = columnas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
            //para crar piedra
            for (int i = 0; i < piedras.Count; i++)
            {
                if (piedras[i].transform.position.x <= -10)
                {
                    float ran = Random.Range(11, 18);
                    piedras[i].transform.position = new Vector3(ran, -2, 0);
                }

                piedras[i].transform.position = piedras[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}

