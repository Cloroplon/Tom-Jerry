using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TomAndJerry.States
{
    public class GameOverState : State
    {
        private SpriteFont gameOverFont;
        private Vector2 gameTextPosition;
        private Vector2 overTextPosition;
        private Vector2 pointsTextPosition;
        

        public GameOverState()
        {
            gameTextPosition = new Vector2(210, 150);
            overTextPosition = new Vector2(240, 250);
            pointsTextPosition = new Vector2(260, 350);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            gameOverFont = this.contentManager.Load<SpriteFont>("Broadway");
            
        }

        public override void UnloadContent()
        {
            base.LoadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.Image.Draw(spriteBatch);
            spriteBatch.DrawString(gameOverFont, "GAME", gameTextPosition, Color.White);
            spriteBatch.DrawString(gameOverFont, "Over", overTextPosition, Color.White);
            spriteBatch.DrawString(this.Image.Font, $"Final Score: {GameState.points}", pointsTextPosition, Color.White);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Game1.InputManager.KeyPressed(Keys.Enter))
            {
                Environment.Exit(0);
            }
        }
        
        

       
    }
}
