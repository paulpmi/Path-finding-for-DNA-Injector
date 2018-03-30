using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stratec
{
    public partial class Form1 : Form
    {
        public class Node
        {
            int posI;
            int posJ;
            int value;
            int priority;

            public Node(int i, int j, int v)
            {
                posI = i;
                posJ = j;
                value = v;
                priority = 0;
            }

            public int getI()
            {
                return posI;
            }

            public int getJ()
            {
                return posJ;
            }

            public int getValue()
            {
                return value;
            }

            public void setProprity(int p)
            {
                priority = p;
            }

            public int getPriority()
            {
                return priority;
            }

            public void updateValue(int v)
            {
                value = v;
            }

            public string toString()
            {
                return value.ToString();
            }
        }

        const int MATRIX_ROWS = 25;
        const int MATRIX_COLUMNS = 25;

        List<Node> Nodes = new List<Node>();

        int[,] matrix = new int[MATRIX_ROWS, MATRIX_COLUMNS];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            this.Paint += Draw2DArray;

            listBox1.Items.Add(-1);
            listBox1.Items.Add(4);
            listBox1.Items.Add(5);
            listBox1.Items.Add(3);
            listBox1.Items.Add(1);
            listBox1.Items.Add(8);
            listBox1.Items.Add(9);

            
            //FindPathsGreedy(20, 1, 2, 12, evade);

        }

        private void Draw2DArray(object sender, PaintEventArgs e)
        {
            int step = 5;
            int width = 4;
            int height = 4;

            using (Graphics g = this.CreateGraphics())
            {
                g.Clear(SystemColors.Control);
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    int rows = matrix.GetUpperBound(0) + 1 - matrix.GetLowerBound(0);
                    int columns = matrix.GetUpperBound(1) + 1 - matrix.GetLowerBound(1);

                    for (int index = 0; index < matrix.Length; index++)
                    {
                        int i = index / columns;
                        int j = index % columns;
                        if (matrix[i,j] == 5)
                        { 
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Red, rect);
                        }
                        if (matrix[i, j] == 4)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Blue, rect);
                        }
                        if (matrix[i, j] == 2)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Yellow, rect);
                        }
                        if (matrix[i, j] == -1)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Gray, rect);
                        }
                        if (matrix[i, j] == 9)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Violet, rect);
                        }
                        if (matrix[i, j] == 1)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Green, rect);
                        }
                        if (matrix[i, j] == 3)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Pink, rect);
                        }
                        if (matrix[i, j] == 8)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.LightBlue, rect);
                        }
                        if (matrix[i, j] == 7)
                        {
                            Rectangle rect = new Rectangle(new Point(5 + step * j, 5 + step * i), new Size(width, height));
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(System.Drawing.Brushes.Black, rect);
                        }

                    }
                }
            }
        }

        private void InitializeGrid()
        {
            for(int i = 0; i < MATRIX_ROWS; i++)
{
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    matrix[i, j] = 0;
                    Node n = new Node(i, j, 0);

                    Nodes.Add(n);

                }
            }

            areaInitializer(8, 8, 8, 20, -1);

            areaInitializer(1, 13, 2, 2, -1);

            areaInitializer(1, 6, 6, 13, 2);

            areaInitializer(1, 6, 16, 23, 2);

            areaInitializer(11, 12, 5, 13, 9);

            areaInitializer(15, 23, 1, 1, 5);

            areaInitializer(15, 23, 3, 3, 5);

            areaInitializer(15, 23, 5, 5, 5);

            areaInitializer(15, 23, 7, 7, 5);

            areaInitializer(11, 23, 15, 15, 8);

            areaInitializer(11, 23, 17, 17, 8);

            areaInitializer(11, 23, 19, 19, 8);

            areaInitializer(11, 23, 21, 21, 8);

            areaInitializer(11, 23, 23, 23, 8);

            areaInitializer(16, 17, 10, 11, 1);

            areaInitializer(19, 19, 10, 11, 3);

            areaInitializer(22, 22, 10, 11, 3);

            areaInitializer(20, 21, 9, 9, 3);

            areaInitializer(20, 21, 12, 12, 3);

            areaInitializer(1, 1, 1, 1, 4);

            areaInitializer(2, 2, 3, 3, 4);

            areaInitializer(3, 3, 1, 1, 4);

            areaInitializer(4, 4, 3, 3, 4);

            areaInitializer(5, 5, 1, 1, 4);

            areaInitializer(6, 6, 3, 3, 4);

            areaInitializer(7, 7, 1, 1, 4);

            areaInitializer(8, 8, 3, 3, 4);

            areaInitializer(9, 9, 1, 1, 4);

            areaInitializer(10, 10, 3, 3, 4);

            areaInitializer(11, 11, 1, 1, 4);

            areaInitializer(12, 12, 3, 3, 4);

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                string s = "";
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    s += Nodes[i * MATRIX_COLUMNS + j].toString();
                    s += " ";
                }

                Console.WriteLine(s);
            }
        }

        private int heruistic(int positionI, int positionJ, int endI, int endJ)
        {
            return Math.Abs(Nodes[positionI * MATRIX_COLUMNS + positionJ].getI() - endI) +
                Math.Abs(Nodes[positionI * MATRIX_COLUMNS + positionJ].getJ() - endJ);
        }

        private List<Node> FindPathsAStar(int positionI, int positionJ, int endI, int endJ, List<int> evade)
        {
            int startI = positionI;
            int startJ = positionJ;
            
            List<Node> path = new List<Node>();
            List<Node> removed = new List<Node>();
            Dictionary<Node, Node> closedList = new Dictionary<Node, Node>();
            Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
            
            path.Add(Nodes[positionI * MATRIX_COLUMNS + positionJ]);
            costSoFar.Add(Nodes[positionI * MATRIX_COLUMNS + positionJ], 0);
            closedList.Add(Nodes[positionI * MATRIX_COLUMNS + positionJ], new Node(20, 1, -1));

            int index = 0;

            Node prevCurrent = path[0];
            Node current;

            while (true)
            {
                current = path[index];

                path.Remove(current);
                removed.Add(current);
                
                List<Node> neghtbors = findNeighbors(current.getI(), current.getJ(), evade);

                foreach (Node next in neghtbors)
                {
                    int cost = costSoFar[current] + 1;
                    if (!costSoFar.ContainsKey(next))
                    {
                        costSoFar.Add(next, cost);
                        int priority = cost + heruistic(next.getI(), next.getJ(), endI, endJ);
                        next.setProprity(priority);
                        path.Add(next);
                        closedList.Add(next, current);
                    }
                    else
                    {
                        if (cost < costSoFar[next])
                        {
                            costSoFar[next] = cost;
                            int priority = cost + heruistic(next.getI(), next.getJ(), endI, endJ);
                            path.Remove(next);
                            next.setProprity(priority);
                            path.Add(next);
                            closedList[next] = current;
                        }   
                    }
                }

                prevCurrent = current;

                if (current.getI() == endI && current.getJ() == endJ)
                    break;

                path = path.OrderBy(n => n.getPriority()).ToList();
                index = 0;
            }

            List<Node> finalPath = new List<Node>();

            Node curr = Nodes[startI * MATRIX_COLUMNS + startJ];
            finalPath.Add(Nodes[endI * MATRIX_COLUMNS + endJ]);
            finalPath.Add(current);
            while (closedList.Keys.Contains(current))
            {
                current = closedList[current];
                finalPath.Add(current);
            }

            finalPath.Reverse();
            return finalPath;
            
            
        }

        private List<string> ManageMoves(List<Node> finalPath, int endI, int endJ)
        {
            List<string> moves = new List<string>();
            Node prev = finalPath[1];
            int currentNeedleHeight = prev.getValue();

            string prevAction = "";
            string checkAction = "";

            for (int i = 2; i < finalPath.Count; i++)
            {

                //Console.WriteLine(finalPath[i].getI() + " " + finalPath[i].getJ() + " vs " + endI + " " + endJ);

                string c = "";
                string currentAction = "";

                if (finalPath[i].getI() == endI && finalPath[i].getJ() == endJ)
                {
                    Console.WriteLine("HERE");
                    c = "Z";
                    for (int q = 0; q < Math.Abs(finalPath[i].getValue() + currentNeedleHeight); q++)
                        currentAction += c;

                    currentNeedleHeight = finalPath[i].getValue();

                }
                else

                if (finalPath[i].getValue() > currentNeedleHeight)
                {
                    c = "P";
                    for (int q = 0; q < Math.Abs(finalPath[i].getValue() - currentNeedleHeight); q++)
                        currentAction += c;

                    currentNeedleHeight = finalPath[i].getValue();
                }

                Nodes[finalPath[i].getI() * MATRIX_COLUMNS + finalPath[i].getJ()] = new Node(finalPath[i].getI(), finalPath[i].getJ(), 7);
                matrix[finalPath[i].getI(), finalPath[i].getJ()] = 7;


                if (finalPath[i].getI() == prev.getI() + 1)
                    currentAction += "D";
                if (finalPath[i].getI() == prev.getI() - 1)
                    currentAction += "U";
                if (finalPath[i].getJ() == prev.getJ() - 1)
                    currentAction += "L";
                if (finalPath[i].getJ() == prev.getJ() + 1)
                    currentAction += "R";

                if (i == 2)
                {
                    checkAction = currentAction;
                    prevAction = currentAction;
                }
                else
                    if (checkAction != currentAction)
                {
                    moves.Add(prevAction);
                    prevAction = currentAction;
                    checkAction = currentAction;
                }
                else
                {
                    prevAction += currentAction;
                    checkAction = currentAction;
                }

                prev = finalPath[i];
            }

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                string s = "";
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    s += Nodes[i * MATRIX_COLUMNS + j].toString();
                    s += " ";
                }
                Console.WriteLine(s);
            }

            string str = "";
            for (int i = 0; i < moves.Count; i++)
            {
                var m = moves[i];
                str += m + " ";
            }
            Console.WriteLine(str);

            return moves;
        }

        private List<Node> findNeighbors(int positionI, int positionJ, List<int> evade)
        {
            List<Node> result = new List<Node>();

            if (Nodes.ElementAtOrDefault(positionI * MATRIX_COLUMNS + (positionJ + 1)) != null &&
                evade.Contains(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getValue()) == false)
            {
                result.Add(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)]);
            }

            if (Nodes.ElementAtOrDefault((positionI + 1) * MATRIX_COLUMNS + positionJ) != null &&
                evade.Contains(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getValue()) == false)
            {
                result.Add(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ]);
            }

            if (Nodes.ElementAtOrDefault(positionI * MATRIX_COLUMNS + (positionJ - 1)) != null &&
                evade.Contains(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getValue()) == false)
            { 
                result.Add(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)]);
            }

            if (Nodes.ElementAtOrDefault((positionI - 1) * MATRIX_COLUMNS + positionJ) != null &&
                evade.Contains(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getValue()) == false)
            {
                result.Add(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ]);
            }

            return result;
        }

        private List<string> FindPathsGreedy(int positionI, int positionJ, int endI, int endJ, List<int> evade)
        {
            Queue<Node> path = new Queue<Node>();
            Queue<string> result = new Queue<string>();
            List<Node> visited = new List<Node>();

            List<string> moves = new List<string>();
            List<List<string>> allPaths = new List<List<string>>();

            visited.Add(Nodes[positionI * positionJ]);

            int min = MATRIX_COLUMNS * MATRIX_ROWS;
            Node candidate = new Node(-1, -1, 1);
            string res = "";

            if (Nodes.ElementAtOrDefault(positionI * MATRIX_COLUMNS + (positionJ + 1)) != null &&
                evade.Contains(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getValue()) == false && 
                min >= Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getI() - endI) +
                Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getJ() - endJ))
            {
                
                res = "R";
                min = Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getI() - endI) +
                Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getJ() - endJ);

                candidate = Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)];

            }

            if (Nodes.ElementAtOrDefault((positionI + 1) * MATRIX_COLUMNS + positionJ) != null && 
                evade.Contains(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getValue()) == false &&
                min >= Math.Abs(Nodes[(positionI +1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                Math.Abs(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ)
                )
            {
                res = "D";
                min = Math.Abs(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                Math.Abs(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ);

                candidate = Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ];

            }

            if (Nodes.ElementAtOrDefault(positionI * MATRIX_COLUMNS + (positionJ - 1)) != null &&
                evade.Contains(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getValue()) == false &&
                min >= Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getI() - endI) +
                Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getJ() - endJ) )
            {
                
                res = "L";
                min = Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getI() - endI) +
                Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getJ() - endJ);

                candidate = Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)];

            }

            if (Nodes.ElementAtOrDefault((positionI - 1) * MATRIX_COLUMNS + positionJ) != null &&
                evade.Contains(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getValue()) == false &&
                min >= Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ) )
            {
                res = "U";
                min = Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ);

                candidate = Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ];
            }

            path.Enqueue(candidate);
            result.Enqueue(res);

            while(path.Any())
            {
                var p = path.Dequeue();
                positionI = p.getI();
                positionJ = p.getJ();

                moves.Add(result.Dequeue());

                Console.WriteLine("Position: " + positionI.ToString() + " " + positionJ.ToString());

                if (positionI != endI || positionJ != endJ)
                {

                    if (Nodes.ElementAtOrDefault(positionI * MATRIX_COLUMNS + (positionJ + 1)) != null &&
                evade.Contains(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getValue()) == false &&
                min >= Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getI() - endI) +
                Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getJ() - endJ))
                    {
                        
                        res = "R";
                        min = Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getI() - endI) +
                        Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)].getJ() - endJ);

                        candidate = Nodes[positionI * MATRIX_COLUMNS + (positionJ + 1)];

                    }

                    if (Nodes.ElementAtOrDefault((positionI + 1) * MATRIX_COLUMNS + positionJ) != null &&
                        evade.Contains(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getValue()) == false &&
                        min >= Math.Abs(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                        Math.Abs(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ)
                        )
                    {
                        
                        res = "D";
                        min = Math.Abs(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                        Math.Abs(Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ);

                        candidate = Nodes[(positionI + 1) * MATRIX_COLUMNS + positionJ];

                    }

                    if (Nodes.ElementAtOrDefault(positionI * MATRIX_COLUMNS + (positionJ - 1)) != null &&
                        evade.Contains(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getValue()) == false &&
                        min >= Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getI() - endI) +
                        Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getJ() - endJ) )
                    {
                        
                        res = "L";
                        min = Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getI() - endI) +
                        Math.Abs(Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)].getJ() - endJ);

                        candidate = Nodes[positionI * MATRIX_COLUMNS + (positionJ - 1)];

                    }

                    if (Nodes.ElementAtOrDefault((positionI - 1) * MATRIX_COLUMNS + positionJ) != null &&
                        evade.Contains(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getValue()) == false &&
                        min >= Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                        Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ))
                    {
                        
                        res = "U";
                        min = Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getI() - endI) +
                        Math.Abs(Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ].getJ() - endJ);

                        candidate = Nodes[(positionI - 1) * MATRIX_COLUMNS + positionJ];
                    }

                    result.Enqueue(res);
                    path.Enqueue(candidate);
                }
                else
                {
                    Console.WriteLine("FOUND");
                    allPaths.Add(moves);
                    moves = new List<string>();
                    visited = new List<Node>();

                }
            }

            Console.WriteLine("Results: ");

            foreach (var ap in allPaths)
            {
                string s = "";
                foreach (var p in ap)
                    s += p + " ";
                Console.WriteLine(s);
            }

            return allPaths[0];
        }

        private void areaInitializer(int rowLocationStart, int rowLocationEnd, int colLocationStart, int colLocationEnd, int value)
        {
            for (int i = rowLocationStart; i <= rowLocationEnd; i++)
                for (int j = colLocationStart; j <= colLocationEnd; j++)
                {
                    matrix[i, j] = value;

                    Nodes[i*MATRIX_COLUMNS+j].updateValue(value);
                }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> evade = new List<int>();

            foreach (var item in listBox2.Items)
                evade.Add(int.Parse(item.ToString()));

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Please Insert the Start Position and End Position", "Not existing Points",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int startPosI = int.Parse(textBox1.Text);
                int startPosJ = int.Parse(textBox2.Text);
                int endPosI = int.Parse(textBox3.Text);
                int endPosJ = int.Parse(textBox4.Text);

                List<Node> path = FindPathsAStar(startPosI, startPosJ, endPosI, endPosJ, evade);
                List<string> moves = ManageMoves(path, endPosI, endPosJ);

                string s = "";
                foreach (var m in moves)
                    s += m + " ";
                textBox5.Text = s;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> evade = new List<int>();

            foreach (var item in listBox2.Items)
                evade.Add(int.Parse(item.ToString()));

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Please Insert the Start Position and End Position", "Not existing Points",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int startPosI = int.Parse(textBox1.Text);
                int startPosJ = int.Parse(textBox2.Text);
                int endPosI = int.Parse(textBox3.Text);
                int endPosJ = int.Parse(textBox4.Text);

                List<string> moves = FindPathsGreedy(startPosI, startPosJ, endPosI, endPosJ, evade);

                string s = "";
                foreach (var m in moves)
                    s += m + " ";
                textBox5.Text = s;
            }
        }
    }
}
