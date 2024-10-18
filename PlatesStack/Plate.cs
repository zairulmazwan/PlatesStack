using System.ComponentModel;
using System.Net;

public class Plate
{
    //static int [] myPlates = {11,6,9,3,2};
    public static double [] myPlates;
    //static int [] myPlates = {12,3,5,3,14,6,9,2,1,4,8,15};
    public int size;
    public double [] stack;
    public double [] temp;


    int top = -1;
    int plateIndex = -1;
    int tempIndex = -1;

    public Plate (double [] data)
    {
        myPlates = (double [])data.Clone();
        size = myPlates.Length;
        stack = new double [size];
        temp = new double [size];

    }

    public bool isStackEmpty()
    {
        return (top == -1);
    }

    public bool isPlateEmpty()
    {
        return (plateIndex == myPlates.Length);
    }

    public bool isTempEmpty()
    {
        return (tempIndex == -1);
    }

    //Insert a new item to stack
    public void push()
    {
        top++;
        stack[top] = myPlates[plateIndex];
        plateIndex++;
    }

    //Remove the top item from stack and place it to the temporary stack
    public void pop()
    {
        tempIndex++;
        temp[tempIndex] = stack[top];
        top--;
    }

    //Need to clear the temporary stack so that the items are inserted back to stack
    public void clearTempStack()
    {
        top++;
        stack[top] = temp[tempIndex];
        tempIndex--;
    }

    //Need to check the top item first before inserting a new one
    public double peek()
    {
        return stack[top];
    }

    //Initialise the task by getting the first item in the dataset
    public void init()
    {
        plateIndex++;
        push(); //insert the first item
    }

    public void printStack()
    {
        foreach(int x in stack)
        {
            Console.WriteLine(x);
        }
    }

    public void arrangePlatesNow()
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

    public double [] stackSort()
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
        // printStack(); //Let's see our plates!
        return stack;
    }
}

//©ZairulMazwan©