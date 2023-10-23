namespace MLRecognitionDiploma;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pictureBox1 = new PictureBox();
        panel1 = new Panel();
        label1 = new Label();
        button2 = new Button();
        textBox3 = new TextBox();
        textBox2 = new TextBox();
        textBox1 = new TextBox();
        button1 = new Button();
        menuStrip1 = new MenuStrip();
        файлToolStripMenuItem = new ToolStripMenuItem();
        вибратиToolStripMenuItem = new ToolStripMenuItem();
        mLToolStripMenuItem = new ToolStripMenuItem();
        згеренуватиКартинкиДляТренуванняToolStripMenuItem = new ToolStripMenuItem();
        тренуватиМодельToolStripMenuItem = new ToolStripMenuItem();
        імпортуватиМодельToolStripMenuItem = new ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        panel1.SuspendLayout();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        pictureBox1.Dock = DockStyle.Fill;
        pictureBox1.Location = new Point(0, 28);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(998, 582);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // panel1
        // 
        panel1.Controls.Add(label1);
        panel1.Controls.Add(button2);
        panel1.Controls.Add(textBox3);
        panel1.Controls.Add(textBox2);
        panel1.Controls.Add(textBox1);
        panel1.Controls.Add(button1);
        panel1.Dock = DockStyle.Right;
        panel1.Location = new Point(697, 28);
        panel1.Name = "panel1";
        panel1.Size = new Size(301, 582);
        panel1.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(36, 129);
        label1.Name = "label1";
        label1.Size = new Size(75, 20);
        label1.TabIndex = 5;
        label1.Text = "Результат";
        // 
        // button2
        // 
        button2.Location = new Point(182, 541);
        button2.Name = "button2";
        button2.Size = new Size(107, 29);
        button2.TabIndex = 4;
        button2.Text = "Clear image";
        button2.UseVisualStyleBackColor = true;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(32, 152);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(253, 27);
        textBox3.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(36, 73);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(253, 27);
        textBox2.TabIndex = 2;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(36, 40);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(253, 27);
        textBox1.TabIndex = 1;
        // 
        // button1
        // 
        button1.Location = new Point(32, 428);
        button1.Name = "button1";
        button1.Size = new Size(125, 36);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, mLToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(998, 28);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        // 
        // файлToolStripMenuItem
        // 
        файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { вибратиToolStripMenuItem });
        файлToolStripMenuItem.Name = "файлToolStripMenuItem";
        файлToolStripMenuItem.Size = new Size(59, 24);
        файлToolStripMenuItem.Text = "Файл";
        // 
        // вибратиToolStripMenuItem
        // 
        вибратиToolStripMenuItem.Name = "вибратиToolStripMenuItem";
        вибратиToolStripMenuItem.Size = new Size(224, 26);
        вибратиToolStripMenuItem.Text = "Вибрати";
        вибратиToolStripMenuItem.Click += вибратиToolStripMenuItem_Click;
        // 
        // mLToolStripMenuItem
        // 
        mLToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { згеренуватиКартинкиДляТренуванняToolStripMenuItem, тренуватиМодельToolStripMenuItem, імпортуватиМодельToolStripMenuItem });
        mLToolStripMenuItem.Name = "mLToolStripMenuItem";
        mLToolStripMenuItem.Size = new Size(43, 24);
        mLToolStripMenuItem.Text = "ML";
        // 
        // згеренуватиКартинкиДляТренуванняToolStripMenuItem
        // 
        згеренуватиКартинкиДляТренуванняToolStripMenuItem.Name = "згеренуватиКартинкиДляТренуванняToolStripMenuItem";
        згеренуватиКартинкиДляТренуванняToolStripMenuItem.Size = new Size(359, 26);
        згеренуватиКартинкиДляТренуванняToolStripMenuItem.Text = "Згеренувати картинки для тренування";
        // 
        // тренуватиМодельToolStripMenuItem
        // 
        тренуватиМодельToolStripMenuItem.Name = "тренуватиМодельToolStripMenuItem";
        тренуватиМодельToolStripMenuItem.Size = new Size(359, 26);
        тренуватиМодельToolStripMenuItem.Text = "Тренувати модель";
        // 
        // імпортуватиМодельToolStripMenuItem
        // 
        імпортуватиМодельToolStripMenuItem.Name = "імпортуватиМодельToolStripMenuItem";
        імпортуватиМодельToolStripMenuItem.Size = new Size(359, 26);
        імпортуватиМодельToolStripMenuItem.Text = "Імпортувати модель";
        імпортуватиМодельToolStripMenuItem.Click += імпортуватиМодельToolStripMenuItem_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(998, 610);
        Controls.Add(panel1);
        Controls.Add(pictureBox1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Panel panel1;
    private Button button1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem вибратиToolStripMenuItem;
    private ToolStripMenuItem mLToolStripMenuItem;
    private ToolStripMenuItem згеренуватиКартинкиДляТренуванняToolStripMenuItem;
    private ToolStripMenuItem тренуватиМодельToolStripMenuItem;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private Button button2;
    private Label label1;
    private ToolStripMenuItem імпортуватиМодельToolStripMenuItem;
}