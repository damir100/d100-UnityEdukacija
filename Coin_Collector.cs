using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Ovo pišemo kada hoćemo korisiti UI mogućnosti u kodu

public class Coin_Collector : MonoBehaviour
{
    // Broj koliko smo pokupili predmeta
    public int skupljeni_Coinsi;
    //public int skupljeni_Artifakti;

    public Text textCoins;
    //public Text textArtifakti;

    public Text textTime; //// TIME
    //float timeRemaining;
    //float timer = 0.0f;  //// 
    //float timer;  //// time remain
    float timer;
    //float timer = brojCoinsaNaSceni * 45;
    //int seconds;

    public AudioSource zvuk;

    int brojCoinsaNaSceni;
    //int brojArtifekataNaSceni;

    void Start()
    {
        //Traženje objekata na sceni sa tagom "Collectable" i zapisivanje koliko ih ima brojčano (Lenght)
        brojCoinsaNaSceni = GameObject.FindGameObjectsWithTag("Collectable").Length;
        //Pisanje texta na UI => 0/3
        textCoins.text = skupljeni_Coinsi + "/" + brojCoinsaNaSceni;
        //brojCoinsaNaSceni = GameObject.FindGameObjectsWithTag("Artifact").Length;
        //textArtifakti.text = skupljeni_Artifakti + "/" + brojArtifekataNaSceni;

        // textTime.text = "Time left:" + Time.deltaTime; ////TIME
        //textTime.text = "Time left: " + timer;
        //timeRemaining = brojCoinsaNaSceni * 3;
        timer = brojCoinsaNaSceni * 45;
        //seconds = (int)(timer % 60);

        /*int minute = Mathf.FloorToInt(timer / 60f);
        int sekunde = Mathf.FloorToInt(timer - minute * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minute, sekunde);
        textTime.text = "Tim: " + niceTime.ToString(); ////TIME*/

    }

    void OnTriggerEnter(Collider other)
    {
        //Ako objekt ima tag "Collectable" onda tek se izvršava ostatak
        if(other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject); //Uništimo objekt koji pokupimo
            skupljeni_Coinsi++; //Povećaju nam se bodovi za 1
            textCoins.text = skupljeni_Coinsi + "/" + brojCoinsaNaSceni;
            zvuk.Play(); //Efekt da smo pokupili
        }
        /*else if(other.gameObject.tag == "Artifact")
        {
            Destroy(other.gameObject);
            skupljeni_Artifakti++;
            textCoins.text = skupljeni_Artifakti + "/" + brojArtifekataNaSceni;
            zvuk.Play();
        }*/
    }

    void Update()
    {
        //Što da se dogodi kada pokupimo sve coinse i artifekte
        if (skupljeni_Coinsi == brojCoinsaNaSceni) // && skupljeni_Artifakti == brojArtifekataNaSceni)
        {
            //Application.Quit ne radi u Unity nego tek u buildanom proizvodu
            Application.Quit(); //exe. file se ugasi
        }

        //// TIME
        //timer = brojCoinsaNaSceni * 45;
        timer -= Time.deltaTime; ////TIME

        if (timer > 0)
        {

            Debug.Log("GO!");
        }
        else
        {
            Debug.Log("TIME'S UP!");
            timer = 0f;
            Application.Quit();
        }

        //float seconds = timer % 60f;
        //int seconds = timer % 60;
        //var seconds = timer % 60;
        //seconds = timer % 60;
        //seconds = (int)(timer % 60);
        //seconds = Convert.ToInt32(timer % 60);

        int minute = Mathf.FloorToInt(timer / 60f);
        int sekunde = Mathf.FloorToInt(timer - minute * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minute, sekunde);
        textTime.text = "Time left: " + niceTime.ToString(); ////TIME

        //textTime.text = "Tim: " + seconds.ToString(); ////TIME
        //textTime.text = "Tim: " + timer.ToString(); ////TIME
        //Debug.Log(timer);

        
    }
}
