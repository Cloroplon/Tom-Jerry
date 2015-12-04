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
        private string path;

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            path = "/Images/test.jpg";
            texture2D = contentManager.Load<Texture2D>(path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture2D);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO
        }
    }
}
