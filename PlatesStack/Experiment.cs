public class Experiment
{

    public static double [] genData (int n)
    {
        double [] res = new double [n];
        Random r= new Random ();

        for (int i = 0; i < n; i++)
        {
            double rand = Math.Round(r.NextDouble()*10,2);
            // Console.WriteLine ("Random : "+rand);
            res [i] = rand;
        }
        return res;
    }

    public static double [] bubbleSort(double [] data)
    {
        double [] res = (double []) data.Clone();
        
        bool swap = true;

        while (swap)
        {
            swap = false;
            for (int i = 0; i < res.Length-1; i++)
            {
                if (res[i] < res[i+1])
                {
                    swap = true;
                    double temp = res[i];
                    res[i] = res[i+1];
                    res[i+1] = temp;
                }
            }
        }

        return res;
    }

    public static void printArray<T> (T [] array)
    {
        foreach(var x in array)
        {
            Console.Write (x+" ");
        }
    }

    public static void runExperiment(int dataSize)
    {
        double [] data = genData(dataSize);
        int exp = 10; //number of experiments
        double [,] bubbleSortRes = new double [exp+1,2];
        double [,] stackSortRes = new double [exp+1,2];
        double bubbleSum = 0;
        double stackSum = 0;

        //Run experiment for bubble sort
        for (int i = 0; i < exp; i++)
        { 
            // data = genData(10);
            // Console.WriteLine("\nData : ");
            // printArray(data);
            DateTime start = DateTime.Now;
            double [] resBubble = bubbleSort(data);
            DateTime end = DateTime.Now;
            
            double nano = (double) (end - start).TotalNanoseconds;
            var mili = nano/1000000;
            bubbleSum += mili;
            // Console.WriteLine("\nRes : "+mili);
            // printArray(resBubble);
            bubbleSortRes[i,0] = i;
            bubbleSortRes[i,1] = mili;
        }
        bubbleSortRes[exp,1] = bubbleSum/exp;
        ReadWriteFile.writeResult(bubbleSortRes, "bubbleSortResults_"+dataSize+".csv");

        //Run experiment for Stack sort
        for (int i = 0; i < exp; i++)
        {
            // data = genData(10);
            // Console.WriteLine("\nData : ");
            // printArray(data);
            Plate p = new Plate(data);
            DateTime start = DateTime.Now;
            double [] resStackSort = p.stackSort();
            DateTime end = DateTime.Now;

            double nano = (double) (end - start).TotalNanoseconds;
            var mili = nano/1000000;
            stackSum += mili;
            // Console.WriteLine("\nRes : "+mili);
            // printArray(resStackSort);

            stackSortRes[i,0] = i;
            stackSortRes[i,1] = mili;
        }
        stackSortRes[exp,1] = stackSum/exp;
        ReadWriteFile.writeResult(stackSortRes, "stackSortResults"+dataSize+".csv");
    }

}