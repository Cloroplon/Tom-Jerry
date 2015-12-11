using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.States
{
    public class GameState : State
    {
        public Image Image;

        public override void LoadContent()
        {
            base.LoadContent();
            // this just a pic to see if it is working. It can be replaced.
            this.Image.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.Image.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            // just a random pic to see if our game is working for now. You can remove it any time.
            this.Image.Draw(spriteBatch);

        }
        
    }
}
