using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Laba_Ku_N1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int len_max = 20500;
        public int countString = 500;

        public List<double[]> times1 = new List<double[]>();
        public List<double[]> times2 = new List<double[]>();



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete("data.txt");

            Form2 form2 = new Form2();
            form2.ShowDialog();

            if (form2.label3.Text == "Тип генерации:\r\nСлучайный\r\n")
            {
                len_max = 0;
                int minL = int.Parse(form2.textBox2.Text);
                int maxL = int.Parse(form2.textBox1.Text);

                countString = int.Parse(form2.textBox3.Text);

                Random rand = new Random();
                for(int i = 0; i < countString; i++)
                {
                    int randValue;
                    string str = "";
                    char letter;



                    int stringlen = rand.Next(minL, maxL);
                    
                        for (int j = 0; j < stringlen; j++)
                        {
                            randValue = rand.Next(0, 64);

                            letter = Convert.ToChar(randValue + 1040);

                            str = str + letter;
                        }

                    richTextBox1.Text += i.ToString() + ". " + str + "\n";

                    len_max += str.Length;

                    using (StreamWriter writer = new StreamWriter("data.txt", true))
                    {
                        writer.WriteLine(str);
                    }
                }
            }
            else
            {
                len_max = int.Parse((string)form2.textBox3.Text);
                richTextBox1.Text = "";

                using (StreamReader sr = new StreamReader("C:\\Users\\яяяяяяяя\\Desktop\\SAASZ\\C#\\Laba_Ku_N1\\Laba_Ku_N1\\Текстовый документ.txt"))
                {
                    for (int i = 0; i< len_max; i++)
                    {
                        richTextBox1.Text += i.ToString() + sr.ReadLine() + "\n";
                    }
                }
                

                string[] words = richTextBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                using (StreamWriter writer = new StreamWriter("data.txt", true))
                {
                    foreach (string word in words)
                    {
                        writer.WriteLine(word);
                    }
                }
            }




        }


        private int naivStringP(string t, string p)
        {
            if (string.IsNullOrEmpty(p))
                return -1;

            int m = p.Length;
            int n = t.Length;

            t = t.ToLower();
            p = p.ToLower();

            int index_of = -1;

            for (int i = 0; i <= n - m; i++)
            {
                if (t.Substring(i, m) == p)
                {
                    index_of = i;
                    break;
                }
            }
            return index_of;        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox1.Text = "";



            //string[] Mass = File.ReadAllLines("data.txt");

            //List<int[]> ints = new List<int[]>();

            //Timer timer = new Timer();

            //timer.Start();

            //for (int i = 0; i < Mass.Length; i++)
            //{
            //    if (naivStringP(Mass[i], textBox1.Text) != -1)
            //    {
            //        ints.Add(new int[] { i, naivStringP(Mass[i], textBox1.Text) });
            //    }
            //}

            //timer.Stop();

            //for (int i = 0; i < ints.Count; i++)
            //{
            //    richTextBox1.Text += ints[i][0].ToString() + " " + Mass[ints[i][0]] + "(" + ints[i][1] + ")" + "\n";
            //}

            //label3.Text = "Time:" + timer.Duration.ToString();
            //times1.Add(new double[] { timer.Duration, len_max });

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text == "")
            //    return;

            //BoyerMoore2 sech = new BoyerMoore2(textBox2.Text.ToLower());

            //richTextBox1.Text = "";

            //string[] Mass = File.ReadAllLines("data.txt");

            //List<int[]> ints = new List<int[]>();

            //Timer timer = new Timer();

            //timer.Start();

            //for (int i = 0; i < Mass.Length; i++)
            //{
            //    if (sech.Search(Mass[i].ToLower(), 0) != -1)
            //    {
            //        ints.Add(new int[] { i, sech.Search(Mass[i].ToLower()) });
            //    }
            //}

            //timer.Stop();

            //for (int i = 0; i < ints.Count; i++)
            //{
            //    richTextBox1.Text += ints[i][0].ToString() + " " + Mass[ints[i][0]] + "(" + ints[i][1] + ")" + "\n";
            //}

            ////using (StreamWriter writer = new StreamWriter("data_time_BoyerMoore.txt", true))
            ////{
            ////    writer.WriteLine(timer.Duration);
            ////    writer.WriteLine(len_max);
            ////}

            //label4.Text ="Time:" +  timer.Duration.ToString();
            //times2.Add(new double[] { timer.Duration, len_max });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

            form3.chart1.Series[0].Points.Clear();
            form3.chart1.Series[1].Points.Clear();

            for(int i = 0; i < times1.Count; i++) 
            {
                form3.chart1.Series[0].Points.AddXY(times1[i][1], times1[i][0]);
            }
            for (int i = 0; i < times2.Count; i++)
            {
                form3.chart1.Series[1].Points.AddXY(times2[i][1], times2[i][0]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";



            string[] Mass = File.ReadAllLines("data.txt");

            List<int[]> ints = new List<int[]>();

            Timer timer = new Timer();

            timer.Start();

            for (int i = 0; i < Mass.Length; i++)
            {
                if (naivStringP(Mass[i], textBox1.Text) != -1)
                {
                    ints.Add(new int[] { i, naivStringP(Mass[i], textBox1.Text) });
                }
            }

            timer.Stop();

            for (int i = 0; i < ints.Count; i++)
            {
                richTextBox1.Text += ints[i][0].ToString() + " " + Mass[ints[i][0]] + "(" + ints[i][1] + ")" + "\n";
            }

            label3.Text = "Time:" + timer.Duration.ToString();

            SORtCOM sorting_el = new SORtCOM();

            

            times1.Add(new double[] { timer.Duration, len_max });

            times1.Sort(sorting_el);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                return;

            BoyerMoore2 sech = new BoyerMoore2(textBox2.Text.ToLower());

            richTextBox1.Text = "";

            string[] Mass = File.ReadAllLines("data.txt");

            List<int[]> ints = new List<int[]>();

            Timer timer = new Timer();

            timer.Start();

            for (int i = 0; i < Mass.Length; i++)
            {
                if (sech.Search(Mass[i].ToLower(), 0) != -1)
                {
                    ints.Add(new int[] { i, sech.Search(Mass[i].ToLower()) });
                }
            }

            timer.Stop();

            for (int i = 0; i < ints.Count; i++)
            {
                richTextBox1.Text += ints[i][0].ToString() + " " + Mass[ints[i][0]] + "(" + ints[i][1] + ")" + "\n";
            }


            label4.Text = "Time:" + timer.Duration.ToString();
            
            times2.Add(new double[] { timer.Duration, len_max });

            SORtCOM sorting_el = new SORtCOM();

            times2.Sort(sorting_el);
        }
    }

    abstract class SearchBase
    {
        public const int InvalidIndex = -1;
        protected string _pattern;
        public SearchBase(string pattern) { _pattern = pattern; }
        public abstract int Search(string text, int startIndex);
        public int Search(string text) { return Search(text, 0); }
    }


    class SORtCOM : IComparer<double[]>
    {
        public int Compare(double[] o1, double[] o2 )
        {
            if (o1[1] > o2[1])
                return 1;

            else return -1;
        }
    }


    class BoyerMoore2 : SearchBase
    {
        private byte[] _skipArray;

        public BoyerMoore2(string pattern)
            : base(pattern)
        {
            _skipArray = new byte[0x10000];

            for (int i = 0; i < _skipArray.Length; i++)
                _skipArray[i] = (byte)_pattern.Length;
            for (int i = 0; i < _pattern.Length - 1; i++)
                _skipArray[_pattern[i]] = (byte)(_pattern.Length - i - 1);
        }

        public override int Search(string text, int startIndex)
        {
            int i = startIndex;

            while (i <= (text.Length - _pattern.Length))
            {
                int j = _pattern.Length - 1;
                while (j >= 0 && _pattern[j] == text[i + j])
                    j--;

                if (j < 0)
                {
                    return i;
                }

                i += Math.Max(_skipArray[text[i + j]] - _pattern.Length + 1 + j, 1);
            }
            return InvalidIndex;
        }
    }

    class Timer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(
        out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(
        out long lpFrequency);
        private long startTime, stopTime;
        private long freq;
        public Timer()
        {
            startTime = 0;
            stopTime = 0;
            if (QueryPerformanceFrequency(out freq) == false)
            {
                MessageBox.Show("Таймер не поддерживается аппаратной частью " +
                    "компьютера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                Application.Exit();
            }
        }
        public double Start()
        {
            Thread.Sleep(0);
            QueryPerformanceCounter(out startTime);
            return 1.0 * startTime / freq;
        }
        public double Stop()
        {
            QueryPerformanceCounter(out stopTime);
            return 1.0 * stopTime / freq;
        }
        public double Duration
        {
            get
            {
                return (double)(stopTime - startTime) / (double)freq;
            }
        }

    }
}