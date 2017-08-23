using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Scissors_Paper
{
    class Program
    {
        static void Main(string[] args)
        {
            // プレイヤーを生成
            Player p1 = new Player("alligator");
            Player p2 = new Player("buffalo");
            Player p3 = new Player("chimpanzee");
            Player p4 = new Player("donkey");
            Player p5 = new Player("elephant");
            Player p6 = new Player("fox");
            Player p7 = new Player("giraffe");
            Player p8 = new Player("hedgehogs");

            // 判定者を生成
            JudgeMan zebra = new JudgeMan();

            // じゃんけんに参加するプレイヤーをJudgeManに登録する
            zebra.addPlayer(p1);
            zebra.addPlayer(p2);
            zebra.addPlayer(p3);
            zebra.addPlayer(p4);
            zebra.addPlayer(p5);
            zebra.addPlayer(p6);
            zebra.addPlayer(p7);
            zebra.addPlayer(p8);

            // 決着が着くまでじゃんけんを行う
            // JudgeManであるzebraが掛け声かけてじゃんけんするイメージで実装
            bool flgEnd = false;
            int battleCnt = 1;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("============ 第" + battleCnt + "回戦 ============");
                flgEnd = zebra.doRockPaperScissors();
                battleCnt++;
            } while (!flgEnd);  // あいこ(flase)な限り続ける
            
        }
    }
}
