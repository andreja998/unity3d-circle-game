using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Boje : Povezivanje {
    int i, BrMats, Boja, ProslaBoja, Boja2;
    public Material[] Mats, MatsP;
    private bool PromeniIgracuBoju, Jednom = true, EkranVrati = false;
    private float Vreme, Trajanje = 0, Inkrementiranje, Podeok = 0.02f, Trajanje2 = 0, Inkrementiranje2, Podeok2 = 0.02f;
    private GameObject[] Objs = new GameObject[6];
    public Text Tekst;
    public Camera Kam;
    public GameObject PO1, PO2, PO3;
    
    void Awake() 
    {
        
    }
	// Use this for initialization
	void Start () {

        Vreme = 1f;
        Mats = Resources.LoadAll<Material>("Materijali");
        MatsP = Resources.LoadAll<Material>("MaterijaliPozadine");
        Debug.Log("MatsP" + MatsP.Length.ToString());
        BrMats = Mats.Length;
        Boja2 = (int)Random.Range(0, BrMats);
        ProslaBoja = Boja2;
        Obj[0] = GameObject.Find("Obj1");
        Obj[0].GetComponent<Renderer>().material = Mats[Boja2];
        PO1.GetComponent<Renderer>().material = MatsP[Boja2];
        PO2.GetComponent<Renderer>().material = MatsP[Boja2];
        PO3.GetComponent<Renderer>().material = MatsP[Boja2];
        for (i = 1; i < 6; i++)
        {
            do
            {
                Boja2 = (int)Random.Range(0, BrMats);
            } while (Boja2 == ProslaBoja);
            ProslaBoja = Boja2;
            Obj[i].GetComponent<Renderer>().material = Mats[Boja2];
            //Obj[i].name = "Obj" + Boja2.ToString();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Jednom)
        {
            Jednom = false;
            Igrac.GetComponent<Renderer>().material = Obj[PocetnaBoja].GetComponent<Renderer>().material;
            ObjAnim.GetComponent<Renderer>().material = Obj[PocetnaBoja].GetComponent<Renderer>().material;
            Tekst.color = Obj[PocetnaBoja].GetComponent<Renderer>().material.color;
            PO1.GetComponent<Renderer>().material = MatsP[PocetnaBoja];
            PO2.GetComponent<Renderer>().material = MatsP[PocetnaBoja];
            PO3.GetComponent<Renderer>().material = MatsP[PocetnaBoja];
        }
        
        for (i = 0; i < 6; i++)
        {
            if (PromeniBoju[i])
            {
                do
                {
                    Boja = (int)Random.Range(0, BrMats);
                } while (Boja == ProslaBoja);
                ProslaBoja = Boja;
                Obj[i].GetComponent<Renderer>().material = Mats[Boja];
                Obj[i].name = "Obj" + Boja.ToString();
                PromeniBoju[i] = false;
            }
        }
        if (MozePromenaBojeIgraca == true)
        {
            
            Inkrementiranje = Podeok / Vreme;
            if (Trajanje < 1)
            {
                //string Ime = Obj[PromenaBoje].name;
                var C = Obj[PromenaBoje].name.ToCharArray();
                int A = int.Parse(C[3].ToString());
                
                Igrac.GetComponent<Renderer>().material.color = Color.Lerp(Igrac.GetComponent<Renderer>().material.color, Obj[PromenaBoje].GetComponent<Renderer>().material.color, Trajanje);
                Tekst.color = Color.Lerp(Tekst.color, Obj[PromenaBoje].GetComponent<Renderer>().material.color, Trajanje);
                PO1.GetComponent<Renderer>().material.color = Color.Lerp(PO1.GetComponent<Renderer>().material.color, MatsP[A].color, Trajanje);
                PO2.GetComponent<Renderer>().material.color = Color.Lerp(PO2.GetComponent<Renderer>().material.color, MatsP[A].color, Trajanje);
                PO3.GetComponent<Renderer>().material.color = Color.Lerp(PO3.GetComponent<Renderer>().material.color, MatsP[A].color, Trajanje);
                Trajanje += Inkrementiranje;
            }
            if (Igrac.GetComponent<Renderer>().material.color == Obj[PromenaBoje].GetComponent<Renderer>().material.color)
            {
                Trajanje = 0;
                MozePromenaBojeIgraca = false;
                print("Kraj boje!");
            }
        } 
        if (PocetnaPromena)
        {
            Igrac.GetComponent<Renderer>().material = Obj[PocetnaBoja].GetComponent<Renderer>().material;
            ObjAnim.GetComponent<Renderer>().material = Obj[PocetnaBoja].GetComponent<Renderer>().material;
            Tekst.color = Obj[PocetnaBoja].GetComponent<Renderer>().material.color;
            PO1.GetComponent<Renderer>().material.color = Color.Lerp(PO1.GetComponent<Renderer>().material.color, MatsP[PocetnaBoja].color, Trajanje);
            PO2.GetComponent<Renderer>().material.color = Color.Lerp(PO2.GetComponent<Renderer>().material.color, MatsP[PocetnaBoja].color, Trajanje);
            PO3.GetComponent<Renderer>().material.color = Color.Lerp(PO3.GetComponent<Renderer>().material.color, MatsP[PocetnaBoja].color, Trajanje);
            PocetnaPromena = false;
        }
        /*if (EkranPromeni)
        {
            Inkrementiranje2 = 0.2f / Vreme;
            Kam.backgroundColor = Color.Lerp(Kam.backgroundColor, Obj[KojiObj].GetComponent<Renderer>().material.color, Trajanje2);
            Trajanje2 += Inkrementiranje2;
            if (Kam.backgroundColor == Obj[KojiObj].GetComponent<Renderer>().material.color)
            {
                EkranPromeni = false;
                EkranVrati = true;
                Trajanje2 = 0;
            }
        }
        if (EkranVrati)
        {
            Inkrementiranje2 = 0.2f / Vreme;
            Kam.backgroundColor = Color.Lerp(Kam.backgroundColor, Color.white, Trajanje2);
            Trajanje2 += Inkrementiranje2;
            if (Kam.backgroundColor == Color.white)
            {
                EkranPromeni = false;
                EkranVrati = false;
                Trajanje2 = 0;
            }
        }*/
        //oksana kazanceva
        //Soci Ruska Federacija
	}
}
