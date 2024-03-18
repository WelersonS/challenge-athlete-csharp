using System.Globalization;

namespace ChallengeAthleteCSharp
{
    class Program
    {
        static void Main(String[] args)
        {
            string name, tallestAthlete = "";
            double height, weight, avgWeight, sumWeight = 0;
            double percentageOfMan, avgHeightWoman, sumHeightWoman = 0, tallestHeight = 0;
            char gender;
            double quantityOfAthlete, quantityOfMan = 0, quantityOfWoman = 0; ;

            //app
            do
            {
                Console.Write("Qual a quantidade de atletas? ");
                quantityOfAthlete = int.Parse(Console.ReadLine());
            } while (quantityOfAthlete <= 0);
               

            for (int i = 1; i <= quantityOfAthlete; i++)
            {
                Console.WriteLine($"Digite os dados do atleta número {i}: ");
                Console.Write("Nome: ");
                name = Console.ReadLine();
                
                Console.Write("Sexo: ");
                gender = char.Parse(Console.ReadLine().ToUpper());

                while(!GenderIsValid(gender))
                {
                    Console.Write("Valor inválido! Favor digitar F ou M: ");
                    gender = char.Parse(Console.ReadLine().ToUpper());
                }


                Console.Write("Altura: ");
                height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);  

                while(!HeightIsValid(height))
                {
                    Console.Write("Valor inválido. Favor digitar um valor positivo: ");
                    height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                if (gender.Equals('M'))
                    quantityOfMan++;
                else
                {
                    quantityOfWoman++;
                    sumHeightWoman += height;
                }

                Console.Write("Peso: ");
                weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                while(!WeightIsValid(weight))
                {
                    Console.Write("Valor inválido. Favor digitar um valor positivo: ");
                    weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                //avg weight
                sumWeight += weight;

                if (height > tallestHeight)
                {
                    tallestAthlete = name;
                    tallestHeight = height;
                }
                
                
            }

            avgWeight = sumWeight / quantityOfAthlete;
            percentageOfMan = (quantityOfMan / quantityOfAthlete) * 100;
      
            //report
            Console.WriteLine();
            Console.WriteLine("RELATÓRIO:");
            Console.WriteLine("Peso médio dos atletas: " + avgWeight.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Atleta mais alto: " + tallestAthlete);
            Console.WriteLine($"Porcentagem de homens: {percentageOfMan.ToString("F1", CultureInfo.InvariantCulture)} %");
            
            if(quantityOfWoman > 0)
            {
                avgHeightWoman = sumHeightWoman / quantityOfWoman;
                Console.WriteLine("Altura média das mulheres: " + avgHeightWoman.ToString("F2", CultureInfo.InvariantCulture));
            }
            else
                Console.WriteLine("Não há mulheres cadastradas");
        }

        static bool GenderIsValid(char gender)
        {
            if (gender != 'M' && gender != 'F')
                return false;
            else
                return true;
        }
        
        static bool HeightIsValid(double height)
        {
            if (height <= 0)
                return false;
            else
                return true;
        }
        
        static bool WeightIsValid(double weight)
        {
            if (weight <= 0)
                return false;
            else
                return true;
        }
    }
}
