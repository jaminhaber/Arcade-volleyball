using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ImportSettings : AssetPostprocessor
{
    /*
     *beshken was here XD love u ben
     */

    private readonly float _bgUnits = 16;
    private readonly float _ballUnits = 1.6f;
    private readonly float _guyUnits = 2;
    private readonly float _ppu = 32;

    private void OnPreprocessTexture()
    {
        Debug.Log("importing: "+assetPath);

        TextureImporter ti = (TextureImporter) assetImporter;
        ti.textureType = TextureImporterType.Sprite;
        ti.mipmapEnabled = false;
        ti.filterMode = FilterMode.Point;
    }

    private void OnPostprocessTexture(Texture2D texture)
    {
        
        string fileName = System.IO.Path.GetFileNameWithoutExtension(assetPath);
        int height = texture.height;
        
        TextureImporter textureImporter = (TextureImporter)assetImporter;

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
        else if (fileName.Contains("guy"))
        {
            textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            textureImporter.spritePixelsPerUnit = height / _guyUnits;
        
            var metas = new List<SpriteMetaData>();

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
        
            textureImporter.spritesheet = metas.ToArray();
        }
        else
        {
            textureImporter.spriteImportMode = SpriteImportMode.Single;
            textureImporter.spritePixelsPerUnit = _ppu;
        }
      
    }
}