using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ImportSettings : AssetPostprocessor
{
    /*
     *beshken was here XD love u ben
     */

    bool postProcess;
    int ppu = 32;

    private void OnPreprocessTexture()
    {
        Debug.Log("importing: "+assetPath);

        TextureImporter ti = (TextureImporter) assetImporter;
        ti.textureType = TextureImporterType.Sprite;
        ti.spritePixelsPerUnit = ppu;
        ti.mipmapEnabled = false;
        ti.filterMode = FilterMode.Point;

        if (assetPath.Contains("guy"))
        {
            ti.spriteImportMode = SpriteImportMode.Multiple;
            postProcess = true;
        }
        else
        {
            ti.spriteImportMode = SpriteImportMode.Single;
            postProcess = false;
        }
    }

    private void OnPostprocessTexture(Texture2D texture)
    {
        if (!postProcess) return;
        
        string fileName = System.IO.Path.GetFileNameWithoutExtension(assetPath);
        int spriteSize = texture.height;
        
        var metas = new List<SpriteMetaData>();


        for (int c = 0; c < texture.width/texture.height; c++)
        {
            SpriteMetaData meta = new SpriteMetaData();
            meta.rect = new Rect(c * spriteSize, 0, spriteSize, spriteSize);
            meta.name = fileName + "_" + c;
            metas.Add(meta);
        }
        
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.spritePixelsPerUnit = spriteSize / 2;
        textureImporter.spritesheet = metas.ToArray();
    }
}