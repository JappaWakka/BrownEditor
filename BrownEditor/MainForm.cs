﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrownEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Brown Editor 0.1";
        }

        public string loadfilter = "GameBoy ROM|*.gb|GameBoy Color ROM|*.gbc|All Files (*.*)|*.*";
        public static byte[] filebuffer;
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            load_file(null);
        }

        void load_file(string filepath)
        {
            string path = filepath;
            int filesize = FileIO.load_file(ref filebuffer, ref path, loadfilter);
            if (filesize > 0)
            {
                enableEditors();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            FileIO.save_data(filebuffer);
        }

        private void moveEditorBut_Click(object sender, EventArgs e)
        {
            Form moves = new BrownEditor.editor.MoveEditor();
            moves.ShowDialog();
            
        }

        private void enableEditors()
        {
            this.ButtonSave.Enabled = true;
            this.moveEditorBut.Enabled = true;
            this.BaseStatsEditorBut.Enabled = true;
            this.evomovesBut.Enabled = true;
            this.wildBut.Enabled = true;
        }

        private void BaseStatsEditorBut_Click(object sender, EventArgs e)
        {
            Form basestats = new BrownEditor.editor.StatsEvos();
            basestats.ShowDialog();
        }

        private void evomovesBut_Click(object sender, EventArgs e)
        {
            Form evomoves = new BrownEditor.editor.evomoves();
            evomoves.ShowDialog();
        }

        public static int ThreeByteToTwoByte(int bank, UInt16 off)
        {
            return ((bank * 0x4000) + (off - 0x4000));
        }
        public static int getBank(int off)
        {
            return off / 0x4000;
        }
        public static int TwoByteOffset(int off)
        {
            return (off % 0x4000) + 0x4000;
        }

        private void wildBut_Click(object sender, EventArgs e)
        {
            Form wildencounters = new BrownEditor.editor.wild();
            wildencounters.ShowDialog();
        }
    }
}