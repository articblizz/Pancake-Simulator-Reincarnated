using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour {

    public Text fallenNumber;

    public GameObject Pancake;

    public float MaxX;

    public Toggle isHardcore;
    public GameObject easyPancake;

    void Start () {

        SpawnNewPancake();
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void SpawnNewPancake()
    {
        if (isHardcore.isOn)
        {
            Instantiate(easyPancake, new Vector3(GetRandomZ(), 7f), Quaternion.Euler(new Vector3(5, 0, 0)));
        }
        else
            Instantiate(Pancake, new Vector3(GetRandomZ(), 7f), Quaternion.Euler(new Vector3(5,0,0)));
    }

    float GetRandomZ()
    {
        return Random.Range(-MaxX, MaxX);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PancakeTrigger")
        {
            Destroy(col.gameObject.transform.parent.gameObject);
            GameObject.Find("ScoreSystem").GetComponent<KeppindaScore>().AddScore(0);
        }
    }
}
