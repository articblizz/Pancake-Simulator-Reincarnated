using System.Collections;
using UnityEngine;

public class StekaPannkakor : MonoBehaviour {

    ParticleSystem particle;

    void Start()
    {
        particle = GetComponentInChildren <ParticleSystem>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Pancake")
        {
            particle.Play();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Pancake")
        {
            particle.Stop();
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (Time.timeScale == 0)
            return;
        if (col.gameObject.tag == "Pancake")
        {

            object[] parameters = new object[2];
            parameters[1] = gameObject;
            if (col.transform.up.y <= 0)
            {
                parameters[0] = "top";

                col.gameObject.SendMessage("Stek", parameters);
            }
            else
            {
                parameters[0] = "bot";
                col.gameObject.SendMessage("Stek", parameters);
            }

            if (Input.GetMouseButtonDown(0))
            {
                GameObject.Find("ScoreSystem").GetComponent<KeppindaScore>().AddScore(col.gameObject.GetComponent<Pannkakan>().Score / 2);
                col.gameObject.GetComponent<Pannkakan>().Score = 0;

                Destroy(col.gameObject);
            }
        }
    }


}
