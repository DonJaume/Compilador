﻿namespace Compilador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("ORG");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("NOP");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("MOVLW");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("MOVF");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("MOVWF");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("ADDLW");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("SUBLW");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("ANDLW");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("IORLW");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("COMW");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("RLF");
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("RRF");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("GOTO");
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("JPC");
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("JPZ");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("CALL");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("RETURN");
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("END");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("Instrucciones", new System.Windows.Forms.TreeNode[] {
            treeNode51,
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56,
            treeNode57,
            treeNode58,
            treeNode59,
            treeNode60,
            treeNode61,
            treeNode62,
            treeNode63,
            treeNode64,
            treeNode65,
            treeNode66,
            treeNode67,
            treeNode68});
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("PORTA 80");
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("UART 81");
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("PRAM 88");
            System.Windows.Forms.TreeNode treeNode73 = new System.Windows.Forms.TreeNode("PROM 89");
            System.Windows.Forms.TreeNode treeNode74 = new System.Windows.Forms.TreeNode("INT 8A");
            System.Windows.Forms.TreeNode treeNode75 = new System.Windows.Forms.TreeNode("Mem Mapeadas", new System.Windows.Forms.TreeNode[] {
            treeNode70,
            treeNode71,
            treeNode72,
            treeNode73,
            treeNode74});
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarSoluciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContenedorVertical = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.BoxDecimal = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.BoxHexa = new System.Windows.Forms.ToolStripTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.labelFila = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.LabelColumnas = new System.Windows.Forms.ToolStripLabel();
            this.Progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.labelCompilado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.labelDireccion = new System.Windows.Forms.ToolStripLabel();
            this.ContenedorHorizontal = new System.Windows.Forms.SplitContainer();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.compilarYProgramarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorVertical)).BeginInit();
            this.ContenedorVertical.Panel1.SuspendLayout();
            this.ContenedorVertical.Panel2.SuspendLayout();
            this.ContenedorVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorHorizontal)).BeginInit();
            this.ContenedorHorizontal.Panel1.SuspendLayout();
            this.ContenedorHorizontal.Panel2.SuspendLayout();
            this.ContenedorHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(956, 522);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarToolStripMenuItem,
            this.toolStripSeparator3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 32);
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ejecutarToolStripMenuItem.Text = "Compilar solución";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ejecutarToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.compilarToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // compilarToolStripMenuItem
            // 
            this.compilarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compilarSoluciónToolStripMenuItem,
            this.compilarYProgramarToolStripMenuItem});
            this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
            this.compilarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.compilarToolStripMenuItem.Text = "Compilar";
            // 
            // compilarSoluciónToolStripMenuItem
            // 
            this.compilarSoluciónToolStripMenuItem.Name = "compilarSoluciónToolStripMenuItem";
            this.compilarSoluciónToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.compilarSoluciónToolStripMenuItem.Text = "Compilar solución";
            this.compilarSoluciónToolStripMenuItem.Click += new System.EventHandler(this.compilarSoluciónToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // ContenedorVertical
            // 
            this.ContenedorVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ContenedorVertical.Location = new System.Drawing.Point(0, 0);
            this.ContenedorVertical.Name = "ContenedorVertical";
            // 
            // ContenedorVertical.Panel1
            // 
            this.ContenedorVertical.Panel1.Controls.Add(this.richTextBox1);
            // 
            // ContenedorVertical.Panel2
            // 
            this.ContenedorVertical.Panel2.Controls.Add(this.splitContainer1);
            this.ContenedorVertical.Size = new System.Drawing.Size(1093, 522);
            this.ContenedorVertical.SplitterDistance = 956;
            this.ContenedorVertical.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(133, 522);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripLabel1,
            this.BoxDecimal,
            this.toolStripLabel3,
            this.BoxHexa});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(133, 105);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(131, 15);
            this.toolStripLabel4.Text = "Conversor Dec<>Hex";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(131, 15);
            this.toolStripLabel1.Text = "Decimal:";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BoxDecimal
            // 
            this.BoxDecimal.Name = "BoxDecimal";
            this.BoxDecimal.Size = new System.Drawing.Size(129, 23);
            this.BoxDecimal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxDecimal_KeyPress);
            this.BoxDecimal.TextChanged += new System.EventHandler(this.BoxDecimal_TextChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(131, 15);
            this.toolStripLabel3.Text = "Hexadecimal:";
            this.toolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BoxHexa
            // 
            this.BoxHexa.Name = "BoxHexa";
            this.BoxHexa.Size = new System.Drawing.Size(129, 23);
            this.BoxHexa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxHexa_KeyPress);
            this.BoxHexa.TextChanged += new System.EventHandler(this.BoxHexa_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode51.Name = "ORG";
            treeNode51.Text = "ORG";
            treeNode52.Name = "NOP";
            treeNode52.Text = "NOP";
            treeNode53.Name = "MOVLW";
            treeNode53.Text = "MOVLW";
            treeNode54.Name = "MOVF";
            treeNode54.Text = "MOVF";
            treeNode55.Name = "MOVWF";
            treeNode55.Text = "MOVWF";
            treeNode56.Name = "ADDLW";
            treeNode56.Text = "ADDLW";
            treeNode57.Name = "SUBLW";
            treeNode57.Text = "SUBLW";
            treeNode58.Name = "ANDLW";
            treeNode58.Text = "ANDLW";
            treeNode59.Name = "IORLW";
            treeNode59.Text = "IORLW";
            treeNode60.Name = "COMW";
            treeNode60.Text = "COMW";
            treeNode61.Name = "RLF";
            treeNode61.Text = "RLF";
            treeNode62.Name = "RRF";
            treeNode62.Text = "RRF";
            treeNode63.Name = "GOTO";
            treeNode63.Text = "GOTO";
            treeNode64.Name = "JPC";
            treeNode64.Text = "JPC";
            treeNode65.Name = "JPZ";
            treeNode65.Text = "JPZ";
            treeNode66.Name = "CALL";
            treeNode66.Text = "CALL";
            treeNode67.Name = "RETURN";
            treeNode67.Text = "RETURN";
            treeNode68.Name = "END";
            treeNode68.Text = "END";
            treeNode69.ForeColor = System.Drawing.Color.Blue;
            treeNode69.Name = "Instrucciones";
            treeNode69.Text = "Instrucciones";
            treeNode70.Name = "PORTA 80";
            treeNode70.Text = "PORTA 80";
            treeNode71.Name = "UART 81";
            treeNode71.Text = "UART 81";
            treeNode72.Name = "PRAM 88";
            treeNode72.Text = "PRAM 88";
            treeNode73.Name = "PROM 89";
            treeNode73.Text = "PROM 89";
            treeNode74.Name = "INT 8A";
            treeNode74.Text = "INT 8A";
            treeNode75.ForeColor = System.Drawing.Color.Blue;
            treeNode75.Name = "Mem Mapeadas";
            treeNode75.Text = "Mem Mapeadas";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode69,
            treeNode75});
            this.treeView1.Size = new System.Drawing.Size(133, 413);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelFila,
            this.toolStripSeparator4,
            this.LabelColumnas,
            this.Progreso,
            this.labelCompilado,
            this.toolStripSeparator5,
            this.labelDireccion});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1093, 27);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // labelFila
            // 
            this.labelFila.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelFila.Name = "labelFila";
            this.labelFila.Size = new System.Drawing.Size(48, 24);
            this.labelFila.Text = "actual 0";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // LabelColumnas
            // 
            this.LabelColumnas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LabelColumnas.Name = "LabelColumnas";
            this.LabelColumnas.Size = new System.Drawing.Size(46, 24);
            this.LabelColumnas.Text = "líneas 0";
            this.LabelColumnas.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // Progreso
            // 
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(100, 24);
            // 
            // labelCompilado
            // 
            this.labelCompilado.Name = "labelCompilado";
            this.labelCompilado.Size = new System.Drawing.Size(16, 24);
            this.labelCompilado.Text = "...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // labelDireccion
            // 
            this.labelDireccion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(49, 24);
            this.labelDireccion.Text = "Dir. nº 0";
            // 
            // ContenedorHorizontal
            // 
            this.ContenedorHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ContenedorHorizontal.Location = new System.Drawing.Point(0, 24);
            this.ContenedorHorizontal.Name = "ContenedorHorizontal";
            this.ContenedorHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ContenedorHorizontal.Panel1
            // 
            this.ContenedorHorizontal.Panel1.Controls.Add(this.ContenedorVertical);
            // 
            // ContenedorHorizontal.Panel2
            // 
            this.ContenedorHorizontal.Panel2.Controls.Add(this.toolStrip2);
            this.ContenedorHorizontal.Size = new System.Drawing.Size(1093, 553);
            this.ContenedorHorizontal.SplitterDistance = 522;
            this.ContenedorHorizontal.TabIndex = 6;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM6";
            // 
            // compilarYProgramarToolStripMenuItem
            // 
            this.compilarYProgramarToolStripMenuItem.Name = "compilarYProgramarToolStripMenuItem";
            this.compilarYProgramarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.compilarYProgramarToolStripMenuItem.Text = "Compilar y programar";
            this.compilarYProgramarToolStripMenuItem.Click += new System.EventHandler(this.compilarYProgramarToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 577);
            this.Controls.Add(this.ContenedorHorizontal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "JHM Compiler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContenedorVertical.Panel1.ResumeLayout(false);
            this.ContenedorVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorVertical)).EndInit();
            this.ContenedorVertical.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ContenedorHorizontal.Panel1.ResumeLayout(false);
            this.ContenedorHorizontal.Panel2.ResumeLayout(false);
            this.ContenedorHorizontal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorHorizontal)).EndInit();
            this.ContenedorHorizontal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarSoluciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.SplitContainer ContenedorVertical;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel LabelColumnas;
        private System.Windows.Forms.SplitContainer ContenedorHorizontal;
        private System.Windows.Forms.ToolStripProgressBar Progreso;
        private System.Windows.Forms.ToolStripLabel labelCompilado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox BoxDecimal;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox BoxHexa;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel labelFila;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel labelDireccion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarYProgramarToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

