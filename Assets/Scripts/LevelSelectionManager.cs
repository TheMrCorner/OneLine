﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    public GameManager instance;
    public CanvasManager canvas;

    public Button levelButton;

    Button [,] levels;

    string title;
    int numLevels = 100;
    int sizeX = 5;
    int sizeY;

    // Start is called before the first frame update
    void Start()
    {
        sizeY = numLevels / sizeX;

        levels = new Button[sizeX, sizeY];

        LoadLevelsSelector();

        title = instance.GetCurrentDifficulty();
        canvas.SetTitleText(title);
    }

    void LoadLevelsSelector()
    {

        GameObject panel = canvas.gameObject.transform.GetChild(0).gameObject;
     
        int cont = 0;
        int completeLevels = 25;

        for (int j = 0; j < sizeY; j++)
        {
            for (int i = 0; i < sizeX; i++)
            {
                Vector3 position = new Vector3((panel.transform.position.x - ((sizeX / 2)*110)) + (i*110),
                    ((panel.transform.position.y + ((sizeY / 2)*110)) - (j*110)), -1);


                // Instantiate GameObjects
                levels[i, j] = Instantiate(levelButton, new Vector3(0, 0, 0), Quaternion.identity);

                // Attacht them to parents
                levels[i, j].transform.SetParent(panel.transform);

                levels[i, j].transform.position = position;

                string number = "";
                if (cont < 10) number = "00" + (cont + 1).ToString();
                else if (cont >= 10 && cont < 100) number = "0" + (cont + 1).ToString();

                levels[i, j].transform.GetChild(1).GetComponent<Text>().text = number;

                if ( cont > completeLevels)
                {
                    levels[i, j].interactable = false;
                    levels[i, j].transform.GetChild(0).gameObject.SetActive(false);
                    levels[i, j].transform.GetChild(1).gameObject.SetActive(false);
                }

                cont++;

            }
        }

       

    }

}