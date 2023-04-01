// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");


static void zad1()
{
    Stack<int> s = new Stack<int>();
    Console.WriteLine("N =  ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine($"Размерность стека {n}");
    for (int i = 1; i <= n; i++)
    {
        s.Push(i);
    }
    Console.WriteLine($"Верхний элемент стека = {n}");
    Console.WriteLine($"Размерность стека {n}");
    Console.Write($"Содержимое стека = ");
    while (s.Count > 0)
    {
        Console.Write($" {s.Pop()}");
    }
    s.Clear();
    Console.WriteLine($"\nНовая размерность {s.Count}");
}

static void zad2()
{
    bool boolean = false;
    Stack<int> s = new Stack<int>();
    Console.WriteLine("Введите формулу");
    string form = Console.ReadLine();
    File.WriteAllText("t.txt", form);
    string str = File.ReadAllText("t.txt");
    for (int i = 0; i < str.Length; i++)
    {
        char c = str[i];

        if (c == '"')
        {
            boolean = !boolean;
        }
        else if (!boolean)
        {
            if (c == '(')
            {
                s.Push(i);
            }
            else if (c == ')')
            {
                if (s.Count > 0)
                {
                    s.Pop();
                }
                else
                {
                    Console.WriteLine("Возможно лишнии ) скобка в позиции: {0}", i + 1);
                    return;
                }
            }
        }
    }
    if (s.Count == 0)
    {
        Console.WriteLine("Скобки сбалансированы");
    }
    else
    {
        Console.WriteLine("Возможно лишнии ( скобка в позиции: {0}", s.Pop() + 1);
        Console.ReadLine();
    }

    Console.ReadLine();
    string f = File.ReadAllText("t.txt");

    int open = 0;
    int close = 0;
    for (int i = 0; i < f.Length; i++)
    {
        char c = f[i];
        if (c == '(') open++;
        else if (c == ')') close++;
    }

    int openToAdd = close - open;
    int closeToAdd = open - close;

    if (openToAdd > 0)
    {
        f = new string('(', openToAdd) + f;
    }
    else if (closeToAdd > 0)
    {
        f = f + new string(')', closeToAdd);
    }
    else if (openToAdd < 0)
    {
        int remove = -openToAdd;
        for (int i = 0; i < remove; i++)
        {
            int index = f.LastIndexOf('(');
            if (index == -1)
            {
                break; 
            }
            f = f.Remove(index, 1);
            
        }
    }
    else if (closeToAdd < 0)
    {
        int remove = -closeToAdd;
        for (int i = 0; i < remove; i++)
        {
            int index = f.IndexOf(')');
            if (index == -1)
            {
                break; 
            }
            f = f.Remove(index, 1);
            
        }
    }

    File.WriteAllText("t1.txt", f);

}
zad1();
zad2();