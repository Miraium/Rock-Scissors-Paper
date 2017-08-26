using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Scissors_Paper
{
    // 可読性向上を目的として作った定数を定義するためのクラス
    // クラスで無理やり作ったので、実践的には良くないかも。(classではなくenumとかが良いかも)
    static class Hand
    {
        public static int rock = 0;
        public static int paper = 1;
        public static int scissors = 2;

        public static string getHandName(int hand)
        {
            string handName = "---";
            switch (hand)
            {
                case 0:
                    handName = "ぐー";
                    break;
                case 1:
                    handName = "ぱー";
                    break;
                case 2:
                    handName = "ちょき";
                    break;
                default:
                    break;
            }
            return handName;
        }
    }

    // プレイヤークラス
    class Player
    {
        private string name;    // プレイヤーの名前
        private int hand;   // 現在の手の状態
		private static System.Random r = new System.Random(); // 乱数生成用変数 乱数なのでクラス変数として1つあればOK

		// コンストラクタ
		public Player(string playerName){
            // 生成時にプレイヤーの名前を決めてしまう
            this.name = playerName;
        }

        // 出す手を決める関数
        private void decideHand()
        {
            // 出す手をランダムに決める
            // 乱数の生成方法
            // Ref. https://dobon.net/vb/dotnet/programing/random.html
            this.hand = r.Next(3);  // 0~2の整数がhandに入る

            // 乱数はPC内の時間をシード値として生成され、
            // 経過時間があまり経っていない(15ミリ秒)と同じシード値を持ってしまう可能性があるらしいので、
            // 苦し紛れのSleepを入れることにする。
            // 単純な解決策だけど処理時間がかかるので良くない。
            // Ref. https://msdn.microsoft.com/ja-jp/library/system.random(v=vs.110).aspx#Multiple
            //System.Threading.Thread.Sleep(15);
        }

        // 出す手を決めて、外に公開する関数
        public int outputHand()
        {
            this.decideHand();
            return hand;
        }

        // 自分の名前を出力する関数
        public string getName()
        {
            return this.name;
        }
        
    }
}
