const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
const string NUMBER = "0123456789";
const string SYMBOLS = "!@#$%^&*()-_+=<>?";
string? entry = "";
if (args.Length > 0)
{
	entry = args[0];
}
else
{
    Console.WriteLine("Digite o tamanho da senha a ser gerada:");
	entry = Console.ReadLine();
}


try
{
	if (entry is null)
		throw new Exception("É necessário digitar algum valor que seja número!");
	int size = int.Parse(entry);

	string[] options = { "Incluir letras maiusculas", "Incluir letrar minusculas", "Incluir números", "Incluir simbolos"};

	bool[] selectedOptions = {false, false, false, false };

	int indexSelectedOption = 0;
	int rowNumberMax = Console.CursorTop;
    for (int i = 0; i < options.Length; i++)
    {
        Console.WriteLine($"[ ] {options[i]}");
    }
    Console.SetCursorPosition(1, Console.CursorTop - 1);
    while (true) {

		var key = Console.ReadKey(true).Key;
		switch (key)
		{
			case ConsoleKey.UpArrow:
				if (Console.CursorTop == rowNumberMax)
					break;
				Console.SetCursorPosition(1, Console.CursorTop - 1);
				break;
            case ConsoleKey.DownArrow:
                if (Console.CursorTop == rowNumberMax - 1 + options.Length)
                    break;
                Console.SetCursorPosition(1, Console.CursorTop + 1);
                break;
			case ConsoleKey.Spacebar:
                Console.SetCursorPosition(1, Console.CursorTop);
                indexSelectedOption = Console.CursorTop - rowNumberMax;
				selectedOptions[indexSelectedOption] = true;
				Console.Write("X");
				break;
			case ConsoleKey.Delete:
				Console.SetCursorPosition(1, Console.CursorTop);
                indexSelectedOption = Console.CursorTop - rowNumberMax;
                selectedOptions[indexSelectedOption] = false;
                Console.Write(" "); 
				break;
            default:
                break;
		}
		if (key == ConsoleKey.Enter)
		{
            Console.SetCursorPosition(1, Console.CursorTop + 5 );
			break;
        }
			
	}
	string password = "";
    while(password.Length < size)
    {
		int randomSelect = new Random().Next(0, 4);
		switch (randomSelect)
		{
			case 0:
				if (selectedOptions[0])
				{
					int randomIndex = new Random().Next(0, UPPERCASE.Length - 1);
                    password += UPPERCASE[randomIndex];
                }
				break;
			case 1:
                if (selectedOptions[1])
                {
                    int randomIndex = new Random().Next(0, LOWERCASE.Length - 1);
                    password += LOWERCASE[randomIndex];
                }
                break;
			case 2:
                if (selectedOptions[2])
                {
                    int randomIndex = new Random().Next(0, NUMBER.Length - 1);
					password += NUMBER[randomIndex];
                }
                break;
			case 3:
                if (selectedOptions[3])
                {
                    int randomIndex = new Random().Next(0, SYMBOLS.Length - 1);
                    password += SYMBOLS[randomIndex];
                }
                break;
			default:
				break;
		}
		

	}
    Console.WriteLine($"Senha gerada: {password}");

}
catch (Exception ex)
{
	Console.WriteLine($"ERROR: {ex.Message}");
}
