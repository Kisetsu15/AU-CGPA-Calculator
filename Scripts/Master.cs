using Utils;

namespace AU_CGPA_Calculater
{
    public class Master {
        private static Dictionary<string, int> grades = new() {
            {"o", 10}, {"a+", 9}, {"a", 8}, {"b+", 7}, {"b", 6}, {"c", 5},
            {"O", 10}, {"A+", 9}, {"A", 8}, {"B+", 7}, {"B", 6}, {"C", 5},
        };

        public static void Main( string[] args ) {
            UserOptions();
        }

        private static void UserOptions() {
            while ( true ) {
                Console.WriteLine("1. GPA\n2. CGPA\n3. Exit");
                int choice = Terminal.Input<int>("Enter your choice: ");
                Action action = () => Console.WriteLine("Invalid choice. Please try again.");

                if ( choice.Equals("1") ) {
                    action = GPA;
                } else if ( choice.Equals("2") ) {
                    action = CGPA;
                } else if ( choice.Equals("3") ) {
                    break;
                }
                action.Invoke();
            }
        }

        private static void CGPA() {
            float current = Terminal.Input<float>("Current CGPA: ");
            float newGpa = Terminal.Input<float>("New GPA: ");
            
            float newCgpa = ( ( 2 * current ) + newGpa ) / 3;

            Console.WriteLine("CGPA : " + newCgpa);
        }

        private static void GPA() {

            float sum = 0f;
            float totalCredit = 0f;

            try {
                int count = Terminal.Input<int>("Number of subjects: ");

                for ( int i = 0; i < count; i++ ) {
                    Console.WriteLine($"Enter Subject {i + 1}:");
                    float credit = Terminal.Input<float>("Credit: ");

                    while ( true ) {
                        string grade = Terminal.Input("Grade: ");
                        if ( grades.TryGetValue(grade, out int value) ) {
                            sum += value * credit;
                            totalCredit += credit;
                            break;
                        } else if ( grade.Equals("u") || grade.Equals("U") ) {
                            break;
                        }
                        Console.WriteLine("Invalid Grade");
                    }
                }
                
            } catch ( Exception e ) {
                Terminal.DisplayError(e);
                return;
            }

            if ( totalCredit <= 0 ) {
                Terminal.DisplayMessage("No valid credits entered.", ConsoleColor.Red);
                return;
            }

            float gpa = sum / totalCredit;

            Console.WriteLine("GPA : " + gpa);
        }
    }
}
