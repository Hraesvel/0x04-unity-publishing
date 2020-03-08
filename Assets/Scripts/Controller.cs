using UnityEngine;
using UnityEngine.UI;

internal class Controller : IController
{
    private Vector2 _pos;

    private float _sensitivity = 1;
    private Vector2 _startPos;


    public Image StartImage { get; set; }

    public Image ToImage { get; set; }

    public Vector2 StartPos
    {
        get { return _startPos; }
        set { _startPos = value; }
    }

    public Vector2 ToPos
    {
        get { return _pos; }
        set { _pos = value; }
    }

    public float Sensitivity
    {
        get { return _sensitivity; }
        set { _sensitivity = value; }
    }

    public bool TouchController(ref Vector3 dir)
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            Vector2 nDir;

            if (touch.phase == TouchPhase.Began)
            {
                StartImage.gameObject.SetActive(true);
                ToImage.gameObject.SetActive(true);

                _startPos = touch.position;
                StartImage.rectTransform.position = _startPos;
                ToImage.rectTransform.position = _startPos;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _pos = touch.position;
                ToImage.rectTransform.position = _pos;

                nDir = new Vector2(_pos.x - _startPos.x, _pos.y - _startPos.y);

                if (nDir.magnitude > 10)
                {
                    dir.x = Mathf.Clamp(nDir.x * .01f * _sensitivity, -1, 1);
                    dir.z = Mathf.Clamp(nDir.y * .01f * _sensitivity, -1, 1);
                }
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                nDir = new Vector2(_pos.x - _startPos.x, _pos.y - _startPos.y);

                if (nDir.magnitude > 10)
                {
                    dir.x = Mathf.Clamp(nDir.x * .01f * _sensitivity, -1, 1);
                    dir.z = Mathf.Clamp(nDir.y * .01f * _sensitivity, -1, 1);
                }
            }
        }
        else
        {
            StartImage.gameObject.SetActive(false);
            ToImage.gameObject.SetActive(false);
            dir.x = 0f;
            dir.z = 0f;
            return false;
        }

        return true;
    }

    public bool KeyController(ref Vector3 dir)
    {
        if (!Input.anyKey) return false;


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) dir.x += 1;


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) dir.x -= 1;


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) dir.z += 1;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) dir.z -= 1;

        return true;
    }
}