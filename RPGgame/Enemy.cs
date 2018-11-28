using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPGgame
{
    class Enemy
    {
        private Vector2 position;
        protected int health;
        protected int speed;
        protected int radius;

        public static List<Enemy> enemies = new List<Enemy>();

        public int Health { get => health; set => health = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Radius { get => radius; }
        public Vector2 Position { get => position;}

        public Enemy(Vector2 newPos)
        {
            position = newPos;
        }

        public void Update(GameTime gameTime, Vector2 playerPos)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveDir = playerPos - position;
            moveDir.Normalize();

            Vector2 checkPos = position;
            checkPos += moveDir * speed * dt;
            if (!Obstacles.didCollide(checkPos,radius)) {
                position += moveDir * speed * dt;
            }
        }
    }

    class Snake : Enemy {
        public Snake(Vector2 newPos) : base(newPos)
        {
            speed = 110;
            radius = 42;
            health = 3;
        }

    }

    class Eye : Enemy {
        public Eye(Vector2 newPos) : base(newPos)
        {
            speed = 70;
            radius = 45;
            health = 5;
        }
    }
        
}
