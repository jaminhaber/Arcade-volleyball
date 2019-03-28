using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(menuName = "SpriteSet")]
    public class SpriteSet : ScriptableObject
    {
        public int FramesPerSprite = 12;
        public Sprite[] Walking;
        public Sprite Jump;
    }
}