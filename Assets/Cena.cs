using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cena : MonoBehaviour
{

    public GameObject filho;
    public GameObject filhoNa;
    public GameObject filhoCl;
    public GameObject filhoSphereOH;
    public GameObject filhoSphereOH2;
    public GameObject filhoCilinderOH;
    public GameObject Quad;
    public TextMeshPro text;
    public GameObject ObjectNaOH;
    public GameObject ObjectHCL;
    public GameObject SphereNa2;
    //public GameObject Plane;
    // Start is called before the first frame update
    void Start()
    {
        
        filho.SetActive(false);
        filhoNa.SetActive(false);
        filhoCl.SetActive(false);
        filhoSphereOH.SetActive(false);
        filhoSphereOH2.SetActive(false);
        filhoCilinderOH.SetActive(false);
        SphereNa2.SetActive(false);
        ObjectHCL.SetActive(false);
        ObjectNaOH.SetActive(false);
        Quad.SetActive(false);
        text.text = "Cena - Quimica";
        //Plane.SetActive(true);
        Debug.Log("Plano ativado");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Other 1 "+other.gameObject.tag);
      
        
        Debug.Log("Teste  de verificação da Cena");

        // Colocando na cena
        /*if (other.gameObject.CompareTag("Na"))
        {
            Debug.Log("Na");
            other.gameObject.SetActive(false);
        }*/
        if (other.gameObject.CompareTag("cl"))
        {
            Debug.Log("Entrou no IF do Cl");
            if (GameObject.Find("ImageTargetN") == false)
            {
                Debug.Log("NaCl");
                other.gameObject.SetActive(false);
                filho.SetActive(true);
                text.text = "NaCl -> Cloreto de Sódio";
            }
            else if (GameObject.Find("ImageTargetCL") == true)
            {
                Debug.Log("cl");
                other.gameObject.SetActive(false);
                filho.SetActive(true);
            } else if (GameObject.Find("ImageTargetH") == false)
            {
                Debug.Log("HCL");
                other.gameObject.SetActive(false);
                ObjectHCL.SetActive(true);
                GameObject.Find("SphereCl2");
                GameObject.Find("CylinderHCL").SetActive(true);
                text.text = "NaCl -> Cloreto de Sódio";
            }

        }
        else if (other.gameObject.CompareTag("Na"))
        {
            Debug.Log("Entrou no IF do Na");
            if (GameObject.Find("ImageTargetCL") == false)
            {
                Debug.Log("NaCl");
                other.gameObject.SetActive(false);
                filhoNa.SetActive(true);                
                text.text = "NaCl -> Cloreto de Sódio";
            }
            else if (GameObject.Find("ImageTargetN").active == true)
            {
                Debug.Log("Na");
                other.gameObject.SetActive(false);
                filhoNa.SetActive(true);
            }
            else if (GameObject.Find("ImageTargetOH") == false)
            {
                Debug.Log("NaOH");
                other.gameObject.SetActive(false);
                ObjectNaOH.SetActive(true);
                text.text = "NaOH -> Hidróxido de sódio";
            }

        }
        // Verificação do OH 
        else if (other.gameObject.CompareTag("OH"))
        {
            Debug.Log("OH");
            if (GameObject.Find("ImageTargetNa") == false)
            {
                Debug.Log("NaOH");
                other.gameObject.SetActive(false);
                ObjectNaOH.SetActive(true);
                text.text = "NaOH -> Hidróxido de sódio";
            }
            else if (GameObject.Find("ImageTargetOH") == true){
                Debug.Log("OH");
                other.gameObject.SetActive(false);
                GameObject.Find("SphereOH2").SetActive(true);
                GameObject.Find("CylinderOH2").SetActive(true);
                GameObject.Find("SphereOH_2").SetActive(true);
            }
        }
        // Verificação do HCL
        else if (other.gameObject.CompareTag("H"))
        {
            Debug.Log("H");
            if (GameObject.Find("ImageTargetCl") == false)
            {
                Debug.Log("NaOH");
                other.gameObject.SetActive(false);
                ObjectHCL.SetActive(true);
                GameObject.Find("SphereH").SetActive(true);
                GameObject.Find("CylinderHCL").SetActive(true);
                text.text = "HCl -> Ácido clorídico";
            }
            else if (GameObject.Find("ImageTargetH") == true)
            {
                Debug.Log("H");
                other.gameObject.SetActive(false);
            }
        }


        //Repulsão
        if (other.gameObject.CompareTag("Na"))
        {
            if (GameObject.Find("SphereH") == true)
            {
                text.text = "Repulsão de cargas iguais";
            }

        }else if (other)
        {

        }


        /*else if (other.gameObject.CompareTag("Na"))
        {
            Debug.Log("Na");
            other.gameObject.SetActive(false);
            if (other.gameObject.CompareTag("cl") == false)
            {
                Debug.Log("NaCl");
                other.gameObject.SetActive(false);
                filho.SetActive(true);
                filhoNa.SetActive(true);
                text.text = "NaCl -> Cloreto de Sódio";
            }
        }        

        //Tirando da cena
        /*if (other.gameObject.CompareTag("Cl"))
        {
            other.gameObject.SetActive(true);
            filho.SetActive(false);

        }*/
        
    }
}
