using System;
using System.Collections.Generic;
using System.Text;

namespace Server_trabajo2
{
    class Ball
    {
        private int _force;
        public int Force {
            get => _force;
            set
            {
                if (value >= 10 && value <= 2000)
                {
                    _force = value;
                    deltaforce = _force;
                }
            }
        }

        int _angle;
        
        public int Angle
        {
            get => _angle;
            set
            {
                if (value >= 0 && value < 359)
                {
                    _angle = value;
                }
            }
        }

        bool _playing = false;
        public bool Playing
        {
            get => _playing;
        }

        double deltax;
        double deltay;
        double deltaforce;

        int x;
        int y;
        

        public Ball()
        {
            x = 10;
            deltax = (double)x;
            y = 10;
            deltay = (double)y;
        }

        public bool Move()
        {
            if (deltaforce > 0) {
                if (y<=1)
                {
                    _angle = 360 - _angle;
                }
                if (y>=588)
                {
                    _angle = 360 - _angle;
                }
                if (x<=1)
                {
                    if (_angle > 180)
                    {
                        _angle = 360 - (_angle - 180);
                    } else
                    {
                        _angle = 180 - _angle;
                    }
                }
                if (x>988)
                {
                    if (_angle > 180)
                    {
                        _angle = 360 - (_angle - 180);
                    }
                    else
                    {
                        _angle = 180 - _angle;
                    }
                }
                double radangle = (double)(_angle * Math.PI / 180);
                double offsetx = _force * Math.Cos(radangle)/50;
                double offsety = _force * Math.Sin(radangle)/50;
                deltax = deltax + offsetx;
                deltay = deltay + offsety;
                x = (int)deltax;
                y = (int)deltay;
                deltaforce = deltaforce - 0.5;
                _force = (int)deltaforce;
                _playing = true;
                return true;
            } else
            {
                deltaforce = 0;
                _force = 0;
                _playing = false;
                return false;
            }
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
