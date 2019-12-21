using UnityEngine;
using System.Collections;

public class Igrac : Povezivanje {
    AudioSource Audio;
    internal bool Pritisnut = false;
    internal float Vreme = 1.5f;
    void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Pritisnut == true)
        {
            Vreme -= Time.deltaTime;
            if (Vreme <= 0)
            {
                Pritisnut = false;
                Vreme = 1.5f;
            }
        }
	    if (Input.GetKeyDown(KeyCode.Escape) && Pritisnut == false)
        {
            Pritisnut = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Pritisnut == true)
        {
            Application.Quit();
        }
	}

    void OnCollisionEnter2D(Collision2D Col)
    {
        if ((Col.gameObject.tag == "Prepreke" || Col.gameObject.tag == "Ivica") && VratiNazad == false)
        {
            MozePoceti = false;
            Kraj = true;
            Audio.Play();
        }
    }
}
