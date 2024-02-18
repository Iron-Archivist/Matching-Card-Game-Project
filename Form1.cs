using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace Matching_Card_Game_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            int BaseDifficultyValue = 2;
            int DifficultyValue = BaseDifficultyValue * DifficultySelect.SelectedIndex;
            int GameColumnCount = (DifficultyValue + 4);
            int GameRowCount = (DifficultyValue + 2);
            int GameCellCount = GameColumnCount * GameRowCount;
            int CurrentCellCount = 0;
            Label[] TestLabels = new Label[GameCellCount];

            Array.Clear(TestLabels, 0, TestLabels.Length);

            GameWindow.ColumnCount = GameColumnCount;
            GameWindow.RowCount = GameRowCount;

            TestLabels = CreateGame(TestLabels);

            for (int i = 0; i <= GameWindow.ColumnCount; i++)
            {
                GameWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); // Each column occupies 25% of the available space
            }

            for (int i = 0; i <= GameWindow.RowCount; i++)
            {
                GameWindow.RowStyles.Add(new RowStyle(SizeType.Percent, 50)); // Each row occupies 50% of the available space
            }

            for (int x = 0; x < GameWindow.ColumnCount; x++)
            {
                for (int y = 0; y < GameWindow.RowCount; y++)
                {
                    Control CurrentCell = GameWindow.GetControlFromPosition(x, y);
                    if (CurrentCell == null)
                    {

                        GameWindow.Controls.Add(TestLabels[CurrentCellCount],x,y);
                    }
                    CurrentCellCount++;
                }
                
            }
            CurrentCellCount = 0;


        }

        public Label[] CreateGame(Label[] GameCells) 
        {
            int[] RandomNumbers = new int[GameCells.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            Random RandomNums = new Random();

            for (j = 0; j < GameCells.Length;j++)
                {
                RandomNumbers[j] = RandomNums.Next();
                }

            for (i = 0;i < GameCells.Length;i++) 
                {
                if (i + 1 > ((GameCells.Length)/2))
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
                }

            Label[] RandomizedLabels = GameCells.OrderBy(GameCells => GameCells.Tag).ToArray();

            return GameCells;
        }



        public void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
