namespace Calculator;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        buttonZero = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        button5 = new System.Windows.Forms.Button();
        button7 = new System.Windows.Forms.Button();
        button6 = new System.Windows.Forms.Button();
        button9 = new System.Windows.Forms.Button();
        button8 = new System.Windows.Forms.Button();
        buttonDecimal = new System.Windows.Forms.Button();
        buttonDivision = new System.Windows.Forms.Button();
        buttonMultiplication = new System.Windows.Forms.Button();
        buttonMinus = new System.Windows.Forms.Button();
        buttonPlus = new System.Windows.Forms.Button();
        buttonEqual = new System.Windows.Forms.Button();
        buttonFraction = new System.Windows.Forms.Button();
        buttonSquareRoot = new System.Windows.Forms.Button();
        buttonRemains = new System.Windows.Forms.Button();
        buttonBackspace = new System.Windows.Forms.Button();
        buttonClearEntry = new System.Windows.Forms.Button();
        buttonAllClear = new System.Windows.Forms.Button();
        buttonChangeSign = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // buttonZero
        // 
        buttonZero.Location = new System.Drawing.Point(10, 231);
        buttonZero.Name = "buttonZero";
        buttonZero.Size = new System.Drawing.Size(80, 30);
        buttonZero.TabIndex = 0;
        buttonZero.Text = "0";
        buttonZero.UseVisualStyleBackColor = true;
        buttonZero.Click += NumberButton_Click;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(10, 195);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(35, 30);
        button1.TabIndex = 1;
        button1.Text = "1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += NumberButton_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(55, 195);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(35, 30);
        button2.TabIndex = 2;
        button2.Text = "2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += NumberButton_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(97, 195);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(35, 30);
        button3.TabIndex = 3;
        button3.Text = "3";
        button3.UseVisualStyleBackColor = true;
        button3.Click += NumberButton_Click;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(10, 159);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(35, 30);
        button4.TabIndex = 4;
        button4.Text = "4";
        button4.UseVisualStyleBackColor = true;
        button4.Click += NumberButton_Click;
        // 
        // button5
        // 
        button5.Location = new System.Drawing.Point(55, 159);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(35, 30);
        button5.TabIndex = 5;
        button5.Text = "5";
        button5.UseVisualStyleBackColor = true;
        button5.Click += NumberButton_Click;
        // 
        // button7
        // 
        button7.Location = new System.Drawing.Point(10, 123);
        button7.Name = "button7";
        button7.Size = new System.Drawing.Size(35, 30);
        button7.TabIndex = 6;
        button7.Text = "7";
        button7.UseVisualStyleBackColor = true;
        button7.Click += NumberButton_Click;
        // 
        // button6
        // 
        button6.Location = new System.Drawing.Point(97, 159);
        button6.Name = "button6";
        button6.Size = new System.Drawing.Size(35, 30);
        button6.TabIndex = 7;
        button6.Text = "6";
        button6.UseVisualStyleBackColor = true;
        button6.Click += NumberButton_Click;
        // 
        // button9
        // 
        button9.Location = new System.Drawing.Point(97, 123);
        button9.Name = "button9";
        button9.Size = new System.Drawing.Size(35, 30);
        button9.TabIndex = 8;
        button9.Text = "9";
        button9.UseVisualStyleBackColor = true;
        button9.Click += NumberButton_Click;
        // 
        // button8
        // 
        button8.Location = new System.Drawing.Point(55, 123);
        button8.Name = "button8";
        button8.Size = new System.Drawing.Size(35, 30);
        button8.TabIndex = 9;
        button8.Text = "8";
        button8.UseVisualStyleBackColor = true;
        button8.Click += NumberButton_Click;
        // 
        // buttonDecimal
        // 
        buttonDecimal.Location = new System.Drawing.Point(97, 231);
        buttonDecimal.Name = "buttonDecimal";
        buttonDecimal.Size = new System.Drawing.Size(35, 30);
        buttonDecimal.TabIndex = 10;
        buttonDecimal.Text = ",";
        buttonDecimal.UseVisualStyleBackColor = true;
        // 
        // buttonDivision
        // 
        buttonDivision.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonDivision.Location = new System.Drawing.Point(138, 123);
        buttonDivision.Name = "buttonDivision";
        buttonDivision.Size = new System.Drawing.Size(35, 30);
        buttonDivision.TabIndex = 11;
        buttonDivision.Text = "/";
        buttonDivision.UseVisualStyleBackColor = false;
        // 
        // buttonMultiplication
        // 
        buttonMultiplication.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonMultiplication.Location = new System.Drawing.Point(138, 159);
        buttonMultiplication.Name = "buttonMultiplication";
        buttonMultiplication.Size = new System.Drawing.Size(35, 30);
        buttonMultiplication.TabIndex = 12;
        buttonMultiplication.Text = "*";
        buttonMultiplication.UseVisualStyleBackColor = false;
        // 
        // buttonMinus
        // 
        buttonMinus.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonMinus.Location = new System.Drawing.Point(138, 195);
        buttonMinus.Name = "buttonMinus";
        buttonMinus.Size = new System.Drawing.Size(35, 30);
        buttonMinus.TabIndex = 13;
        buttonMinus.Text = "-";
        buttonMinus.UseVisualStyleBackColor = false;
        // 
        // buttonPlus
        // 
        buttonPlus.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonPlus.Location = new System.Drawing.Point(138, 231);
        buttonPlus.Name = "buttonPlus";
        buttonPlus.Size = new System.Drawing.Size(35, 30);
        buttonPlus.TabIndex = 14;
        buttonPlus.Text = "+";
        buttonPlus.UseVisualStyleBackColor = false;
        // 
        // buttonEqual
        // 
        buttonEqual.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonEqual.Location = new System.Drawing.Point(179, 195);
        buttonEqual.Name = "buttonEqual";
        buttonEqual.Size = new System.Drawing.Size(35, 66);
        buttonEqual.TabIndex = 15;
        buttonEqual.Text = "=";
        buttonEqual.UseVisualStyleBackColor = false;
        // 
        // buttonFraction
        // 
        buttonFraction.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonFraction.Location = new System.Drawing.Point(179, 159);
        buttonFraction.Name = "buttonFraction";
        buttonFraction.Size = new System.Drawing.Size(35, 30);
        buttonFraction.TabIndex = 16;
        buttonFraction.Text = "1/x";
        buttonFraction.UseVisualStyleBackColor = false;
        // 
        // buttonSquareRoot
        // 
        buttonSquareRoot.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonSquareRoot.Location = new System.Drawing.Point(179, 87);
        buttonSquareRoot.Name = "buttonSquareRoot";
        buttonSquareRoot.Size = new System.Drawing.Size(35, 30);
        buttonSquareRoot.TabIndex = 17;
        buttonSquareRoot.Text = "√";
        buttonSquareRoot.UseVisualStyleBackColor = false;
        // 
        // buttonRemains
        // 
        buttonRemains.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonRemains.Location = new System.Drawing.Point(179, 123);
        buttonRemains.Name = "buttonRemains";
        buttonRemains.Size = new System.Drawing.Size(35, 30);
        buttonRemains.TabIndex = 18;
        buttonRemains.Text = "%";
        buttonRemains.UseVisualStyleBackColor = false;
        // 
        // buttonBackspace
        // 
        buttonBackspace.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonBackspace.Location = new System.Drawing.Point(97, 86);
        buttonBackspace.Name = "buttonBackspace";
        buttonBackspace.Size = new System.Drawing.Size(35, 30);
        buttonBackspace.TabIndex = 19;
        buttonBackspace.Text = "<-";
        buttonBackspace.UseVisualStyleBackColor = false;
        // 
        // buttonClearEntry
        // 
        buttonClearEntry.BackColor = System.Drawing.Color.DarkOrange;
        buttonClearEntry.Location = new System.Drawing.Point(10, 87);
        buttonClearEntry.Name = "buttonClearEntry";
        buttonClearEntry.Size = new System.Drawing.Size(35, 30);
        buttonClearEntry.TabIndex = 20;
        buttonClearEntry.Text = "CE";
        buttonClearEntry.UseVisualStyleBackColor = false;
        // 
        // buttonAllClear
        // 
        buttonAllClear.BackColor = System.Drawing.Color.DarkOrange;
        buttonAllClear.Location = new System.Drawing.Point(55, 87);
        buttonAllClear.Name = "buttonAllClear";
        buttonAllClear.Size = new System.Drawing.Size(35, 30);
        buttonAllClear.TabIndex = 21;
        buttonAllClear.Text = "C";
        buttonAllClear.UseVisualStyleBackColor = false;
        // 
        // buttonChangeSign
        // 
        buttonChangeSign.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonChangeSign.Location = new System.Drawing.Point(137, 87);
        buttonChangeSign.Name = "buttonChangeSign";
        buttonChangeSign.Size = new System.Drawing.Size(35, 30);
        buttonChangeSign.TabIndex = 22;
        buttonChangeSign.Text = "±";
        buttonChangeSign.UseVisualStyleBackColor = false;
        // 
        // textBox1
        // 
        textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        textBox1.Location = new System.Drawing.Point(10, 20);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(204, 60);
        textBox1.TabIndex = 23;
        textBox1.Text = "0";
        textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.WhiteSmoke;
        ClientSize = new System.Drawing.Size(224, 281);
        Controls.Add(textBox1);
        Controls.Add(buttonChangeSign);
        Controls.Add(buttonAllClear);
        Controls.Add(buttonClearEntry);
        Controls.Add(buttonBackspace);
        Controls.Add(buttonRemains);
        Controls.Add(buttonSquareRoot);
        Controls.Add(buttonFraction);
        Controls.Add(buttonEqual);
        Controls.Add(buttonPlus);
        Controls.Add(buttonMinus);
        Controls.Add(buttonMultiplication);
        Controls.Add(buttonDivision);
        Controls.Add(buttonDecimal);
        Controls.Add(button8);
        Controls.Add(button9);
        Controls.Add(button6);
        Controls.Add(button7);
        Controls.Add(button5);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(buttonZero);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        MaximizeBox = false;
        Text = "Calculator";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button buttonZero;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Button buttonBackspace;
    private System.Windows.Forms.Button buttonClearEntry;
    private System.Windows.Forms.Button buttonAllClear;
    private System.Windows.Forms.Button buttonChangeSign;

    private System.Windows.Forms.Button buttonSquareRoot;
    private System.Windows.Forms.Button buttonRemains;

    private System.Windows.Forms.Button buttonFraction;

    private System.Windows.Forms.Button buttonEqual;

    private System.Windows.Forms.Button buttonDecimal;
    private System.Windows.Forms.Button buttonDivision;
    private System.Windows.Forms.Button buttonMultiplication;
    private System.Windows.Forms.Button buttonMinus;
    private System.Windows.Forms.Button buttonPlus;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;
    private System.Windows.Forms.Button button10;

    private System.Windows.Forms.Button button1;

    #endregion
}