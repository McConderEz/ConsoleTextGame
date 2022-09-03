using CodeBlogHomeWorkInteface2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkException2022
{
    public class Menu
    {
        public static void MenuController()
        {
            try
            {
                ChooseHero();//Первый герой
                ChooseHero();//Второй герой
                GamePlay(Hero.heroes[0], Hero.heroes[1]);
                Console.ReadLine();
                #region Test
                //berserk.HitsSeries(knight);
                //berserk.Rage();
                //berserk.Intimidation(knight);

                //knight.CheckEffectsOnUnit();
                //knight.EndOfMove();
                //berserk.EndOfMove();
                //knight.EndOfMove();
                //berserk.EndOfMove();
                //knight.EndOfMove();
                //berserk.EndOfMove();
                //knight.EndOfMove();
                //berserk.EndOfMove();
                //knight.EndOfMove();
                //berserk.Hit(knight);
                //knight.Hit(berserk);
                //Console.WriteLine("-------------------------------------");
                //Console.WriteLine(knight.GetState);
                //Console.WriteLine(berserk.GetState);
                #endregion
            }
            catch (PointException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение работы...");
            }
        }


        public static void ChooseHero()
        {
            Console.WriteLine("Выберите героя:");
            int key = ReadInteger();
            
                switch (key)
                {
                    case 1:
                        Create<Knight>(CreateKnight());
                        break;
                    case 2:
                        Create<Mage>(CreateMage());
                        break;
                    case 3:                        
                        Create<Berserk>(CreateBerserk());
                        break;
                    default:
                        Console.WriteLine("Такой опции не существует");
                        break;

                }

        }
        
        public static void GamePlay(Hero unit_1, Hero unit_2)
        {
            
            while(unit_1.Hp >= 0 || unit_2.Hp >= 0)
            {
                if (unit_1._IsStunned)
                {
                    unit_1._IsStunned = false;
                    goto u_2;
                }
                Console.WriteLine($"\n\t\t1 Игрок({unit_1.ClassName})", Console.ForegroundColor = ConsoleColor.Blue);
                Console.ForegroundColor = ConsoleColor.White;
                AutoChooseController(unit_1, unit_2);
                unit_2.EndOfMove();
                if(unit_2.Hp <= 0)
                {
                    Console.WriteLine("Победил Игрок 1!");
                    break;
                }
            u_2:
                if (unit_2._IsStunned)
                {
                    unit_2._IsStunned = false;
                    continue;
                }
                Console.WriteLine($"\n\t\t2 Игрок({unit_2.ClassName})", Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.White;
                AutoChooseController(unit_2, unit_1);
                unit_1.EndOfMove();
                if (unit_1.Hp <= 0)
                {
                    Console.WriteLine("Победил Игрок 2!");
                    break;
                }
                //TODO:Сделать метод выводящий состояние героев после каждого хода
                Console.WriteLine($"\n\t\t1 Игрок({unit_1.ClassName}): {unit_1.Hp} хп\t2 Игрок({unit_2.ClassName}): {unit_2.Hp} хп\n",Console.ForegroundColor = ConsoleColor.Green);
                Console.WriteLine($"\n\t\t1 Игрок({unit_1.ClassName}): {unit_1.Mana} маны\t2 Игрок({unit_2.ClassName}): {unit_2.Mana} маны\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Игра окончена");
            Thread.Sleep(3000);
        }

        public static void AutoChooseController(Hero unit, Hero target)
        {
            switch (unit.ClassName)
            {
                case "Берсерк":
                    BerserkController(unit, target);
                    break;
                case "Маг":
                    MageController(unit, target);
                    break;
                case "Рыцарь":
                    KnightController(unit, target);
                    break;
                default:
                    Console.WriteLine("Что-то пошло не так");
                    break;
            }
        }

        public static void BerserkController(Hero unit, Hero target)
        {
            Berserk berserk = (Berserk)unit;
            Console.WriteLine("Выберите АА/Навык:\n1)АА\n2)Серия ударов\n3)Устрашение\n4)Ярость");
            int key = ReadInteger();
            switch (key)
            {
                case 1:
                    berserk.ApplyHitOnTarget(target);
                    break;
                case 2:
                    berserk.HitsSeries(target);
                    break;
                case 3:
                    berserk.Intimidation(target);
                    break;
                case 4:
                    berserk.Rage();
                    break;
                default:
                    Console.WriteLine("Такой опции не предусмотрено");
                    break;
            }
        }

        public static void MageController(Hero unit, Hero target)
        {
            Mage mage = (Mage)unit;
            Console.WriteLine("Выберите АА/Навык:\n1)АА\n2)Цепи Бога\n3)Кара небес\n4)Реквием");
            int key = ReadInteger();
            switch (key)
            {
                case 2:
                    Console.WriteLine("Выберите в комбинацию АА/Навык:\n1)АА\n2)Кара небес\n3)Реквием");
                    key = ReadInteger();
                    mage.GodChains(target,key);
                    break;
                case 3:
                    mage.ActivateHevansPunish(target);
                    break;
                case 4:
                    mage.ActivateRequiem(target);
                    break;
                case 1:
                    mage.ApplyHitOnTarget(target);
                    break;
                default:
                    Console.WriteLine("Такой опции не предусмотрено");
                    break;
            }
        }

        public static void KnightController(Hero unit, Hero target)
        {
            Knight knight = (Knight)unit;
            Console.WriteLine("Выберите АА/Навык:\n1)АА\n2)Разлом Оков\n3)Deus Vult");
            int key = ReadInteger();
            switch (key)
            {
                case 1:
                    knight.ApplyHitOnTarget(target);
                    break;
                case 2:
                    knight.BreakingChains();
                    break;
                case 3:
                    knight.DeusVult();
                    break;                
                default:
                    Console.WriteLine("Такой опции не предусмотрено");
                    break;
            }
        }

        public static void Create<T>(T hero) where T:Hero
        {
            Console.WriteLine("Распределите очки вашего героя(8 очков)\nСила\tЛовкость\tВыносливость\tИнтеллект");
            int strength = ReadInteger();
            int agility = ReadInteger();
            int durability = ReadInteger();
            int intelligence = ReadInteger();
            if (strength + agility + durability + intelligence > 8)
                throw new PointException("Вы превысили количество допустимых очков на распределение");
            hero.PointDistribution(strength, agility, durability, intelligence);
            AddHeroInList(hero);
            Console.WriteLine("Герой создан!");
        }

        public static Berserk CreateBerserk(int strength = 1, int agility = 1, int durability=1, int intelligence = 1) => new Berserk(strength, agility, durability, intelligence);
        public static Knight CreateKnight(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1) => new Knight(strength, agility, durability, intelligence);
        public static Mage CreateMage(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1) => new Mage(strength, agility, durability, intelligence);

        public static void AddHeroInList(Hero hero)
        {
          
           Hero.heroes.Add(hero);
            
            
        }

        public static int ReadInteger()
        {
            int result = 0;
            while(!int.TryParse(Console.ReadLine(),out result))
            {
                Console.WriteLine("Неверный ввод!Попробуйте еще раз:");
            }
            return result;
        }

    }
}
