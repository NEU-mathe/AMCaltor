using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamSysWinform;
using ExamSysWinform.WebService;
using System.Data;
using System.IO;
using System.Text;

namespace fakepack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Function.Login(textBox2.Text, textBox4.Text);
            string[] str = new String[100];
            str = Function.ExamTemplate(comboBox1.Text,textBox2.Text);
            string str2 = string.Join("\r\n", str);
            this.textBox1.Text = str2;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Function.Login(textBox2.Text, textBox4.Text);
            string[] str = new String[100];
            str = Function.ExamTemplate(comboBox1.Text,textBox2.Text,int.Parse(textBox3.Text));
            string str2 = string.Join("\r\n", str);
            this.textBox1.Text = str2;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Guid.NewGuid().GetHashCode().ToString());
            int[] array = null;
            List<int> list2 = new List<int>();
            for (int m = 0; m < 30; m++)
            {
                list2.Add(m);
            }
            //List<string> list2 = {0,1,……,strArray.Length}
            //int array[] = {0,1,……,strArray.Length}
            array = list2.ToArray();
            int[] numArray2 = new int[3];
            numArray2[0] = -1;
            numArray2[2] = 1;
            //int rnd[3] = {-1,?,1}
            int[] rnd = numArray2;
            Array.Sort<int>(array, delegate(int i, int j)
            {
                if (i == j)
                {
                    return 0;
                }
                return rnd[new Random(Guid.NewGuid().GetHashCode()).Next(0, 3)];
            });
            string str1 = "";
            for (int n = 0; n < array.Length; n++)
            {
                str1 = str1 + array[n] + ",";
            }
            MessageBox.Show(str1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Function.Login(textBox2.Text, textBox2.Text);
            StudentService ws;
            ws = new StudentService();
            DataSet set = ws.ShowStuPaper("_3[#$%wd*", this.textBox2.Text,  "高等数学_GS");
            DataTable dt = set.Tables[0];
            //MessageBox.Show(set.Tables[0].ToString());
            string[] str = new String[100];
                    //ClientExamTemplate examModel = new ClientExamTemplate {
                    //    ChoiceSource = dt.Rows[i]["choiceSource"].ToString(),
                    //    Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                    //    Flag = int.Parse(dt.Rows[i]["flag"].ToString()),
                    //    Enable = bool.Parse(dt.Rows[i]["enable"].ToString()),
                    //    Grade = dt.Rows[i]["grade"].ToString(),
                    //    Src = "PublishChoice/" + dt.Rows[i]["src"].ToString(),
                    //    StudentAnwser = dt.Rows[i]["studentAnwser"].ToString(),
                    //    Template = dt.Rows[i]["template"].ToString(),
                    //    Name = dt.Rows[i]["Name"].ToString(),
                    //    ResultRand = dt.Rows[i]["sortNumber"].ToString(),
                    //    ButtonText = "恢复试卷"
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str[0] = dt.Rows[i]["choiceSource"].ToString();
                str[1] = dt.Rows[i]["Id"].ToString();
                str[2] = dt.Rows[i]["flag"].ToString();
                str[3] = dt.Rows[i]["enable"].ToString();
                str[4] = dt.Rows[i]["grade"].ToString();
                str[5] = "PublishChoice/" + dt.Rows[i]["src"].ToString();
                str[6] = dt.Rows[i]["studentAnwser"].ToString();
                str[7] = dt.Rows[i]["template"].ToString();
                str[8] = dt.Rows[i]["Name"].ToString();
                str[9] = dt.Rows[i]["sortNumber"].ToString();
                str[13] = string.Join("\r\n", str);
                this.textBox1.Text += "\r\n" + str[13];

            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            StudentService ws;
            ws = new StudentService();
            DataSet set = ws.getTemplate("_3[#$%wd*", this.textBox2.Text, "1", "高等数学_GS");
            DataTable dt = set.Tables[0];
            //MessageBox.Show(set.Tables[0].ToString());
            string[] str = new String[100];
            //            ChoiceSource = dt.Rows[i]["choiceSource"].ToString(),
            //            Id = int.Parse(dt.Rows[i]["Id"].ToString()),
            //            Flag = int.Parse(dt.Rows[i]["flag"].ToString()),
            //            StartTime = DateTime.Parse(dt.Rows[i]["startTime"].ToString()),
            //            EndTime = DateTime.Parse(dt.Rows[i]["endTime"].ToString()),
            //            ExamTime = int.Parse(dt.Rows[i]["examTime"].ToString()),
            //            UsedTime = int.Parse(dt.Rows[i]["usedTime"].ToString()),
            //            Enable = bool.Parse(dt.Rows[i]["enable"].ToString()),
            //            Src = "PublishChoice/" + dt.Rows[i]["src"].ToString(),
            //            StudentAnwser = dt.Rows[i]["studentAnwser"].ToString(),
            //            Template = dt.Rows[i]["template"].ToString(),
            //            Name = dt.Rows[i]["Name"].ToString(),
            //            ResultRand = dt.Rows[i]["sortNumber"].ToString()
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str[0] = dt.Rows[i]["choiceSource"].ToString();
                str[1] = dt.Rows[i]["Id"].ToString();
                str[2] = dt.Rows[i]["flag"].ToString();
                str[3] = dt.Rows[i]["startTime"].ToString();
                str[4] = dt.Rows[i]["endTime"].ToString();
                str[5] = dt.Rows[i]["examTime"].ToString();
                str[6] = dt.Rows[i]["usedTime"].ToString();
                str[7] = dt.Rows[i]["enable"].ToString();
                str[8] = "PublishChoice/" + dt.Rows[i]["src"].ToString();
                str[9] = dt.Rows[i]["studentAnwser"].ToString();
                str[10] = dt.Rows[i]["template"].ToString();
                str[11] = dt.Rows[i]["Name"].ToString();
                str[12] = dt.Rows[i]["sortNumber"].ToString();
            }
            str[13] = string.Join("\r\n", str);
            this.textBox1.Text += "\r\n" + str[13];
        }



        private void textBox3_Enter(object sender, EventArgs e)
        {
            if(textBox3.Text == "选中的考试（ExamTemplate）")
                textBox3.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text == "学号")
            textBox2.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "密码")
                textBox4.Text = "";
        }



    }
}
