namespace Calculator;

partial class CalculatorForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
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
        buttonBackspace = new System.Windows.Forms.Button();
        buttonClearEntry = new System.Windows.Forms.Button();
        buttonAllClear = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        buttonToggleSign = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // buttonZero
        // 
        buttonZero.Location = new System.Drawing.Point(68, 242);
        buttonZero.Name = "buttonZero";
        buttonZero.Size = new System.Drawing.Size(40, 32);
        buttonZero.TabIndex = 0;
        buttonZero.Text = "0";
        buttonZero.UseVisualStyleBackColor = true;
        buttonZero.Click += NumberButton_Click;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(22, 204);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(40, 32);
        button1.TabIndex = 1;
        button1.Text = "1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += NumberButton_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(68, 204);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(40, 32);
        button2.TabIndex = 2;
        button2.Text = "2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += NumberButton_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(114, 204);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(40, 32);
        button3.TabIndex = 3;
        button3.Text = "3";
        button3.UseVisualStyleBackColor = true;
        button3.Click += NumberButton_Click;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(22, 167);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(40, 32);
        button4.TabIndex = 4;
        button4.Text = "4";
        button4.UseVisualStyleBackColor = true;
        button4.Click += NumberButton_Click;
        // 
        // button5
        // 
        button5.Location = new System.Drawing.Point(68, 167);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(40, 32);
        button5.TabIndex = 5;
        button5.Text = "5";
        button5.UseVisualStyleBackColor = true;
        button5.Click += NumberButton_Click;
        // 
        // button7
        // 
        button7.Location = new System.Drawing.Point(22, 131);
        button7.Name = "button7";
        button7.Size = new System.Drawing.Size(40, 32);
        button7.TabIndex = 6;
        button7.Text = "7";
        button7.UseVisualStyleBackColor = true;
        button7.Click += NumberButton_Click;
        // 
        // button6
        // 
        button6.Location = new System.Drawing.Point(114, 167);
        button6.Name = "button6";
        button6.Size = new System.Drawing.Size(40, 32);
        button6.TabIndex = 7;
        button6.Text = "6";
        button6.UseVisualStyleBackColor = true;
        button6.Click += NumberButton_Click;
        // 
        // button9
        // 
        button9.Location = new System.Drawing.Point(114, 131);
        button9.Name = "button9";
        button9.Size = new System.Drawing.Size(40, 32);
        button9.TabIndex = 8;
        button9.Text = "9";
        button9.UseVisualStyleBackColor = true;
        button9.Click += NumberButton_Click;
        // 
        // button8
        // 
        button8.Location = new System.Drawing.Point(68, 131);
        button8.Name = "button8";
        button8.Size = new System.Drawing.Size(40, 32);
        button8.TabIndex = 9;
        button8.Text = "8";
        button8.UseVisualStyleBackColor = true;
        button8.Click += NumberButton_Click;
        // 
        // buttonDecimal
        // 
        buttonDecimal.BackColor = System.Drawing.Color.DarkGray;
        buttonDecimal.Location = new System.Drawing.Point(114, 242);
        buttonDecimal.Name = "buttonDecimal";
        buttonDecimal.Size = new System.Drawing.Size(40, 32);
        buttonDecimal.TabIndex = 10;
        buttonDecimal.Text = ",";
        buttonDecimal.UseVisualStyleBackColor = false;
        buttonDecimal.Click += CommaButton_Click;
        // 
        // buttonDivision
        // 
        buttonDivision.BackColor = System.Drawing.Color.DarkOrange;
        buttonDivision.Location = new System.Drawing.Point(160, 93);
        buttonDivision.Name = "buttonDivision";
        buttonDivision.Size = new System.Drawing.Size(40, 32);
        buttonDivision.TabIndex = 11;
        buttonDivision.Text = "/";
        buttonDivision.UseVisualStyleBackColor = false;
        buttonDivision.Click += OperatorButton_Click;
        // 
        // buttonMultiplication
        // 
        buttonMultiplication.BackColor = System.Drawing.Color.DarkOrange;
        buttonMultiplication.Location = new System.Drawing.Point(160, 131);
        buttonMultiplication.Name = "buttonMultiplication";
        buttonMultiplication.Size = new System.Drawing.Size(40, 32);
        buttonMultiplication.TabIndex = 12;
        buttonMultiplication.Text = "*";
        buttonMultiplication.UseVisualStyleBackColor = false;
        buttonMultiplication.Click += OperatorButton_Click;
        // 
        // buttonMinus
        // 
        buttonMinus.BackColor = System.Drawing.Color.DarkOrange;
        buttonMinus.Location = new System.Drawing.Point(160, 167);
        buttonMinus.Name = "buttonMinus";
        buttonMinus.Size = new System.Drawing.Size(40, 32);
        buttonMinus.TabIndex = 13;
        buttonMinus.Text = "-";
        buttonMinus.UseVisualStyleBackColor = false;
        buttonMinus.Click += OperatorButton_Click;
        // 
        // buttonPlus
        // 
        buttonPlus.BackColor = System.Drawing.Color.DarkOrange;
        buttonPlus.Location = new System.Drawing.Point(160, 204);
        buttonPlus.Name = "buttonPlus";
        buttonPlus.Size = new System.Drawing.Size(40, 32);
        buttonPlus.TabIndex = 14;
        buttonPlus.Text = "+";
        buttonPlus.UseVisualStyleBackColor = false;
        buttonPlus.Click += OperatorButton_Click;
        // 
        // buttonEqual
        // 
        buttonEqual.BackColor = System.Drawing.Color.DarkOrange;
        buttonEqual.Location = new System.Drawing.Point(160, 242);
        buttonEqual.Name = "buttonEqual";
        buttonEqual.Size = new System.Drawing.Size(40, 32);
        buttonEqual.TabIndex = 15;
        buttonEqual.Text = "=";
        buttonEqual.UseVisualStyleBackColor = false;
        buttonEqual.Click += EqualsButton_Click;
        // 
        // buttonBackspace
        // 
        buttonBackspace.BackColor = System.Drawing.SystemColors.ControlDark;
        buttonBackspace.ForeColor = System.Drawing.SystemColors.ControlText;
        buttonBackspace.Location = new System.Drawing.Point(22, 93);
        buttonBackspace.Name = "buttonBackspace";
        buttonBackspace.Size = new System.Drawing.Size(40, 32);
        buttonBackspace.TabIndex = 19;
        buttonBackspace.Text = "<-";
        buttonBackspace.UseVisualStyleBackColor = false;
        buttonBackspace.Click += BackspaceButton_Click;
        // 
        // buttonClearEntry
        // 
        buttonClearEntry.BackColor = System.Drawing.Color.DarkGray;
        buttonClearEntry.Location = new System.Drawing.Point(68, 93);
        buttonClearEntry.Name = "buttonClearEntry";
        buttonClearEntry.Size = new System.Drawing.Size(40, 32);
        buttonClearEntry.TabIndex = 20;
        buttonClearEntry.Text = "CE";
        buttonClearEntry.UseVisualStyleBackColor = false;
        buttonClearEntry.Click += ClearEntryButton_Click;
        // 
        // buttonAllClear
        // 
        buttonAllClear.BackColor = System.Drawing.Color.DarkGray;
        buttonAllClear.Location = new System.Drawing.Point(114, 93);
        buttonAllClear.Name = "buttonAllClear";
        buttonAllClear.Size = new System.Drawing.Size(40, 32);
        buttonAllClear.TabIndex = 21;
        buttonAllClear.Text = "C";
        buttonAllClear.UseVisualStyleBackColor = false;
        buttonAllClear.Click += ClearAllButton_Click;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.Color.WhiteSmoke;
        label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.Location = new System.Drawing.Point(22, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(178, 33);
        label1.TabIndex = 24;
        label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.WhiteSmoke;
        label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label2.Location = new System.Drawing.Point(22, 42);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(178, 46);
        label2.TabIndex = 25;
        label2.Text = "0";
        label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // buttonToggleSign
        // 
        buttonToggleSign.BackColor = System.Drawing.Color.DarkGray;
        buttonToggleSign.Location = new System.Drawing.Point(22, 242);
        buttonToggleSign.Name = "buttonToggleSign";
        buttonToggleSign.Size = new System.Drawing.Size(40, 32);
        buttonToggleSign.TabIndex = 26;
        buttonToggleSign.Text = "±";
        buttonToggleSign.UseVisualStyleBackColor = false;
        buttonToggleSign.Click += ToggleSignButton_Click;
        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightGray;
        ClientSize = new System.Drawing.Size(224, 281);
        Controls.Add(buttonToggleSign);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(buttonAllClear);
        Controls.Add(buttonClearEntry);
        Controls.Add(buttonBackspace);
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
    }

    private System.Windows.Forms.Button buttonToggleSign;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button buttonZero;

    private System.Windows.Forms.Button buttonBackspace;
    private System.Windows.Forms.Button buttonClearEntry;
    private System.Windows.Forms.Button buttonAllClear;

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

    private System.Windows.Forms.Button button1;

    #endregion
}