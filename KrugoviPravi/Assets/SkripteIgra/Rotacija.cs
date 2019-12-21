using UnityEngine;
using System.Collections;

public class Rotacija : Povezivanje {
    private int TrenutniSkor, Levo;
    public int[] Brzina = new int[6];
    public int[] Brzine = new int[] { 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210 };
    private GameObject[] Objekti = new GameObject[6];
    char Broj;
    public int LevoDesno = 1;
	// Use this for initialization
	void Start () {
        Levo = 1;
        for (int i = 0; i < 6; i++)
        {
            Obj[i] = GameObject.Find("Obj" + (i + 1));
        }
        PocetneBrzine();
	}
	
	// Update is called once per frame
	void Update () {
	    if (VratiNazad && Jednom == true)
        {
            
            /**/
            Jednom = false;
            
            Levo = LevoDesno == 1 ? -1 : 1;
        }
        if (ZaustaviRot == false)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Obj[i].transform.position.x == PozicijaX[i] && Obj[i].transform.position.y == PozicijaY[i]) { }
                else
                {
                    
                    Obj[i].transform.Rotate(new Vector3(0, 0, 1), (Brzina[i] * Levo) * Time.smoothDeltaTime, 0);
                }
            }
        }
        
        if (KrajRotacije)
        {
            PocetneBrzine();
            KrajRotacije = false;
        }
	}

    void PocetneBrzine()
    {
        Brzina[0] = Brzine[(int)Random.Range(1, 4)];
        Brzina[1] = Brzine[(int)Random.Range(0, 4)];
        Brzina[2] = Brzine[(int)Random.Range(0, 4)];
        Brzina[3] = Brzine[(int)Random.Range(1, 4)];
        Brzina[4] = Brzine[(int)Random.Range(0, 4)];
        Brzina[5] = Brzine[(int)Random.Range(0, 4)];
        Levo = 1;
    }

    public void PostaviBrzine(int A, int B)
    {
        {
            Brzina[1] = Brzine[(int)Random.Range(A, B)];
            Brzina[2] = Brzine[(int)Random.Range(A, B)];
            Brzina[4] = Brzine[(int)Random.Range(A, B)];
            Brzina[5] = Brzine[(int)Random.Range(A, B)];
        }
    }
}
