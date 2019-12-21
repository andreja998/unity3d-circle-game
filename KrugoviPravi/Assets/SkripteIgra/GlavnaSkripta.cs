using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlavnaSkripta : Povezivanje {
	private int i, Tema, SadObj, PrviPut = 0;
	private bool[] KaSredini = new bool[6];
	private int ProsliObj, ObjZaVracanje, Lvl = 0;
	private float Vreme = 1f, Inkrementiranje, Podeok = 0.02f, Trajanje = 0, Trajanje2 = 0, Trajanje3 = 0, Inkrementiranje2 = 0, Inkrementiranje3 = 0;
	private Vector3 NaSredini = new Vector3(0, -6, 0), IgracPoz = new Vector3(0, 7, 0);
	private bool PomeriZaKraj, Pocetak = true, MozeBoja = true, AnimacijaKraj = true, PocetakAnimacija = true, 
				 RotirajDo = false, Kreni = false, StopRot, PocetakAnim = true, Promena = true, SledeciO = false;
	private GameObject Kamera, Igrac;
	public Material Mat1, Mat2;
	public Text Tekst, PocetakTekst, SkorTekst;
	private int[] Lvl1 = new int[] { 0, 1, 3, 4 }, Lvl2 = new int[] { 1, 3, 4, 2 },
				  Lvl3 = new int[] { 1, 3, 4, 5 }, Lvl4 = new int[] { 0, 1, 2, 3, 4, 5 };
	public Camera Kam;
	AudioSource Audio;
	Rotacija rotacija;

	void Awake ()
	{
		
		Audio = GetComponent<AudioSource>();
		//Kam.backgroundColor = Color.blue;
		ZaustaviRot = true;
		KojiObj = ProsliObj = SadObj = 1;
		PocetnaBoja = KojiObj;
		
	}

	// Use this for initialization
	void Start () {
		rotacija = Kam.GetComponent<Rotacija>();
		//Tema = (int)Random.Range(0, 2);
		MozePoceti = false;
		Skor = 0;
		if (PlayerPrefs.HasKey("HighScore"))
		{
			SkorTekst.text = "Highscore\n" + PlayerPrefs.GetInt("HighScore").ToString();
		}
		else
		{
			SkorTekst.text = "Highscore\n0";//.text = "0";
		}
		Tekst.GetComponent<Text>().enabled = false;
		
		KaIgracu = false;
		//PostaviPozicije();
		VratiNazad = false;
		for (i = 0; i < 6; i++)
		{
			//Obj[i] = GameObject.Find("Obj" + (i + 1));
			RotirajObj[i] = false;
		}
		//print(Tema.ToString());
		//Kamera = GameObject.Find("GlavnaKamera");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (MozePoceti)
		{
			if (!KaIgracu)
			{
				Inkrementiranje = 0.04f / 1f;
				Obj[KojiObj].transform.position = new Vector2(Mathf.Lerp(Obj[KojiObj].transform.position.x, 0, Trajanje), Mathf.Lerp(Obj[KojiObj].transform.position.y, -6, Trajanje));
				Trajanje += Inkrementiranje;
				if (MozeBoja)
				{
					BojaIgr = true;
				}
				if (Obj[KojiObj].transform.position.x >= -0.1f && KojiObj == 0)
				{
					Obj[KojiObj].transform.position = new Vector2(0, -6);
					Trajanje = 0;
				}
				if (Obj[KojiObj].transform.position.x <= -0.1f && KojiObj == 1)
				{
					Obj[KojiObj].transform.position = new Vector2(0, -6);
					Trajanje = 0;
				}
				if (Obj[KojiObj].transform.position.y >= -0.1f && KojiObj == 2)
				{
					Obj[KojiObj].transform.position = new Vector2(0, -6);
					Obj[4].GetComponent<PolygonCollider2D>().enabled = true;
					Trajanje = 0;
				}
				if (Obj[KojiObj].transform.position.x >= -0.1f && KojiObj == 3)
				{
					Obj[KojiObj].transform.position = new Vector2(0, -6);
					Trajanje = 0;
				}
				if (Obj[KojiObj].transform.position.y >= -0.1f && KojiObj == 4)
				{
					Obj[KojiObj].transform.position = new Vector2(0, -6);
					Trajanje = 0;
				}
				if (Obj[KojiObj].transform.position.x <= -0.1f && KojiObj == 5)
				{
					Obj[KojiObj].transform.position = new Vector2(0, -6);
					Trajanje = 0;
				}
				if (Obj[KojiObj].transform.position == NaSredini && Promena == true)
				{
					EkranPromeni = true;
					KrajBoje = true;
					Trajanje = 0;
					MozePritisnuti = true;
					Promena = false;
				}
			}
		}
		if (KaIgracu)
		{
			Promena = true;
			Inkrementiranje3 = 0.02f / 1f;
			Obj[KojiObj].transform.position = new Vector2(Mathf.Lerp(Obj[KojiObj].transform.position.x, 0, Trajanje3), Mathf.Lerp(Obj[KojiObj].transform.position.y, 7, Trajanje3));
			Trajanje3 += Inkrementiranje3;
			if (Obj[KojiObj].transform.position.y >= 6.9f)
			{
				Debug.Log("KaIgracu " + KojiObj);
				Skor += 1;
				Audio.Play();
				Tekst.text = Skor.ToString();
				ObjZaVracanje = KojiObj;
				Trajanje3 = 0;
				Obj[KojiObj].transform.position = IgracPoz;
				
				//Promena = true;
				ZaustaviRot = false;
				do
				{
					if (Skor <= 5)
					{
						KojiObj = Lvl1[(int)Random.Range(0, 4)];
					}
					if (Skor > 5 && Skor <= 12)
					{
						KojiObj = Lvl2[(int)Random.Range(0, 4)];
						if (Lvl > 3)
						{
							KojiObj = Lvl1[(int)Random.Range(0, 4)];
						}
						if (KojiObj == 2 && Lvl <= 2 && ProsliObj != 2)
						{
							Lvl++;
							break;
						}
					}
					if (Skor > 12)
					{
						KojiObj = (int)Random.Range(0, 6);
					}
				} while (KojiObj == ProsliObj);
				KaIgracu = false;
				Trajanje = 0;
				ProsliObj = KojiObj;
				PromenaBoje = KojiObj;
				MozePromenaBojeIgraca = true;
				MozePritisnuti = false;
				VratiNazad = true;
				Jednom = true;
			}
		}
		if (VratiNazad)
		{
			Inkrementiranje2 = 0.03f / 1f;
			Obj[ObjZaVracanje].transform.position = new Vector2(Mathf.Lerp(Obj[ObjZaVracanje].transform.position.x, PozicijaX[ObjZaVracanje], Trajanje2), Mathf.Lerp(Obj[ObjZaVracanje].transform.position.y, PozicijaY[ObjZaVracanje], Trajanje2));
			Trajanje2 += Inkrementiranje2;
			KrajBoje = false;
			if (Obj[ObjZaVracanje].transform.position.x <= -39.9f && ObjZaVracanje == 0)
			{
				Obj[ObjZaVracanje].transform.position = new Vector2(-40, 0);
                Rotiraj();
			}
			if (Obj[ObjZaVracanje].transform.position.x >= 39.9f && ObjZaVracanje == 1)
			{
				Obj[ObjZaVracanje].transform.position = new Vector2(40, 0);
                Rotiraj();
            }
			if (Obj[ObjZaVracanje].transform.position.y <= -39.9f && ObjZaVracanje == 2)
			{
				Obj[ObjZaVracanje].transform.position = new Vector2(0, -40);
				Obj[4].GetComponent<PolygonCollider2D>().enabled = true;
                Rotiraj();
            }
			if (Obj[ObjZaVracanje].transform.position.x <= -39.9f && ObjZaVracanje == 3)
			{
				Obj[ObjZaVracanje].transform.position = new Vector2(-40, -40);
                Rotiraj();
            }
			if (Obj[ObjZaVracanje].transform.position.y <= -69.9f && ObjZaVracanje == 4)
			{
				Obj[ObjZaVracanje].transform.position = new Vector2(0, -70);
                Rotiraj();
            }
			if (Obj[ObjZaVracanje].transform.position.x <= -39.8f && ObjZaVracanje == 5)
			{
				Obj[ObjZaVracanje].transform.position = new Vector2(-40, 40);
                Rotiraj();
            }
			if (Obj[ObjZaVracanje].transform.position.x == PozicijaX[ObjZaVracanje] && Obj[ObjZaVracanje].transform.position.y == PozicijaY[ObjZaVracanje])
			{
				PromeniBoju[ObjZaVracanje] = true;
				VratiNazad = false;
				Trajanje2 = 0;
				Vreme = 0;
				//print("Nesto");
			}
		}
		
		if (Kraj)
		{
			//Obj[ObjZaVracanje].transform.position = new Vector2(Mathf.Lerp(Obj[ObjZaVracanje].transform.position.x, PozicijaX[ObjZaVracanje], Vreme), Mathf.Lerp(Obj[ObjZaVracanje].transform.position.y, PozicijaY[ObjZaVracanje], Vreme));
			PomeriZaKraj = true;
			VratiNazad = false;
			
			if (PlayerPrefs.HasKey("HighScore"))
			{
				if (Skor > PlayerPrefs.GetInt("HighScore"))
				{
					PlayerPrefs.SetInt("HighScore", Skor);
					SkorTekst.text = "Highscore\n" + Skor.ToString();
				}
				else if (Skor < PlayerPrefs.GetInt("HighScore"))
				{
					SkorTekst.text = "Highscore\n" + PlayerPrefs.GetInt("HighScore").ToString();
				}
				else if (Skor == PlayerPrefs.GetInt("HighScore"))
				{
					SkorTekst.text = "Highscore\n" + Skor.ToString();
				}
			}
			else
			{
				PlayerPrefs.SetInt("HighScore", Skor);
				SkorTekst.text = "Highscore\n" + Skor.ToString();
			}
				
			
			//MozePoceti = true;
			KaIgracu = false;
			Skor = 0;
			Promena = true;
			Tekst.text = Skor.ToString();
			Vreme = 0;
			print("Kraj");
			Kraj = false;
			KojiObj = Lvl1[(int)Random.Range(0, 4)];
			PocetakTekst.GetComponent<Text>().enabled = true;
			KrajRotacije = true;
			PritisakZaRot = false;
			ObjAnim.SetActive(true);
			PostaviPozicije();
			PocetnaPromena = true;
			PomeriTekstNazad = true;
			ZaustaviRot = true;
			ObjAnim.transform.eulerAngles = new Vector3(0, 0, 35);
			//MozePritisnuti = true;
			Obj[0].transform.position = new Vector3(-40, -6, 0);
			PocniAnimaciju = true;
			Trajanje = Trajanje2 = Trajanje3 = 0;
		}
		
	}

	void PostaviPozicije()
	{
		if (PomeriZaKraj == true)
		{
			for (i = 0; i < 6; i++)
			{
				Obj[i].transform.position = new Vector3(PozicijaX[i], PozicijaY[i], 0);
			}
		}
	}

	void Rotiraj()
	{
        rotacija.LevoDesno = (int)Random.Range(0, 3);
        if (Skor >= 3)
		{
			Debug.Log(Skor);
			rotacija.Brzina[0] = rotacija.Brzine[(int)Random.Range(0, 4)];
			rotacija.Brzina[3] = rotacija.Brzine[(int)Random.Range(0, 4)];
			rotacija.PostaviBrzine(8, 10);
		}
		if (Skor >= 5)
		{
			Debug.Log(Skor);
			rotacija.Brzina[0] = rotacija.Brzine[(int)Random.Range(4, 7)];
			rotacija.Brzina[3] = rotacija.Brzine[(int)Random.Range(4, 7)];
			rotacija.PostaviBrzine(4, 6);
		}
		if (Skor >= 7)
		{
			Debug.Log(Skor);
			rotacija.Brzina[0] = rotacija.Brzine[(int)Random.Range(5, 8)];
			rotacija.Brzina[3] = rotacija.Brzine[(int)Random.Range(5, 8)];
			rotacija.PostaviBrzine(5, 8);
		}
		if (Skor >= 10)
		{
			Debug.Log(Skor);
			rotacija.Brzina[0] = rotacija.Brzine[(int)Random.Range(6, 9)];
			rotacija.Brzina[3] = rotacija.Brzine[(int)Random.Range(6, 9)];
			rotacija.PostaviBrzine(6, 9);

		}
		if (Skor >= 12)
		{
			Debug.Log(Skor);
			rotacija.Brzina[0] = rotacija.Brzine[(int)Random.Range(7, 10)];
			rotacija.Brzina[3] = rotacija.Brzine[(int)Random.Range(7, 10)];
			rotacija.PostaviBrzine(8, 9);
		}
		if (Skor >= 15)
		{
			Debug.Log(Skor);
			rotacija.Brzina[0] = rotacija.Brzine[(int)Random.Range(8, 10)];
			rotacija.Brzina[3] = rotacija.Brzine[(int)Random.Range(8, 10)];
			rotacija.PostaviBrzine(8, 10);
		}
		if (Skor >= 20)
		{
			rotacija.Brzina[0] = rotacija.Brzine[(int)Random.Range(10, 11)];
			rotacija.Brzina[3] = rotacija.Brzine[(int)Random.Range(10, 11)];
			rotacija.PostaviBrzine(10, 12);
		}
	}

	void OnMouseDown()
	{
		if (ObjAnim.transform.position == new Vector3(0, -6, 0)) 
		{
			if (PritisakZaRot == false)
			{
				Pritisak = true;
				MozeRotiranje = true;
				PritisakZaRot = true;
			}
		}
		if (MozePritisnuti == true && MozePoceti == true && Promena == false)
		{
			//print("Pritisak");
			
			KaIgracu = true;
			MozePritisnuti = false;
			ZaustaviRot = true;
		}
		
	}
}
