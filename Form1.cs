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

        private void button1_Click(object sender, EventArgs e)
        {
            int BaseDifficultyValue = 2;
            int DifficultyValue = BaseDifficultyValue * DifficultySelect.SelectedIndex;
            int GameColumnCount = (DifficultyValue + 4);
            int GameRowCount = (DifficultyValue + 2);
            int GameCellCount = GameColumnCount * GameRowCount;
            int CurrentCellCount = 0;
            _ = (0, 0);
            Label[] TestLabels = new Label[GameCellCount];

            GameWindow.ColumnCount = GameColumnCount;
            GameWindow.RowCount = GameRowCount;

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
                        TestLabels[CurrentCellCount] = new Label();
                        TestLabels[CurrentCellCount].Text = (CurrentCellCount + 1).ToString();
                        TestLabels[CurrentCellCount].Dock = DockStyle.Fill;
                        GameWindow.Controls.Add(TestLabels[CurrentCellCount],x,y);
                    }
                    CurrentCellCount++;
                }
                
            }
            CurrentCellCount = 0;


        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
