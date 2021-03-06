﻿namespace FidgetSpinnerEditor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBoxEditor = new System.Windows.Forms.PictureBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.openPrevFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.externalEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.counterclockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.holesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.generatePreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogBin = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogBin = new System.Windows.Forms.OpenFileDialog();
            this.colorDialogBody = new System.Windows.Forms.ColorDialog();
            this.colorDialogLights = new System.Windows.Forms.ColorDialog();
            this.colorDialogHoles = new System.Windows.Forms.ColorDialog();
            this.openFileDialogImport = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.fileSystemWatcherExternalEditor = new System.IO.FileSystemWatcher();
            this.batchConvertFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.toImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToBinariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialogConversion = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditor)).BeginInit();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherExternalEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxEditor
            // 
            this.pictureBoxEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEditor.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxEditor.Location = new System.Drawing.Point(22, 50);
            this.pictureBoxEditor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxEditor.Name = "pictureBoxEditor";
            this.pictureBoxEditor.Size = new System.Drawing.Size(1210, 1148);
            this.pictureBoxEditor.TabIndex = 0;
            this.pictureBoxEditor.TabStop = false;
            this.pictureBoxEditor.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBoxEditor_DragDrop);
            this.pictureBoxEditor.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBoxEditor_DragEnter);
            this.pictureBoxEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxEditor_Paint);
            this.pictureBoxEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEditor_MouseMove);
            this.pictureBoxEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEditor_MouseMove);
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStripMain.Size = new System.Drawing.Size(1254, 42);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripMenuItem8,
            this.openPrevFileToolStripMenuItem,
            this.openNextFileToolStripMenuItem,
            this.toolStripMenuItem4,
            this.batchConvertFolderToolStripMenuItem,
            this.toolStripMenuItem9,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(298, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(298, 6);
            // 
            // openPrevFileToolStripMenuItem
            // 
            this.openPrevFileToolStripMenuItem.Enabled = false;
            this.openPrevFileToolStripMenuItem.Name = "openPrevFileToolStripMenuItem";
            this.openPrevFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.openPrevFileToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.openPrevFileToolStripMenuItem.Text = "Previous file";
            this.openPrevFileToolStripMenuItem.Click += new System.EventHandler(this.openPrevFileToolStripMenuItem_Click);
            // 
            // openNextFileToolStripMenuItem
            // 
            this.openNextFileToolStripMenuItem.Enabled = false;
            this.openNextFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openNextFileToolStripMenuItem.Image")));
            this.openNextFileToolStripMenuItem.Name = "openNextFileToolStripMenuItem";
            this.openNextFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.openNextFileToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.openNextFileToolStripMenuItem.Text = "Next &file";
            this.openNextFileToolStripMenuItem.Click += new System.EventHandler(this.openNextFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(298, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.saveAsToolStripMenuItem.Text = "&Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.exportToolStripMenuItem.Text = "E&xport...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(298, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.quitToolStripMenuItem.Text = "&Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertToolStripMenuItem,
            this.reverseToolStripMenuItem,
            this.toolStripMenuItem6,
            this.externalEditorToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(60, 34);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.invertToolStripMenuItem.Text = "&Invert colors";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // reverseToolStripMenuItem
            // 
            this.reverseToolStripMenuItem.Name = "reverseToolStripMenuItem";
            this.reverseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reverseToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.reverseToolStripMenuItem.Text = "&Reverse direction";
            this.reverseToolStripMenuItem.Click += new System.EventHandler(this.reverseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(331, 6);
            // 
            // externalEditorToolStripMenuItem
            // 
            this.externalEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("externalEditorToolStripMenuItem.Image")));
            this.externalEditorToolStripMenuItem.Name = "externalEditorToolStripMenuItem";
            this.externalEditorToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.externalEditorToolStripMenuItem.Text = "&Edit in external editor";
            this.externalEditorToolStripMenuItem.Click += new System.EventHandler(this.externalEditorToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateClockwiseToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.generatePreviewToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(69, 34);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // rotateClockwiseToolStripMenuItem
            // 
            this.rotateClockwiseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.counterclockwiseToolStripMenuItem,
            this.clockwiseToolStripMenuItem});
            this.rotateClockwiseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rotateClockwiseToolStripMenuItem.Image")));
            this.rotateClockwiseToolStripMenuItem.Name = "rotateClockwiseToolStripMenuItem";
            this.rotateClockwiseToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.rotateClockwiseToolStripMenuItem.Text = "&Rotate";
            // 
            // counterclockwiseToolStripMenuItem
            // 
            this.counterclockwiseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("counterclockwiseToolStripMenuItem.Image")));
            this.counterclockwiseToolStripMenuItem.Name = "counterclockwiseToolStripMenuItem";
            this.counterclockwiseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.counterclockwiseToolStripMenuItem.Size = new System.Drawing.Size(307, 34);
            this.counterclockwiseToolStripMenuItem.Text = "&Counter-clockwise";
            this.counterclockwiseToolStripMenuItem.Click += new System.EventHandler(this.counterclockwiseToolStripMenuItem_Click);
            // 
            // clockwiseToolStripMenuItem
            // 
            this.clockwiseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clockwiseToolStripMenuItem.Image")));
            this.clockwiseToolStripMenuItem.Name = "clockwiseToolStripMenuItem";
            this.clockwiseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.clockwiseToolStripMenuItem.Size = new System.Drawing.Size(307, 34);
            this.clockwiseToolStripMenuItem.Text = "C&lockwise";
            this.clockwiseToolStripMenuItem.Click += new System.EventHandler(this.clockwiseToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bodyToolStripMenuItem,
            this.toolStripMenuItem3,
            this.holesToolStripMenuItem,
            this.toolStripMenuItem7,
            this.resetToDefaultToolStripMenuItem});
            this.colorsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("colorsToolStripMenuItem.Image")));
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.colorsToolStripMenuItem.Text = "&Colors";
            // 
            // bodyToolStripMenuItem
            // 
            this.bodyToolStripMenuItem.Name = "bodyToolStripMenuItem";
            this.bodyToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.bodyToolStripMenuItem.Text = "&Body...";
            this.bodyToolStripMenuItem.Click += new System.EventHandler(this.bodyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(250, 34);
            this.toolStripMenuItem3.Text = "&Enabled...";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.lightsToolStripMenuItem_Click);
            // 
            // holesToolStripMenuItem
            // 
            this.holesToolStripMenuItem.Name = "holesToolStripMenuItem";
            this.holesToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.holesToolStripMenuItem.Text = "&Disabled...";
            this.holesToolStripMenuItem.Click += new System.EventHandler(this.holesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(247, 6);
            // 
            // resetToDefaultToolStripMenuItem
            // 
            this.resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
            this.resetToDefaultToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.resetToDefaultToolStripMenuItem.Text = "&Reset to default";
            this.resetToDefaultToolStripMenuItem.Click += new System.EventHandler(this.resetToDefaultToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(262, 6);
            this.toolStripMenuItem5.Visible = false;
            // 
            // generatePreviewToolStripMenuItem
            // 
            this.generatePreviewToolStripMenuItem.Name = "generatePreviewToolStripMenuItem";
            this.generatePreviewToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.generatePreviewToolStripMenuItem.Text = "Generate &preview";
            this.generatePreviewToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 34);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutProgramToolStripMenuItem.Image")));
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(195, 34);
            this.aboutProgramToolStripMenuItem.Text = "&About";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // openFileDialogBin
            // 
            this.openFileDialogBin.Filter = "Bin file (*.bin)|*.bin";
            // 
            // openFileDialogImport
            // 
            this.openFileDialogImport.Filter = "Supported images|*.bmp;*.gif;*.png;*.jpeg;*.jpg";
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.Filter = "BMP (*.bmp)|*.bmp";
            // 
            // fileSystemWatcherExternalEditor
            // 
            this.fileSystemWatcherExternalEditor.EnableRaisingEvents = true;
            this.fileSystemWatcherExternalEditor.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcherExternalEditor.SynchronizingObject = this;
            this.fileSystemWatcherExternalEditor.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcherExternalEditor_Changed);
            // 
            // batchConvertFolderToolStripMenuItem
            // 
            this.batchConvertFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toImagesToolStripMenuItem,
            this.imagesToBinariesToolStripMenuItem});
            this.batchConvertFolderToolStripMenuItem.Name = "batchConvertFolderToolStripMenuItem";
            this.batchConvertFolderToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.batchConvertFolderToolStripMenuItem.Text = "Batch";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(298, 6);
            // 
            // toImagesToolStripMenuItem
            // 
            this.toImagesToolStripMenuItem.Name = "toImagesToolStripMenuItem";
            this.toImagesToolStripMenuItem.Size = new System.Drawing.Size(289, 34);
            this.toImagesToolStripMenuItem.Text = "Binaries to images...";
            this.toImagesToolStripMenuItem.Click += new System.EventHandler(this.toImagesToolStripMenuItem_Click);
            // 
            // imagesToBinariesToolStripMenuItem
            // 
            this.imagesToBinariesToolStripMenuItem.Name = "imagesToBinariesToolStripMenuItem";
            this.imagesToBinariesToolStripMenuItem.Size = new System.Drawing.Size(289, 34);
            this.imagesToBinariesToolStripMenuItem.Text = "Images to binaries...";
            this.imagesToBinariesToolStripMenuItem.Click += new System.EventHandler(this.imagesToBinariesToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1254, 1220);
            this.Controls.Add(this.pictureBoxEditor);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormMain";
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditor)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherExternalEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxEditor;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogBin;
        private System.Windows.Forms.OpenFileDialog openFileDialogBin;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem counterclockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem holesToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogBody;
        private System.Windows.Forms.ColorDialog colorDialogLights;
        private System.Windows.Forms.ColorDialog colorDialogHoles;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem generatePreviewToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogImport;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.ToolStripMenuItem openNextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem externalEditorToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcherExternalEditor;
        private System.Windows.Forms.ToolStripMenuItem reverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPrevFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem batchConvertFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToBinariesToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogConversion;
    }
}

