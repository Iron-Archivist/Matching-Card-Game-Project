using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Card_Game
{
    public partial class GameWindow : UserControl
    {

        int BaseDifficultyValue = 2;
        int DifficultyValue;
        int GameColumnCount;
        int GameRowCount;
        int GameCellCount;
        int CurrentCellCount = 0;
        int Matches = 0;
        Label LastObjectClicked;
        int LastObjectClickedPosition;
        PictureBox[] TestPictures;
        Label[] TestLabels;

        public GameWindow()
        {
            InitializeComponent();
        }

        public void CallGameStart(int SelectedDifficulty)
        {
                DifficultyValue = BaseDifficultyValue * SelectedDifficulty;
                GameColumnCount = (DifficultyValue + 4);
                GameRowCount = (DifficultyValue + 2);
                GameCellCount = GameColumnCount * GameRowCount;
                TestLabels = new Label[GameCellCount];
                TestPictures = new PictureBox[GameCellCount];
                var GameSet = (TestLabels, TestPictures);
                GameSet.TestLabels = TestLabels;
                GameSet.TestPictures = TestPictures;

                GameTable.ColumnCount = GameColumnCount;
                GameTable.RowCount = GameRowCount;

                GameSet = CreateGame(GameSet);
                TestLabels = GameSet.TestLabels;
                TestPictures = GameSet.TestPictures;
                FillCells(TestLabels, TestPictures);
                ResizeCells();
        }

        private (Label[], PictureBox[]) CreateGame((Label[] GameCells, PictureBox[] GameImages)GameSet)
        {
            Label[] GameCells = GameSet.GameCells;
            PictureBox[] GameImages = GameSet.GameImages;

            int[] RandomNumbers = new int[GameCells.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            Random RandomNums = new Random();

            for (j = 0; j < GameCells.Length; j++)
            {
                RandomNumbers[j] = RandomNums.Next();
            }

            for (i = 0; i < GameCells.Length; i++)
            {
                if (i + 1 > ((GameCells.Length) / 2))
                {
                    k = i - ((GameCells.Length) / 2);
                }
                else
                {
                    k = i;
                }
                GameCells[i] = new Label();
                GameImages[i] = new PictureBox();
                GameCells[i].Text = (k + 1).ToString();
                GameCells[i].Visible = false;
                GameImages[i].Image = (Image)Properties.Resources.ResourceManager.GetObject("CardBack");
                GameCells[i].Dock = DockStyle.Fill;
                GameImages[i].Dock = DockStyle.Fill;
                GameImages[i].SizeMode = PictureBoxSizeMode.StretchImage;
                GameCells[i].Tag = RandomNumbers[i];
                GameImages[i].Tag = RandomNumbers[i];
                GameCells[i].Click += GameObjectClick;
                GameImages[i].Click += GameImageClick;
            }

            Label[] RandomizedLabels = GameCells.OrderBy(Label => Label.Tag).ToArray();
            PictureBox[] RandomizedImages = GameImages.OrderBy(Label => Label.Tag).ToArray();
            GameSet.GameCells = RandomizedLabels;
            GameSet.GameImages = RandomizedImages;

            return GameSet;
        }
        private void FillCells(Label[] Labels, PictureBox[] Pictures)
        {         
            for (int x = 0; x < GameTable.ColumnCount; x++)
            {
                for (int y = 0; y < GameTable.RowCount; y++)
                {
                    Control CurrentCell = GameTable.GetControlFromPosition(x, y);
                    if (CurrentCell == null)
                    {
                       GameTable.Controls.Add(Pictures[CurrentCellCount], x, y);
                       GameTable.Controls.Add(Labels[CurrentCellCount], x, y);
                    }
                    CurrentCellCount++;
                }

            }
            CurrentCellCount = 0;
        }
        private void ResizeCells()
        {
            for (int i = 0; i < GameTable.ColumnCount; i++)
            {
                GameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            }

            for (int i = 0; i < GameTable.RowCount; i++)
            {
                GameTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            }
        }
        private void GameObjectClick(object sender, EventArgs e)
        {
            int ClickedArrayPosition = Array.IndexOf(TestLabels, sender);
            Label ClickedObject = (Label)sender;
            TestPictures[ClickedArrayPosition].Image = (Image)Properties.Resources.ResourceManager.GetObject("Card" + (ClickedObject.Text));

            if (LastObjectClicked != null)
            {
                if (ClickedObject == LastObjectClicked)
                {
                    MessageBox.Show("same thing clicked twice");
                    LastObjectClicked = null;
                }
                else if (ClickedObject.Text == LastObjectClicked.Text)
                {
                    Matches = Matches + 1;
                    MessageBox.Show("Correct Match." + Matches.ToString() + "/ " + GameCellCount.ToString());
                    TestPictures[ClickedArrayPosition].Visible = false;
                    TestPictures[LastObjectClickedPosition].Visible = false;
                    LastObjectClicked = null;
                    
                    if (Matches >= (GameCellCount/2))
                    {
                        MessageBox.Show("Victory");
                    }


                }
                else
                {
                    MessageBox.Show("No Match");
                    TestPictures[ClickedArrayPosition].Image = (Image)Properties.Resources.ResourceManager.GetObject("CardBack");
                    TestPictures[LastObjectClickedPosition].Image = (Image)Properties.Resources.ResourceManager.GetObject("CardBack");
                    LastObjectClicked = null;
                }
            }
            else
            {
                LastObjectClicked = ClickedObject;
                LastObjectClickedPosition = ClickedArrayPosition;
            }


        }
        private void GameImageClick(object sender, EventArgs e)
        {
            int ArrayPosition = Array.IndexOf(TestPictures, sender);
            GameObjectClick(TestLabels[ArrayPosition], EventArgs.Empty);
        }

    }
}
