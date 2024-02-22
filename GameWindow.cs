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
        Label LastObjectClicked;
        string LastValueClicked;

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
                Label[] TestLabels = new Label[GameCellCount];

                GameTable.ColumnCount = GameColumnCount;
                GameTable.RowCount = GameRowCount;

                TestLabels = CreateGame(TestLabels);
                FillCells(TestLabels);
                ResizeCells();
        }

        private Label[] CreateGame(Label[] GameCells)
        {
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
                GameCells[i].Text = (k + 1).ToString();
                GameCells[i].Dock = DockStyle.Fill;
                GameCells[i].Tag = RandomNumbers[i];
                GameCells[i].Click += GameObjectClick;
            }

            Label[] RandomizedLabels = GameCells.OrderBy(Label => Label.Tag).ToArray();

            return RandomizedLabels;
        }
        private void FillCells(Label[] Labels)
        {
            for (int x = 0; x < GameTable.ColumnCount; x++)
            {
                for (int y = 0; y < GameTable.RowCount; y++)
                {
                    Control CurrentCell = GameTable.GetControlFromPosition(x, y);
                    if (CurrentCell == null)
                    {

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
                GameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); // Each column occupies 25% of the available space
            }

            for (int i = 0; i < GameTable.RowCount; i++)
            {
                GameTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50)); // Each row occupies 50% of the available space
            }
        }
        private void GameObjectClick(object sender, EventArgs e)
        {
            Label ClickedObject = (Label)sender;
            if (LastObjectClicked != null)
            {
                if (ClickedObject == LastObjectClicked)
                {
                    MessageBox.Show("same thing clicked twice");
                    LastObjectClicked = null;
                    LastValueClicked = null;
                }
                else if (ClickedObject.Text == LastObjectClicked.Text)
                {
                    MessageBox.Show("Correct Match.");
                    LastObjectClicked = null;
                    LastValueClicked = null;
                }
                else
                {
                    MessageBox.Show("No Match");
                    LastObjectClicked = null;
                    LastValueClicked = null;
                }
            }
            else
            {
                LastObjectClicked = ClickedObject;
                LastValueClicked = ClickedObject.Text;
            }


        }

    }
}
