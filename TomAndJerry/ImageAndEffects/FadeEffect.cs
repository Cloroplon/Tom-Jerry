using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TomAndJerry.ImageAndEffects
{
    public class FadeEffect : ImageEffect
    {
        public float FadeSpeed;
        public bool Increase;

        public FadeEffect()
        {
            FadeSpeed = 1.0f;
            Increase = false;
        }

        public override void LoadContent(ref Image Image)
        {
            base.LoadContent(ref Image);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (this.Image.IsActive)
            {
                if (!Increase)
                {
                    this.Image.Alpha -= FadeSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    this.Image.Alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (this.Image.Alpha > 1.0f)
                {
                    Increase = false;
                    this.Image.Alpha = 1.0f;
                }
                else if (this.Image.Alpha < 0.0f)
                {
                    Increase = true;
                    this.Image.Alpha = 0.0f;
                }
                
            }
            else
            {
                this.Image.Alpha = 1.0f;
            }
        }
    }
}
