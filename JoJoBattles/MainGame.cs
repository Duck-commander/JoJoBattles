namespace JoJoBattles
{
    public class JoJoBattles
    {
        static void Main()
        {
            Console.CursorVisible = false;

            BattleMechanic battle = new BattleMechanic();

            Jotoro jotoro = new Jotoro();
            Dio dio = new Dio();

            battle.Battle(jotoro, dio);

            /*
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.R)
                {
                    battleInterfase.DrawBattleInit(dio, jotoro);
                    Console.SetCursorPosition(3, 13);
                    //Thread.Sleep(100);
                }
                if (key == ConsoleKey.F)
                {
                    jotoro.OraOra(dio);
                    battleInterfase.DrawBattleUpdate(dio, jotoro);
                    Console.SetCursorPosition(3, 13);
                    //Thread.Sleep(100);
                }
                if (key == ConsoleKey.G)
                {
                    dio.MudaMuda(jotoro);
                    battleInterfase.DrawBattleUpdate(dio, jotoro);
                    Console.SetCursorPosition(3, 13);
                    //Thread.Sleep(100);
                }
                if (key == ConsoleKey.T)
                {
                    dio.RoadRoller(jotoro);
                    battleInterfase.DrawBattleUpdate(dio, jotoro);
                    Console.SetCursorPosition(3, 13);
                }
            }
            */
        }
    }
}