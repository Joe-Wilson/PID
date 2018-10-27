using UnityEngine;
using System.Collections;

public class PID : MonoBehaviour {
    float integral, derivative, proportion;
    public float target;
    public float kProp, kInt, kDiff;
    float previousProportion;
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        float current = transform.position.z;
        proportion = target - current;
        integral += proportion * dt;
        derivative = (proportion - previousProportion) / dt;

        this.GetComponent<Rigidbody>().AddForce(0,0,kProp * proportion + kInt * integral + kDiff * derivative);
        previousProportion = proportion;
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
    }
}
