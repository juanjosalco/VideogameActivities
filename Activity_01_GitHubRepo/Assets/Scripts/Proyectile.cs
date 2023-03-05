using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions; 

public class Proyectile : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _lifeTime = 3f;

    private float points = 10f;

    //Declarar el objeto de tipo MovementShip
    MovementShip mvship;  

    // private GUIManager _gui; 
    void Start(){
        /* 
        Nota Importante
        Si voy a crear objetos dinamicamente es indispensable que tenga al menos 1 estrategia de destruccion.

        destroy - destruye game objects completos
        o componentes
        
        */
        // Obtenemos de Ship el componente Script - MovementShip
        mvship = GameObject.Find("Ship").GetComponent<MovementShip>();
        
        
        Destroy(gameObject, _lifeTime);

        //ESTO VA A CAMBIAR
            // GameObject guiGO = GameObject.find("GUIManager");
            // Assert.IsNotNull(guiGO, "NO HAY GUIMANAGER");

            // _gui = guiGO.GetComponent<GUIManager>();
            // Assert.IsNotNull(_gui, "GUIMANAGER NO TIENE COMPONENTE"); 
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime,0);
    }
    //COLISIONES
    /*
    1. Tiene que tener un collider
    2. Tiene que tener rigidbody
    3. El rigidbody tiene que estar en un objeto que se mueva
    */
    // void OnCollisionEnter(Collision c){
    //     //Objeto colision que recibimos, contiene info de la colision
    //     //1. Filtrar por tag
    //     //2. Filtrar por layer
    //     print("ENTER " + c.transform.name + c.transform.tag);
    // }
    // void OnCollisionStay(Collision c){
    //     print("STAY");
    // }
    // void OnCollisionExit(Collision c){
    //     print("EXIT");
    // }

    void OnTriggerEnter(Collider e){
        if(e.gameObject.CompareTag("Enemy")){
            Debug.Log("ENEMY HIT");
            mvship.Score(points);
            Destroy(e.gameObject);
            Destroy(gameObject);

        }
    }

}
