/**
 * ISIM SOYISIM:
 * OGRENCI NO:
 * EMAIL:
 *
 **/


using System;

namespace BoslukDoldurmaca
{
	class BoslukDoldurmaca
	{
		static char[] board;
		static int boardLen;
		static int pawnNumber;

		public static void CreateBoard(int boardLen, int pawnNumber)
		{
			boardLen = (boardLen > 32) ? 32 : boardLen;
			boardLen = (boardLen < 10) ? 10 : boardLen;
			if (boardLen <= pawnNumber)
			{
				pawnNumber = boardLen - 1;
			}
			pawnNumber = (pawnNumber > 26) ? 26 : pawnNumber;

			board = new char[boardLen];
			BoslukDoldurmaca.boardLen = boardLen;
			BoslukDoldurmaca.pawnNumber = pawnNumber;


			Random numberGenerator = new Random();
			int coinBits = 1 << numberGenerator.Next(0, boardLen);
			int coinsPlaced = 1;

			while (coinsPlaced < pawnNumber)
			{
				int randomLocation = numberGenerator.Next(boardLen);
				if ((coinBits | (1 << randomLocation)) != coinBits)
				{
					coinBits = coinBits ^ (1 << randomLocation);
					coinsPlaced++;
				}
			}

			char coinChar = 'A';
			for (int b = 0; b < boardLen; b++)
			{
				if (((1 << b) & coinBits) != 0)
				{
					board[b] = coinChar;
					coinChar++;
				}
				else
				{
					board[b] = '*';
				}
			}
		}

		public static bool MovePawn(char pawnSymbol, int step)
		{
			return true;
		}

		public static bool GameOver()
		{
		  return false;
		}

		public static void PrintBoard()
		{
			for (int i = 0; i < boardLen; i++)
			{
				Console.Write(board[i]);
			}
			Console.WriteLine();
		}


		public static void Main(string[] args)
		{
			Console.WriteLine("Oyun tahtasinin uzunlugunu giriniz.");
			String boardSizeStr = Console.ReadLine();
			int boardSize = Convert.ToInt32(boardSizeStr);
			Console.WriteLine("Oyun tahtasina rastgele dagitilmasini istediginiz piyon sayisini giriniz");
			String pawnCntStr = Console.ReadLine();
			int pawnNumber = Convert.ToInt32(pawnCntStr);
			String[] players = new String[2];
			Console.WriteLine("Ilk oyuncunun ismini giriniz");
			players[0] = Console.ReadLine();
			Console.WriteLine("Ikinci oyuncunun ismini giriniz");
			players[1] = Console.ReadLine();


			do
			{
				CreateBoard(boardSize, pawnNumber);
			} while (GameOver());

			Console.WriteLine("Oyun tahtasi olusturuldu! Oyun tahtasinin gorunumu:");
			PrintBoard();

			char pawnID;
			int step;
			String pawnIDStr, stepStr;
			while (5 == 5)
			{
				for (int playerID = 0; playerID < 2; playerID++)
				{
					Console.WriteLine("{0}'in hamlesi bekleniyor", players[playerID]);
					while (true)
					{
						Console.WriteLine("Sola hareket ettirmek istediginiz piyonun sembolunu giriniz.");
						pawnIDStr = Console.ReadLine();
						pawnID = Convert.ToChar(pawnIDStr);
						Console.WriteLine("{0} piyonunu kac adim sola hareket ettirmek istediginiz giriniz.", pawnID);
						stepStr = Console.ReadLine();
						step = Convert.ToInt32(stepStr);

						if (MovePawn(pawnID, step))
						{
							Console.WriteLine("{0} {1} piyonunu {2} adim sola hareket ettirdi.", players[playerID], pawnID, step);
							Console.WriteLine("Oyun tahtasinin yeni hali:");
							PrintBoard();
							break;
						}
					}
					if (GameOver())
					{
						Console.WriteLine("Oyun bitti! {0} oyunu kazandi! Tebrikler!", players[playerID]);
						return;
					}
				}
			}
		}
	}
}
