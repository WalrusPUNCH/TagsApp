using System;
using System.Drawing;

namespace TagsApp.Fabric_Method.Products
{
    public class HardField : Field
    {
        private readonly uint _chance;
        public HardField(uint w, uint l, uint chanceOfRandomCancel) :base(w, l, "bckwrd")
        {
           // Name = "bckwrd";
            Tags[w-1, l-1] = new Tag();
            _chance = chanceOfRandomCancel;
            base.MoveTag(new FromToCoords(w - 1, l - 1, w - 1, l - 2));            
        }


        public override void MoveTag(FromToCoords fromTo)//overloaded func, can cancel users move
        {
            Random rnd = new Random();
            int randomInt = rnd.Next(1, 101);
            
            if (randomInt>_chance)
            {
                base.MoveTag(fromTo);
            }
            else
            {         
                Core.UndoCommand.Execute();
 
                MakeRandomMove();
            }
        }

        private void MakeRandomMove()
        {
            FindEmptyTag(out uint x, out uint y);
            
            int counter = 0;
            while (counter < 2)
            {
                counter++;
                FromToCoords fromTo = new FromToCoords(x, y, x, y);
                Random r = new Random();
                int xory = r.Next(0, 2);
                uint positionChange = (uint)(r.Next(0,2) * 2 - 1);
                if (xory == 0)
                {
                    fromTo.ToX += positionChange;
                    x += positionChange;
                }
                else
                {
                    fromTo.ToY += positionChange;
                    y += positionChange;
                }

                try
                {
                    base.MoveTag(fromTo);
                }
                catch (InvalidOperationException exception)
                {
                    counter--;
                }
            }
        }

        private void FindEmptyTag(out uint x, out uint y)
        {
            x = 0;
            y = 0;
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
            
        }
    }
}
