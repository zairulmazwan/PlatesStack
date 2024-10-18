public class ReadWriteFile
{
    public static void writeResult(double [,] results, string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            for (int i = 0; i < results.GetLength(0)-1; i++)
            {
                sw.Write(results[i, 0]);
                sw.Write(",");
                sw.Write(results[i,1]);
                sw.WriteLine();
            }
            sw.Write("Average");
            sw.Write(",");
            sw.Write(results[results.GetLength(0)-1,1]);
        }
    }
}