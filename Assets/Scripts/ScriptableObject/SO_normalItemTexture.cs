using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skin/NormalItemTexture")]
public class SO_normalItemTexture : ScriptableObject
{
    [System.Serializable]
    public class TextureResources
    {
        public List<Texture2D> texture2Ds;
    }
    public List<TextureResources> NewTextures = new List<TextureResources>();

    //public List<Texture2D> OldTextures = new List<Texture2D>();
}
