using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.States
{
    class GameState : State
    {
        private Texture2D texture2D;
        

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            // this just a pic to see if it is working. It can be replaced.
            texture2D = contentManager.Load<Texture2D>("Start");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // just a random pic to see if our game is working for now. You can remove it any time.
            spriteBatch.Draw(texture2D,new Vector2(0,0));
            
        }

        public override void Update(GameTime gameTime)
        {
            // TODO
        }
    }
}
