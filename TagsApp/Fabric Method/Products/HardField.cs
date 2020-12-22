using System;
using System.Drawing;

namespace TagsApp.Fabric_Method.Products
{
    public class HardField : Field
    {
        private readonly uint _chance;
        public HardField(uint w, uint l, uint chanceOfRandomCancel) :base(w, l, "bckwrd")
        {
            Tags[w-1, l-1] = new Tag();
            _chance = chanceOfRandomCancel;
            base.MoveTag(new FromToCoords(w - 1, l - 1, w - 1, l - 2));            
        }


        public override void MoveTag(FromToCoords fromTo)//overloaded func, can cancel users move
        {
            var random = new Random();
            var randomInt = random.Next(1, 101);
            
            if (randomInt > _chance)
            {
                base.MoveTag(fromTo);
            }
            else
            {         
                MakeRandomMove();
            }
        }

        private void MakeRandomMove()
        {
            FindEmptyTag(out uint x, out uint y);
            
            FromToCoords originalCoordinates = new FromToCoords(x, y, x, y);

            var moveWasMade = false;
            do
            {
                FromToCoords randomCoordinates = GetRandomDestinationCoordinates(originalCoordinates);

                try
                {
                    base.MoveTag(randomCoordinates);
                    moveWasMade = true;
                }
                catch (IndexOutOfRangeException exception)  
                {
                }
                
            } while (moveWasMade == false);
        }

        private FromToCoords GetRandomDestinationCoordinates(FromToCoords originalCoordinates)
        {
            Random random = new Random();

            int xOrY = random.Next(0, 2);
            int positionChange = random.Next(0, 2) * 2 - 1;
            
            if (xOrY == 0) // x
                originalCoordinates.ToX = (uint)(originalCoordinates.ToX + positionChange);
            else // y
                originalCoordinates.ToY = (uint)(originalCoordinates.ToY + positionChange);

            return originalCoordinates;
        }
        private void FindEmptyTag(out uint x, out uint y)
        {
            x = 0;
            y = 0;
            for(uint i = 0; i < Width; i++)
            {
                for(uint j = 0; j < Length; j++)
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
