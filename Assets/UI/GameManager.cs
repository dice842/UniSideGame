using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOverSprite;
    public Sprite gameClearSprite;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image titleImage;

    public GameObject timeber;
    public GameObject timeText;
    TimeController timeController;

    private void Start()
    {
        timeController = GetComponent<TimeController>();
        if (timeController != null)
        {
            if (timeController.gameTime == 0f)
            {
                timeber.SetActive(false);
            }
        }
        Invoke("Inactivelmage", 0.5f);
        panel.SetActive(false);
    }
    private void Update()
    {
        if (PlayerController.gamestate == "gameover")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);
            nextButton.GetComponent<Button>().interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            PlayerController.gamestate = "gameend";


            if (timeController != null)
            {
                timeber.SetActive(false);
            }
        }
        else if (PlayerController.gamestate == "gameclear")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);
            restartButton.GetComponent<Button>().interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            PlayerController.gamestate = "gameend";

            if (timeController != null)
            {
                timeber.SetActive(false);
            }
        }
        else if (PlayerController.gamestate == "playing")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();

            if (timeController != null)
            {
                if (timeController.displayTime > 0f)
                {
                    int time = (int)timeController.displayTime;

                    timeText.GetComponent<Text>().text = $"{time}";

                    if (time == 0)
                    {
                        playerController.Dead();
                    }
                }
            }

        }
    }
    void Inactivelmage()
    {
        mainImage.SetActive(false);
    }
}
