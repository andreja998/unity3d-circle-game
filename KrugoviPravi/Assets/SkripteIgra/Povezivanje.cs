using UnityEngine;
using System.Collections;

public class Povezivanje : MonoBehaviour {
    public static bool VratiNazad, KaIgracu, Rotiraj, MozePoceti, Kraj, BojaIgr, KrajBoje, MozePromenaBojeIgraca, MozePritisnuti,
                       KrajRotacije, ZaustaviRot, PocniAnimaciju, ZavrsiAnimaciju, PokreniIgru,
                       MozeRotiranje, Pritisak, PritisakZaRot, PocetnaPromena, PomeriTekst, PomeriTekstNazad, Jednom, EkranPromeni, Pauziraj, Promena = true;
    public static int Skor, PocetnaBoja, PromenaBoje, KojiObj, HSkor, Levo;
    public static bool[] RotirajObj = new bool[6], PromeniBoju = new bool[6], PromeniBojuIgraca = new bool[6];
    public static float[] PozicijaX = new float[6], PozicijaY = new float[6];
    public static GameObject[] Obj = new GameObject[6];
    public static GameObject Igrac, ObjAnims, ObjAnim;
    private int[] Niz = new int[] { 0, 3 };

    void Awake()
    {
        Igrac = GameObject.Find("Igrac");
        for (int i = 0; i < 6; i++)
        {
            Obj[i] = GameObject.Find("Obj" + (i + 1));
        }
        ObjAnim = GameObject.Find("ObjAnim");
        ObjAnim.transform.position = new Vector3(-40, -6, 0);
        PozicijaX[0] = -40;
        PozicijaY[0] = 0;
        PozicijaX[1] = 40;
        PozicijaY[1] = 0;
        PozicijaX[2] = 0;
        PozicijaY[2] = -40;
        PozicijaX[3] = -40;
        PozicijaY[3] = -40;
        PozicijaX[4] = 0;
        PozicijaY[4] = -70;
        PozicijaX[5] = 40;
        PozicijaY[5] = -40;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
