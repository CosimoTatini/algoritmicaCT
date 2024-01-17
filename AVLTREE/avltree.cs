

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;
    public int Height;

    public Node(int valore)
    {
        Value = valore;
        Left = null;
        Right = null;
        Height = 1; // Inizialmente, un nuovo nodo ha altezza 1
    }
}

public class AVLTree
{
    public Node Root;

    public AVLTree()
    {
        Root = null;
    }

    // Restituisce l'altezza di un nodo
    private int Height(Node node)
    {
        if (node == null)
            return 0;
        return node.Height;
    }

    // Restituisce il massimo tra due interi
    private int Max(int a, int b)
    {
        return (a > b) ? a : b;
    }

    // Calcola il fattore di bilanciamento di un nodo
    private int BilanceFactor(Node node)
    {
        if (node == null)
            return 0;
        return Height(node.Left) - Height(node.Right);
    }

    // Esegue una rotazione a sinistra intorno a un nodo
    private Node LeftRotate(Node y)
    {
        Node x = y.Right;
        Node T2 = x.Left;

        // Esegui la rotazione
        x.Left = y;
        y.Right = T2;

        // Aggiorna le altezze
        y.Height = Max(Height(y.Left), Height(y.Right)) + 1;
        x.Height = Max(Height(x.Left), Height(x.Right)) + 1;

        // Restituisci il nuovo nodo radice
        return x;
    }

    // Esegue una rotazione a destra intorno a un nodo
    private Node RightRotate(Node x)
    {
        Node y = x.Left;
        Node T2 = y.Right;

        // Esegui la rotazione
        y.Right = x;
        x.Left = T2;

        // Aggiorna le altezze
        x.Height = Max(Height(x.Left), Height(x.Right)) + 1;
        y.Height = Max(Height(y.Left), Height(y.Right)) + 1;

        // Restituisci il nuovo nodo radice
        return y;
    }

    // Inserisce un nuovo nodo nell'albero AVL
    public Node Inserisci(Node root, int value)
    {
        // Esegui l'inserimento come in un albero binario di ricerca
        if (root == null)
            return new Node(value);

        if (value < root.Value)
            root.Left = Inserisci(root.Left, value);
        else if (value > root.Value)
            root.Right = Inserisci(root.Right, value);
        else
            return root; // Nodi con valori duplicati non sono consentiti in un BST

        // Aggiorna l'altezza del nodo corrente
        root.Height = 1 + Max(Height(root.Left), Height(root.Right));

        // Calcola il fattore di bilanciamento
        int balance = BilanceFactor(root);

        // Esegui le rotazioni per bilanciare l'albero
        // Rotazione a sinistra
        if (balance > 1 && value < root.Left.Value)
            return RightRotate(root);

        // Rotazione a destra
        if (balance < -1 && value > root.Right.Value)
            return LeftRotate(root);

        // Rotazione a sinistra-destra
        if (balance > 1 && value > root.Left.Value)
        {
            root.Left = LeftRotate(root.Left);
            return RightRotate(root);
        }

        // Rotazione a destra-sinistra
        if (balance < -1 && value < root.Right.Value)
        {
            root.Right = RightRotate(root.Right);
            return LeftRotate(root);
        }

        // Nessuna rotazione necessaria
        return root;
    }

    // Esegue la cancellazione di un nodo dall'albero AVL
    public Node Remove(Node root, int value)
    {
        // Esegui la cancellazione come in un albero binario di ricerca
        if (root == null)
            return root;

        if (value < root.Value)
            root.Left = Remove(root.Left, value);
        else if (value > root.Value)
            root.Right = Remove(root.Right, value);
        else
        {
            // Nodo con un solo figlio o nessun figlio
            if ((root.Left == null) || (root.Right == null))
            {
                Node temp = null;
                if (temp == root.Left)
                    temp = root.Right;
                else
                    temp = root.Left;

                // Nessun figlio
                if (temp == null)
                {
                    temp = root;
                    root = null;
                }
                else // Un figlio
                    root = temp; // Copia il contenuto del figlio non nullo
            }
            else
            {
                // Nodo con due figli: trova il successore (il più piccolo nel sottoalbero destro)
                Node temp = FindMin(root.Right);

                // Copia il valore del successore nel nodo corrente
                root.Value = temp.Value;

                // Cancella il successore
                root.Right = Remove(root.Right, temp.Value);
            }
        }

        // Se l'albero ha solo un nodo, restituisci radice
        if (root == null)
            return root;

        // Aggiorna l'altezza del nodo corrente
        root.Height = 1 + Max(Height(root.Left), Height(root.Right));

        // Calcola il fattore di bilanciamento
        int bilanciamento = BilanceFactor(root);

        // Esegui le rotazioni per bilanciare l'albero
        // Rotazione a sinistra
        if (bilanciamento > 1 && BilanceFactor(root.Left) >= 0)
            return RightRotate(root);

        // Rotazione a destra
        if (bilanciamento < -1 && BilanceFactor(root.Right) <= 0)
            return LeftRotate(root);

        // Rotazione a sinistra-destra
        if (bilanciamento > 1 && BilanceFactor(root.Left) < 0)
        {
            root.Left = LeftRotate(root.Left);
            return RightRotate(root);
        }

        // Rotazione a destra-sinistra
        if (bilanciamento < -1 && BilanceFactor(root.Right) > 0)
        {
            root.Right = RightRotate(root.Right);
            return LeftRotate(root);
        }

        // Nessuna rotazione necessaria
        return root;
    }

    // Trova il nodo con il valore minimo nell'albero
    private Node FindMin(Node node)
    {
        Node currentNode = node;

        // Trova il nodo più a sinistra
        while (currentNode.Left != null)
            currentNode = currentNode.Left;

        return currentNode;
    }
}

public class Program
{
    public static void Main()
    {
        // Creazione di un albero AVL di esempio
        AVLTree alberoAVL = new AVLTree();
        alberoAVL.Root = alberoAVL.Inserisci(alberoAVL.Root, 15);
        alberoAVL.Root = alberoAVL.Inserisci(alberoAVL.Root, 25);
        alberoAVL.Root = alberoAVL.Inserisci(alberoAVL.Root, 35);
        alberoAVL.Root = alberoAVL.Inserisci(alberoAVL.Root, 10);
        alberoAVL.Root = alberoAVL.Inserisci(alberoAVL.Root, 5);

        // Stampa l'albero AVL dopo l'inserimento
        Console.WriteLine("Albero AVL dopo l'inserimento:");
        StampaInOrdine(alberoAVL.Root);
        Console.WriteLine();

        // Cancellazione di un nodo dall'albero AVL
        alberoAVL.Root = alberoAVL.Remove(alberoAVL.Root, 25);

        // Stampa l'albero AVL dopo la cancellazione
        Console.WriteLine("Albero AVL dopo la cancellazione:");
        StampaInOrdine(alberoAVL.Root);
    }

    // Funzione di stampa in ordine
    static void StampaInOrdine(Node radice)
    {
        if (radice != null)
        {
            StampaInOrdine(radice.Left);
            Console.Write(radice.Value + " ");
            StampaInOrdine(radice.Right);
        }
    }
}

