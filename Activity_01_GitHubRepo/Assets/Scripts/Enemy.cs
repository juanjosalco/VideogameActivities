using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    private float _lifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            -_speed * Time.deltaTime,
            0
        );
    }
    // void OnTriggerEnter(Collider c){
    //     if(c.gameObject.CompareTag("Shot")){
    //         Destroy(c.gameObject);
    //         Destroy(gameObject);
    //     }
    // }

}
