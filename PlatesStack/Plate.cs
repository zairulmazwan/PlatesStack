using System.ComponentModel;

public class Plate
{
    //static int [] myPlates = {11,6,9,3,2};
    static int [] myPlates = {6,9,2,1,12,3,5,14,4,8,15};
    //static int [] myPlates = {12,3,5,3,14,6,9,2,1,4,8,15};
    static int size = myPlates.Length;
    static int [] stack = new int [size];
    static int [] temp = new int [size];


    static int top = -1;
    static int plateIndex = -1;
    static int tempIndex = -1;

    public static bool isStackEmpty()
    {
        return (top == -1);
    }

    public static bool isPlateEmpty()
    {
        return (plateIndex == myPlates.Length);
    }

    public static bool isTempEmpty()
    {
        return (tempIndex == -1);
    }

    //Insert a new item to stack
    public static void push()
    {
        top++;
        stack[top] = myPlates[plateIndex];
        plateIndex++;
    }

    //Remove the top item from stack and place it to the temporary stack
    public static void pop()
    {
        tempIndex++;
        temp[tempIndex] = stack[top];
        top--;
    }

    //Need to clear the temporary stack so that the items are inserted back to stack
    public static void clearTempStack()
    {
        top++;
        stack[top] = temp[tempIndex];
        tempIndex--;
    }

    //Need to check the top item first before inserting a new one
    public static int peek()
    {
        return stack[top];
    }

    //Initialise the task by getting the first item in the dataset
    public static void init()
    {
        plateIndex++;
        push(); //insert the first item
    }

    public static void printStack()
    {
        foreach(int x in stack)
        {
            Console.WriteLine(x);
        }
    }

    public static void arrangePlatesNow()
    {
       while (!isPlateEmpty()) //So long as the plat is not empty to arrange
       {
            if(plateIndex == -1) //Since the initial value is -1, initialise the task
            {
                init(); //get the first item
            }

            while(!isStackEmpty() && peek()<myPlates[plateIndex]) //As long as the stack is not empty and the top item is lesser than the new item
            {
                pop(); //remove the top item in stack and place it temporary in the temporary stack
            }
                
            push(); // now start inserting a new item
            while (!isTempEmpty()) //But, we may have some items in the temporary stack, put them back into stack
            {
                clearTempStack(); //clearing the temporary stack by inserting all items back to stack
            }
          
       }
        printStack(); //Let's see our plates!
    }
}

//©ZairulMazwan©