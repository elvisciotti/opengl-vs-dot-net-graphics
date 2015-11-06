using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections; // per ArrayList !!!!!!!!!!!!!
using System.IO; //per scrivere su file
using System.Data.OleDb;
using System.Drawing.Imaging;

namespace ase1
{
    partial class Form1
    {
        void Loadtxt()
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                txt_principale.Text = "seleziona un file !";
                return;
            }

            StreamReader f = new StreamReader(openFileDialog1.FileName, false); //apro in w false.

            //txt_principale.AppendText("Carico grafo da file in memoria...\r\n");
            N_NODI = Convert.ToInt32(f.ReadLine());
            DEG = Convert.ToInt32(textBox_deg.Text);
            settaNnodi(N_NODI);


            String s;

            //leggo nodi
            for (int i = 0; i < N_NODI; i++)
            {
                //int a, b, c;

                s = f.ReadLine();

                nodi[i].x = Convert.ToInt32(s.Substring(FILE_TAB_SPACE, FILE_TAB_SPACE));
                nodi[i].y = Convert.ToInt32(s.Substring(2 * FILE_TAB_SPACE, FILE_TAB_SPACE));
                nodi[i].name = Convert.ToString(i);
                //archi[i].RemoveRange(0, archi[i].Count );

                //d[i].RemoveRange(0, d[i].Count);

                archi[i] = new ArrayList();
                d[i] = new ArrayList();
            }

            //leggo archi
            m = Convert.ToInt32(f.ReadLine());

