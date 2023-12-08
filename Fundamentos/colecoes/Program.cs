using System;
using System.Collections.Generic;
using System.Numerics;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {

        // GetIndex("leetcode");
        // Console.WriteLine(ReverseInteger(-21));
        int[] arr = { 2, 7, 11, 15 };

        // Console.WriteLine(Multiply("498828660196", "840477629533"));
        // Console.WriteLine(LengthOfLastWord("   fly me   to   the moon  "));

        // int[] array = TwoSum(arr, 9);

        // int[] meuArray = { 1, 2, 3, 3 };
        // int[] meuArray = { 1, 1, 1 };

        // Criar uma lista ligada a partir do array
        // ListNode minhaListaLigada = CriarListaLigada(meuArray);

        // Exibir os elementos da lista ligada
        // ImprimirListaLigada(DeleteDuplicates(minhaListaLigada));
        // ImprimirListaLigada(minhaListaLigada);
        // DeleteDuplicates(minhaListaLigada);

        // int?[] meuArray = { 5, 1, 4, null, null, 3, 6 };
        int?[] meuArray = { 5, 4, 6, null, null, 3, 7 };

        // Criar uma árvore de busca binária a partir do array
        TreeNode minhaArvore = ConstruirArvore(meuArray, 0);

        Console.WriteLine(IsValidBST(minhaArvore));
    }

    public static bool IsValidBST(TreeNode root)
    {

        return Auxiliar(root, root.val);
    }

    public static bool Auxiliar(TreeNode root, int rootVal)
    {
        TreeNode current = root;
        // Console.WriteLine("LEFT: " + root?.left?.val + " ROOT: " + root.val);
        // Console.WriteLine("RIGHT: " + root?.right?.val + " ROOT: " + root.val);

        if (current.left != null || current.right != null)
        {

            int currentLeftVal = current.left.val;
            int currentRightVal = current.right.val;

            if (currentLeftVal > current.val || (currentLeftVal < rootVal && current.val > rootVal))
            {
                Console.WriteLine("OLAA LEFT: " + currentLeftVal);
                return false;
            }
            if (currentRightVal < current.val || (currentRightVal > rootVal && current.val < rootVal))
            {
                Console.WriteLine("OLAA RIGHT");
                return false;
            }

            // if (root.left != null)
            // {

            // }
            Auxiliar(root.left, rootVal);

            Auxiliar(root.right, rootVal);
        }


        return true;
    }

    public static int GetIndex(string s)
    {
        int hasIndex = -1;
        string letra = "";

        var dic = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (dic.ContainsKey(s[i]))
            {
                dic[s[i]]++;
                continue;
            }

            dic.Add(s[i], 1);
        }

        foreach (var keyValuePair in dic)
        {
            if (keyValuePair.Value == 1)
            {
                hasIndex = s.IndexOf(keyValuePair.Key);
            }
        }

        Console.WriteLine(hasIndex);
        return hasIndex;
    }

    public static int ReverseInteger(int x)
    {
        string str = new string(x.ToString().Trim('-').Reverse().ToArray());
        int resultInt;

        if (int.TryParse(str, out resultInt))
        {
            if (x < 0)
                resultInt = resultInt * -1;

            if (resultInt < Int32.MinValue || resultInt > Int32.MaxValue)
                return 0;

            return resultInt;
        }
        else
        {

            return 0;
        }
    }

    public static string Multiply(string num1, string num2)
    {
        long numA = Convert.ToInt64(num1);
        long numB = Convert.ToInt64(num2);

        long a = 498828660196;
        long b = 840477629533;
        // BigInteger d = 419254329864656431168468;

        ulong c = (ulong)(a * b);

        Console.WriteLine(numA);
        Console.WriteLine(numB);
        Console.WriteLine(c);

        return (numA * numB).ToString();
    }

    public static int LengthOfLastWord(string s)
    {
        string m = s.Trim();
        string[] arr = m.Split();

        return arr[arr.Length - 1].Length;
    }

    public static int[] TwoSum(int[] numbers, int target)
    {
        int[] result = new int[2];

        for (int i = 0, j = numbers.Length - 1; i < j;)
        {
            int sum = numbers[i] + numbers[j];

            if (sum == target)
            {
                result[0] = j + 1;
                result[1] = i + 1;
            }

            if (sum > target)
            {
                j--;
            }
            else
            {
                i++;
            }
        }
        // int i = 0;
        // int j = numbers.Length - 1;
        // bool hasFindNumbers = false;
        // while (i < j )
        // {
        //     int sum = numbers[i] + numbers[j];
        //     if (sum == target)
        //     {
        //         result[0] = i + 1;
        //         result[1] = j + 1;
        //         return result;
        //     }

        //     if (sum > target)
        //     {
        //         j--;
        //     }
        //     else
        //     {
        //         i++;
        //     }
        // }

        return result;
    }


    public static ListNode DeleteDuplicates(ListNode head)
    {
        ListNode current = head;
        while (current != null && current.next != null)
        {

            if (current.val == current.next.val)
            {
                current.next = current.next.next;

            }
            else
            {
                current = current.next;
            }
        }

        return head;
    }

    static ListNode CriarListaLigada(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return null;
        }

        ListNode cabeca = new ListNode(array[0]);
        ListNode atual = cabeca;

        for (int i = 1; i < array.Length; i++)
        {
            atual.next = new ListNode(array[i]);
            atual = atual.next;
        }

        return cabeca;
    }

    static void ImprimirListaLigada(ListNode listaLigada)
    {
        ListNode atual = listaLigada;

        while (atual != null)
        {
            Console.WriteLine(atual.val);
            atual = atual.next;
        }
    }

    static TreeNode ConstruirArvore(int?[] array, int indice)
    {
        if (indice >= array.Length || array[indice] == null)
        {
            return null;
        }

        TreeNode no = new TreeNode((int)array[indice]);
        no.left = ConstruirArvore(array, 2 * indice + 1);
        no.right = ConstruirArvore(array, 2 * indice + 2);

        return no;
    }

}

// public static bool IsValidBST(TreeNode root)
//     {

//         return Auxiliar(root.left, root.right, root.val);
//     }

//     public static bool Auxiliar(TreeNode rootLeft, TreeNode rootRight, int rootVal)
//     {
//         TreeNode currentLeft = rootLeft;
//         TreeNode currentRight = rootRight;
//         // Console.WriteLine("LEFT: " + root?.left?.val + " ROOT: " + root.val);
//         // Console.WriteLine("RIGHT: " + root?.right?.val + " ROOT: " + root.val);

//         if (current.left != null || current.right != null)
//         {

//             if (current.left.val > rootVal)
//             {
//                 Console.WriteLine("OLAA");
//                 return false;
//             }
//             if (current.right.val < rootVal)
//             {
//                 Console.WriteLine("OLAA");
//                 return false;
//             }

//             Auxiliar(rootLeft, rootRight, rootVal);
//             // Auxiliar(root.right, rootVal);
//         }


//         return true;
//     }