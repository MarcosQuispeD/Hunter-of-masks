using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;
    public Text itemText;
    public int itemsBonus;


    void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddItems()
    {
        itemsBonus += 1;
        itemText.text = itemsBonus.ToString();
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
