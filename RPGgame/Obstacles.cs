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
    class Obstacles
    {
        protected Vector2 position;
        protected int radius;
        protected Vector2 hitPos;

        public static List<Obstacles> obstacles = new List<Obstacles>();

        public Vector2 Position { get => position;}
        public int Radius { get => radius;}
        public Vector2 HitPos { get => hitPos; set => hitPos = value; }

        public Obstacles(Vector2 newPos)
        {
            position = newPos;
        }

        public static bool didCollide(Vector2 otherPos,int otherRad)
        {
            foreach(Obstacles ob in Obstacles.obstacles)
            {
                int sum = ob.Radius + otherRad;
                if(Vector2.Distance(ob.HitPos,otherPos) < sum)
                return true;
            }
            return false; 
        }
    }

    class Tree : Obstacles
    {
        public Tree(Vector2 newPos) : base(newPos) {
            radius =  20;
            hitPos = new Vector2(position.X + 64, position.Y + 150);
        }
    }

    class Bush : Obstacles
    {
        public Bush (Vector2 newPos) : base(newPos)
        {
            radius = 32;
            hitPos = new Vector2(position.X + 56, position.Y + 57);
        }
    }


}
