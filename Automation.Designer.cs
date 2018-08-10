using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using Kompas6API5;
using Kompas6Constants;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using KAPITypes;
using KompasAPI7;

namespace Steps.NET
{

    partial class Automation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private static Automation instance;

        public static Automation Instance
        {
            get
            {
                if (instance == null)
                    instance = new Automation();
                return instance;

            }
        }
        private KompasObject kompasObject;
        public KompasObject KompasObject
        {
            get
            {
                return kompasObject;
            }
            set
            {
                kompasObject = value;
            }
        }
        private ksDocument2D document2d;
        public ksDocument2D Document2D
        {
            get
            {
                return document2d;
            }
            set
            {
                document2d = value;
            }
        }
        //private _Application kompasApp;
        //public _Application KompasApp
        //{
        //    get
        //    {
        //        return kompasApp;
        //    }
        //    set
        //    {
        //        kompasApp = value;
        //    }
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Automation));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(61, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Эконом 1",
            "Эконом 2",
            "Эконом 3",
            "Эконом 4",
            "Эконом 5",
            "Эконом 6",
            "Эконом 7",
            "Эконом 8",
            "Эконом 9",
            "Эконом 10",
            "Эконом 11",
            "Эконом 12",
            "Эконом 13",
            "Эконом 14",
            "Эконом 15",
            "Эконом 16",
            "Эконом 17",
            "Эконом 18",
            "Эконом 19",
            "Эконом 20",
            "Эконом 21",
            "Эконом 22",
            "Эконом 23",
            "Эконом 24",
            "Эконом 25",
            "Эконом 26",
            "Эконом 27",
            "Эконом 28",
            "Эконом 29",
            "Эконом 30",
            "Эконом 31",
            "Эконом 32",
            "Эконом 33",
            "Эконом 34",
            "Эконом 35",
            "Эконом 36",
            "Эконом 37",
            "Эконом 38",
            "Эконом 39",
            "Эконом 40",
            "Эконом 41",
            "Эконом 42",
            "Эконом 43",
            "Эконом 44",
            "Эконом 45",
            "Эконом 46",
            "Эконом 47",
            "Эконом 48",
            "Эконом 49",
            "Эконом 50",
            "Эконом 51",
            "Эконом 52",
            "Эконом 53",
            "Эконом 54",
            "Эконом 55",
            "Эконом 56",
            "Эконом 57",
            "Эконом 58",
            "Эконом 59",
            "Эконом 60",
            "Эконом 61",
            "Эконом 62",
            "Эконом 63",
            "Эконом 64",
            "Эконом 65",
            "Эконом 66",
            "Эконом 67",
            "Эконом 68",
            "Эконом 69",
            "Эконом 70",
            "Эконом 71",
            "Эконом 72",
            "Эконом 73",
            "Эконом 74",
            "Эконом 75",
            "Эконом 76",
            "Эконом 77",
            "Эконом 78",
            "Эконом 79",
            "Эконом 80",
            "Эконом 81",
            "Эконом 82",
            "Эконом 83",
            "V Классика 1",
            "V Классика 2",
            "V Классика 3",
            "V Классика 4",
            "V Классика 5",
            "V Классика 6",
            "V Классика 7",
            "V Классика 8",
            "V Классика 9",
            "V Классика 10",
            "V Классика 11",
            "V Классика 12",
            "V Классика 13",
            "V Классика 14",
            "V Классика 15",
            "V Классика 16",
            "V Классика 17",
            "V Классика 18",
            "V Классика 19",
            "V Классика 20",
            "V Классика 21",
            "V Классика 22",
            "V Классика 23",
            "V Классика 24",
            "V Классика 25",
            "V Классика 26",
            "V Классика 27",
            "V Классика 28",
            "V Классика 29",
            "V Классика 30",
            "V Классика 31",
            "V Классика 32",
            "V Классика 33",
            "V Классика 34",
            "V Классика 35",
            "V Классика 36",
            "V Классика 37",
            "V Классика 38",
            "V Классика 39",
            "V Классика 40",
            "V Классика 41",
            "V Классика 42",
            "V Классика 43",
            "V Классика 44",
            "V Классика 45",
            "V Классика 46",
            "V Классика 47",
            "V Классика 48",
            "V Классика 49",
            "V Классика 50",
            "V Классика 51",
            "V Классика 52",
            "V Классика 53",
            "V Классика 54",
            "V Классика 55",
            "V Классика 56",
            "V Классика 57",
            "V Классика 58",
            "V Классика 59",
            "V Классика 60",
            "V Классика 61",
            "V Классика 62",
            "V Классика 63",
            "V Классика 64",
            "V Классика 65",
            "V Классика 66",
            "V Классика 67",
            "V Классика 68",
            "V Классика 69",
            "V Классика 70",
            "V Классика 71",
            "V Классика 72",
            "V Классика 73",
            "V Классика 74",
            "V Классика 75",
            "V Классика 76",
            "V Классика 77",
            "V Классика 78",
            "V Классика 79",
            "V Классика 80",
            "V Классика 81",
            "V Классика 82",
            "V Классика 83",
            "V Классика 84",
            "V Классика 85",
            "V Классика 86",
            "V Классика 87",
            "V Классика 88",
            "V Классика 89",
            "V Классика 90",
            "V Классика 91",
            "V Классика 92",
            "V Классика 93",
            "V Классика 94",
            "V Классика 95",
            "V Классика 96",
            "V Классика 97",
            "V Классика 98",
            "V Классика 99",
            "V Классика 100",
            "V Классика 101",
            "V Классика 102",
            "V Классика 103",
            "V Классика 104",
            "V Классика 105",
            "V Классика 106",
            "V Классика 107",
            "V Классика 108",
            "V Классика 109",
            "V Классика 110",
            "V Классика 111",
            "V Классика 112",
            "V Классика 113",
            "V Классика 114",
            "V Классика 115",
            "V Классика 116",
            "V Классика 117",
            "V Классика 118",
            "V Классика 119",
            "V Классика 120",
            "V Классика 121",
            "V Классика 122",
            "V Классика 123"});
            this.comboBox1.Location = new System.Drawing.Point(28, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(212, 32);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(130, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 29);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(130, 138);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 29);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "2000";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(24, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Высота";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(24, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ширина";
            // 
            // Automation
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(264, 248);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Automation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Label label1;
        private Label label2;
    }
}