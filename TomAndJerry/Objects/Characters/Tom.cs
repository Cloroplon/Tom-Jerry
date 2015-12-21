using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TomAndJerry.Factories;
using TomAndJerry.Objects.Items.Weapons;
using TomAndJerry.States;

namespace TomAndJerry.Objects.Characters
{
    public class Tom : Character
    {
        private int bombCounter = 0;
        private WeaponFactory weaponFactory;

        public Tom ()
        {
            weaponFactory = new WeaponFactory();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            bombCounter++;
            // this is around 2 seconds.
            if (bombCounter == 30)
            {
                bombCounter = 0;
                ThrowBomb();

            }
        }

        private void ThrowBomb()
        {
            Weapon bomb = weaponFactory.CreateWeapon("Bomb");
            bomb.LoadContent();
            GameState.gameObjects.Add(bomb);


        }


    }
}
