using UnityEngine;

    public static class GameCalculator
    {
        public static Vector2 ServePosition(bool P1)
        {
            return new Vector2(P1?-6:6,
                Loader.i.settings.GroundLevel
                +2*Loader.i.mode.CharacterSize
                -Loader.i.mode.PlayerJumpSpeed/Physics2D.gravity.y);
        }

    }
