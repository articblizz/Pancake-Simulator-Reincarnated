using UnityEngine;
using System.Collections;

public class Pannkakan : MonoBehaviour {

	public GameObject bot;
	public GameObject top;

	GameObject side;
	public float Score = 0;
	public float colorTick; // def -0.001

    float tmpScore;

    float multiplier = 1;

	//float lel = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //print(Score);
        if (Input.GetMouseButtonDown(1))
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

        var pos = Camera.main.transform.position;

        pos = Vector3.MoveTowards(pos, new Vector3(0 , 2.72f, (-transform.position.y / 2) - 10), Vector3.Distance(pos, transform.position));
        //pos.z = (-transform.position.y / 2) - 10;
        if (pos.z >= -10f)
            pos.z = -10f;
        if (pos.z <= -35f)
            pos.z = -35f;

        if (transform.position.y >= 6)
        {
            //print(rigidbody.velocity.y);
            if(GetComponent<Rigidbody>().velocity.y > 0)
                multiplier = transform.position.y / 6;
        }
        Camera.main.transform.position = pos;

        Score = tmpScore * multiplier;
	}

    //public void Stek(string sida, GameObject sender)

	public void Stek(object[] parameters)
	{
        var sida = (string)parameters[0];
        //var sender = (GameObject)parameters[1];
		Color c = new Color();
		
		if (sida == "top")
		{
			c = top.GetComponent<Renderer>().material.color;
			side = top;
		}
		else if (sida == "bot")
		{
			c = bot.GetComponent<Renderer>().material.color;
			side = bot;
		}



        //print(c.b);
		if (c.b <= 0 && tmpScore > 0)
		{
			tmpScore += c.b;
			if (tmpScore <= 0)
				tmpScore = 0;

            c.r += colorTick;
            c.g += colorTick;
            c.b += colorTick;
		}
		else
		{
			tmpScore -= colorTick * 100;

            c.r += colorTick / 10;
            c.g += colorTick / 2;
            c.b += colorTick;
		}

		side.GetComponent<Renderer>().material.color = c;
	}
}
