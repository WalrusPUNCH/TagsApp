using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Command;

namespace TagsApp.Fabric_Method
{
    public class HardField : Field
    {
        private uint Chance;
        private ICommand undocomm;
        public HardField(uint w, uint l, uint chanceOfRandomCancel, ICommand undo) :base(w, l)
        {
            Name = "bckwrd";
            Tags[w-1, l-1] = new Tag();
            Chance = chanceOfRandomCancel;
            base.MoveTag(new FromToCoords(w - 1, l - 1, w - 1, l - 2));
            undocomm = undo;
        }


        public override void MoveTag(FromToCoords fromTo)//overloaded func, can cancel users move
        {
            Random rnd = new Random();
            int randomInt = rnd.Next(1, 101);
            
            if (randomInt>Chance)
            {
                base.MoveTag(fromTo);
            }
            else
            {
                undocomm.Execute(); 
                MakeRandomMove();
            }
        }
        private void MakeRandomMove()
        {
            uint x = 0;
            uint y = 0;
            for(uint i = 0; i<Width; i++)
            {
                for(uint j = 0; j< Length; j++)
                {
                    if(Tags[i, j].Name ==  Tag.Empty)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            
            int rndmovecounter = 0;
            while (rndmovecounter < 2)
            {
                rndmovecounter++;

                var fromTo = ii(x, y);

                try
                {
                    base.MoveTag(fromTo);
                }
                catch
                {
                    rndmovecounter--;
                }
            }
        }
        private FromToCoords ii(uint x, uint y)
        {
            FromToCoords fromTo = new FromToCoords(x, y, x, y);
            Random r = new Random();
            int x_Or_y = r.Next(0, 2);
            int plus_or_minus = r.Next(0, 2);
            if (x_Or_y == 0)
            {
                if (plus_or_minus == 0)
                {
                    fromTo.toX++;
                    x++;
                }
                else
                {
                    x--;
                    fromTo.toX--;
                }
            }
            else
            {
                if (plus_or_minus == 0)
                {
                    y++;
                    fromTo.toY++;
                }
                else
                {
                    y--;
                    fromTo.toY--;
                }
            }
            return fromTo;
        }
    }
}
