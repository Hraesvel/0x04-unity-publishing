using UnityEngine;

public class Rotator : MonoBehaviour

{
    public float rate = 1;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0) * transform.rotation,
            Time.deltaTime * rate);
    }
}