using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.States;

namespace TomAndJerry
{
    class Image
    {
        private float alpha;
        private string text, fontname, path;
        private Vector2 position, scale;
        private Rectangle sourceRectangle;

        private RenderTarget2D renderTarget2;

        private Texture2D texture;
        private Vector2 origin;
        private ContentManager contentManager;

        public Image()
        {
            this.Path = this.Text = String.Empty;
            this.Fontname = "Arial";
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Alpha = 1.0f; // means the image is fully showing;
            this.SourceRectangle = Rectangle.Empty;
        }

        public void LoadContent()
        {
            this.contentManager = new ContentManager(StateManager.Content.ServiceProvider, "Content");
            if (this.Path != String.Empty)
            {
                this.Texture = contentManager.Load<Texture2D>(this.Path);
            }
            Vector2 dimension = Vector2.Zero;

            if (Texture != null)
            {
                dimension.X += Texture.Width;
                dimension.Y += Texture.Height;
             }

        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Fontname
        {
            get { return fontname; }
            set { fontname = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public Rectangle SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }

        public RenderTarget2D RenderTarget2
        {
            get { return renderTarget2; }
            set { renderTarget2 = value; }
        }

    }
}
