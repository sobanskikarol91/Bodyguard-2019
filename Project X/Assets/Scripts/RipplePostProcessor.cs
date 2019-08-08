using System;
using UnityEngine;

public class RipplePostProcessor : MonoBehaviour
{
    public Material RippleMaterial;
    public float MaxAmount = 50f;

    [Range(0, 1)]
    public float Friction = .9f;

    private float Amount = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Amount = MaxAmount;
            Vector3 pos = Input.mousePosition;
            RippleMaterial.SetFloat("_CenterX", pos.x);
            RippleMaterial.SetFloat("_CenterY", pos.y);
        }

        RippleMaterial.SetFloat("_Amount", Amount);
        Amount *= Friction;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, RippleMaterial);
    }
}