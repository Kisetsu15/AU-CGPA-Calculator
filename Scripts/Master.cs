using Utils;

namespace AU_CGPA_Calculater
{
    public class Master {
        private static Dictionary<string, int> grades = new() {
            {"o", 10}, {"a+", 9}, {"a", 8}, {"b+", 7}, {"b", 6}, {"c", 5},
        };


        public static void Main( string[] args ) {
            Console.WriteLine(Calculate());
        }

        private static float Calculate() {
            float sum = 0f;
            float totalCredit = 0f;
            int num = Int(Terminal.Input("no of subjects: "));
            for ( int i = 0; i < num; i++ ) {
                Console.WriteLine($"Enter Subject {i+1}:");
                float credit = Float(Terminal.Input("Credit: "));
                while ( true ) {
                    string v = Terminal.Input("Grade:");
                    if ( grades.TryGetValue(v, out int value) ) {
                        sum += value * credit;
                        totalCredit += credit;
                        break;
                    } else if ( v == "u" ) {
                        break;
                    }
                    Console.WriteLine("Invalid Grade");
                }
            }
            return sum / totalCredit;
        }

        private static float Float( string str ) {
            return float.Parse(str);
        }

        private static int Int( string str ) {
            return Int32.Parse(str);
        }
    }
}
