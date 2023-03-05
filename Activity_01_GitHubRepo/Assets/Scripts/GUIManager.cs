// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Assertions;
// using TMPro;
// public class GUIManager : MonoBehaviour
// {
//     [SerializeField]
//     public TMP_Text _text;
//     // Start is called before the first frame update
//     void Start()
//     {
//         Assert.IsNotNull(_text, "TEXTO NO PUEDE SER NULO");
//         _text.text = "Hola desde codigo"; 
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;


public class GUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_Text _texto; // TMP Text Mesh Pro

    MovementShip score;

    void Start()
    {
        Assert.IsNotNull(_texto,"Texto NO puede ser Nulo");
        _texto.text = "Hola desde GUIManager script";
        score = GameObject.Find("Ship").GetComponent<MovementShip>();
    }

    // Update is called once per frame
    void Update()
    {
        changeText();
    }

    void changeText(){
        _texto.text = "Score: " + score.GetScore().ToString();
    }
}
