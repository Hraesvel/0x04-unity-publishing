using UnityEngine;
using UnityEngine.UI;

internal interface IController
{
    Image StartImage { get; set; }

    Image ToImage { get; set; }
    Vector2 StartPos { get; set; }
    Vector2 ToPos { get; set; }
    float Sensitivity { get; set; }
    bool TouchController(ref Vector3 dir);
    bool KeyController(ref Vector3 dir);
}