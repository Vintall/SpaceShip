using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSysterPreviewPanel : MonoBehaviour
{
    [SerializeField] Material test_material;

    private void Start()
    {
        test_material.SetVector(Shader.PropertyToID("_DrawPosition"), new Vector4(0.5f, 0.5f, 0, 0));
    }
}
