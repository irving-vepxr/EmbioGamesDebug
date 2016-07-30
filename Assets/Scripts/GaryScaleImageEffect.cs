using UnityEngine;
using System.Collections;

public class GaryScaleImageEffect : MonoBehaviour 
{
	public Shader currentShader;
	public float grayScaleAmount;
	private Material currentMaterial;

	Material material
	{
		get
		{
			if (currentMaterial == null) 
			{				
				currentMaterial = new Material (currentShader);
				currentMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return currentMaterial;
		}
	}

	void Start()
	{
		if (!SystemInfo.supportsImageEffects) 
		{
			enabled = false;
			return;
		}

		if (!currentShader && !currentShader.isSupported) 
		{
			enabled = false;
		}
	}

	void OnRenderImage(RenderTexture sourceTexture, 
					   RenderTexture destTexture)
	{
		if (currentShader != null) 
		{
			material.SetFloat ("_LuminosityAmount", grayScaleAmount);
			Graphics.Blit (sourceTexture, destTexture, material);
		}
		else
			Graphics.Blit (sourceTexture, destTexture);
	}

	void Update()
	{
		grayScaleAmount = Mathf.Clamp (grayScaleAmount, 0.0f, 1.0f);
	}

	void OnDisable()
	{
		if (currentMaterial)
			DestroyImmediate(currentMaterial);
	}
}
