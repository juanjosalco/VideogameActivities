using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/*Con esta directiva obligamos la presencia de un componente en el gameobject
(todos tienen transform asi que este ejemplo es redundante) */
[RequireComponent(typeof(Transform))]

public class MovementShip : MonoBehaviour
{
    //Para las situaciones donde se tenga que acceder a otros componentes, voy a necesitar una referencia a ellos.
    private Transform _transform;

    [SerializeField]
    private float _speed = 10;
    // Start is called before the first frame update

    [SerializeField]
    private Proyectile _disparoOriginal;

    [SerializeField]
    private Enemy _enemyOriginal;

    private Camera cam; 
    private Vector2 _lowerleft;
    private Vector2 _upperright;
    private float camX;

    private float score;

    
    void Start()
    {
        // Assert.IsNotNull(_transform, "Es necesario para el movimiento el tener un transform");
        // Assert.IsNotNull(_disparoOriginal, "Disparo no puede ser nulo");
        Assert.AreNotEqual(0, _speed, "Velocidad debe ser mayor a 0");
        
        Debug.Log("START");
        /*referencia a otro componente
        Notas:
        - GetComponent es lento, hazlo lo menos posible
        - con transform ya tenemos referencia 
        - esta operacion puede regresar nulo */
        // _transform = GetComponent<Transform>();
        cam = Camera.main;

        _lowerleft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        _upperright = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        camX = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        //polling por dispositivo
        //Cuando el cuadro anterior no estaba presionado y ahora lo esta
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float _randomX = Random.Range(-7f, 7f);
        /* 
        Movimiento:
        1. directamente con el transform
        2. por medio de character controller
        3. por medio de fisicas
        4. por medio de navmesh (AI)
        */
        StartCoroutine(limits()); 
        

        transform.Translate( new Vector3(horizontal * _speed, vertical * _speed, 0)* Time.deltaTime);

                //igual se pueden usar ejes como botones
        if(Input.GetButtonDown("Jump")){
            Debug.Log("JUMP");
            /*
            Si queremos un GameObject predefinido para clonar usamos instantiate 
            */
            GameObject _proyectil = Instantiate(
                _disparoOriginal.gameObject, 
                transform.position, 
                transform.rotation
            );
        }
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("ENEMY");
            GameObject _enemy = Instantiate(
                _enemyOriginal.gameObject,
                new Vector3(_randomX, 9, 0),
                transform.rotation
            );
        }
    }

    IEnumerator limits () {
        if (transform.position.x > 12.5f)
            transform.position = new Vector3(12.49f, transform.position.y, transform.position.z);
        else if (transform.position.x < -12.5f)
            transform.position = new Vector3(-12.49f, transform.position.y, transform.position.z);
        else if (transform.position.y > 6.5f)
            transform.position = new Vector3(transform.position.x, 6.49f, transform.position.z);
        else if (transform.position.y < -4.6)
            transform.position = new Vector3(transform.position.x, -4.59f, transform.position.z);
        yield return new WaitForSeconds(.5f);
    }

    public void Score(float points){
        score += points;
    }

    public float GetScore(){
        return score; 
    }

}
