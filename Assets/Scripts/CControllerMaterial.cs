using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CControllerMaterial : MonoBehaviour
{
    public Color MeshTint = Color.white;
    public Texture MeshTexture;

    private MaterialPropertyBlock PropertyBlock;
    private Renderer Renderer;

    private void Reset()
    {
        Renderer = GetComponent<Renderer>();
        PropertyBlock = new MaterialPropertyBlock();
    }
    private void OnValidate()
    {
        UpdateOnInspector();
    }
    private void Awake()
    {
        Reset();
        UpdateMaterial();
    }
    private void Update()
    {
        UpdateMaterial();
    }
    public void UpdateMaterial()
    {
        if(Renderer == null || PropertyBlock == null) return;
        PropertyBlock.SetColor("_Color", MeshTint);
        if(MeshTexture != null) PropertyBlock.SetTexture("_MainTex", MeshTexture);
        Renderer.SetPropertyBlock(PropertyBlock);
    }
    [ContextMenu("Update Material")]
    public void UpdateOnInspector()
    {
        if(Renderer == null) Renderer = GetComponent<Renderer>();
        if(PropertyBlock == null) PropertyBlock = new MaterialPropertyBlock();

        PropertyBlock.SetColor("_Color", MeshTint);
        if(MeshTexture != null) PropertyBlock.SetTexture("_MainTex", MeshTexture);
        Renderer.SetPropertyBlock(PropertyBlock);
    }


}
