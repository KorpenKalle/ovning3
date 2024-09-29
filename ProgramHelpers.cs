internal static class ProgramHelpers
{
    private static void Main(string[] args)
    {
        try
        {
            PersonHandler handler = new PersonHandler();
            Person person1 = handler.CreatePerson(25, "John", "Doe", 180.0, 75.0);
            Console.WriteLine($"Person: {person1.FName} {person1.LName}, Age: {person1.Age}, Height: {person1.Height}, Weight: {person1.Weight}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Fel: {ex.Message}");
        }

        // 3.2 Polymorfism

        List<UserError> errors = new List<UserError>
        {
            new NumericInputError(),
            new TextInputError()
        };

        foreach (var error in errors)
        {
            Console.WriteLine(error.UEMessage());
        }
    }
}