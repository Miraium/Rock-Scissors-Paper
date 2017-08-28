using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Scissors_Paper
{
    class JudgeMan
    {
        // 参加プレイヤーを管理するためのリスト
        public List<Player> playerList = new List<Player>();

        public void addPlayer(Player p)
        {
            this.playerList.Add(p);
        }

        private List<int> collectAllHands()
        {
            // 全員の手を一時的にリスト化して保存
            List<int> handList = new List<int>();
            foreach (Player p in this.playerList)
            {
                // プレイヤーの手を取得
                int hand = p.outputHand();
                // 取得した手をリストに追加して保存しておく
                handList.Add(hand);

                // プレイヤー名とその手を出力(確認用)
                Console.WriteLine(p.getName() + ": "+ Hand.getHandName(hand));
            }

            return handList;
        }

        // 手を
        // 決着がついたらtrueを返す
        private bool judge(List<Player> playerList, List<int> handList)
        {
            // Rock, Paper, Scissorsが1つでも出ていたらフラグを立てる
            // 全部の手を見終えた後、フラグのtrueが
            // 1つor3つ　・・・ あいこ
            // それ以外　・・・ 勝者がいる
            bool flgR = false;
            bool flgP = false;
            bool flgS = false;
            foreach (int h in handList)
            {
                if (h == Hand.rock)
                {
                    flgR = true;
                }
                else if (h == Hand.paper)
                {
                    flgP = true;
                }
                else if (h == Hand.scissors)
                {
                    flgS = true;
                }
            }

            bool flgType3 = (flgR && flgP && flgS);
            bool flgOnly1 = (flgR && !flgP && !flgS) || (!flgR && flgP && !flgS) || (!flgR && !flgP && flgS);
            //bool flgOnly1 =
            // (flgR == true && flgP == false && flgS == false) ||
            // (flgR == false && flgP == true && flgS == false) ||
            // (flgR == false && flgP == false && flgS == true);
            //bool flgType3 =
            // (flgR == true && flgP == true && flgS == true);

            // 結果をコンソールに表示
            Console.Write("【結果】・・・・・・");

            if (flgType3 || flgOnly1)
            {
                Console.WriteLine("あいこでーす");
                return false;
            }
            else
            {
                Console.WriteLine("決着！");
                return true;
            }
        }

        public bool doRockPaperScissors()
        {
            // 全員の手を確認して、リスト化して保存
            List<int> handList = collectAllHands();

            // プレイヤーリストと手のリストから、あいこか勝者がいるか判定
            bool flgResult = judge(playerList,handList);

            return flgResult;
        }
    }
}
