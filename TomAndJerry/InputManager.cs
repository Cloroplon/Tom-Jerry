using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using TomAndJerry.States;

namespace TomAndJerry
{
    public class InputManager
    {
        KeyboardState currentKeyState, prevKeyState;

        public void Update()
        {
            prevKeyState = currentKeyState;
            if (!Game1.StateManager.IsTransioning)
            {
                currentKeyState = Keyboard.GetState();
            }

         }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KeyRelease(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KeyIsDown(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
