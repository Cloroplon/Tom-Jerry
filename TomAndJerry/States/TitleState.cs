using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TomAndJerry.States
{
   public class TitleState : State
    {
        public override void LoadContent()
        {
            base.LoadContent();
            // this just a pic to see if it is working. It can be replaced.
        
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
          
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            

            if (Game1.InputManager.KeyPressed(Keys.Enter) && !Game1.StateManager.IsTransioning)
            {
                Game1.StateManager.ChangeStates("MenuState");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
          
         

        }


    }
}
