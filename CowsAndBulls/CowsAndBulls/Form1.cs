using System.Windows.Forms;

namespace CowsAndBulls
{
    public partial class Form1 : Form
    {
        private string number;

        private string hiddenNumber;

        private int countOfRightNumbers;

        private int countOfRightNumberPlaces;

        private int countOfAttempts;

        public Form1()
        {
            InitializeComponent();
        }

        public void DoAComparison(string numberToCompare)
        {
            var tempCountOfRightNumbers = 0;
            var tempCountOfRightNumberPlaces = 0;
            var unrepeatingNumbers = new List<char>();
            for (var i = 0; i < numberToCompare.Length; i++)
            {
                if (hiddenNumber[i] == numberToCompare[i])
                {
                    tempCountOfRightNumberPlaces++;
                }
                if (hiddenNumber.Contains(numberToCompare[i])) 
                {
                    tempCountOfRightNumbers++;
                }
            }
            if (tempCountOfRightNumberPlaces == numberToCompare.Length)
            {
                MessageBox.Show($"������ c {countOfAttempts}-� �������!");
                DoStop();
                return;
            }
            countOfRightNumbers = tempCountOfRightNumbers;
            countOfRightNumberPlaces = tempCountOfRightNumberPlaces;
            UpdateCountOfRightNumbers();
        }

        private void UpdateCountOfRightNumbers()
        {
            label4.Text = $"������� ���� {countOfRightNumbers}";
            label5.Text = $"�� ��� �� ����� ������ {countOfRightNumberPlaces}";
        }

        public void DoStop()
        {
            countOfAttempts = 0;
            toolStripStatusLabel1.Text = "";
            countOfRightNumbers = 0;
            countOfRightNumberPlaces = 0;
            textBox1.Clear();
            UpdateCountOfRightNumbers();
        }

        private void ExecuteAttempt(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoAComparison(textBox1.Text);
                countOfAttempts++;
                toolStripStatusLabel1.Text = $"���������� �������: {countOfAttempts}";
            }
        }

        private void OnClickStart(object sender, EventArgs e)
        {
            if (button1.Text == "�����")
            {
                button1.Text = "����";
                hiddenNumber = GetRandomValue((int)numericUpDown1.Value);
                UpdateCountOfRightNumbers();
                //��������� ������� ����� ������
                MessageBox.Show(hiddenNumber);
                toolStripStatusLabel1.Text = "������� �����";
            }
            else DoStop();
        }

        private static string GetRandomValue(int lengthOfNumber)
        {
            Random random = new Random();
            return random.Next((int)Math.Pow(10, lengthOfNumber - 1), (int)Math.Pow(10, lengthOfNumber)).ToString();
        }

        private void OnClickStop(object sender, EventArgs e)
        {
            Dispose(true);
        }
    }
}