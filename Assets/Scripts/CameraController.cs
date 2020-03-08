using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _relativePosition;

    public GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        _relativePosition = transform.position - player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        var playerPosition = player.transform.position;

        transform.position = playerPosition + _relativePosition;
    }
}