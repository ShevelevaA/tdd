using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tdd
{
    public class Game
    {
        public Game()
        {
            matr = new int[3][];
            for (int i = 0; i < 3; i++)
                matr[i] = new int[3];
        }

        private int[][] matr;
       

        public void initMatr()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matr[i][j] = 0;
            matr[2][2] = 1;
        }

        public int[][] getMatr()
        {
            return matr;
        }
    }
}
