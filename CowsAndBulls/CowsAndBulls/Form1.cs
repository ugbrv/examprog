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
                MessageBox.Show($"Победа c {countOfAttempts}-й попытки!");
                DoStop();
                return;
            }
            countOfRightNumbers = tempCountOfRightNumbers;
            countOfRightNumberPlaces = tempCountOfRightNumberPlaces;
            UpdateCountOfRightNumbers();
        }

        private void UpdateCountOfRightNumbers()
        {
            label4.Text = $"Угадано цифр {countOfRightNumbers}";
            label5.Text = $"Из них на своих местах {countOfRightNumberPlaces}";
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
                toolStripStatusLabel1.Text = $"Количество попыток: {countOfAttempts}";
            }
        }

        private void OnClickStart(object sender, EventArgs e)
        {
            if (button1.Text == "Старт")
            {
                button1.Text = "Стоп";
                hiddenNumber = GetRandomValue((int)numericUpDown1.Value);
                UpdateCountOfRightNumbers();
                //следующую строчку можно убрать
                MessageBox.Show(hiddenNumber);
                toolStripStatusLabel1.Text = "Введите число";
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