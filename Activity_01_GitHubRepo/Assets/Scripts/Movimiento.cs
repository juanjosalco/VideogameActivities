using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// OJO
// Con esta directiva obligamos la presencia de un componente en el gameObject
// Todos tienen transform así que es redundante
[RequireComponent(typeof(Transform))]

public class Movimiento : MonoBehaviour
{
    private Transform _transform;

    [SerializeField]
    private float _speed;
    // Se invoca al inicio de la vida del componente
    // Awake se invoca  aunque el objeto esté desabilitado
    
    void Awake()
    {
        print("Awake");
    }

    //Se invoca una vez después que fueron invocados todos los awake

    void Start()
    {
        Debug.Log("Start");

        // Como obtener referencia a otro componente

        // NOTAS: 
        // GetComponent es lento, minimizar su uso.
        // Con transform ya tenems referencia
        // Esta operació puede regresar Nulo
        _transform = GetComponent<Transform>();

        // Si tienes require esto ya no es necesario
        Assert.IsNotNull(_transform, "Es necesario para movimiento tener un transform");
    }

    // Update is called once per frame
    // Frame, Cuadro, Fotograma
    // Target mínimo -> 30 FPS
    // Ideal -> 60 FPS

    void Update()
    {
        // Debug.LogWarning("Updating");

        // SIEMPRE vamos a tratar que este sea lo más magro posible
        // Update lo usamos para 2 cosas:
        // 1. Entrada de usuario
        // 2. Movimiento

        // (Ahorita) -> Vamos a hacer Polling por dispositivo

        // True cuando en el cuadro aterior estaba libre y en este presionado
        if(Input.GetKeyDown(KeyCode.A)){
            print("Key down: A");
        }
        // True cuando en el cuadro aterior estaba presionado y sigue presionado
        if(Input.GetKey(KeyCode.A)){
            print("Key: A");
        }
        // True cuando en el cuadro aterior estaba presionado y ya no
        if(Input.GetKeyUp(KeyCode.A)){
            print("Key Up: A");
        }

        if(Input.GetMouseButtonDown(0)){
            print("Mouse Button Down");
        }
        if(Input.GetMouseButton(0)){
            print("Mouse Button");
        }
        if(Input.GetMouseButtonUp(0)){
            print("Mouse Button Up");
        }



        // (Después) -> Vamos a usar ejes

        // Hacemos Polling a eje en lugar de a hardware específico
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // print(horizontal + " " + vertical);

        if(Input.GetButtonDown("Jump")){
            print("Salto");
        }

        // Mover Objetos
        // 4 Opciones
        // 1. Con su Transform
        // 2. Caracter Controller 
        // 3. Por medio del motor de físcia
        // 4. Por medio de Navmesh (AI)

        _transform.Translate(1 * Time.deltaTime, 0, 0, Space.World);
    }

    // Fixed -> Fijo / Limitado
    // Update que corre en intérvalo fijado en la configuración del proyecto
    // No puede correr más frecuentemente que update

    void FixedUpdate()
    {
        // Debug.LogError("Fixed Update");
    }

    // Corre todos los cuadros
    // Una vez que los updates están terminados

    void LateUpdate()
    {
        // print("Late Update");
    }
}
