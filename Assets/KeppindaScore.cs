using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeppindaScore : MonoBehaviour {

    public float Score = 0;

    public int TotalPancakes = 0;
    public int FallenPancakes = 0;

    public DisplayText dspText;

    public Text scoreText;
    public Text totalText;

    float maxScore;

    public CheckScript checker;

    public Toggle isHardcore;

    public Canvas menu;
    public Canvas gui;

    float finalScore
    {
        get { return Score / (TotalPancakes); }
    }

    void Start()
    {
        gui.enabled = false;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            Screen.lockCursor = true;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gui.enabled = false;
        menu.enabled = true;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gui.enabled = true;
        menu.enabled = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}


    public void AddScore(float score)
    {
        TotalPancakes++;
        //print(Score + " + " + score + " = " + (score + Score));
        Score += score;

        //print(finalScore);
        totalText.text = TotalPancakes.ToString();
        scoreText.text = string.Format("{0:0.0} %", finalScore);

        if (score > 0 && GJAPI.User != null)
        {
            if (!isHardcore.isOn)
                GJAPI.Scores.Add(score + " %", (uint)score);
            else
                GJAPI.Scores.Add(score + " %", (uint)score, 43155);
        }

        if (score >= 100)
            dspText.ShowText(string.Format("Sick air!! {0:0.0} %!", score), Color.red, 40);
        else if(score != 0)
            dspText.ShowText(string.Format("{0:0.0} %!", score), Color.black);

        
        checker.SpawnNewPancake();
    }

}
