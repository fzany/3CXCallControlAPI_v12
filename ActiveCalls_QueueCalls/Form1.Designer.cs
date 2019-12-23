namespace ActiveCalls_QueueCalls
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
            this.actveCallsLabel = new System.Windows.Forms.Label();
            this.queueCallsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(65, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Calls";
            // 
            // actveCallsLabel
            // 
            this.actveCallsLabel.AutoSize = true;
            this.actveCallsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actveCallsLabel.Location = new System.Drawing.Point(175, 59);
            this.actveCallsLabel.Name = "actveCallsLabel";
            this.actveCallsLabel.Size = new System.Drawing.Size(41, 13);
            this.actveCallsLabel.TabIndex = 1;
            this.actveCallsLabel.Text = "label2";
            // 
            // queueCallsLabel
            // 
            this.queueCallsLabel.AutoSize = true;
            this.queueCallsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queueCallsLabel.Location = new System.Drawing.Point(175, 94);
            this.queueCallsLabel.Name = "queueCallsLabel";
            this.queueCallsLabel.Size = new System.Drawing.Size(41, 13);
            this.queueCallsLabel.TabIndex = 3;
            this.queueCallsLabel.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(65, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Calls in Queues";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 323);
            this.Controls.Add(this.queueCallsLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.actveCallsLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label actveCallsLabel;
        private System.Windows.Forms.Label queueCallsLabel;
        private System.Windows.Forms.Label label3;
    }
}

