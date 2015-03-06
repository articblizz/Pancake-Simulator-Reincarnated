using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

    public float TextLength = 2;
    float timer;

    public Text theText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (timer >= TextLength)
        {
            theText.text = "";
            theText.fontSize = 28;
            theText.color = Color.black;

        }
        else
        {
            timer += Time.deltaTime;
        }
	}

    public void ShowText(string text,  Color color, int size = 28)
    {
        theText.color = color;
        theText.fontSize = size;
        theText.text = text;
        timer = 0;
    }
}
