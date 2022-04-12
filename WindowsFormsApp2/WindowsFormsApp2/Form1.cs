using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string[] lines;
        int _var = 0;

        List<string> allLines = new List<string>();
        List<Block> blocks = new List<Block>();


        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "cat\ncat cat\ncat cat\ncat cat cat cat cat\ncat";
            _var = 0;

            allLines = richTextBox1.Lines.ToList();
            listBox1.Items.Add(allLines.Count.ToString());
        }

        private void compile_Click(object sender, EventArgs e)
        {
            allLines = richTextBox1.Lines.ToList();
            //find blocks
            int i = 0;
            Block newBlock;
            while ( i < allLines.Count)
            {
                if (allLines[i] == "cat")
                {
                    newBlock = new Block();
                    newBlock.Start = i;
                    newBlock.End = allLines.Count - 1;
                    List<string> data = new List<string>();
                    int j = i;
                    while (j < allLines.Count)
                    {
                        if (allLines[j]==string.Empty)
                        {
                            newBlock.End = j-1;
                            break;
                        }
                        j++;
                    }
                    for (int l = newBlock.Start+1; l < newBlock.End-1; l++)
                    {
                        data.Add(allLines[l]);
                    }
                    newBlock.blockData = data;
                    blocks.Add(newBlock);
                    i = j;
                }
                else
                {
                    i++;
                }
            }
            foreach (var block in blocks)
            {
                listBox1.Items.Add($"{block.Start.ToString()}\n{block.End.ToString()}\n{block.blockData}");
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (var block in blocks)
            //{
            //    if (block.blockData[0] == "cat cat")
            //    {
            //        for (int i = 1; i < block.End; i++)
            //        {
            //            string[] temp = block.blockData[i].Split(' ');
            //            _var = _var + temp.Length;
            //        }
            //    }
            //}
            richTextBox2.Text += blocks[0].blockData[0];
        }
    }
}

