using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TomAndJerry.ImageAndEffects
{
   public  class SpriteSheetEffect : ImageEffect
   {
        // we are setting the default current frame and amount of frames in the objects LoadContent
       public int FrameCounter;
       public int SwitchFrame;
       public byte CurrentFrame; // this shows on which picture we are from the spritesheed. It is nor Vector2 because we will actually have only one line of images.
       public byte AmountOfFrames; // this will be all of the pictures on the sprite. Again not Vector2 because we have only one line


       public SpriteSheetEffect() : base()
       {
          
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
       }
    }
}
