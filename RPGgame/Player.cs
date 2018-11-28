using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    class Player
    {
        private Vector2 position = new Vector2(100, 100);
        private int health = 3;
        private int speed = 200;
        private int radius = 56;
        private Dir direction = Dir.Down;
        private float healthTimer = 0f;
        private bool isMoving = false;
        private KeyboardState kStateOld = Keyboard.GetState();

        private AnimatedSprite anim;
        private AnimatedSprite[] animations = new AnimatedSprite[4];

        public int Speed { get => speed; set => speed = value; }
        public int Health { get => health; set => health = value; }
        public Vector2 Position { get => position;}
        public AnimatedSprite Anim { get => anim; set => anim = value; }
        public AnimatedSprite[] Animations { get => animations; set => animations = value; }
        public int Radius { get => radius; set => radius = value; }
        public float HealthTimer { get => healthTimer; set => healthTimer = value; }

        public void setX(float newX)
        {
            position.X = newX;
        }

        public void setY(float newY)
        {
            position.Y = newY;
        }

        public void update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (healthTimer > 0)
                healthTimer -= dt;

            anim = animations[(int)direction];

            if (isMoving) // apply animation
                anim.Update(gameTime);
            else //player will appear as standing with frame [1] from the atlas.
                anim.CurrentFrame = 1;

            isMoving = false;

            if (kstate.IsKeyDown(Keys.Right))
            {
                direction = Dir.Right;
                isMoving = true;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                direction = Dir.Left;
                isMoving = true;
            }

            if (kstate.IsKeyDown(Keys.Up))
            {
                direction = Dir.Up;
                isMoving = true;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                direction = Dir.Down;
                isMoving = true;
            }

            if (isMoving) {
                Vector2 checkPosition = position;
                switch (direction)
                {
                    case Dir.Right:
                        checkPosition.X += speed * dt;
                        if (!Obstacles.didCollide(checkPosition, radius))
                        {
                            position.X += speed * dt;
                        }
                        break;
                    case Dir.Left:
                        checkPosition.X -= speed * dt;
                        if (!Obstacles.didCollide(checkPosition, radius))
                        {
                            position.X -= speed * dt;
                        }
                        break;
                    case Dir.Down:
                        checkPosition.Y += speed * dt;
                        if (!Obstacles.didCollide(checkPosition, radius))
                        {
                            position.Y += speed * dt;
                        }
                        break;
                    case Dir.Up:
                        checkPosition.Y -= speed * dt;
                        if (!Obstacles.didCollide(checkPosition, radius))
                        {
                            position.Y -= speed * dt;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (kstate.IsKeyDown(Keys.Space) && kStateOld.IsKeyUp(Keys.Space)) 
            {
                Projectile.projectiles.Add(new Projectile(position,direction));
            }
            kStateOld = kstate;
        }
    }
}
