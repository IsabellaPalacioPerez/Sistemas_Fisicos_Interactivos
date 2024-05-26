using System;
using System.Collections.Generic;
using System.Text;

namespace Server_trabajo2
{
    class Hole
    {
        
        int x;
        int y;

        public Hole()
        {
            Random random = new Random();
            x = random.Next(0, 200);
            y = random.Next(0, 200);
        }

        public Hole(int nx, int ny)
        {
            Random random = new Random();
            x = random.Next(130, nx);
            y = random.Next(130, ny);
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void Delete()
        {

        }

    }
}
