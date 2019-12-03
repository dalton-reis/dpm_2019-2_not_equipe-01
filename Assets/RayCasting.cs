using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RayCasting : MonoBehaviour
{
    [SerializeField]private Material highlightMaterial;
    [SerializeField]private Material defaultMaterial;
    public TextMeshPro showText;
    public TextMeshPro TextOH;
    public TextMeshPro TextN;
    public TextMeshPro TextH;
    public ScrollRect scroll;
    private string selectableTag = "Selectable";
    public GameObject QuadCL;
    public GameObject QuadH;
    public GameObject QuadN;
    public GameObject QuadOH;
    public Collider other;

    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        QuadCL.SetActive(false);
        QuadH.SetActive(false);
        QuadOH.SetActive(false);
        QuadN.SetActive(false);

    }
  
    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;            
                Debug.Log("Selectable");
              Debug.Log(showText);
                if (selection.CompareTag("cl"))
                {
                    QuadCL.SetActive(true);
                    showText.text = "O cloro ( grego chlorós, esverdeado ) é um elemento químico ," + "\r\n" + " símbolo Cl de número atômico 17 ( 17 prótons e 17 elétrons ) com massa atômica 35,5 u," + "\r\n" + " encontrado em temperatura ambiente no estado gasoso. Gás extremamente tóxico e de odor irritante," + "\r\n" + " foi descoberto em 1774 pelo sueco Carl Wilhelm Scheele.";
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                        Debug.Log("Teste RayCasting CL");
                        Debug.Log(showText);
                        
                    }
                    _selection = selection;
                }           
                Debug.Log(TextN);
                if (selection.CompareTag("Na"))
                {
                    QuadN.SetActive(true);
                    TextN.text = "O cloro ( grego chlorós, esverdeado ) é um elemento químico ," + "\r\n" + " símbolo Cl de número atômico 17 ( 17 prótons e 17 elétrons ) com massa atômica 35,5 u," + "\r\n" + " encontrado em temperatura ambiente no estado gasoso. Gás extremamente tóxico e de odor irritante," + "\r\n" + " foi descoberto em 1774 pelo sueco Carl Wilhelm Scheele.";
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                        Debug.Log("Teste RayCasting Na");
                        Debug.Log(TextN);
                        
                    }
                    _selection = selection;
                }
                if (selection.CompareTag("OH"))
                {
                    QuadOH.SetActive(true);
                    TextOH.text = "Os álcoois (função álcool) são compostos que apresentam como grupo funcional a hidroxila (‒OH)," + "\r\n" + " ligados a carbonos saturados, em sua estrutura. Podem possuir insaturações, cadeias cíclicas e ramificações." + "\r\n" + " Em geral são solúveis em água e até onze carbonos são líquidos.";
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                        Debug.Log("Teste RayCasting OH");
                        Debug.Log(TextOH);
                        
                    }
                    _selection = selection;
                }            
                if (selection.CompareTag("H"))
                    {
                    QuadH.SetActive(true);
                    TextH.text = "Do Grego de Hydro Genes que significa formador de água." + "\r\n" + " Descoberto por Henry Cavendish em 1766 em Londres pela reação do ácido vitriólico (H2SO4) com Zn," + "\r\n" + " Fe ou Sn. Chamou-o de 'ar inflamável'. É um gás incolor," + "\r\n" + " mais leve que o ar com o qual forma mistura explosiva. Possui três isótopos," + "\r\n" + " prótio (H), deutério (D) descoberto em 1932 por Urey e tritio (T) sendo os dois primeiros naturais." + "\r\n" + " O deutério existe no hidrogênio natural na proporção de 1 átomo para 6.000 átomos de prótio. " + "\r\n" + "Pode ser obtido pela eletrólise de uma solução ácido sulfúrico ou clorídrico, utilizando eletrodos inertes, " + "\r\n" + "sendo desprendido no cátodo (pólo negativo).";
                    var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            selectionRenderer.material = highlightMaterial;
                            Debug.Log("Teste RayCasting H");
                            Debug.Log(TextH);
                        
                        }
                        _selection = selection;
                  }
            
        }
    }
}
