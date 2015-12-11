using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.States;

/// <summary>
/// what this class does is that it is drawing the Image and the text as one and it gives a bigger control over them. 
/// </summary>
namespace TomAndJerry
{
    public class Image
    {
        public float Alpha;
        public string Text, FontName;
        public string Path;
        public Vector2 Position, Scale;
        public Rectangle SourceRectangle;
        [XmlIgnore]
        public SpriteFont Font;
        [XmlIgnore]
        public Texture2D Texture;

        private RenderTarget2D renderTarget;
        private Vector2 origin;
        private ContentManager contentManager;

        public Image()
        {
            this.Path = this.Text = String.Empty;
            this.FontName = "Arial";
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Alpha = 1.0f; // means the Image is fully showing;
            this.SourceRectangle = Rectangle.Empty;
        }

        public void LoadContent()
        {
            this.contentManager = new ContentManager(StateManager.Content.ServiceProvider, "Content");
            if (this.Path != String.Empty)
            {
                this.Texture = contentManager.Load<Texture2D>(this.Path);
            }
            Font = contentManager.Load<SpriteFont>(FontName);

            Vector2 dimension = Vector2.Zero;

            if (Texture != null)
            {
                dimension.X += Texture.Width;
                dimension.X += this.Font.MeasureString(Text).X;
            }

            if (Texture != null)
            {
                dimension.Y = Math.Max(Texture.Height, this.Font.MeasureString(Text).Y);

            }
            else
            {
                dimension.Y = this.Font.MeasureString(Text).Y;
            }

            if (this.SourceRectangle == Rectangle.Empty)
            {
                this.SourceRectangle = new Rectangle(0, 0, (int)dimension.X, (int)dimension.Y);
            }

            this.renderTarget = new RenderTarget2D(StateManager.GraphicsDevice, (int)dimension.X, (int)dimension.Y);
            StateManager.GraphicsDevice.SetRenderTarget(this.renderTarget);
            StateManager.GraphicsDevice.Clear(Color.Transparent);
            StateManager.SpriteBatch.Begin();
            if (Texture != null)
            {
                StateManager.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
            }
            StateManager.SpriteBatch.DrawString(this.Font, Text, Vector2.Zero, Color.White);
            StateManager.SpriteBatch.End();

            Texture = this.renderTarget;
            StateManager.GraphicsDevice.SetRenderTarget(null);
        }

        public void UnloadContent()
        {
            this.contentManager.Unload();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.origin = new Vector2(SourceRectangle.Width / 2, SourceRectangle.Height / 2); // taking the center of the pic
            spriteBatch.Draw(Texture, Position + origin, SourceRectangle, Color.White * this.Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f); // the mutipying with alpha will give us the transparancy. To the position is added to the origin for accurate displaying
        }

        
    }
}
