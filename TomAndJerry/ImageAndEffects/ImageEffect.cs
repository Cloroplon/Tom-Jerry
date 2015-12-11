using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TomAndJerry
{
    public class ImageEffect
    {
        protected Image Image;
        private bool isActive = false;

        public ImageEffect()
        {
            
        }

        public virtual void LoadContent(ref Image Image)
        {
            this.Image = Image;
        }

        public virtual void UnloadContent()
        {
            
        }
        public virtual void Update(GameTime gameTime)
        {

        }

        public bool IsActive { get; set; }
        
    }
}
