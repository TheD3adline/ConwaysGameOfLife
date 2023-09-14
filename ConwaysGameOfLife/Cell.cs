using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    internal class Cell
    {
        public bool Alive { get; set; }
        public bool AliveNextRound { get; set; }
        public bool LastGenerationStatus { get; set; }
        public int AmountOfNeighbours { get; set; }

        public Cell(bool alive) 
        {
            Alive = alive;
        }

        public void CheckNextCellStatus()
        {
            LastGenerationStatus = Alive;

            if (Alive == false)
            {
                if (AmountOfNeighbours == 3)
                    AliveNextRound = true;
            }
            else
            {
                if (AmountOfNeighbours < 2)
                    AliveNextRound = false;
                else if (AmountOfNeighbours == 2 || AmountOfNeighbours == 3)
                    AliveNextRound = true;
                else if (AmountOfNeighbours > 3)
                    AliveNextRound = false;
            }
        }

        public void Update()
        {
            Alive = AliveNextRound;
        }
    }
}