using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        char[] zimu =
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };
        char[] fuhao =
        {
            '`','~','@','#','$','%','^','&','*','(',')','_','-','+','=','\\','|',',','/','.','<','>','?','"',';',':','\''
        };

        Random randGen = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            List<char> password = new List<char>(16);

            int passlen = randGen.Next(8, 16);
            //1/5符号 2/5数字 3/5字母
            int fuhaoNum = passlen / 5 + randGen.Next(0, 1);
            int shuziNum = passlen / 5 * 2 + randGen.Next(0, 1);
            int zimuNum = passlen - fuhaoNum - shuziNum;

            int[] randbase = { 0, 1, 2 };
            for(int i = 0; i < passlen; i++)
            {
                int t = randGen.Next(0, 9999)%3;
                switch (randbase[t])
                {
                    case 0:
                        if (fuhaoNum > 0)
                        {
                            password.Add(GenFuHao());
                            fuhaoNum--;
                        }
                        else
                        {
                            randbase[0] = randbase[1];
                            i--;
                        }
                        break;
                    case 1:
                        if(shuziNum > 0)
                        {
                            password.Add(GenShuZi());
                            shuziNum--;
                        }else
                        {
                            randbase[1] = randbase[2];
                            i--;
                        }
                        break;
                    case 2:
                        if(zimuNum > 0)
                        {
                            password.Add(GenZiMu());
                            zimuNum--;
                        }else
                        {
                            randbase[2] = randbase[0];
                            i--;
                        }
                        break;
                }
            }
            string pwd = new string(password.ToArray());
            txtPassword.Text = pwd;
        }

        char GenZiMu()
        {
            int idx = randGen.Next(0, zimu.Length);
            return zimu[idx];
        }

        char GenFuHao()
        {
            int idx = randGen.Next(0, fuhao.Length);
            return fuhao[idx];
        }

        char GenShuZi()
        {
            int n = randGen.Next(0, 10);
            return n.ToString()[0];
        }
    }
}