            for (int j = 0; j < m; j++) // per ogni arco...
            {

                s = f.ReadLine();
                int from = Convert.ToInt32(s.Substring(0, FILE_TAB_SPACE));
                int dest = Convert.ToInt32(s.Substring(FILE_TAB_SPACE, FILE_TAB_SPACE));
                int dist = Convert.ToInt32(s.Substring(2 * FILE_TAB_SPACE, FILE_TAB_SPACE));

                //aggiungo arco
                archi[from].Add(dest);
                d[from].Add(dist);

            }
            txt_principale.AppendText("Grafo caricato in memoria\r\n");
            //DrawGraph();
        }

        void SavetxtToFile()
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                txt_principale.Text = "seleziona un file !";
                return;
            }
            Savetxt(saveFileDialog1.FileName);
        }


        void Savetxt(String filePath)
        {
            StreamWriter f = new StreamWriter(filePath, false); //apro in w
            //f.WriteLine("Num. nodi = {0} m = {1}", n, m);
            f.WriteLine(N_NODI);
            int i;
            for (i = 0; i < N_NODI; i++)
            {
                f.WriteLine("{0," + FILE_TAB_SPACE + "}{1," + FILE_TAB_SPACE + "}{2," + FILE_TAB_SPACE + "}{3," + FILE_TAB_SPACE + "}", i, nodi[i].x, nodi[i].y, nodi[i].name);
            }

            f.WriteLine(m);
            for (i = 0; i < N_NODI; i++) // per ogni nodo...
            {
                for (int jjj = 0; jjj < archi[i].Count; jjj++)
                {
                    //origine, dest, lunghezza

                    int nodo_arr = Convert.ToInt32(archi[i][jjj]);

                    f.WriteLine("{0," + FILE_TAB_SPACE + "}{1," + FILE_TAB_SPACE + "}{2," + FILE_TAB_SPACE + "}", i, nodi[nodo_arr].name, d[i][jjj]);
                }
            }
            f.Close();
            //txt_principale.Clear();
            txt_principale.AppendText("\r\nGrafo salvato su file !\r\n");
        }

        void salvaSuDb()
        {
            if (N_NODI == 0)
            {
                MessageBox.Show("Crea prima il grafo !");
                return;
            }


            string sconn;
            sconn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb";
            OleDbConnection conn = new OleDbConnection(sconn);

            try
            {
                conn.Open();

                new OleDbCommand("DELETE * FROM nodi", conn).ExecuteScalar();
                new OleDbCommand("DELETE * FROM archi", conn).ExecuteScalar();

                String q = "UPDATE parametri set valore='" + N_NODI + "' WHERE parametro='n'";
                //txt_principale.AppendText(q + "\n");
                new OleDbCommand(q, conn).ExecuteScalar();

                for (int i = 0; i < N_NODI; i++)
                {
                    String q_insert = "INSERT INTO nodi (x,y,nome) VALUES (" + nodi[i].x + "," + nodi[i].y + ",'" + nodi[i].name + "') ";
                    //txt_principale.AppendText(q_insert + "\n");
                    new OleDbCommand(q_insert, conn).ExecuteScalar();

                }

                for (int i = 0; i < N_NODI; i++) // per ogni nodo...
                {
                    for (int jjj = 0; jjj < archi[i].Count; jjj++)
                    {
                        //origine, dest, lunghezza

                        int nodo_arr = Convert.ToInt32(archi[i][jjj]);


                        String q_insert = "INSERT INTO archi (x,y,dist) VALUES (" + i + ",'" + (nodi[nodo_arr].name) + "','" + d[i][jjj] + "') ";
                        //txt_principale.AppendText(q_insert + "\n");
                        new OleDbCommand(q_insert, conn).ExecuteScalar();

                    }
                }
                txt_principale.AppendText("Salvato su DB");
                conn.Close();

            }
            catch (OleDbException e)
            {
                MessageBox.Show("Errore DB" + e.Message);
            }


        }

        int getint32(String query, int num_colonn, OleDbConnection conn)
        {
            OleDbDataReader myreader = new OleDbCommand(query, conn).ExecuteReader();
            myreader.Read();
            return myreader.GetInt32(num_colonn);


        }

        void caricaDaDb()
        {


            string sconn;
            sconn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb";
            OleDbConnection conn = new OleDbConnection(sconn);



            try
            {
                conn.Open();

                N_NODI = getint32("SELECT valore FROM parametri WHERE parametro='n' ", 0, conn);
                settaNnodi(N_NODI);
                m = getint32("SELECT valore FROM parametri WHERE parametro='m' ", 0, conn);


                //leggo nodi
                OleDbDataReader myreader = new OleDbCommand("select x,y,nome from nodi", conn).ExecuteReader();

                for (int i = 0; i < N_NODI; i++)
                {
                    nodi[i].x = nodi[i].y = 0;
                    archi[i] = new ArrayList();
                    d[i] = new ArrayList();

                }

                while (myreader.Read())
                {
                    int x;
                    int y;
                    int nome;
                    //int a, b, c;
                    //myreader.Read();


                    x = myreader.GetInt32(0);
                    y = myreader.GetInt32(1);
                    nome = Convert.ToInt32(myreader.GetString(2));

                    nodi[nome].x = x;
                    nodi[nome].y = y;
                    nodi[nome].name = Convert.ToString(nome);


                    archi[nome] = new ArrayList();
                    d[nome] = new ArrayList();
                }



                //leggo archi
                myreader = new OleDbCommand("select x,y,dist from archi", conn).ExecuteReader();
                //for (int j = 0; j < m; j++) // per ogni arco...
                while (myreader.Read())
                {
                    int from;
                    int dest;
                    int dist;

                    //myreader.Read();

                    from = myreader.GetInt32(0);
                    dest = myreader.GetInt32(1);
                    dist = myreader.GetInt32(2);


                    //aggiungo arco
                    if (archi[from] == null)
                        archi[from] = new ArrayList();

                    if (d[from] == null)
                        d[from] = new ArrayList();

                    archi[from].Add(dest);
                    d[from].Add(dist);

                }

                DrawGraph();


                conn.Close();


            }
            catch (OleDbException e)
            {
                MessageBox.Show("Errore DB" + e.Message);
            }

        }

        
    }
}
