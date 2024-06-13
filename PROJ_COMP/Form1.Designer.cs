namespace PROJ_COMP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTbAction = new System.Windows.Forms.RichTextBox();
            this.richTbConsole = new System.Windows.Forms.RichTextBox();
            this.richTbCommand = new System.Windows.Forms.RichTextBox();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.panelBG = new System.Windows.Forms.Panel();
            this.buttonSyntax = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(485, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Action";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Console";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(562, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.saveToolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.loadToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(125, 26);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(125, 26);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // instructionToolStripMenuItem
            // 
            this.instructionToolStripMenuItem.Name = "instructionToolStripMenuItem";
            this.instructionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.instructionToolStripMenuItem.Text = "Instruction";
            this.instructionToolStripMenuItem.Click += new System.EventHandler(this.instructionToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // richTbAction
            // 
            this.richTbAction.Location = new System.Drawing.Point(420, 48);
            this.richTbAction.Name = "richTbAction";
            this.richTbAction.Size = new System.Drawing.Size(211, 36);
            this.richTbAction.TabIndex = 9;
            this.richTbAction.Text = "";
            this.richTbAction.TextChanged += new System.EventHandler(this.richTbAction_TextChanged);
            this.richTbAction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTbAction_KeyDown);
            // 
            // richTbConsole
            // 
            this.richTbConsole.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.richTbConsole.Location = new System.Drawing.Point(20, 305);
            this.richTbConsole.Name = "richTbConsole";
            this.richTbConsole.Size = new System.Drawing.Size(381, 83);
            this.richTbConsole.TabIndex = 10;
            this.richTbConsole.Text = "";
            this.richTbConsole.TextChanged += new System.EventHandler(this.richTbConsole_TextChanged);
            this.richTbConsole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTbConsole_KeyPress);
            // 
            // richTbCommand
            // 
            this.richTbCommand.Location = new System.Drawing.Point(20, 49);
            this.richTbCommand.Name = "richTbCommand";
            this.richTbCommand.Size = new System.Drawing.Size(381, 199);
            this.richTbCommand.TabIndex = 11;
            this.richTbCommand.Text = "";
            this.richTbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTbCommand_KeyDown);
            // 
            // panelOutput
            // 
            this.panelOutput.BackColor = System.Drawing.SystemColors.Window;
            this.panelOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOutput.Location = new System.Drawing.Point(433, 192);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(340, 229);
            this.panelOutput.TabIndex = 12;
            this.panelOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOutput_Paint);
            // 
            // panelBG
            // 
            this.panelBG.Controls.Add(this.buttonSyntax);
            this.panelBG.Controls.Add(this.richTbAction);
            this.panelBG.Controls.Add(this.label1);
            this.panelBG.Controls.Add(this.richTbConsole);
            this.panelBG.Controls.Add(this.richTbCommand);
            this.panelBG.Controls.Add(this.label2);
            this.panelBG.Controls.Add(this.label3);
            this.panelBG.Location = new System.Drawing.Point(13, 33);
            this.panelBG.Name = "panelBG";
            this.panelBG.Size = new System.Drawing.Size(775, 405);
            this.panelBG.TabIndex = 13;
            this.panelBG.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBG_Paint);
            // 
            // buttonSyntax
            // 
            this.buttonSyntax.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSyntax.Location = new System.Drawing.Point(654, 48);
            this.buttonSyntax.Name = "buttonSyntax";
            this.buttonSyntax.Size = new System.Drawing.Size(106, 35);
            this.buttonSyntax.TabIndex = 13;
            this.buttonSyntax.Text = "Syntax";
            this.buttonSyntax.UseVisualStyleBackColor = true;
            this.buttonSyntax.Click += new System.EventHandler(this.buttonSyntax_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelBG);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Procos V";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelBG.ResumeLayout(false);
            this.panelBG.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTbAction;
        private System.Windows.Forms.RichTextBox richTbCommand;
        private System.Windows.Forms.Panel panelOutput;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.Panel panelBG;
        private System.Windows.Forms.Button buttonSyntax;
        private System.Windows.Forms.ToolStripMenuItem instructionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        /// <summary>
        /// making to public to use it in other classes
        /// </summary>
        public System.Windows.Forms.RichTextBox richTbConsole;
    }
}

