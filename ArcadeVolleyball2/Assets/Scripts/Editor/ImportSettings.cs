using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ImportSettings : AssetPostprocessor
{
    private const float BgUnits = 16;
    private const float BallUnits = 1.5f;
    private const float GuyUnits = 2;
    private const float Ppu = 32;

    private void OnPreprocessTexture()
    {
        if (System.IO.Path.GetDirectoryName(assetPath) != "Assets/Sprites") return;
        
        string fileName = System.IO.Path.GetFileNameWithoutExtension(assetPath);

        Debug.Log("importing: "+fileName);

        char[] split = {'_'};
        string[] parts = fileName.Split(split,StringSplitOptions.None);
        
        TextureImporter ti = (TextureImporter) assetImporter;
        ti.textureType = TextureImporterType.Sprite;
        ti.mipmapEnabled = false;
        ti.filterMode = FilterMode.Point;
        ti.spriteImportMode = SpriteImportMode.Single;
        
        
        if (parts.Length < 3) ti.spritePixelsPerUnit = Ppu;
        else
        {
            float height = float.Parse(parts[2]);
            
            switch (parts[0])
            {
                case "ball": 
                    ti.spritePixelsPerUnit =  height / BallUnits;
                    break;
                case "guy": 
                    ti.spriteImportMode = SpriteImportMode.Multiple;
                    ti.spritePixelsPerUnit =  height / GuyUnits;
                    break;
                case "background":
                    ti.spritePixelsPerUnit =  height / BgUnits;
                    break;
                default:
                    ti.spritePixelsPerUnit = Ppu; 
                    break;
            }
        }


    }

    private void OnPostprocessTexture(Texture2D texture)
    {
        
        string fileName = System.IO.Path.GetFileNameWithoutExtension(assetPath);

        if (!fileName.Contains("guy")) return;
        
        var metas = new List<SpriteMetaData>();
        int height = texture.height;

        for (int c = 0; c < texture.width/texture.height; c++)
        {
            SpriteMetaData meta = new SpriteMetaData
            {
                rect = new Rect(c * height, 0, height, height), 
                name = fileName + "_" + c,
                alignment = (int)SpriteAlignment.BottomCenter
            };
            metas.Add(meta);
        }
        
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.spritesheet = metas.ToArray();

    }
}

/*
     if (fileName.Contains("ball"))
        {
            textureImporter.spriteImportMode = SpriteImportMode.Single;
            textureImporter.spritePixelsPerUnit = height / _ballUnits;
        }
        else if (fileName.Contains("background"))
        {
            textureImporter.spriteImportMode = SpriteImportMode.Single;
            textureImporter.spritePixelsPerUnit = height / _bgUnits;
        }
 * 
 */
     