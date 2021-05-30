using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> dusman, siradakiler;
    GameObject anaDusman, skorTablosu, kus;

    int bolum, seviye, index;
    float movementSpeed, test;
    void Start()
    {
        index = RandomSayi(dusman);
        skorTablosu = GameObject.Find("ScoreText");
        anaDusman = Instantiate(dusman[index], new Vector3(transform.position.x, dusman[index].transform.position.y, 1), Quaternion.identity);
        movementSpeed = anaDusman.GetComponent<GroundManager>().movementSpeed;
        bolum = 0;
        seviye = bolum;
        test = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    int RandomSayi(List<GameObject> dusman)
    {
        return Random.Range(0, dusman.Count);
    }
    void Spawn()
    {
        index = RandomSayi(dusman);
        if ((transform.position.x - anaDusman.transform.position.x) > 20 + test)
        {
            test = Random.Range(-10f, 10f);
            bolum = (int)skorTablosu.GetComponent<ScoreManager>().GetScore() / 100;

            if (seviye != bolum)
            {
                SeviyeAtlama();
            }
            GameObject clone;

            if (dusman[index].name == "Kus")
            {
                float rnd = Random.Range(-2.5f, 0f);
                print(rnd);
                clone = Instantiate(dusman[index], new Vector3(transform.position.x, rnd, 1), Quaternion.identity);
            }
            else
            {
                clone = Instantiate(dusman[index], new Vector3(transform.position.x, dusman[index].transform.position.y, 1), Quaternion.identity);
            }

            clone.GetComponent<GroundManager>().movementSpeed = movementSpeed;
            anaDusman = clone;
        }
    }

    void SeviyeAtlama()
    {
        seviye = bolum;
        if (movementSpeed < 50)
        {
            movementSpeed += 1f;
        }
        YeniDusmanEkle();
    }

    void YeniDusmanEkle()
    {
        if (siradakiler.Count != 0)
        {
            dusman.Add(siradakiler[0]);
            siradakiler.RemoveAt(0);
        }
    }
}
