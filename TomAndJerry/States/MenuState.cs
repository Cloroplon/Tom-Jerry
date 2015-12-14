﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.States
{
    public class MenuState : State
    {
        private MenuManager menuManager;
        

        public MenuState()
        {
            menuManager = new MenuManager();
            
        }

        public override void LoadContent()
        {
            base.LoadContent();
            menuManager.LoadContent("../../../Load/Menu.xml");
            this.Image.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.Image.UnloadContent();
            menuManager.UnloadContent();
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.Image.Update(gameTime);
            menuManager.Update(gameTime);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.Image.Draw(spriteBatch);
            menuManager.Draw(spriteBatch);
            
        }
    }
}
