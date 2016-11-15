using UnityEngine;
using System.Collections;
using UnityEditor;

public class AutoSetTextureUISprite : AssetPostprocessor {
    void OnPreprocessTexture() { 
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;
 
        string dirName = System.IO.Path.GetDirectoryName(assetPath);
        Debug.Log("Import ---  " + dirName);
        string folderStr = System.IO.Path.GetFileName(dirName);
        Debug.Log("Set Packing Tag ---  " + folderStr);

        textureImporter.spritePackingTag = folderStr;
    }
}
