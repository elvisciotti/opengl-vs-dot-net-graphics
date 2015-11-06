using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
//using System.Windows.Forms;
using System.Collections; // per ArrayList !!!!!!!!!!!!!
using System.IO; //per scrivere su file
using System.Data.OleDb;
using System.Drawing.Imaging;



namespace ase1
{
    public partial class Form1// : Form //partial: accedibile da + files
    {
        // ---------------------------------------------------------- Quick Sort con indici maniezzo
        // http://astarte.csr.unibo.it/snippets/QuickSort.txt
        // A=valori, ind=indici che riordina e ritorna (deve essere da 0, 1, 2...) , p e r
        void Quicksort(int[] A, int[] ind, int p, int r)
        {
            int q;

            if (p < r)
            {
                q = partition(A, ind, p, r);
                Quicksort(A, ind, p, q);
                Quicksort(A, ind, q + 1, r);
            }
        }

        void Quicksort(double[] A, int[] ind, int p, int r)
        {
            int q;

            if (p < r)
            {
                q = partition(A, ind, p, r);
                Quicksort(A, ind, p, q);
                Quicksort(A, ind, q + 1, r);
            }
        }

        int partition(int[] A, int[] ind, int p, int r)
        {
            int i, j, x, temp;
            x = A[ind[p]];
            i = p - 1;
            j = r + 1;
            while (true)
            {
                do j = j - 1;
                while (A[ind[j]] > x);

                do i = i + 1;
                while (A[ind[i]] < x);

                if (i < j)
                {
                    temp = ind[i];
                    ind[i] = ind[j];
                    ind[j] = temp;
                }
                else
                    return (j);
            }
        }

        int partition(double[] A, int[] ind, int p, int r)
        {
            int i, j, temp;
            double x;
            x = A[ind[p]];
            i = p - 1;
            j = r + 1;
            while (true)
            {
                do j = j - 1;
                while (A[ind[j]] > x);

                do i = i + 1;
                while (A[ind[i]] < x);

                if (i < j)
                {
                    temp = ind[i];
                    ind[i] = ind[j];
                    ind[j] = temp;
                }
                else
                    return (j);
            }
        }

        //agisce su d e p dei nodi, leggendo archi[] e d[]
        void Dijkstra(int s)
        {
            int i, j, u = -1, Q, minQ;
            bool[] S = new bool[N_NODI];

            for (i = 0; i < N_NODI; i++)
            {
                nodi[i].d = INF;
                nodi[i].p = INF;
                S[i] = false;      // ---- S = \emptyset
            }
            nodi[s].d = 0;
            nodi[s].p = s;

            Q = N_NODI;
            while (Q != 0)
            {  // --------------------- u = Extract-Min(Q)
                minQ = INF;
                for (i = 0; i < N_NODI; i++)
                    if (!S[i] && nodi[i].d < minQ)
                    {
                        minQ = nodi[i].d;
                        u = i;
                    }
                // ---------------------- S = S \bigcup {u}
                S[u] = true;
                Q--;

                for (i = 0; i < archi[u].Count; i++)
                {
                    j = (int)archi[u][i];
                    if (nodi[j].d > nodi[u].d + (int)d[u][i])
                    {
                        nodi[j].d = nodi[u].d + (int)d[u][i];
                        nodi[j].p = u;
                    }
                }
            }
        }

    }
}