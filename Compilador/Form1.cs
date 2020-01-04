using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Globalization;

namespace Compilador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //**variables de menú archivo
        string RutaArchivo;
        string NombreArchivo;
        bool CambiosArchivo = false;

        //**variables de compilado y coloreado
        Hashtable claves;
        static string[] instrucciones = {"ORG", "NOP", "MOVLW", "MOVF", "MOVWF", "ADDLW", "SUBLW", "ANDLW", "IORLW", "COMW", "RLF", "RRF", "GOTO", "JPC", "JPZ", "RETURN", "END", "CALL", "RETURN" };
        int Actulineas = 0;
        

        private void compilarSoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compilar(false);
        }

        private void compilarYProgramarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compilar(true);
        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compilar(false);
        }

        void Compilar(bool programar)
        {
            string[] programa = new string[1024];
            int contador = 0;

            string[] lineas = richTextBox1.Lines;
            claves = new Hashtable();
            AgregarClaves();

            //barra de progreso
            Progreso.Value = 0;
            Progreso.Maximum = lineas.Length * 2;
            labelCompilado.Text = "Compilando...";


            bool doblepasada = false;

            for (int o = 0; o < 2; o++)
            {
                contador = 0;

                for (int i = 0; i < lineas.Length; i++)
                {
                    string temp = lineas[i];
                    temp = temp.ToUpper();          //TODO EN MAYUSCULAS
                    temp = temp.Replace("\t", " ");  //ELIMINAMOS TABULADORES
                    temp = EliminaEspIniciales(temp);


                    if (temp.Contains("ORG"))       //si la contiene ORG, asignamos el numero siguiente al contador
                    {
                        temp = temp.Replace("ORG", "");
                        temp = temp.Replace(" ", "");
                        temp = FormatoORG(temp);
                        if (temp == null)
                        {
                            MessageBox.Show("Error en frase: '" + lineas[i] + "'", "ERROR línea: " + (i + 1).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            labelCompilado.Text = "Error en frase: '" + lineas[i] + "'";
                            return;
                        }

                        if (temp.Length > 2) temp = temp.Remove(2);
                        int Rdir = Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber);
                        if (Rdir < contador)
                        {
                            MessageBox.Show("Asignación de memoria ya ocupada: '" + lineas[i] + "'", "ERROR línea: " + (i + 1).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            labelCompilado.Text = "Asignación de memoria ya ocupada: '" + lineas[i] + "'";
                            return;
                        }
                        else contador = Rdir;


                    }
                    else if (temp == "") { }          //no hacemos nada
                    else if (temp.Replace(" ", "")[0] == ';') { }       //es un comentario
                    else if (temp[0] == '*')        //programar direccion con nombre
                    {
                        if (!doblepasada)
                        {
                            temp = temp.Replace("*", "");
                            temp = temp.Replace(" ", "");
                            if (temp.Contains(";")) temp = temp.Remove(temp.IndexOf(';'));


                            string cont = contador.ToString("X").PadLeft(2, '0');
                            claves.Add(temp, cont);
                        }
                    }
                    else if (temp[0] == '#')      //direccion de memoria, agregar al diccionario
                    {
                        if (!doblepasada)
                        {
                            temp = temp.Replace("#", "");
                            if (temp.Contains(";")) temp = temp.Remove(temp.IndexOf(';'));

                            temp = FormatoDirMem(temp);

                            if (temp == null)
                            {
                                MessageBox.Show("Error en frase: '" + lineas[i] + "', formato de dirección inválido.", "ERROR línea: " + (i + 1).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                labelCompilado.Text = "Error en frase: '" + lineas[i] + "', formato de dirección inválido.";
                                return;
                            }

                            string direccion = temp.Remove(0, temp.Length - 2);
                            string nombre = temp.Remove(temp.Length - 2, 2).Replace(" ", "");


                            claves.Add(nombre, direccion);  //comprovar que la direccion es valida
                        }
                    }
                    else
                    {
                        temp = temp.Replace(" ", "");
                        string instruccion = ConvertInstr(temp, contador.ToString("X").PadLeft(2, '0'));
                        if (instruccion == null)
                        {
                            MessageBox.Show("Error en frase: '" + lineas[i] + "'", "ERROR línea: " + (i + 1).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            labelCompilado.Text = "Error en frase: '" + lineas[i] + "'";
                            return;
                        }
                        else programa[contador] = instruccion;
                        contador++;
                    }
                    Progreso.Value++;
                }
                doblepasada = true;
            }

            GuardarBinario(programa, contador, programar);
        }

        string EliminaEspIniciales(string N)
        {
            for(int i=0;i<N.Length;i++)
            {
                //32
                if (N[i] != 32) { N = N.Remove(0, i); break; }
            }
            return N;
        }

        string FormatoDirMem(string N)
        {
            if (N.Length == 0) return null;

            //[0][1]
            char split = ' ';
            string[] seps = N.Split(split);

            string Dir = "";
            bool A = true;

            N = "";

            for (int i = 0; i < seps.Length; i++)
            {
                if (seps[i] != "")
                {
                    if (A) { Dir = seps[i]; A = false; }
                    else { N = seps[i]; break; }
                }   
            }
            
            if (N.Length == 1) N = "0" + N;
            if (N.Length == 0) N = "00";

            char n0 = N[0];
            char n1 = N[1];

            if (!((n0 > 47 && n0 < 58) || (n0 > 64 && n0 < 71))) return null;
            if (!((n1 > 47 & n1 < 58) || (n1 > 64 & n1 < 71))) return null;
            //else N = N.Insert(0, "0");
            
            return Dir+N;
        }

        string FormatoORG(string N)
        {
            if(N == "") return "00";
            if (N.Length == 1) N = "0" + N;

            foreach (DictionaryEntry e in claves)
            {
                N = N.Replace(e.Key.ToString(), e.Value.ToString());
            }

            char n0 = N[0];
            char n1 = N[1];

            if (!((n0 > 47 && n0 < 58) || (n0 > 64 && n0 < 71))) return null;
            if ((n1 > 47 && n1 < 58) || (n1 > 64 && n1 < 71)) return N;
            else N = N.Insert(0, "0");

            return N;            
        }

        void AgregarClaves()
        {
            claves.Add("PORTA", "80");
            //claves.Add("TRISA", "81");
            claves.Add("UART", "81");
            claves.Add("PRAM", "88");
            claves.Add("PROM", "89");
            claves.Add("INT", "8A");
        }

        string ConvertInstr(string linea, string contador)
        {
            linea = linea.Replace(" ", "");
            linea = linea.Replace("\t", "");
            if (linea.Contains(';'))
            {
                int a = linea.IndexOf(';');
                int b = linea.Length;
                linea = linea.Remove(a , b-a);
            }

            foreach(DictionaryEntry e in claves)
            {
                linea = linea.Replace(e.Key.ToString(), e.Value.ToString());
            }

            if (linea.Contains("NOP")) linea = linea.Replace("NOP", "00");
            else if (linea.Contains("MOVLW")) linea = linea.Replace("MOVLW", "01");
            else if (linea.Contains("MOVF")) linea = linea.Replace("MOVF", "02");
            else if (linea.Contains("MOVWF")) linea = linea.Replace("MOVWF", "03");
            else if (linea.Contains("ADDLW")) linea = linea.Replace("ADDLW", "04");
            else if (linea.Contains("SUBLW")) linea = linea.Replace("SUBLW", "05");
            else if (linea.Contains("ANDLW")) linea = linea.Replace("ANDLW", "06");
            else if (linea.Contains("IORLW")) linea = linea.Replace("IORLW", "07");
            else if (linea.Contains("COMW")) linea = linea.Replace("COMW", "08");
            else if (linea.Contains("RLF")) linea = linea.Replace("RLF", "09");
            else if (linea.Contains("RRF")) linea = linea.Replace("RRF", "0A");
            else if (linea.Contains("GOTO")) linea = linea.Replace("GOTO", "0B");
            else if (linea.Contains("JPC")) linea = linea.Replace("JPC", "0C");
            else if (linea.Contains("JPZ")) linea = linea.Replace("JPZ", "0D");
            else if (linea.Contains("CALL")) linea = linea.Replace("CALL", "0E");
            else if (linea.Contains("RETURN")) linea = linea.Replace("RETURN", "0F");
            else if (linea.Contains("END")) linea = "0B" + contador;
            else return null;

            if (linea.Length == 3)
                linea = linea.Insert(2, "0");
            else
                linea = linea.PadRight(4, '0');

            return linea;

        }

        void GuardarBinario(string[] pr, int instrucciones, bool programar)
        {
            if (RutaArchivo == null)
                GuardarArchivo(true);

            if (RutaArchivo != null)
            {
                string RutaArchivoBIN = RutaArchivo.Replace(".asm", ".bin");
                string RutaArchivoICE = RutaArchivo.Replace(".asm", ".txt");

                FileStream fs = new FileStream(RutaArchivoBIN, FileMode.Create);
                BinaryWriter escribir = new BinaryWriter(fs);
                StreamWriter escribirIce = new StreamWriter(RutaArchivoICE, false);

                byte[] programa_bin = new byte[(instrucciones * 2) + 1];
                int cont_bin = 0;

                for (int i = 0; i < instrucciones; i++)
                {
                    escribirIce.WriteLine(pr[i]);   //escribe en txt para la IceZum

                    //test
                    string hexString = pr[i];
                    byte[] data = new byte[hexString.Length / 2];

                    for (int index = 0; index < data.Length; index++)
                    {
                        string byteValue = hexString.Substring(index * 2, 2);
                        byte temp = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                        escribir.Write(temp);
                        programa_bin[cont_bin] = temp;
                        cont_bin++;
                    }
                }
                programa_bin[programa_bin.Length -1] = byte.Parse("FF", NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                fs.Close();
                escribir.Close();
                escribirIce.Close();

                labelCompilado.Text = NombreArchivo + ".bin compilado con éxito | Memoria utilizada: " + instrucciones;
                if (programar) Programar(programa_bin);
            }
        }

        void Programar(byte[] binario)
        {
            try
            {
                serialPort1.Open();         //abrimos puerto serie
                bool error = true;

                for(int i=0; i<5;i++)
                {
                    if (serialPort1.CtsHolding)
                    {
                        serialPort1.Write(binario, 0, binario.Length);
                        labelCompilado.Text = labelCompilado.Text + " | Programa cargado";
                        error = false;
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);                        
                    }
                }

                if(error) MessageBox.Show("Datos no cargados. Compruebe que el uC está en modo programación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
            serialPort1.Close();
        }

        //-----------------ZONA DE COLOREADO DE INSTRUCCIONES----------------------------------------------

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(!CambiosArchivo)
            {
                this.Text = "JHM Compiler **(" + NombreArchivo + ")";
                CambiosArchivo = true;
            }

            int lns = richTextBox1.Lines.Length;            

            if (lns > Actulineas + 1)
                RepintadoColores();

            else
                PintaInstruccionesIndividuales();

            Actulineas = lns;
            LabelColumnas.Text = "líneas "  + lns;
            labelCompilado.Text = "";
            Progreso.Value = 0;
        }

        void PintaInstruccionesIndividuales()
        {
            int posactual = richTextBox1.SelectionStart;
            int Ilinea = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int Nlinea = richTextBox1.GetLineFromCharIndex(Ilinea);

            PintaLineaNegro(Nlinea, posactual);
            PintaInstrucciones(Nlinea, posactual);
            PintaDireccionesROM(Nlinea, posactual);
            PintaDireccionesRAM(Nlinea, posactual);
            PintaComentarios(Nlinea, posactual);

        }

        void RepintadoColores()
        {
            int Nlineas = richTextBox1.Lines.Length;
            int posactual = richTextBox1.SelectionStart;

            for (int i = 0; i < Nlineas; i++)
            {
                PintaLineaNegro(i, posactual);
                PintaInstrucciones(i, posactual);
                PintaDireccionesROM(i, posactual);
                PintaDireccionesRAM(i, posactual);
                PintaComentarios(i, posactual);
            }
        }


        //colores de lineas 
        
        void PintaLineaNegro(int Nlinea, int posactual)
        {
            int Ilinea = richTextBox1.GetFirstCharIndexFromLine(Nlinea);
            int Longlinea = 0;
            bool error = false;
            try { Longlinea = richTextBox1.Lines[Nlinea].Length; }
            catch { error = true; }

            if (!error)
            {
                richTextBox1.Select(Ilinea, Longlinea);
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.Select(posactual, 0);
            }
        }
        
        void PintaInstrucciones(int Nlinea, int posactual)
        {
            int palabra = -1;
            int Ilinea = richTextBox1.GetFirstCharIndexFromLine(Nlinea);
            int Longlina = 0;
            int longPalabra = 0;
            bool error = false;

            try { Longlina = richTextBox1.Lines[Nlinea].Length; }
            catch { error = true; }

            int Flinea = Ilinea + Longlina;


            if (!error)
            {

                for (int i = 0; i < instrucciones.Length; i++)
                {
                    palabra = richTextBox1.Find(instrucciones[i], Ilinea, Flinea + 1, RichTextBoxFinds.None);
                    longPalabra = instrucciones[i].Length;
                    if (palabra != -1) break;
                }
                if (palabra != -1)
                {
                    richTextBox1.Select(palabra, longPalabra);
                    richTextBox1.SelectionColor = Color.DarkCyan;
                    richTextBox1.Select(posactual, 0);
                    richTextBox1.SelectionColor = Color.Black;
                }
            }
        }

        void PintaDireccionesROM(int Nlinea, int posactual)
        {
            int palabra = -1;
            int Ilinea = richTextBox1.GetFirstCharIndexFromLine(Nlinea);
            int Longlina = 0;
            bool error = false;

            try { Longlina = richTextBox1.Lines[Nlinea].Length; }
            catch { error = true; }

            int Flinea = Ilinea + Longlina;

            if (!error)
            {
                palabra = richTextBox1.Find("*", Ilinea, Flinea + 1, RichTextBoxFinds.NoHighlight);
                if (palabra != -1)
                {
                    richTextBox1.Select(palabra, Longlina);
                    richTextBox1.SelectionColor = Color.DarkMagenta;
                    richTextBox1.Select(posactual, 0);
                    richTextBox1.SelectionColor = Color.Black;
                }
            }
        }

        void PintaDireccionesRAM(int Nlinea, int posactual)
        {
            int palabra = -1;
            int Ilinea = richTextBox1.GetFirstCharIndexFromLine(Nlinea);
            int Longlina = 0;
            bool error = false;

            try { Longlina = richTextBox1.Lines[Nlinea].Length; }
            catch { error = true; }

            int Flinea = Ilinea + Longlina;

            if (!error)
            {
                palabra = richTextBox1.Find("#", Ilinea, Flinea + 1, RichTextBoxFinds.NoHighlight);
                if (palabra != -1)
                {
                    richTextBox1.Select(palabra, Longlina);
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.Select(posactual, 0);
                    richTextBox1.SelectionColor = Color.Black;
                }
            }
        }

        void PintaComentarios(int Nlinea, int posactual)
        {
            int palabra = -1;
            int Ilinea = richTextBox1.GetFirstCharIndexFromLine(Nlinea);
            int Longlina = 0;
            bool error = false;

            try { Longlina = richTextBox1.Lines[Nlinea].Length; }
            catch { error = true; }

            int Flinea = Ilinea + Longlina;

            if (!error)
            {
                palabra = richTextBox1.Find(";", Ilinea, Flinea + 1, RichTextBoxFinds.MatchCase);
                if (palabra != -1)
                {
                    richTextBox1.Select(palabra, Flinea - palabra);
                    richTextBox1.SelectionColor = Color.Green;
                    richTextBox1.Select(posactual, 0);
                    richTextBox1.SelectionColor = Color.Black;
                }
            }
        }

        //*********************************barra lateral derecha****************************************

        private void BoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar > 47 && e.KeyChar < 58 || e.KeyChar == 8))
                e.Handled = true;
        }

        private void BoxHexa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar > 64 && e.KeyChar < 71) || (e.KeyChar > 96 && e.KeyChar < 103) || (e.KeyChar == 8)))
                e.Handled = true;
        }

        private void BoxDecimal_TextChanged(object sender, EventArgs e)
        {
            this.BoxHexa.TextChanged -= new System.EventHandler(this.BoxHexa_TextChanged);
            //BoxHexa.Text= Int32.Parse(BoxDecimal.Text, System.Globalization.NumberStyles.HexNumber).ToString();
            if (BoxDecimal.Text != "")
                BoxHexa.Text = Int32.Parse(BoxDecimal.Text).ToString("X");   
            this.BoxHexa.TextChanged += new System.EventHandler(this.BoxHexa_TextChanged);
        }

        private void BoxHexa_TextChanged(object sender, EventArgs e)
        {
            this.BoxDecimal.TextChanged -= new System.EventHandler(this.BoxDecimal_TextChanged);
            if (BoxHexa.Text != "")
                BoxDecimal.Text = Int32.Parse(BoxHexa.Text, System.Globalization.NumberStyles.HexNumber).ToString();

            this.BoxDecimal.TextChanged += new System.EventHandler(this.BoxDecimal_TextChanged);
        }

        //***********************MENU ARCHIVO***************************



        //ABRIR
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirArchivo = new OpenFileDialog();                                           //Creamos el objeto de dialogo
            AbrirArchivo.DefaultExt = ".asm";
            AbrirArchivo.Filter = "Assembly|*.asm|Text Files|*.txt";

            if (CambiosArchivo)
            {
                DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios?", "¿Guardar cambios?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (RutaArchivo == null) GuardarArchivo(true);
                    else GuardarArchivo(false);                    
                }
                else if (resultado == DialogResult.Cancel) return;
            }

            if (AbrirArchivo.ShowDialog() == DialogResult.OK)                                                //si el resultado es OK, abrimos el archivo
            {
                this.richTextBox1.TextChanged -= new System.EventHandler(this.richTextBox1_TextChanged);    //Desactiva el evento de cambio de texto

                RutaArchivo = AbrirArchivo.FileName;                            //ruta del archivo
                NombreArchivo = Path.GetFileNameWithoutExtension(RutaArchivo);  //nombre del archivo sin la ruta
                this.Text = "JHM Compiler (" + NombreArchivo + ")";             //ponemos el nombre arriba

                using (StreamReader sr = new StreamReader(RutaArchivo, Encoding.Default))         //abrimos el archivo
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
                richTextBox1.SelectionStart = richTextBox1.Text.Length;         //situamos el cursor al final del texto abierto
                CambiosArchivo = false;                                         //seteamos en falso la variable que indica si hay cambios en el archivo
                Actulineas = 0;

                RepintadoColores();                                                                         //pintamos los colores del texto
                this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);    //reactivamos el evento por cambio de texto
            }
        }

        //guardar
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RutaArchivo != null) GuardarArchivo(false);     //Si el archivo a guardar no es nuevo, guardamos en ruta conocida.
            else GuardarArchivo(true);                          //Si no hay ruta conocida, guardamos en nuevo archivo
        }

        //guardarcomo
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarArchivo(true);
        }

        //Rutina de guardado
        private void GuardarArchivo(bool NuevoGuardado)
        {
            if(NuevoGuardado)
            {
                SaveFileDialog GArchivo = new SaveFileDialog();
                GArchivo.DefaultExt = ".asm";
                GArchivo.Filter = "Assembly|*.asm|Text Files|*.txt";

                if (GArchivo.ShowDialog() == DialogResult.OK)
                {
                    RutaArchivo = GArchivo.FileName;
                    NombreArchivo = Path.GetFileNameWithoutExtension(RutaArchivo);

                    using (StreamWriter sw = new StreamWriter(RutaArchivo, false, Encoding.Default))
                    {
                        sw.Write(richTextBox1.Text);
                        sw.Close();

                        CambiosArchivo = false;
                        this.Text = "JHM Compiler (" + NombreArchivo + ")";             //ponemos el nombre arriba
                    }
                }
                
            }
            else                        //Si no es nuevo guardado, guardamos el archivo en la ruta conocida
            {
                using (StreamWriter sw = new StreamWriter(RutaArchivo, false, Encoding.Default))
                {
                    sw.Write(richTextBox1.Text);
                    sw.Close();
                    CambiosArchivo = false;
                    this.Text = "JHM Compiler (" + NombreArchivo + ")";             //ponemos el nombre arriba
                }
            }
        }

        //Limpieza de ventana
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //desea guardar cambios?
            if (CambiosArchivo)
            {
                DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios?", "¿Guardar cambios?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (RutaArchivo == null) GuardarArchivo(true);
                    else GuardarArchivo(false);

                    NuevoArchivo();
                }
                else if (resultado == DialogResult.No) NuevoArchivo();
            }
            else NuevoArchivo();
        }

        void NuevoArchivo()
        {
            richTextBox1.Clear();
            Actulineas = 0;
            RutaArchivo = null;
            NombreArchivo = null;
            CambiosArchivo = false;
            this.Text = "JHM Compiler";
            labelCompilado.Text = "...";
            LabelColumnas.Text = "líneas 0";
            Progreso.Value = 0;

            claves = new Hashtable();
            AgregarClaves();
            treeView1.Nodes[1].Nodes.Clear();
            foreach (DictionaryEntry e in claves)
            {
                treeView1.Nodes[1].Nodes.Add(e.Key.ToString() + " " + e.Value.ToString());
            }
            //treeView1.ExpandAll();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CambiosArchivo)
            {
                DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios?", "¿Guardar cambios?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (RutaArchivo == null) GuardarArchivo(true);
                    else GuardarArchivo(false);
                }
                else if (resultado == DialogResult.Cancel) e.Cancel = true;
            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            LineaCursor();
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            LineaCursor();
        }

        void LineaCursor()
        {
            int Ilinea = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int Nlinea = richTextBox1.GetLineFromCharIndex(Ilinea);
            labelFila.Text = "actual " + (Nlinea + 1).ToString();

            int Ninstruccion = PreCompilar(Nlinea);
            if (Ninstruccion == -1) Ninstruccion = 0;   //para futura modificacion

            labelDireccion.Text = "Dir. nº " + Ninstruccion.ToString();

            treeView1.Nodes[1].Nodes.Clear();
            foreach (DictionaryEntry e in claves)
                treeView1.Nodes[1].Nodes.Add(e.Key.ToString() + " " + e.Value.ToString());
            treeView1.ExpandAll();
            //treeView1.Sort();
        }

        int PreCompilar(int lineaentrada)
        {            
            int contador = 0;
            int PosMemoria = 0;

            string[] lineas = richTextBox1.Lines;
            claves = new Hashtable();
            AgregarClaves();
            
            
                contador = 0;

                for (int i = 0; i < lineas.Length; i++)
                {
                    string temp = lineas[i];
                    temp = temp.ToUpper();          //TODO EN MAYUSCULAS
                    temp = temp.Replace("\t", " ");  //ELIMINAMOS TABULADORES
                    temp = EliminaEspIniciales(temp);


                    if (temp.Contains("ORG"))       //si la contiene ORG, asignamos el numero siguiente al contador
                    {
                        temp = temp.Replace("ORG", "");
                        temp = temp.Replace(" ", "");
                        temp = FormatoORG(temp);
                        if (temp == null) { return -1;}

                        if (temp.Length > 2) temp = temp.Remove(2);
                        int Rdir = Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber);
                        if (Rdir < contador)
                        {
                            labelCompilado.Text = "Error en línea " + (i + 1) + ". Asignación de memoria ya ocupada: '" + lineas[i] + "'";
                            return -1;
                        }
                        else contador = Rdir;


                    }
                    else if (temp == "") { }          //no hacemos nada
                    else if (temp.Replace(" ", "")[0] == ';') { }       //es un comentario
                    else if (temp[0] == '*')        //programar direccion con nombre
                    {                     
                            temp = temp.Replace("*", "");
                            temp = temp.Replace(" ", "");
                            if (temp.Contains(";")) temp = temp.Remove(temp.IndexOf(';'));

                            string cont = contador.ToString("X").PadLeft(2, '0');
                            try { claves.Add(temp, cont); }
                            catch { labelCompilado.Text = "Error en línea " + (i + 1) + ". Etiqueta ya utilizasa '" + lineas[i] + "'"; return -1; }
                      
                    }
                    else if (temp[0] == '#')      //direccion de memoria, agregar al diccionario
                    {
                        
                            temp = temp.Replace("#", "");
                            if (temp.Contains(";")) temp = temp.Remove(temp.IndexOf(';'));

                            temp = FormatoDirMem(temp);

                            if (temp == null)
                            {
                                labelCompilado.Text = "Error en frase: '" + lineas[i] + "', formato de dirección inválido.";
                                return -1;
                            }

                            string direccion = temp.Remove(0, temp.Length - 2);
                            string nombre = temp.Remove(temp.Length - 2, 2).Replace(" ", "");

                            try { claves.Add(nombre, direccion); }
                            catch { labelCompilado.Text = "Error en línea " + (i + 1) + ". Etiqueta ya utilizasa '" + lineas[i] + "'"; return -1; }
                    }
                    else
                    {
                        temp = temp.Replace(" ", "");
                        string instruccion = ConvertInstr(temp, contador.ToString("X").PadLeft(2, '0'));
                    if (instruccion == null) { return -1; }
                    else PosMemoria = contador;
                        contador++;

                    if (i == lineaentrada) return PosMemoria;
                    }

                }                
        return -1;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            treeView1.ExpandAll();
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.richTextBox1.TextChanged -= new System.EventHandler(this.richTextBox1_TextChanged);

            int posactual = richTextBox1.SelectionStart;
            string texto = treeView1.SelectedNode.Text;

            if (texto.Contains(" ")) texto = texto.Remove(texto.IndexOf(' '));
            else texto += " ";

            richTextBox1.Text = richTextBox1.Text.Insert(posactual, texto);
            richTextBox1.Focus();

            richTextBox1.SelectionStart = posactual + texto.Length;
            RepintadoColores();
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.Show();
        }

       
    }
}
