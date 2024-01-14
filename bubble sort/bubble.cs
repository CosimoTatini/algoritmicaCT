int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
BubbleSort(arr);
foreach (var numero in arr)
{
    Console.Write(numero + " ");


}
Console.ReadLine();
static void BubbleSort (int[] arr)
{ int n = arr.Length;
    for (int i=0;i<n-1; i++)
    {
     for (int j=0; j<n -1; j++) 
     { 
       if ( arr[j] >  arr[j+1])
       {

              int temporaneo = arr[j];
              arr[j] = arr[j+1];
              arr[j+1] = temporaneo;


       }

        
      }



    }



}
