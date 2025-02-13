﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Unity.Editor;
using Firebase.Extensions;
using Firebase.Database;
public class Cena : MonoBehaviour
{

    public GameObject filhoNa;
    public GameObject filhoCl;
    public GameObject Quad;
    public TextMeshPro text;
    public Text TextPergunta;
    public Text TextRespostas;
    public GameObject ObjectNaOH;
    public GameObject ObjectHCL;

    // ObjectNaOH
    public GameObject SphereNa2;
    public GameObject SphereOH2;
    public GameObject CylinderOH2;
    public GameObject SphereOH_2;

    // ObjectHCL
    public GameObject SphereCl2;
    public GameObject CylinderHCL;
    public GameObject SphereH;
    public GameObject LimpaCena;

    // Marcadores
    public GameObject MarcadorNa;
    public GameObject MarcadorCl;
    public GameObject MarcadorH;
    public GameObject MarcadorOH;

    //Panel
    public GameObject panel;

    //Botões
    public GameObject ButtonPergunta;
    public GameObject ButtonVoltar;
    public GameObject ButtonRespostas;

    public FirebaseDatabase perguntas;


    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://quimica-5ae65.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        filhoNa.SetActive(false);
        filhoCl.SetActive(false);
        SphereNa2.SetActive(false);
        SphereOH2.SetActive(false);
        CylinderOH2.SetActive(false);
        SphereOH_2.SetActive(false);
        SphereH.SetActive(false);
        SphereCl2.SetActive(false);
        CylinderHCL.SetActive(false);

        ObjectHCL.SetActive(false);
        ObjectNaOH.SetActive(false);
        Quad.SetActive(false);
        text.text = "Cena - Química";

        panel.SetActive(false);
        ButtonVoltar.SetActive(false);
        ButtonRespostas.SetActive(false);
        TextPergunta.text = "";
        TextRespostas.text = "";


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
                filhoCl.SetActive(true);
                text.text = "NaCl -> Cloreto de Sódio";
            }
            else if ((GameObject.Find("ImageTargetCL") == true)&&(GameObject.Find("ImageTargetH") != false))
            {
                Debug.Log("cl");
                other.gameObject.SetActive(false);
                filhoCl.SetActive(true);
            }
            else if (GameObject.Find("ImageTargetH") == false)
            {
                Debug.Log("HCL");
                other.gameObject.SetActive(false);
                SphereCl2.SetActive(true);

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
            else if ((GameObject.Find("ImageTargetN") == true)&&(GameObject.Find("ImageTargetOH") != false))
            {
                Debug.Log("Na");
                other.gameObject.SetActive(false);
                filhoNa.SetActive(true);
            }else if (GameObject.Find("ImageTargetOH") == false)
            {
                Debug.Log("NaOH");
                filhoNa.SetActive(false);
                SphereNa2.SetActive(true);
                other.gameObject.SetActive(false);
                text.text = "NaOH -> Hidróxido de sódio";
            }           
        }
        // Verificação do OH 
        else if (other.gameObject.CompareTag("OH"))
        {
            Debug.Log("OH");
            if (GameObject.Find("ImageTargetN") == false)
            {
                Debug.Log("NaOH");
                other.gameObject.SetActive(false);
                filhoNa.SetActive(false);
                SphereOH2.SetActive(true);
                SphereOH_2.SetActive(true);
                CylinderOH2.SetActive(true);
                SphereNa2.SetActive(true);
                text.text = "NaOH -> Hidróxido de sódio";
            }
            else if (GameObject.Find("ImageTargetOH") == true){
                Debug.Log("OH");
                other.gameObject.SetActive(false);
                SphereOH2.SetActive(true);
                CylinderOH2.SetActive(true);
                SphereOH_2.SetActive(true);
            }
        }
        // Verificação do HCL
        else if (other.gameObject.CompareTag("H"))
        {
            Debug.Log("H");
            if (GameObject.Find("ImageTargetCL") == false)
            {
                Debug.Log("NaOH");
                other.gameObject.SetActive(false);
                filhoCl.SetActive(false);
                CylinderHCL.SetActive(true);
                SphereH.SetActive(true);
                SphereCl2.SetActive(true);
                text.text = "HCl -> Ácido clorídico";
            }
            else if (GameObject.Find("ImageTargetH") == true)
            {
                Debug.Log("H");
                other.gameObject.SetActive(false);               
                CylinderHCL.SetActive(true);
                SphereH.SetActive(true);
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

        //Limpa Cena e ativa os marcadores individuais
        if (other.gameObject.CompareTag("ClenaScene"))
        {
            SceneManager.LoadScene("Menu");
            /*
            filhoNa.SetActive(false);
            filhoCl.SetActive(false);
            SphereNa2.SetActive(false);
            SphereOH2.SetActive(false);
            CylinderOH2.SetActive(false);
            SphereOH_2.SetActive(false);
            ObjectHCL.SetActive(false);
            ObjectNaOH.SetActive(false);
            Quad.SetActive(false);
            text.text = "Cena - Quimica";
            
            // Ativando marcadores
            MarcadorNa.SetActive(true);
            MarcadorCl.SetActive(true);
            MarcadorOH.SetActive(true);
            MarcadorH.SetActive(true);*/
        }

    }

    public void BotaoPergunta()
    {
        ButtonPergunta.SetActive(false);
        ButtonVoltar.SetActive(true);
        panel.SetActive(true);
        int num = Random.Range(1,4);
        Debug.Log(num);
        DataSnapshot snapshot = null;
        FirebaseDatabase.DefaultInstance
          .GetReference("perguntas").Child(num.ToString()).Child("Descricao").Child("")
          .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                  Debug.Log("Antes do texto");
                  TextPergunta.text = task.Result.Value.ToString();
                  Debug.Log(snapshot);
                // Do something with snapshot...
            }
        });
        
        //TextPergunta.text = snapshot.Value.ToString();
        // Debug.Log(snapshot.Value.ToString());
        Debug.Log("Respostas");
        FirebaseDatabase.DefaultInstance
          .GetReference("respostas").Child("1").Child("Descricao").Child("")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {

              }
              else if (task.IsCompleted)
              {
                  Debug.Log("Respostas");
                  snapshot = task.Result;
                  Debug.Log(task.Result.Value.ToString());

              }
          });
        TextRespostas.text = snapshot.Value.ToString();

    }
 
    public void BotaoFechar()
    {
        ButtonPergunta.SetActive(true);
        ButtonVoltar.SetActive(false);
        panel.SetActive(false);
    }
}
