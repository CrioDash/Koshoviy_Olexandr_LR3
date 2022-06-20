namespace Prog_Lab3_Task2
{
    internal class Programm
    {
        static void Main()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>
                {[1] = "Михайло", [2] = "Петро", [3] = "Василь", [10] = "Михайло", [4] = "Петро"};
            FindDublicates(dictionary);
        }

        public static void FindDublicates(Dictionary<int, string> dict)
        {
            List<KeyValuePair<int,string>> temp = dict.ToList();
            for(int i = 0; i<temp.Count;i++)
            {
                for(int j=0;j<temp.Count;j++)
                {
                    if(i==j) continue;
                    if (temp[i].Value == temp[j].Value)
                    {
                        Console.WriteLine($@"Знайшлась однакова пара ({temp[i].Key}, '{temp[i].Value}') i ({temp[j].Key}, '{temp[j].Value}')");
                        temp.Remove(temp[j]);
                        j--;
                    }
                }
                temp.Remove(temp[i]);
                i--;
            }
        }
}
}