using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace test_tdd
{
    public class Game
    {
        private int[][] matr;
        private int whoFirst;
        public bool hdpc;//true - сейчас ход компьютера, false - ход пользователя
        public bool pervhod;  //true говорит о том, что у компьютера нынче первый ход. первым ходом компьютер должен ходить в
        //центр, дальше по ситуации. значение false переправляет на путь "дальше по ситуации"

        public Game()
        {
            matr = new int[3][];
            for (int i = 0; i < 3; i++)
                matr[i] = new int[3];

            whoFirst = 2; // первый ходит пользователь
            hdpc = false;
            pervhod = true;
        }

        public void initMatr()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matr[i][j] = 0;

        }

        public int[][] getMatr()
        {
            return matr;
        }

        public int getWhoFirst()
        {
            return whoFirst;
        }

        public void setWhoFirst(int who)
        {
            whoFirst = who;
        }

        public void hodComp(int i, int j)
        {
            matr[i][j] = 1;
        }

        public void firstHodComp(Graphics gPanel)
        {
            if (matr[1][1] == 0)
            {
                hodComp(1,1);   //компьютер первым ходом всегда ходит в центр(если есть возможность), независимо от того какими он играет
            }
            else
            {
                randomHodComp(gPanel);
            }
            paintHodComp(gPanel);
            hdpc = false;
            pervhod = false;
        }

        public void randomHodComp(Graphics gPanel)
        {
            //заполняем любую пустую клетку
            bool rand = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (rand == false)
                    {
                        if (matr[i][j] == 0)
                        {
                            hodComp(i, j);
                            rand = true;
                            hdpc = false;
                            paintHodComp(gPanel);
                        }
                    }
                }
            }
        }


        public void paintHodComp(Graphics gPanel)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (whoFirst == 1)   //если компьютер начинал, то 1 - это крестики
                    {
                        if (matr[i][j] == 1)
                        {
                            //Graphics gPanel = panel1.CreateGraphics();
                            Pen p = new Pen(Color.Black, 3);
                            gPanel.DrawLine(p, 2 + i * 100, 2 + j * 100, 98 + i * 100, 98 + j * 100);
                            gPanel.DrawLine(p, 98 + i * 100, 2 + j * 100, 2 + i * 100, 98 + j * 100);
                        }
                    }
                    else   //компьютер ходил вторым, 1 - нолики
                    {
                        if (matr[i][j] == 1)
                        {
                            //Graphics gPanel = panel1.CreateGraphics();
                            Pen p = new Pen(Color.Black, 3);
                            gPanel.DrawEllipse(p, 4 + i * 100, 4 + j * 100, 92, 92);
                        }
                    }
                }
            }
        }




    }
}
