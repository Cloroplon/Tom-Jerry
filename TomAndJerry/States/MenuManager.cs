using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TomAndJerry.States
{
    public class MenuManager
    {
        private Menu menu;

        public MenuManager()
        {
            menu = new Menu();
            // we are adding a method to our event which we want to call when the id of item is set;
            this.menu.OnMenuChange += menu_OnMenuChange;
        }

        private void menu_OnMenuChange(object sender, EventArgs e)
        {
            XMLManager<Menu> xmlMenuManager = new XMLManager<Menu>();
            menu.UnloadContent();
            // transition
            menu = xmlMenuManager.Load(menu.ID);
            menu.LoadContent();
        }

        public void LoadContent(string menuPath)
        {
            if (menuPath != String.Empty)
            {
                menu.ID = menuPath;
            }
        }

        public void UnloadContent()
        {
            menu.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
          menu.Update(gameTime);   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
