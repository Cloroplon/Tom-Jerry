using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TomAndJerry.States
{
    public class Menu : IBasicMethods
    {
        
        public event EventHandler OnMenuChange;
        
        public string Axis;
        public string Effects;
        [XmlElement("Item")]
        public List<MenuItem> Items;

        private int itemNumber;
        private string id;

        public Menu()
        {
            this.id =  String.Empty;
            this.itemNumber = 0;
            this.Effects = String.Empty;
            Items = new List<MenuItem>();
        }

        void AlignMenuItems()
        {
            Vector2 dimensions = Vector2.Zero;
            foreach (var item in Items)
            {
                // we are adding the total width and height of all of our items
                dimensions += new Vector2(item.Image.SourceRectangle.Width,
                    item.Image.SourceRectangle.Height);
            }
            // this will show us where we will need to start drawing in order to centralize our text.
            dimensions = new Vector2(
                (Game1.StateManager.CurrentState.Dimensions.X - dimensions.X) / 2,
                (Game1.StateManager.CurrentState.Dimensions.Y - dimensions.Y) / 2);

            foreach (var item in Items)
            {
                // centralizing based on wide or height axis
                if (Axis == "X")
                {
                    item.Image.Position = new Vector2(dimensions.X,
                      (Game1.StateManager.CurrentState.Dimensions.Y - item.Image.SourceRectangle.Height) / 2);
                }
                else if (Axis == "Y")
                {
                    item.Image.Position = new Vector2((Game1.StateManager.CurrentState.Dimensions.X - item.Image.SourceRectangle.Width) / 2,
                    dimensions.Y);
                }
                dimensions += new Vector2(item.Image.SourceRectangle.Width,
                    item.Image.SourceRectangle.Height);
            }
        }

        public void LoadContent()
        {
            string[] effectsSplit = Effects.Split(':');
            
            foreach (var item in Items)
            {
                item.Image.LoadContent();
                foreach (var effect in effectsSplit)
                {
                    item.Image.ActivateEffect(effect);
                }
            }
            AlignMenuItems();
        }

        public void UnloadContent()
        {
            foreach (var item in Items)
            {
                item.Image.UnloadContent();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in Items)
            {
                item.Image.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Axis == "X")
            {
                if (Game1.InputManager.KeyPressed(Keys.Right))
                {
                    itemNumber++;
                }
                else if (Game1.InputManager.KeyPressed(Keys.Left))
                {
                    itemNumber--;
                }
            }
            else if (Axis == "Y")
            {
                if (Game1.InputManager.KeyPressed(Keys.Up))
                {
                    itemNumber--;
                }
                else if (Game1.InputManager.KeyPressed(Keys.Down))
                {
                    itemNumber++;
                }
            }
            // we are checking to not go outside boundaries
            if (itemNumber < 0)
            {
                itemNumber = 0;
            }
            else if (itemNumber > Items.Count - 1)
            {
                itemNumber = Items.Count - 1;
            }
            // after taking the input we are going to activate the item which corresponds to the itemNumber we are currently on.
            for (int i = 0; i < Items.Count; i++)
            {
                
                if (i == itemNumber)
                {
                    Items[i].Image.IsActive = true;
                    
                }
                else
                {

                    Items[i].Image.IsActive = false;
                   
                }
                Items[i].Image.Update(gameTime);
            }
            
            if (Items[0].Image.IsActive && Game1.InputManager.KeyPressed(Keys.Space) && !Game1.StateManager.IsTransioning )
            {
                Game1.StateManager.ChangeStates("GameState");
            }
            
        }



        public string ID
        {
            get { return this.id; }
            set
            {
                id = value;
                OnMenuChange(this, null);
            }
        }
    }
}
