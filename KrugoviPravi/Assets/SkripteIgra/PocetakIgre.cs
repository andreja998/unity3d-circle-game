using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PocetakIgre : Povezivanje {
    public Text TekstTap, TekstTren, TekstH;
    private float Vreme = 0, Vreme2 = 0, Trajanje = 0f, Podeok = 0.02f, Inkrementiranje;
    private bool Ka300Moze = false, Ka0Moze = false;
    
    void Awake()
    {
        
        PocniAnimaciju = true;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (PocniAnimaciju)
        {
            Vreme += 0.5f * Time.deltaTime;
            ObjAnim.transform.position = new Vector2(Mathf.Lerp(ObjAnim.transform.position.x, 0f, Vreme), Mathf.Lerp(ObjAnim.transform.position.y, -6, Vreme));
            if (ObjAnim.transform.position.x >= -0.1f && ObjAnim.transform.position.x != 0) 
            {
                ObjAnim.transform.position = new Vector3(0, -6, 0);
                PocniAnimaciju = false;
                //MozeRotiranje = true;
                ZaustaviRot = true;
                //Pritisak = true;
                Vreme = 0;
            }
        }
        if (ZavrsiAnimaciju)
        {
            Vreme += 0.5f * Time.deltaTime;
            ObjAnim.transform.position = new Vector2(Mathf.Lerp(ObjAnim.transform.position.x, -40, Vreme), Mathf.Lerp(ObjAnim.transform.position.y, -6, Vreme));
            if (ObjAnim.transform.position.x <= -39.9f && ObjAnim.transform.position.x != -40)
            {
                ObjAnim.transform.position = new Vector3(-40, -6, 0);
                ObjAnim.SetActive(false);
                ZaustaviRot = false;
                TekstTren.GetComponent<Text>().enabled = true;
                ZavrsiAnimaciju = false;
                MozePoceti = true;
                MozePritisnuti = true;
            }
        }
        if (MozeRotiranje && Pritisak == true)
        {
            Inkrementiranje = Podeok / 1f;
            //Vreme2 += 0.5f * Time.deltaTime;
            ObjAnim.transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(ObjAnim.transform.eulerAngles.z, 35f, Trajanje));
            Trajanje += Inkrementiranje;
            //Debug.Log(Trajanje);
            if (Vector3.Distance(ObjAnim.transform.eulerAngles, new Vector3(0, 0, 35)) < 0.4f)//ObjAnim.transform.eulerAngles.z <= 35f)
            {
                ObjAnim.transform.eulerAngles = new Vector3(0, 0, 35);
                Trajanje = 0;
                MozeRotiranje = false;
                Pritisak = false;
                ZavrsiAnimaciju = true;
                Debug.Log("Jestee");
                PomeriTekst = true;

            }
            /*if (Vector3.Distance(ObjAnim.transform.eulerAngles, new Vector3(0, 0, 35)) > 0.2f)
            {
                ObjAnim.transform.eulerAngles = Vector3.Lerp(ObjAnim.transform.rotation.eulerAngles, new Vector3(0, 0, 35) * 0.1f, Time.deltaTime);
            }
            
            else
            {
                ObjAnim.transform.eulerAngles = new Vector3(0, 0, 35);
                MozeRotiranje = false;
                Pritisak = false;
                ZavrsiAnimaciju = true;
                PomeriTekst = true;
                //Tekst.GetComponent<Text>().enabled = false;
                
            }*/

        }
        if (PomeriTekst)
        {
            Vreme2 += 0.5f * Time.deltaTime;
            TekstTap.GetComponent<RectTransform>().position = new Vector2(Mathf.Lerp(TekstTap.GetComponent<RectTransform>().position.x, 30, Vreme2), Mathf.Lerp(TekstTap.GetComponent<RectTransform>().position.y, TekstTap.GetComponent<RectTransform>().position.y, Vreme2));
            TekstH.GetComponent<RectTransform>().position = new Vector2(Mathf.Lerp(TekstH.GetComponent<RectTransform>().position.x, 30, Vreme2), Mathf.Lerp(TekstH.GetComponent<RectTransform>().position.y, TekstH.GetComponent<RectTransform>().position.y, Vreme2));
            if (TekstTap.GetComponent<RectTransform>().position.x >= 29 && TekstH.GetComponent<RectTransform>().position.x >= 29)
            {
                TekstTap.GetComponent<RectTransform>().position = new Vector3(30, -6, 0);
                TekstH.GetComponent<RectTransform>().position = new Vector3(30, TekstH.GetComponent<RectTransform>().position.y, 0);
                
                TekstTren.GetComponent<Text>().enabled = true;
                Vreme2 = 0;
                PomeriTekst = false;
            }
        }
        if (PomeriTekstNazad)
        {
            Vreme2 += 0.5f * Time.deltaTime;
            TekstTap.GetComponent<RectTransform>().position = new Vector2(Mathf.Lerp(TekstTap.GetComponent<RectTransform>().position.x, 0, Vreme2), Mathf.Lerp(TekstTap.GetComponent<RectTransform>().position.y, -6, Vreme2));
            TekstH.GetComponent<RectTransform>().position = new Vector2(Mathf.Lerp(TekstH.GetComponent<RectTransform>().position.x, 0, Vreme2), Mathf.Lerp(TekstH.GetComponent<RectTransform>().position.y, TekstH.GetComponent<RectTransform>().position.y, Vreme2));

            if (TekstTap.GetComponent<RectTransform>().position.x <= 0.2f && TekstH.GetComponent<RectTransform>().position.x <= 0.2f)
            {
                TekstTap.GetComponent<RectTransform>().position = new Vector3(0, -6, 0);
                TekstH.GetComponent<RectTransform>().position = new Vector3(0, TekstH.GetComponent<RectTransform>().position.y, 0);
                TekstTren.GetComponent<Text>().enabled = false;
                Vreme2 = 0;
                PomeriTekstNazad = false;
            }
        }
        if (Pritisak == false && MozePoceti == false)
        {
            //print(ObjAnim.transform.rotation.z.ToString());
            //print("as");
            TekstTren.GetComponent<Text>().enabled = false;
            ObjAnim.transform.Rotate(new Vector3(0, 0, 1), 70 * Time.deltaTime, 0);
        }
    }
}
