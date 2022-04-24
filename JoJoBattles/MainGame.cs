namespace JoJoBattles
{
    public class JoJoBattles
    {
        static void Main()
        {
            Jotoro jotoro = new Jotoro();
            Dio dio = new Dio();
            BattleInterfase battleInterfase = new BattleInterfase();

            battleInterfase.DrawBattle(dio, jotoro);
        }
    }
}