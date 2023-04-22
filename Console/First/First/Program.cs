// See https://aka.ms/new-console-template for more information


char[] operators = { '/', '*','+', '-' };

Console.WriteLine("Enter value:");
string temp = Console.ReadLine();

List<string> value = new List<string>();
List<string> opArr = new List<string>();

//double num1;
//double num2;
double result = 0;
bool hasResult = false;



//Console.WriteLine("value {0}", value);
//Console.WriteLine(" temp.Length {0}", temp.Length);
do
{
    int position = temp.IndexOfAny(operators);

   
    if (position > 0)
    {

        //Console.WriteLine("position {0}", position);
        value.Add(temp.Substring(0, position));

        string op = temp.Substring(position, 1);
        //Console.WriteLine("operator {0}", op);

        value.Add(op);

        temp = temp.Substring(position + 1);
    }
    else
    {
        //Console.WriteLine("else here");
        value.Add(temp.Substring(0));
        temp = "";
    }

    //Console.WriteLine("temp {0}", temp);
} while (temp.Length > 0);

Console.WriteLine("value.Count {0}", value.Count);




foreach (string v in value)
{
    Console.Write("{0} ", v);
}


string[] pemdas = { "*", "/" };


for (int i = 0; i < value.Count; i++)
{
   //if(i == 0 || i % 2 == 0 )
   // {
        Console.WriteLine("");
        Console.WriteLine("i {0} === size {1}", i, value.Count);
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
                Console.WriteLine("pemdas looop {0}", value.FindIndex(a => a == c));
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

        Console.WriteLine("z {0}", z);
        if (leftPosition != 0)
        {
            Double.TryParse(value?[leftPosition], out num1);
            Double.TryParse(value?[leftPosition + 2], out num2);
            op = Convert.ToChar(value?[z]);
        } 
           

            Console.WriteLine("num1 {0} op {1} num2 {2}", num1, op, num2);

            if (i == 0)
            {
                result += num1;
            }

            switch (op)
            {
                case '+':
                    Console.WriteLine("inside switch result {0} + num2 {0}", result, num2);
                    result = num1 + num2;
                    break;
                case '-':
                Console.WriteLine("inside switch - {0}", num2);
                result = num1 - num2;
                    break;
                case '*':
                Console.WriteLine("inside switch * {0}", num2);
                result = num1 * num2;
                    break;
            default:
                Console.WriteLine("inside switch / {0}", num2);
                result = num1 / num2;
                    break;
            }


        if (leftPosition != 0)
        {
            Console.WriteLine(" value left hand  {0} index of {1}", value[leftPosition], leftPosition);
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
        
     
        Console.WriteLine("Values =====");
        foreach (string v in value)
            {
                Console.Write("{0} ", v);
            }
        Console.WriteLine("\nend =====");
        Console.WriteLine("");

            Console.WriteLine("result loop {0} ", result, op, num2);
            Console.WriteLine("");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    //}
}



Console.WriteLine("Result {0}", result);


//bool hasOperator = false;

//do
//{

//    Console.WriteLine("temp do above: {0} ===> result {1} ", temp, result);


//    foreach (char op in operators)
//    {
//        if (temp.Contains(op))
//        {

//            int position = temp.IndexOf(op);

//            if (position > 0)
//            {
//                hasOperator = true;

//                Console.WriteLine("hasOperator {0}", hasOperator);
//                Console.WriteLine("position {0}", position);
//                Console.WriteLine("operator {0}", op);
//                Console.WriteLine("temp foreach above: {0}", temp);
//                Console.WriteLine("hasResult {0}", hasResult);


//                if (hasResult)
//                {
//                    num1 = result;
//                } else
//                {
//                    num1 = Double.Parse(temp.Substring(0, position));
//                }

//                //int index = Array.FindIndex(operators, c => c == temp[i])
//                int succeedingOp = temp.Substring(position + 1).IndexOfAny(operators);
//                Console.WriteLine("raw: {0}  ===== succeedingOp {1} ", temp.Substring(position + 1), succeedingOp);


//                if (succeedingOp > 0)
//                {
//                    num2 = Double.Parse(temp.Substring(position + 1, succeedingOp));
//                } else
//                {
//                    num2 = Double.Parse(temp.Substring(position + 1));
//                }


//                Console.WriteLine("raw: {0}  ===== succeedingOp below {1} ", temp.Substring(position + 1), succeedingOp);


//                Console.WriteLine("temp.Substring(0, position) {0}", temp.Substring(0, position));





//                string test = temp.Substring(position + 1);

//                Console.WriteLine("test {0}", test);


//                Console.WriteLine("num1 {0}", num1);
//                Console.WriteLine("num2 {0}", num2);


//                int testc = num1.ToString().Length + num2.ToString().Length + 1;

//                Console.WriteLine("testc {0}", testc);

//                Console.WriteLine("third array {0}", temp.Substring(testc));



//switch (op)
//{
//    case '+':
//        result = Convert.ToDouble(num1 + num2);
//        break;
//    case '-':
//        result = Convert.ToDouble(num1 - num2);
//        break;
//    case '/':
//        result = Convert.ToDouble(num1 / num2);
//        break;
//    case '*':
//        result = Convert.ToDouble(num1 * num2);
//        break;
//}


//                temp = Convert.ToString(result) + temp.Substring(testc);

//                //Console.WriteLine("temp inside: {0}", temp);

//                //hasResult = true;


//            }

//            hasResult = false;



//            Console.WriteLine("Result {0}", result);

//            //int testc = num1.ToString().Length + num2.ToString().Length ;

//            //Console.WriteLine("testc {0}", testc);

//            //Console.WriteLine(temp.Substring( testc));

//            //temp = temp.Substring( testc);

//            //position = 0;
//        }




//    }

//    //hasOperator = false;
//    t--;
////} while(hasOperator);

//} while (t > 0) ;


Console.WriteLine("temp below and outside loop {0}", temp);



Console.ReadKey();