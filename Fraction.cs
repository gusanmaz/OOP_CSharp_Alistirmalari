/* UYGULAMA 5 - 1 KASIM 2016
 * Hazirlayan Ars. Gor. Guvenc Usanmaz
 * 
 * UYGULAMA ACIKLAMALARI
 * 
 * 1 - Asagida pay ve payda kismi tam sayi olan kesirler uzerinde cesitli islemler yapan 
 * Fraction sinifina ait kodlari bulabilirsiniz. Oncelikle bu kodu inceleniz. Bu inceleme 
 * sonunda sinifta tanimlanmis olan  tum construct ve fonksiyonlarin islevlerini anlamis
 * olmaniz beklenmektedir.
 * 
 * 2 - Baska bir class'da (main fonksiyonu altinda) cesitli kesirleri temsil edebilmek icin
 * Fraction sinifini kullanarak objeler olusturun ve bu objeler uzerinde Fraction sinifinda
 * tanimlanan fonksiyonlari kullanarak cesitli islemler yapiniz. 
 * 
 * 3 - Baska bir class'da (main fonksiyonu altinda) Fraction sinifinda tanimlanan static 
 * fonksiyonlari kullanarak cesitli kesirli islemler yapiniz.  
 * 
 * 4 - Fraction sinifinda kesirli sayilar uzerinde carpma ve bolme islemlerini yapacak
 * fonksiyonlar yazilmamistir. Fraction sinifina bu islevleri gerceklestirecek fonksiyonlari
 * ekleyiniz.
 * 
 * 5 - Fraction sinifindaki set ve get fonksiyonlarini silip bu fonksiyonlar ile ayni islevi 
 * yerine getirecek property tanimlarini yapiniz.
 * 
 * 6 - Fraction sinifini siz tasarlayacak olsaniz nasil tasarlardiniz. Mevcut kodda ne gibi
 * eklemeler ve degisiklikler yapardiniz.
 * 	   	
 * */

using System;

namespace Fractions
{
	public class Fraction
	{
		private int numerator;
		private int denominator;

		public Fraction (int _numerator, int _denominator)
		{
			numerator   = _numerator;
			denominator = _denominator;
		}

		public Fraction(){
			numerator = 1;
			denominator = 1;
		}

		public bool setNumerator(int numeratorVal){
			numerator = numeratorVal;
			return true;
		}

		public bool setDenominator(int denominatorVal){
			if (denominatorVal == 0) {
				return false;
			} else {
				denominator = denominatorVal;
				return true;
			}
		}

		public int getNumerator(){
			return numerator;
		}

		public int getDenominator(){
			return denominator;
		}

		public double getFractionValue(){
			return (numerator + 0.000) / denominator;
		}

		public Fraction addFractions(Fraction f){
			int newDenominator = denominator * f.getDenominator();
			int newNumerator  = (numerator * f.getDenominator()) + (f.getNumerator() * denominator);
			Fraction newFraction = new Fraction(newNumerator, newDenominator); 
			return newFraction;
		}

		public static Fraction addFractions(int numerator1, int denominator1, int numerator2, int denominator2){
			int newDenominator = denominator1 * denominator2;
			int newNumerator  = (numerator1 * denominator2) + (numerator2 * denominator1);
			return new Fraction(newNumerator, newDenominator);
		}

		public Fraction subtractFractions(Fraction f){
			int newDenominator = denominator * f.getDenominator();
			int newNumerator  = (numerator * f.getDenominator()) - (f.getNumerator() * denominator);
			Fraction newFraction = new Fraction(newNumerator, newDenominator); 
			return newFraction;
		}

		public static Fraction SubtractFractions(int numerator1, int denominator1, int numerator2, int denominator2){
			int newDenominator = denominator1 * denominator2;
			int newNumerator  = (numerator1 * denominator2) - (numerator2 * denominator1);
			return new Fraction(newNumerator, newDenominator);
		}

		public void negate(){
			numerator *= -1;
		}

		public static void negate(Fraction f){
			f.setNumerator(-1 * f.getNumerator());
		}

		public void inverse(){
			int oldNumerator = numerator;
			numerator = denominator;
			denominator = oldNumerator;
		}

		public static void inverse(Fraction f){
			int oldNumerator = f.getNumerator();
			f.setNumerator (f.getDenominator());
			f.setDenominator (oldNumerator);
		}
	}
}

