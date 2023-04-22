
char[] operators = { '/', '*','+', '-' };

Console.WriteLine("Enter value:");
string temp = Console.ReadLine().Trim(); // TODO: sanitize string 

List<string> value = new List<string>();
List<string> opArr = new List<string>();


double result = 0;
bool hasResult = false;


do
{
    int position = temp.IndexOfAny(operators);

   
    if (position > 0)
    {
        value.Add(temp.Substring(0, position));

        string op = temp.Substring(position, 1);
        value.Add(op);

        temp = temp.Substring(position + 1);
    }
    else
    {
        value.Add(temp.Substring(0));
        temp = "";
    }

} while (temp.Length > 0);





//foreach (string v in value)
//{
//    Console.Write("{0} ", v);
//}


string[] pemdas = { "*", "/" };


for (int i = 0; i <= value.Count; i++)
{
        //Console.WriteLine("");
        //Console.WriteLine("i {0} === size {1}", i, value.Count);
        try
        {

            double num1;
            double num2;

        int z = -1;

        int leftPosition = 0;
            int rightPosition = 2;


            // start with PEMDAS
       
            foreach (string c in pemdas)
            {
                //Console.WriteLine("pemdas looop {0}", value.FindIndex(a => a == c));
                int indexFound = value.FindIndex(a => a == c);
                if(indexFound != -1)
                {
                    leftPosition = indexFound - 1;
                    z = indexFound;
                break;
                }
            }

        Double.TryParse(value?[0], out num1);
        Double.TryParse(value?[2], out num2);
        char op = Convert.ToChar(value?[1]);

        //Console.WriteLine("z {0}", z);
        if (leftPosition != 0)
        {
            Double.TryParse(value?[leftPosition], out num1);
            Double.TryParse(value?[leftPosition + 2], out num2);
            op = Convert.ToChar(value?[z]);
        } 
           

            //Console.WriteLine("num1 {0} op {1} num2 {2}", num1, op, num2);

            if (i == 0)
            {
                result += num1;
            }

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                result = num1 - num2;
                    break;
                case '*':
                result = num1 * num2;
                    break;
            default:
                result = num1 / num2;
                    break;
            }


        if (leftPosition != 0)
        {
            value[leftPosition] = Convert.ToString(result);
            value.RemoveRange(z, 2);

        } else
        {
            value[0] = Convert.ToString(result);
            if(value.Count > 1)
            {
                value.RemoveRange(1, 2);
            }
        }


       
        //Console.WriteLine(" value index 0 {0}", value[0]);
        //Console.WriteLine(" value index 1 {0}", value[1]);
        //Console.WriteLine(" value index 2 {0}", value[2]);
        
     
        //Console.WriteLine("Values =====");
        //foreach (string v in value)
        //    {
        //        Console.Write("{0} ", v);
        //    }
        //Console.WriteLine("\nend =====");
        //Console.WriteLine("");

        //    Console.WriteLine("result loop {0} ", result, op, num2);
        //    Console.WriteLine("");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    //}
}



Console.WriteLine("Result: {0}", result);


Console.ReadKey();