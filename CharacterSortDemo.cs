namespace OOPLab4;

// Делегат описує метод, який приймає масив символів і повертає відсортований масив.
internal delegate char[] CharacterArraySorter(char[] characters);

internal static class CharacterSortDemo
{
    public static void Run()
    {
        Console.Write("Введіть рядок символів: ");
        string input = Console.ReadLine() ?? string.Empty;
        char[] characters = input.ToCharArray();

        // Анонімний метод задає тіло функції без окремого іменованого методу.
        CharacterArraySorter anonymousSorter = delegate (char[] values)
        {
            return SortDescending(values);
        };

        // Лямбда-вираз має той самий підпис делегата, але записаний коротше.
        CharacterArraySorter lambdaSorter = values => SortDescending(values);

        char[] anonymousResult = anonymousSorter((char[])characters.Clone());
        char[] lambdaResult = lambdaSorter((char[])characters.Clone());

        Console.WriteLine($"Результат анонімного методу: {new string(anonymousResult)}");
        Console.WriteLine($"Результат лямбда-виразу:     {new string(lambdaResult)}");
        Console.WriteLine($"Результати збігаються: {anonymousResult.SequenceEqual(lambdaResult)}");
    }

    private static char[] SortDescending(char[] characters)
    {
        // Порівнюємо символи за їхніми значеннями char у зворотному порядку.
        Array.Sort(characters);
        Array.Reverse(characters);
        return characters;
    }
}