namespace Lab2;

// Объявляем обобщенный класс Dish
public class Dish 
{

    // Объявляем свойство Name для хранения названия блюда
    public string Name { get; set; }

    // Объявляем свойство Calories для хранения калорийности блюда
    public int Calories { get; set; }

    // Объявляем свойство BJU для хранения массива из 3 элементов: белки, жиры, углеводы
    public int[] BJU { get; set; } 

    // Объявляем конструктор класса Dish, инициализирующий свойства Name, Calories и BJU
    public Dish(string name, int calories, int[] bju) 
    {

        // Присваиваем значение параметра name свойству Name
        Name = name;

        // Присваиваем значение параметра calories свойству Calories
        Calories = calories;

        // Присваиваем значение параметра bju свойству BJU
        BJU = bju; 
    }
}

// Объявляем статический класс DishExtensions, который содержит методы расширения для класса Dish
public static class DishExtensions 
{

    // Объявляем метод расширения GetDishesWithMostCarbs, который принимает список Dish и возвращает список блюд с наибольшим содержанием углеводов
    public static List<Dish> GetDishesWithMostCarbs(this List<Dish> dishes) 
    {

        // Сортируем список блюд по убыванию значения третьего элемента в массиве BJU (углеводы), используя метод OrderByDescending
        var sortedDishes = dishes.OrderByDescending(d => d.BJU[2]).ToList(); 

        // Возвращаем первые 3 элемента отсортированного списка блюд с помощью метода Take, преобразуем результат в список с помощью метода ToList()
        return sortedDishes.Take(3).ToList(); 
    }
}

// Объявляем классс DishList, который наследует класс List<Dish>
public class DishList : List<Dish> 
{

    // Объявляем конструктор класса DishList, который инициализирует список блюд
    public DishList() 
    {

        // Добавляем блюдо "Каре Ягненка" с калорийностью 350 и массивом BJU { 10, 35, 25 } в список блюд
        Add(new Dish("Каре Ягненка", 100, new int[] { 10, 5, 15 }));

        // Добавляем блюдо "Веллингтон" с калорийностью 250 и массивом BJU { 50, 10, 10} в список блюд
        Add(new Dish("Веллингтон", 150, new int[] { 5, 5, 25 }));

        // Добавляем блюдо "Лохиккейто" с калорийностью 180 и массивом BJU { 2, 18, 18 } в список блюд
        Add(new Dish("Лохиккейто", 50, new int[] { 2, 1, 5 }));

        // Добавляем блюдо "Том Ям" с калорийностью 160 и массивом BJU { 5, 5, 40 } в список блюд
        Add(new Dish("Том Ям", 120, new int[] { 6, 2, 20 }));

        // Добавляем блюдо "Гаспачо" с калорийностью 80 и массивом BJU { 20, 5, 2 } в список блюд
        Add(new Dish("Гаспачо", 180, new int[] { 20, 10, 5 }));
        
    }
}

// Объявляем класс Program
public class Program
{

    // Объявляем точку входа в программу с помощью статистического метода Main
    public static void Main(string[] args) 
    {

        // Создаем экземпляр класса DishList с типом dishList
        DishList dishList = new DishList();

        // Вызываем метод GetDishesWithMostCarbs для экземпляра DishList, сохраняем результат в переменную topCarbsDishes типа List<Dish>
        List<Dish> topCarbsDishes = dishList.GetDishesWithMostCarbs();

        // Выводим "Блюда с наибольшим содержанием углеводов:" в консоль
        Console.WriteLine("Блюда с наибольшим содержанием углеводов:");

        // Цикл foreach, который перебирает каждый элемент в списке topCarbsDishes
        foreach (Dish dish in topCarbsDishes) 
        {

            // Выводим название блюда и количество углеводов (третий элемент в массиве BJU) в консоль
            Console.WriteLine($"{dish.Name} - Углеводы: {dish.BJU[2]}г"); 
        }
    }
}

