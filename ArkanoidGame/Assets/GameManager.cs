using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public Text livesText;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;
    public GameObject loadLevelPanel;

        // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfBricks = GameObject.FindGameObjectsWithTag("Block").Length;
    

        if (numberOfBricks == 0)
        {
             SceneManager.LoadScene("Level2");
        }
     
          

    }
        public void UpdateLives(int changeInLives)
        {
            lives += changeInLives;

            //sprawdza 

            livesText.text = "Lives: " + lives;
        }

        public void UpdateNumberOfBricks(int changeInLives)
        {
            numberOfBricks--;
        }

    void LoadLevel()
    {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("Block").Length;
        SceneManager.LoadScene("Level2");
        //loadLevelPanel.SetActive(false);
    }
}
