using System;
using UnityEngine;

    public static class GameCalculator
    {
        
        private static bool last;

        public static Vector2 ServePosition(bool P1)
        {
            return new Vector2(P1?-6:6,
                Loader.i.settings.GroundLevel
                +2*Loader.i.mode.CharacterSize
                -Loader.i.mode.PlayerJumpSpeed/Physics2D.gravity.y);
        }

        public static Func<State, State, bool> ServeFunction(ServeMode serve)
        {
            switch (serve)
            {
                case ServeMode.Winner:
                    return (n, o) => n.p1score > o.p1score;
                case ServeMode.Loser:
                    return (n, o) => n.p1score == o.p1score;
                case ServeMode.Alternate:
                    return (n, o) => last ^= true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(serve), serve, null);
            }
        }

        public static float BallAcceleration()
        {
            return Loader.i.mode.ballAcceleration * Time.fixedDeltaTime * .1f;
        }

        public static float BallGravity()
        {
            return -Loader.i.mode.ballGravity * Time.fixedDeltaTime * .01f;
        }
        

    }
