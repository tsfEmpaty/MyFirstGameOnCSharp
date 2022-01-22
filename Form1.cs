using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace MyFirstGameOnCSharp
{
    public partial class Form1 : Form
    {
        // Creating array and variables which need for game
        int[,] gameField = new int[13, 25];
        int hero1_i, hero1_j, hero2_i, hero2_j;

        // Inrialization form
        public Form1()
        {
            InitializeComponent();
        }

        // General game logic
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                MoveUp();
            }
            if (e.KeyData == Keys.A)
            {
                MoveLeft();
            }
            if (e.KeyData == Keys.S)
            {
                MoveDown();
            }
            if (e.KeyData == Keys.D)
            {
                MoveRight();
            }
        }

        // Method which drawing border on the game field
        public void DrawBorder(PictureBox P, int x, int y)
        {
            Graphics G = P.CreateGraphics();
            Image block = Properties.Resources.block;
            G.DrawImage(block, x, y);
        }

        // Method which drawing grass on the game field
        public void DrawGrass(PictureBox P, int x, int y)
        {
            Graphics G = P.CreateGraphics();
            Image block = Properties.Resources.grass;
            G.DrawImage(block, x, y);
        }

        // Method which drawing first hero on the game field
        public void DrawHero1(PictureBox P, int x, int y)
        {
            Graphics G = P.CreateGraphics();
            Image block = Properties.Resources.Hero1;
            G.DrawImage(block, x, y);
        }

        // Method which drawing second hero on the game field
        public void DrawHero2(PictureBox P, int x, int y)
        {
            Graphics G = P.CreateGraphics();
            Image block = Properties.Resources.Hero2;
            G.DrawImage(block, x, y);
        }

        // Method which drawing door on the game field
        public void DrawDoor(PictureBox P, int x, int y)
        {
            Graphics G = P.CreateGraphics();
            Image block = Properties.Resources.Door;
            G.DrawImage(block, x, y);
        }

        private void buttonLoadLevel_Click(object sender, EventArgs e)
        {
            GenerateLevel();
        }

        // Method for moving up
        public void MoveUp()
        {
            if (gameField[hero1_i - 1, hero1_j] == 0)
            {
                hero1_i--;
                gameField[hero1_i, hero1_j] = 2;
                gameField[hero1_i + 1, hero1_j] = 0;
                DrawHero1(pictureBox1, hero1_j * 20, hero1_i * 20);
                DrawGrass(pictureBox1, hero1_j * 20, (hero1_i + 1) * 20);
            }
            if (gameField[hero2_i - 1, hero2_j] == 0)
            {
                hero2_i--;
                gameField[hero2_i, hero2_j] = 3;
                gameField[hero2_i + 1, hero2_j] = 0;
                DrawHero2(pictureBox1, hero2_j * 20, hero2_i * 20);
                DrawGrass(pictureBox1, hero2_j * 20, (hero2_i + 1) * 20);
            }
        }

        // Method for moving left
        public void MoveLeft()
        {
            if (gameField[hero1_i, hero1_j - 1] == 0)
            {
                hero1_j--;
                gameField[hero1_i, hero1_j] = 2;
                gameField[hero1_i, hero1_j + 1] = 0;
                DrawHero1(pictureBox1, hero1_j * 20, hero1_i * 20);
                DrawGrass(pictureBox1, (hero1_j + 1) * 20, hero1_i * 20);
            }
            if (gameField[hero2_i, hero2_j + 1] == 0)
            {
                hero2_j++;
                gameField[hero2_i, hero2_j] = 3;
                gameField[hero2_i, hero2_j - 1] = 0;
                DrawHero2(pictureBox1, hero2_j * 20, hero2_i * 20);
                DrawGrass(pictureBox1, (hero2_j - 1) * 20, hero2_i * 20);
            }
        }

        // Method for moving down
        public void MoveDown()
        {
            if (gameField[hero1_i + 1, hero1_j] == 0)
            {
                hero1_i++;
                gameField[hero1_i, hero1_j] = 2;
                gameField[hero1_i - 1, hero1_j] = 0;
                DrawHero1(pictureBox1, hero1_j * 20, hero1_i * 20);
                DrawGrass(pictureBox1, hero1_j * 20, (hero1_i - 1) * 20);
            }
            if (gameField[hero2_i + 1, hero2_j] == 0)
            {
                hero2_i++;
                gameField[hero2_i, hero2_j] = 3;
                gameField[hero2_i - 1, hero2_j] = 0;
                DrawHero2(pictureBox1, hero2_j * 20, hero2_i * 20);
                DrawGrass(pictureBox1, hero2_j * 20, (hero2_i - 1) * 20);
            }
        }

        // Method for moving right
        public void MoveRight()
        {
            if (gameField[hero1_i, hero1_j + 1] == 0)
            {
                hero1_j++;
                gameField[hero1_i, hero1_j] = 2;
                gameField[hero1_i, hero1_j - 1] = 0;
                DrawHero1(pictureBox1, hero1_j * 20, hero1_i * 20);
                DrawGrass(pictureBox1, (hero1_j - 1) * 20, hero1_i * 20);
            }
            if (gameField[hero2_i, hero2_j - 1] == 0)
            {
                hero2_j--;
                gameField[hero2_i, hero2_j] = 3;
                gameField[hero2_i, hero2_j + 1] = 0;
                DrawHero2(pictureBox1, hero2_j * 20, hero2_i * 20);
                DrawGrass(pictureBox1, (hero2_j + 1) * 20, hero2_i * 20);
            }
        }

        public void GenerateLevel()
        {
            // Creating varibles for generating level
            string path = "C:\\Users\\DAVA\\source\\repos\\MyFirstGameOnCSharp\\level1.txt";
            string[] lines = File.ReadAllLines(path).ToArray();
            string s = "";

            // Generating the level
            for (int i = 0; i <= 12; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    s = Convert.ToString(lines[i][j]);
                    gameField[i, j] = Convert.ToInt32(s);

                    if (gameField[i, j] == 1)
                    {
                        DrawBorder(pictureBox1, j * 20, i * 20);
                    }
                    if (gameField[i, j] == 0)
                    {
                        DrawGrass(pictureBox1, j * 20, i * 20);
                    }
                    if (gameField[i, j] == 2)
                    {
                        DrawHero1(pictureBox1, j * 20, i * 20);
                        hero1_i = i; hero1_j = j;
                    }
                    if (gameField[i, j] == 3)
                    {
                        DrawHero2(pictureBox1, j * 20, i * 20);
                        hero2_i = i; hero2_j = j;
                    }
                    if (gameField[i, j] == 5)
                    {
                        DrawDoor(pictureBox1, j * 20, i * 20);
                    }
                }
            }
        }
    }
}
