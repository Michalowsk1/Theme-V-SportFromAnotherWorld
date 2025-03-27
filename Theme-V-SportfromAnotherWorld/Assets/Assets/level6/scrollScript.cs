using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scrollScript : MonoBehaviour
{
    [SerializeField] Renderer background;

    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset += new Vector2(0.25f * Time.deltaTime, 0);
    }
}
