//Заполнение массива по диагоналям
using System.Collections.Specialized;

class ArrayDemo
{
    static void Main()
    {
        Console.WriteLine("Введите число: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 2)
        {
            Console.WriteLine("Ошибка! Введите число больше 1!");
            return;
        }
        int k = n * n;
        int[,] arr = new int[n, n];
        int sum = 1; //вес диагонали
        arr[0, 0] = k;
        bool flag = true; //направление по диагонали
        bool fl = true; //вес диагоналей увеличивается - true, уменьшается - false
        int i = 0, j = 0;
        while (k != 0)
        {
            int t = 0; //отвечает за место в диагонали
            if (flag)
            {
                if (fl) j++;
                else i++;
                arr[i, j] = --k; 
                for (int s = j - 1; t < sum; s--, t++)
                {
                    i++;
                    arr[i, s] = --k;
                    j = s;
                }
                flag = false;
            }
            else
            {
                if (fl) i++;
                else j++;
                arr[i, j] = --k;
                if (k == 1)
                    break;
                for (int s = j + 1; t < sum; t++, s++)
                {
                    i--;
                    arr[i, s] = --k;
                    j = s;
                }
                flag = true;
            }
            if (sum+1 == n) fl = false; //дошли до наибольшей диагонали, теперь вес уменьшается
            if (fl) sum++;
            else sum--;
        }
        //вывод массива:
        for(int q = 0; q < n; q++)
        {
            for(int w = 0; w < n; w++)
                Console.Write($"{arr[q,w]} ");
            Console.Write("\n");
        }
    }
}