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
    public ScrollRect scroll;
    private string selectableTag = "Selectable";
    public GameObject Quad;

    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        Quad.SetActive(true);

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
            if (GameObject.Find("ImageTargetCL").CompareTag("cl"))
            {
                showText.text = "O cloro ( grego chlorós, esverdeado ) é um elemento químico , símbolo Cl de número atômico 17 ( 17 prótons e 17 elétrons ) com massa atômica 35,5 u, encontrado em temperatura ambiente no estado gasoso. Gás extremamente tóxico e de odor irritante, foi descoberto em 1774 pelo sueco Carl Wilhelm Scheele.";
                scroll.enabled = true;
                Debug.Log(showText);
                if (selection.CompareTag(selectableTag))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                        Debug.Log("Teste RayCasting");
                        Debug.Log(showText);
                        Quad.SetActive(true);
                    }
                    _selection = selection;
                }

            }else if (GameObject.Find("ImageTargetN").CompareTag("Na"))
            {

            }else if (GameObject.Find("ImageTargetOH").CompareTag("OH"))
            {

            }
            else if (GameObject.Find("ImageTargetH").CompareTag("H"))
            {

            }
        }
    }
}
