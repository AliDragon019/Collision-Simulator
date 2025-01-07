using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
    public GameObject p1;
    public Rigidbody2D r1;
    public Collision2D collision1;
    public float m1;
    public float vi1;
    public float v1;

    public GameObject p2;
    public Rigidbody2D r2;
    public Collision2D collision2;
    public float m2;
    public float vi2;
    public float v2;

    public float a;
    public float c1;
    public float c2;

    public int numberOfCollisions = 0;

    public Text ncollisions;

    // Start is called before the first frame update
    void Start()
    {
        v1 = vi1;
        v2 = vi2;

        // a = m1/m2;
        a = m2/m1;
        c1 = ((float)(0.5*m1*vi1*vi1+0.5*m2*vi2*vi2));
        c2 = m1*vi1+m2*vi2;

        r1.velocity = new Vector2(v1, 0);
        r2.velocity = new Vector2(v2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){
        // Vector3 d1 = p1.transform.position;
        // Vector3 d2 = p2.transform.position;

        // p1.transform.position = new Vector3(d1.x + v1*Time.deltaTime, d1.y, d1.z);
        // p2.transform.position = new Vector3(d2.x + v2*Time.deltaTime, d2.y, d2.z);

        r1.velocity = new Vector2(v1, 0);
        r2.velocity = new Vector2(v2, 0);
    }

    public void SetSpeed(){
        float oldv1 = v1;
        float oldv2 = v2;
        // v2 = ( 2*a*c2 - a*Mathf.Sqrt( 16*m1*c1+4*c2*c2 ) )/(4*m1);
        // v1 = ( (c2/m2) - v2 )/(a);
        // v2 = (2*m2*vi1)/(m2+m2*m2/m1);
        // v1 = vi1*(m1*m2-m2*m2)/(m1*m2+m2*m2);
        v1 = oldv2*(2*a)/(1+a) + oldv1*(1-a)/(1+a);
        v2 = oldv2*(a-1)/(1+a) + oldv1*(2)/(1+a);
    }

    public void Collision(Collision2D other){
        Debug.Log(other.collider.name);
        numberOfCollisions++;
        ncollisions.text = "Collisions: "+numberOfCollisions;
        if(other.collider.name == "Wall"){
            v2 = -v2;
        } else{
            SetSpeed();
        }
    }
}
